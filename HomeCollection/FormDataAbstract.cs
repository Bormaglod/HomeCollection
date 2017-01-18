//-----------------------------------------------------------------------
// <copyright file="FormDataAbstract.cs" company="Sergey Teplyashin">
//     Copyright (c) 2010-2012 Sergey Teplyashin. All rights reserved.
// </copyright>
// <author>Тепляшин Сергей Васильевич</author>
// <email>sergey-teplyashin@yandex.ru</email>
// <license>
//     This program is free software; you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation; either version 3 of the License, or
//     (at your option) any later version.
//
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
//
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// </license>
// <date>02.05.2011</date>
// <time>14:03</time>
// <summary>Defines the FormDataAbstract class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using ComponentLib.Controls;
    using ComponentLib.Core;
    using HomeCollection.AddIns;
    using HomeCollection.Core;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of FormDataAbstract.
    /// </summary>
    public class FormDataAbstract : KryptonForm
    {
        #region Using directives
        
        private IDataCollection collection;
        private Database database;
        private ObjectData obj;
        private List<Control> controls;
        private List<Control> evalControls;
        private Dictionary<Field, string> updatedFields;
        private Parser parser;
        
        #endregion
        
        public FormDataAbstract()
        {
        }
        
        public FormDataAbstract(IDataCollection collection, Database data) : this()
        {
            this.collection = collection;
            this.database = data;
            this.controls = new List<Control>();
            this.evalControls = new List<Control>();
            this.updatedFields = new Dictionary<Field, string>();
            this.parser = new Parser(this.GetFieldValue);
            KeyPreview = true;
            KeyDown += new KeyEventHandler(this.FormKeyDown);
            FormClosing += new FormClosingEventHandler(this.FormDataClosing);
        }
        
        public ObjectData Obj
        {
            get { return this.obj; }
        }
        
        public Database Data
        {
            get { return this.database; }
        }
        
        public bool CreateObjectData(ObjectClass objectClass)
        {
            this.Data.Objects.StartTransaction();
            /*try
            {*/
                this.obj = new ObjectData(objectClass);
                this.obj.ReferencedObjectData += new EventHandler<ObjectDataEventArgs>(this.FormDataAbstract_ReferencedObjectData);
                try
                {
                    this.CreateControls();
                    this.CreatePluginContextMenu();
                    if (ShowDialog() == DialogResult.OK)
                    {
                        SaveData();
                        this.Data.Objects.Commit();
                        return true;
                    }
                    else
                    {
                        this.Data.Objects.Rollback();
                    }
                }
                finally
                {
                    this.obj.ReferencedObjectData -= new EventHandler<ObjectDataEventArgs>(this.FormDataAbstract_ReferencedObjectData);
                }
            /*}
            catch (Exception e)
            {
                this.Data.Objects.Rollback();
                throw new Exception(e.Message);
            }*/
            
            return false;
        }
        
        public bool ModifyObjectData(ObjectData data)
        {
            this.Data.Objects.StartTransaction();
            try
            {
                Text = data.ObjectClass.Name;
                this.obj = data;
                this.CreateControls();
                this.CreatePluginContextMenu();
                if (ShowDialog() == DialogResult.OK)
                {
                    SaveData();
                    this.Data.Objects.Commit();
                    return true;
                }
                else
                {
                    this.Data.Objects.Rollback();
                }
            }
            catch (Exception e)
            {
                this.Data.Objects.Rollback();
                throw new Exception(e.Message);
            }
            
            return false;
        }
        
        public void ImportData(DataPlugin plugin)
        {
            plugin.SetCurrentGuid(this.obj.ObjectClass.Identifier);
            foreach (string attr in plugin.GetNeededAttributes())
            {
                plugin.SetData(attr, this.GetFieldValue(attr));
            }
            
            plugin.Execute();
            foreach (string attr in plugin.GetChangedAttributes())
            {
                this.SetFieldValue(attr, plugin.GetData(attr));
            }
        }
        
        protected virtual void CreateControls()
        {
        }
        
        protected virtual Control CreateControl(Field field)
        {
            Control result = null;
            switch (field.FieldType)
            {
                case FieldType.Text:
                    result = this.CreateTextBoxControl(Obj, field);
                    break;
                case FieldType.Boolean:
                    result = this.CreateCheckBoxControl(Obj, field);
                    break;
                case FieldType.Select:
                    result = this.CreateSelectControl(Obj, field);
                    break;
                case FieldType.Number:
                    result = this.CreateNumericControl(Obj, field);
                    break;
                case FieldType.Url:
                    result = this.CreateUrlControl(Obj, field);
                    break;
                case FieldType.Date:
                    result = this.CreateDateControl(Obj, field);
                    break;
                case FieldType.Rating:
                    result = this.CreateNumericControl(Obj, field);
                    break;
                case FieldType.Reference:
                    result = this.CreateReferenceControl(Obj, field);
                    break;
                case FieldType.Memo:
                    result = this.CreateMemoControl(Obj, field);
                    break;
                case FieldType.List:
                    result = this.CreateListControl(Obj, field);
                    break;
                case FieldType.Table:
                    result = this.CreateTableControl(Obj, field);
                    break;
                case FieldType.Image:
                    result = this.CreateImageControl(Obj, field);
                    break;
                default:
                    result = new KryptonLabel();
                    ((KryptonLabel)result).Text = "No control";
                    break;
            }
            
            result.Tag = field;
            result.Leave += new EventHandler(this.EvaluateFields);
            
            return result;
        }

        protected void SaveData()
        {
            this.Data.Objects.ClearData(this.obj);
            foreach (Control ctrl in this.controls)
            {
                Field field = (Field)ctrl.Tag;
                switch (field.FieldType)
                {
                    case FieldType.Boolean:
                        KryptonCheckBox check = (KryptonCheckBox)ctrl;
                        this.obj[field] = check.Checked;
                        break;
                    case FieldType.Date:
                        KryptonDateTimePicker date = (KryptonDateTimePicker)ctrl;
                        if (date.Checked)
                        {
                            this.obj[field] = date.Value;
                        }
                        else
                        {
                            this.obj[field] = DateTime.MinValue;
                        }
                        
                        break;
                    case FieldType.Image:
                        if (ctrl is ImageSelectBase)
                        {
                            this.obj[field] = ((ImageSelectBase)ctrl).CreateImageData();
                        }
                        
                        break;
                    case FieldType.List:
                        ListData ld = (ListData)this.obj[field];
                        foreach (ObjectData od in ((ListBoxControl)ctrl).ListData)
                        {
                            ld.Objects.Add(od);
                        }
                        
                        break;
                    case FieldType.Memo:
                        KryptonTextBox memo = (KryptonTextBox)ctrl;
                        this.obj[field] = memo.Text;
                        break;
                    case FieldType.Number:
                        TextBoxNumber num = (TextBoxNumber)ctrl;
                        this.obj[field] = num.Value;
                        
                        break;
                    case FieldType.Rating:
                        TextBoxNumber raiting = (TextBoxNumber)ctrl;
                        this.obj[field] = raiting.Value;
                        break;
                    case FieldType.Reference:
                        KryptonComboBox box = (KryptonComboBox)ctrl;
                        if (box.SelectedIndex == -1)
                        {
                            this.obj[field] = 0;
                        }
                        else
                        {
                            this.obj[field] = (ObjectData)box.SelectedItem;
                        }
                        
                        break;
                    case FieldType.Select:
                        KryptonComboBox selectBox = ctrl as KryptonComboBox;
                        this.obj[field] = selectBox.SelectedIndex;
                        break;
                    case FieldType.Text:
                        KryptonTextBox text = ctrl as KryptonTextBox;
                        this.obj[field] = text.Text;
                        break;
                    case FieldType.Url:
                        KryptonTextBox url = ctrl as KryptonTextBox;
                        this.obj[field] = url.Text;
                        break;
                    case FieldType.Table:
                        this.obj[field] = ((TableControl)ctrl).CreateTableData();
                        break;
                }
            }
            
            foreach (Field f in this.updatedFields.Keys)
            {
                this.obj[f] = this.updatedFields[f];
            }
            
            if (obj.IsNew)
            {
                database.Objects.Add(this.obj);
            }
            else
            {
                database.Objects.Update(this.obj);
            }
        }
        
        protected Control AddFieldControl(Field field)
        {
            Control ctrl = this.CreateControl(field);
            this.controls.Add(ctrl);
            if (field.Evaluated)
            {
                this.evalControls.Add(ctrl);
            }
            
            return ctrl;
        }
        
        protected void SelectFirstControl(ICollection controls)
        {
            foreach (Control c in controls)
            {
                if (c.Tag != null)
                {
                    Field field = (Field)c.Tag;
                    if (field.Evaluated)
                    {
                        continue;
                    }
                    
                    c.Select();
                    break;
                }
            }
        }
        
        private KryptonContextMenu CreateUrlContextMenu(KryptonTextBox textBox)
        {
            KryptonContextMenu menuUrl = new KryptonContextMenu();
            menuUrl.Items.Add(new KryptonContextMenuItems());
            ((KryptonContextMenuItems)menuUrl.Items[0]).Items.AddRange(new KryptonContextMenuItem[] {
                                     new KryptonContextMenuItem(Strings.File, this.MenuURLClick),
                                     new KryptonContextMenuItem(Strings.Folder, this.MenuURLClick),
                                     new KryptonContextMenuItem(Strings.URL, this.MenuURLClick)
                                 } );
            
            foreach (KryptonContextMenuItem item in ((KryptonContextMenuItems)menuUrl.Items[0]).Items)
            {
                item.Tag = textBox;
            }
            
            return menuUrl;
        }
        
        private void CreatePluginContextMenu()
        {
            if (this.obj != null)
            {
                IEnumerable<DataPlugin> plugins = Plugins.GetPlugins(this.obj.ObjectClass.Identifier);
                if (plugins.Count() > 0)
                {
                    Control button;
                    if (plugins.Count() == 1)
                    {
                        button = new KryptonButton();
                    }
                    else
                    {
                        button = new KryptonDropButton();
                    }
                    
                    button.Text = Strings.ButtonPlugin;
                    button.Location = new System.Drawing.Point(12, Height - 71);
                    button.Size = new System.Drawing.Size(120, 25);
                    button.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
                    Controls.Add(button);
                    if (plugins.Count() > 1)
                    {
                        KryptonContextMenu menu = new KryptonContextMenu();
                        KryptonContextMenuItems items = new KryptonContextMenuItems();
                        menu.Items.Add(items);
                        foreach (DataPlugin plugin in plugins)
                        {
                            KryptonContextMenuItem item = new KryptonContextMenuItem(plugin.GetName(), this.MenuPluginClick);
                            item.Tag = plugin;
                            items.Items.Add(item);
                        }
                        
                        ((KryptonDropButton)button).KryptonContextMenu = menu;
                    }
                    else
                    {
                        button.Tag = plugins.First();
                        button.Click += new EventHandler(this.ButtonPluginClick);
                    }
                }
            }
        }
        
        private void MenuPluginClick(object sender, EventArgs e)
        {
            KryptonContextMenuItem item = (KryptonContextMenuItem)sender;
            this.ImportData((DataPlugin)item.Tag);
        }
        
        private void ButtonPluginClick(object sender, EventArgs e)
        {
            Control item = (Control)sender;
            this.ImportData((DataPlugin)item.Tag);
        }
        
        private void FormDataAbstract_ReferencedObjectData(object sender, ObjectDataEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.ValueData))
            {
                ObjectClass objectClass = e.Field.Data as ObjectClass;
                if (objectClass != null)
                {
                    e.ObjectData = this.database.Objects.GetValueData(objectClass, e.ValueData);
                    if (e.ObjectData == null && e.Creating)
                    {
                        e.ObjectData = new ObjectData(objectClass);
                        e.ObjectData[SystemProperty.Name] = e.ValueData;
                        this.database.Objects.Add(e.ObjectData);
                        e.Created = true;
                    }
                }
            }
        }
        
        private void ShowSelectUrlDialog(KryptonTextBox txt, UrlType type)
        {
            if (type == UrlType.Folder)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;
                if (System.IO.Directory.Exists(txt.Text))
                {
                    fbd.SelectedPath = txt.Text;
                }
                
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txt.Text = fbd.SelectedPath;
                }
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (System.IO.File.Exists(txt.Text))
                {
                    ofd.FileName = txt.Text;
                }
                
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txt.Text = ofd.FileName;
                }
            }
        }
        
        private void MenuURLClick(object sender, EventArgs e)
        {
            KryptonContextMenuItem item = sender as KryptonContextMenuItem;
            KryptonTextBox txt = item.Tag as KryptonTextBox;
            if (txt != null)
            {
                if (item.Text == Strings.Folder)
                {
                    this.ShowSelectUrlDialog(txt, UrlType.Folder);
                }
                else
                {
                    this.ShowSelectUrlDialog(txt, UrlType.File);
                }
            }
        }
        
        private void SelectUrlTextClick(object sender, EventArgs e)
        {
            ButtonSpecAny button = (ButtonSpecAny)sender;
            UrlProperty prop = (UrlProperty)button.Tag;
            KryptonTextBox txt = button.Owner as KryptonTextBox;
            this.ShowSelectUrlDialog(txt, prop.Type);
        }
        
        private void EvaluateFields(object sender, EventArgs e)
        {
            foreach (var cat in this.Obj.GroupingFields)
            {
                foreach (Field field in cat)
                {
                    if (field.Evaluated)
                    {
                        bool find = false;
                        string res = this.parser.Execute(field.Expression);
                        foreach (Control c in this.evalControls)
                        {
                            if (((Field)c.Tag).Name == field.Name && c is KryptonTextBox)
                            {
                                KryptonTextBox txt = (KryptonTextBox)c;
                                txt.Text = res;
                                find = true;
                                break;
                            }
                        }
                        
                        if (!find)
                        {
                            if (this.updatedFields.ContainsKey(field))
                            {
                                this.updatedFields[field] = res;
                            }
                            else
                            {
                                this.updatedFields.Add(field, res);
                            }
                        }
                    }
                }
            }
        }
        
        private void ComboBoxClearClick(object sender, EventArgs e)
        {
            ButtonSpecAny item = (ButtonSpecAny)sender;
            KryptonComboBox combo = (KryptonComboBox)item.Owner;
            combo.SelectedIndex = -1;
        }
        
        private void ComboBoxAddClick(object sender, EventArgs e)
        {
            ButtonSpecAny item = (ButtonSpecAny)sender;
            KryptonComboBox combo = (KryptonComboBox)item.Owner;
            Field field = (Field)combo.Tag;
            ObjectClass c = ReferenceProperty.Get(field).Reference;
            ObjectData d = collection.Add(c, false);
            if (d != null)
            {
                combo.Items.Add(d);
                combo.SelectedItem = d;
                this.AddDataItem(field, d);
            }
        }
        
        private void AddDataItem(Field field, ObjectData data)
        {
            this.AddDataItem(field, new List<ObjectData>() { data });
        }
        
        private void AddDataItem(Field field, IEnumerable<ObjectData> items)
        {
            foreach (Control ctrl in this.controls)
            {
                Field f = ctrl.Tag as Field;
                if (f != null && f != field)
                {
                    foreach (ObjectData d in items)
                    {
                        switch (f.FieldType)
                        {
                            case FieldType.Reference:
                                if (ReferenceProperty.Get(f).Reference == d.ObjectClass)
                                {
                                    KryptonComboBox box = (KryptonComboBox)ctrl;
                                    if (!box.Items.Contains(d))
                                    {
                                        box.Items.Add(d);
                                    }
                                }
                                
                                break;
                            case FieldType.Table:
                                TableControl table = (TableControl)ctrl;
                                table.AddDataItem(d);
                                break;
                        }
                    }
                }
            }
        }
        
        private void box_DataItemsAdded(object sender, DataItemsEventArgs e)
        {
            ListBoxControl list = (ListBoxControl)sender;
            Field field = (Field)list.Tag;
            this.AddDataItem(field, e.Items);
        }
        
        private Control CreateTextBoxControl(ObjectData obj, Field field)
        {
            KryptonTextBox textBox = new KryptonTextBox();
            textBox.Text = obj[field].ToString();
            if (field.Evaluated)
            {
                textBox.ReadOnly = true;
                textBox.TabStop = false;
            }
            
            /*textBox.StateCommon.Border.Rounding = 4;
            textBox.StateCommon.Border.Width = 2;*/
            return textBox;
        }
        
        private Control CreateUrlControl(ObjectData obj, Field field)
        {
            KryptonTextBox textBox = new KryptonTextBox();
            textBox.Text = obj[field].ToString();
            ButtonSpecAny button = new ButtonSpecAny();
            button.Text = string.Empty;
            button.Image = Resources.folder2;
            if (((UrlProperty)field.Data).Type == UrlType.Select)
            {
                button.KryptonContextMenu = this.CreateUrlContextMenu(textBox);
            }
            else
            {
                button.Tag = field.Data;
                button.Click += new EventHandler(this.SelectUrlTextClick);
            }
            
            textBox.ButtonSpecs.Add(button);
            /*textBox.StateCommon.Border.Rounding = 4;
            textBox.StateCommon.Border.Width = 2;*/
            return textBox;
        }
        
        private Control CreateCheckBoxControl(ObjectData obj, Field field)
        {
            KryptonCheckBox checkBox = new KryptonCheckBox();
            checkBox.Text = string.Empty;
            checkBox.Checked = Convert.ToBoolean(obj[field]);
            return checkBox;
        }
        
        private Control CreateSelectControl(ObjectData obj, Field field)
        {
            KryptonComboBox combo = new KryptonComboBox();
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            ButtonSpecAny item = new ButtonSpecAny();
            item.Image = Resources.crest;
            item.Edge = PaletteRelativeEdgeAlign.Near;
            item.Style = PaletteButtonStyle.Standalone;
            //item.Style = PaletteButtonStyle.NavigatorStack;
            item.Click += new EventHandler(this.ComboBoxClearClick);
            combo.ButtonSpecs.Add(item);
            foreach (string s in (List<string>)field.Data)
            {
                combo.Items.Add(s);
            }
            
            combo.SelectedIndex = Convert.ToInt32(obj[field]);
            /*combo.StateCommon.ComboBox.Border.Rounding = 4;
            combo.StateCommon.ComboBox.Border.Width = 2;*/
            return combo;
        }
        
        private Control CreateNumericControl(ObjectData obj, Field field)
        {
            TextBoxNumber num = new TextBoxNumber();
            if (field.FieldType == FieldType.Rating)
            {
                num.DecimalPlaces = 1;
                num.Maximum = 10;
            }
            else
            {
                NumberProperty prop = (NumberProperty)field.Data;
                num.DecimalPlaces = prop.DecimalPlaces;

                double d = decimal.ToDouble(decimal.MaxValue);
                d = Math.Sqrt(d);
                decimal dm = Convert.ToDecimal(d);
                num.Maximum = prop.Bounds ? prop.Maximum : dm;
                num.Minimum = prop.Bounds ? prop.Minimum : decimal.Negate(dm);
                num.Increment = prop.Increment;
                num.ThousandsSeparator = prop.Thousands;
                num.Prefix = prop.Prefix;
                num.Suffix = prop.Suffix;
            }
            
            object val = obj[field];
            if (field.IsEmptyData(val))
            {
                num.Text = string.Empty;
            }
            else
            {
                num.Value = Convert.ToDecimal(obj[field]);
            }
            
            /*num.StateCommon.Border.Rounding = 4;
            num.StateCommon.Border.Width = 2;*/
            return num;
        }
        
        private Control CreateDateControl(ObjectData obj, Field field)
        {
            KryptonDateTimePicker date = new KryptonDateTimePicker();
            date.CalendarTodayText = Strings.Today;
            date.ShowCheckBox = true;
            DateTime dt = Convert.ToDateTime(obj[field]);
            if (dt != DateTime.MinValue)
            {
                date.Value = dt;
                date.Checked = true;
            }
            else
            {
                date.Checked = false;
            }
            
            DateProperty prop = field.Data as DateProperty;
            if (prop != null)
            {
                date.Format = DateTimePickerFormat.Custom;
                if (prop.ViewTime)
                {
                    date.CustomFormat = "d MMM yyy H:mm:ss";
                }
                else
                {
                    date.CustomFormat = "d MMM yyy";
                }
            }
            
            /*date.StateCommon.Border.Rounding = 4;
            date.StateCommon.Border.Width = 2;*/
            return date;
        }
        
        private Control CreateReferenceControl(ObjectData obj, Field field)
        {
            KryptonComboBox combo = new KryptonComboBox();
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            
            ObjectClass c = ReferenceProperty.Get(field).Reference;
            ButtonSpecAny item;
            if (!string.IsNullOrEmpty(c.Form))
            {
                item = new ButtonSpecAny();
                item.Image = Resources.plus;
                item.Edge = PaletteRelativeEdgeAlign.Near;
                item.Style = PaletteButtonStyle.Standalone;
                //item.Style = PaletteButtonStyle.NavigatorStack;
                item.Click += new EventHandler(this.ComboBoxAddClick);
                combo.ButtonSpecs.Add(item);
            }
            
            item = new ButtonSpecAny();
            item.Image = Resources.crest;
            item.Edge = PaletteRelativeEdgeAlign.Near;
            item.Style = PaletteButtonStyle.Standalone;
            //item.Style = PaletteButtonStyle.NavigatorStack;
            item.Click += new EventHandler(this.ComboBoxClearClick);
            combo.ButtonSpecs.Add(item);
            
            if (c != null)
            {
                foreach (ObjectData d in Data.Objects.GetData(c))
                {
                    combo.Items.Add(d);
                }
            
                if (obj[field] is ObjectData)
                {
                    combo.SelectedItem = (ObjectData)obj[field];
                }
                else
                {
                    combo.SelectedIndex = -1;
                }
            }
            
            /*combo.StateCommon.ComboBox.Border.Rounding = 4;
            combo.StateCommon.ComboBox.Border.Width = 2;*/
            return combo;
        }
        
        private Control CreateMemoControl(ObjectData obj, Field field)
        {
            KryptonTextBox textBox = new KryptonTextBox();
            textBox.Multiline = true;
            textBox.Text = obj[field].ToString();
            /*textBox.StateCommon.Border.Rounding = 4;
            textBox.StateCommon.Border.Width = 2;*/
            return textBox;
        }
        
        private Control CreateListControl(ObjectData obj, Field field)
        {
            ListBoxControl box = new ListBoxControl(this.collection, Data, obj, field);
            box.DataItemsAdded += new EventHandler<DataItemsEventArgs>(this.box_DataItemsAdded);
            return box;
        }
        
        private Control CreateTableControl(ObjectData obj, Field field)
        {
            TableControl grid = new TableControl(Data, obj, field);
            return grid;
        }
        
        private Control CreateImageControl(ObjectData obj, Field field)
        {
            ImageData id = (ImageData)obj[field];
            //ImageSelect image = new ImageSelect(this.database, id, MainForm.AppDir + @"\images", field);
            SimpleImageSelect image = new SimpleImageSelect(this.database, id, MainForm.AppDir + @"\images");
            return image;
        }
        
        private string GetFieldValue(string fieldName)
        {
            foreach (Control c in this.controls)
            {
                Field f = c.Tag as Field;
                if (f != null)
                {
                    if (f.Name == fieldName)
                    {
                        return this.GetTextValue(c);
                    }
                }
            }
            
            return this.Obj[fieldName].ToString();
        }
        
        private void SetFieldValue(string fieldName, string value)
        {
            foreach (Control c in this.controls)
            {
                Field f = c.Tag as Field;
                if (f != null && f.Name == fieldName)
                {
                    this.SetTextValue(c, value);
                    break;
                }
            }
        }
        
        private string GetTextValue(Control c)
        {
            Type t = c.GetType();
            if (t == typeof(KryptonTextBox))
            {
                return ((KryptonTextBox)c).Text;
            }
            else if (t == typeof(KryptonComboBox))
            {
                KryptonComboBox kc = c as KryptonComboBox;
                if (kc.SelectedItem == null)
                {
                    return string.Empty;
                }
                else
                {
                    return kc.SelectedItem.ToString();
                }
            }
            else if (t == typeof(TextBoxNumber))
            {
                TextBoxNumber tbn = c as TextBoxNumber;
                Field field = (Field)c.Tag;
                if (!field.IsEmptyData(tbn.Value) || !string.IsNullOrEmpty(tbn.Text))
                {
                    return tbn.Value.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            else if (t == typeof(KryptonDateTimePicker))
            {
                return ((KryptonDateTimePicker)c).Value.ToString();
            }
            else if (t == typeof(KryptonCheckBox))
            {
                return ((KryptonCheckBox)c).Checked.ToString();
            }
            else if (t == typeof(KryptonCheckedListBox))
            {
                return ConvertExtension.ToString(((KryptonCheckedListBox)c).Items, ";");
            }
            
            return string.Empty;
        }
        
        private void SetTextValue(Control c, string value)
        {
            Type t = c.GetType();
            Field field = (Field)c.Tag;
            if (t == typeof(KryptonTextBox))
            {
                ((KryptonTextBox)c).Text = value;
            }
            else if (t == typeof(KryptonComboBox))
            {
                KryptonComboBox kc = c as KryptonComboBox;
                if (field.FieldType == FieldType.Select)
                {
                    int idx = kc.Items.IndexOf(value);
                    if (idx != -1)
                    {
                        kc.SelectedIndex = idx;
                    }
                }
                else
                {
                    bool created = false;
                    ObjectData od = obj.GetReferenceData(field, value, ref created);
                    if (od != null)
                    {
                        int idx = kc.Items.IndexOf(od);
                        if (idx == -1)
                        {
                            kc.Items.Add(od);
                            
                        }
                        
                        kc.SelectedItem = od;
                        
                        if (created)
                        {
                            this.AddDataItem(field, od);
                        }
                    }
                }
            }
            else if (t == typeof(TextBoxNumber))
            {
                TextBoxNumber tbn = c as TextBoxNumber;
                tbn.Value = decimal.Parse(value);
            }
            else if (t == typeof(KryptonDateTimePicker))
            {
                ((KryptonDateTimePicker)c).Value = Convert.ToDateTime(value);
            }
            else if (t == typeof(KryptonCheckBox))
            {
                ((KryptonCheckBox)c).Checked = bool.Parse(value);
            }
            else if (t == typeof(ListBoxControl))
            {
                ListBoxControl kclb = c as ListBoxControl;
                if (!string.IsNullOrEmpty(value))
                {
                    string[] clb = value.Split(new char[] { ';' });
                    List<ObjectData> added = new List<ObjectData>();
                    foreach (string s in clb)
                    {
                        bool created = false;
                        ObjectData od = obj.GetReferenceData(field, s, ref created);
                        if (od != null)
                        {
                            if (!kclb.Exist(od))
                            {
                                kclb.AddItem(od);
                                if (created)
                                {
                                    added.Add(od);
                                }
                            }
                            
                            kclb.SelectData(od);
                            
                        }
                    }
                    
                    this.AddDataItem(field, added);
                }
            }
        }
        
        private void FormDataClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                this.EvaluateFields(null, EventArgs.Empty);
            }
        }
        
        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                DialogResult dr = DialogResult.OK;
                if (ActiveControl is TextBox)
                {
                    TextBox box = (TextBox)ActiveControl;
                    if (box.Multiline)
                    {
                        dr = DialogResult.None;
                    }
                }

                DialogResult = dr;
            }
        }
    }
}
