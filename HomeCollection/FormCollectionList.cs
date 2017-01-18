//-----------------------------------------------------------------------
// <copyright file="FormCollectionList.cs" company="Sergey Teplyashin">
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
// <date>02.02.2011</date>
// <time>13:47</time>
// <summary>Defines the FormCollectionList class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using System.Xml;
    using ComponentFactory.Krypton.Toolkit;
    using ComponentLib.Core;
    using HomeCollection.Core;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    
    #endregion

    /// <summary>
    /// Description of FormCollectionList.
    /// </summary>
    public partial class FormCollectionList : ToolWindow, IDataCollection
    {
        private IEnumerable<ObjectClass> classes;
        private Folder folder;
        private string filterText;
        private string category;
        private Filter filter;
        private DetailInfoControl detailInfo;
        private History<HistoryPoint> history;
        private int updated;
        //private PluginManager<IImportPlugin> importPlugins;
        private List<TransformData> importPlugins;
        private List<TransformData> exportPlugins;
        
        public FormCollectionList(IApplication app, Database data) : base(app, data)
        {
            this.InitializeComponent();

            this.detailInfo = new DetailInfoControl(data, this);
            this.detailInfo.Dock = DockStyle.Fill;
            this.detailInfo.ObjectDataSelected += new EventHandler<EventArgs>(this.FormCollectionList_ObjectDataSelected);
            this.detailInfo.ImageDataSelected += new EventHandler<EventArgs>(this.FormCollectionList_ImageDataSelected);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.detailInfo);
            
            this.history = new History<HistoryPoint>();
            this.SetTableFont(MainForm.Config.App.View.TableFont.CreateFont());
            
            this.LoadEIPlugins();
        }
        
        public ObjectData CurrentData
        {
            get { return this.gridData.SelectedRows.Count > 0 ? (ObjectData)this.gridData.SelectedRows[0].Tag : null; }
        }
        
        public bool PanelInfoVisible
        {
            get { return !this.kryptonSplitContainer1.Panel2Collapsed; }
            set { this.kryptonSplitContainer1.Panel2Collapsed = !value; }
        }
        
        #region IDataCollection
        
        public void StoreHistory()
        {
            HistoryPoint point = new HistoryPoint(this.folder, this.filter, this.category, this.filterText, this.CurrentData);
            if (this.history.Count > 0 && this.history.Last.Equal(point))
            {
                if (this.history.Last.ObjectData != this.CurrentData)
                {
                    this.history.Last.ChangeObject(this.CurrentData);
                }
            }
            else
            {
                this.history.Add(point);
            }
            
            this.UpdateHistoryButtons();
        }
        
        public void UpdateDataList()
        {
            if (this.classes == null && this.filter == null)
            {
                return;
            }
            
            this.BeginUpdate();
            try
            {
                // Сохраним текущую запись, что бы потом её выделить
                ObjectData od = null;
                if (this.gridData.SelectedRows.Count > 0)
                {
                    od = (ObjectData)this.gridData.SelectedRows[0].Tag;
                }
                
                this.gridData.Rows.Clear();
                DataGridViewRow sel_row = null;
                IEnumerable<ObjectData> datas = this.filter == null ? Database.Objects.GetFilteredData(this.classes, this.folder, this.filterText) : Database.Objects.GetFilteredData(this.filter);
                foreach (ObjectData d in datas)
                {
                    int row = this.AddRow(d);
                    if (d == od)
                    {
                        sel_row = this.gridData.Rows[row];
                    }
                }
                
                if (sel_row == null && this.gridData.Rows.Count > 0)
                {
                    sel_row = this.gridData.Rows[0];
                }
                
                if (sel_row != null)
                {
                    sel_row.Selected = true;
                    this.gridData.CurrentCell = sel_row.Cells[0];
                    this.SetDetailInfoData((ObjectData)sel_row.Tag);
                }
                else
                {
                    this.SetDetailInfoData(null);
                }
                
                this.UpdateActions();
            }
            finally
            {
                this.EndUpdate();
            }
        }
        
        public void UpdateDataList(Filter filter)
        {
            this.folder = null;
            this.classes = null;
            this.category = string.Empty;
            this.filterText = string.Empty;
            this.filter = filter;
            if (this.filter == null)
            {
                this.gridData.Rows.Clear();
                this.SetDetailInfoData(null);
            }
            else
            {
                this.UpdateDataList();
            }
        }
        
        public void UpdateDataList(Folder folder)
        {
            this.UpdateDataList(folder, string.Empty);
        }
        
        public void UpdateDataList(string category)
        {
            this.folder = null;
            this.classes = Database.Classes.GetClasses(category);
            this.category = category;
            this.filterText = string.Empty;
            this.filter = null;
            this.UpdateDataList();
        }
        
        public void UpdateDataList(Folder folder, string filterData)
        {
            this.folder = folder;
            this.classes = folder.Classes;
            this.category = folder.Category;
            this.filterText = filterData;
            this.filter = null;
            this.UpdateDataList();
        }
        
        public void UpdateDetailInfo()
        {
            this.detailInfo.UpdateData();
        }
        
        public ObjectData Add(ObjectClass objectClass, bool selectData)
        {
            FormDataAbstract form;
            if (!string.IsNullOrEmpty(objectClass.Form))
            {
                XmlDocument doc = new XmlDocument();
                try
                {
                    doc.LoadXml(objectClass.Form);
                    form = new FormUserData(this, Database, doc);
                }
                catch (XmlException)
                {
                    form = new FormDataObject(this, Database);
                }
            }
            else
            {
                form = new FormDataObject(this, Database);
            }
            
            if (form.CreateObjectData(objectClass))
            {
                this.BeginUpdate();
                try
                {
                    if (this.filter != null && form.Obj.Filter(this.filter))
                    {
                        this.AddRow(form.Obj);
                    }
                    else
                    {
                        bool objectInCategory = App.Folder.CurrentCategory == form.Obj.ObjectClass.Category;
                        App.Folder.CreateTree(this.folder);
                        if (!string.IsNullOrEmpty(this.filterText))
                        {
                            App.Folder.SelectFolder(this.folder, this.filterText, string.Empty);
                        }
                        else if (objectInCategory)
                        {
                            if (this.folder == null || form.Obj.Filter(this.folder, this.filterText))
                            {
                                this.AddRow(form.Obj);
                            }
                        }
                    }
                }
                finally
                {
                    this.EndUpdate();
                }
                
                if (selectData)
                {
                    this.SelectObjectData(form.Obj);
                }
                
                return form.Obj;
            }
            
            return null;
        }
        
        public void UpdateCurrentRow()
        {
            if (this.gridData.CurrentRow != null)
            {
                ObjectData obj = this.gridData.CurrentRow.Tag as ObjectData;
                if (obj != null)
                {
                    this.gridData.CurrentRow.Cells[0].Value = obj[SystemProperty.Name];
                }
            }
        }
        
        public void UpdateCurrentData()
        {
            this.UpdateObjectData(this.gridData.CurrentRow, this.CurrentData);
        }
        
        #endregion
        
        public void Add()
        {
            ObjectClass oc = null;
            if (this.folder != null && this.folder.Classes.Count() == 1)
            {
                oc = this.folder.Classes.First();
            }
            else
            {
                FormSelectClass form = new FormSelectClass(Database, this.category, this.folder);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    oc = form.Selected;
                }
            }
            
            if (oc != null)
            {
                this.Add(oc, true);
            }
        }
        
        public void Edit()
        {
            if (this.gridData.SelectedRows.Count > 0)
            {
                this.Edit(this.gridData.SelectedRows[0].Index);
            }
        }
        
        public void Delete()
        {
            if (KryptonMessageBox.Show(Strings.ConfirmDeleteRecord, Strings.Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (this.gridData.SelectedRows.Count > 0)
                {
                    ObjectData od = (ObjectData)this.gridData.SelectedRows[0].Tag;
                    Database.Objects.Remove(od);
                    this.gridData.Rows.Remove(this.gridData.CurrentRow);
                    if (this.gridData.Rows.Count == 0)
                    {
                        this.SetDetailInfoData(null);
                        if (!string.IsNullOrEmpty(this.filterText))
                        {
                            App.Folder.DeleteFilterFolder(this.folder, this.filterText);
                        }
                    }
                }
            }
        }
        
        public bool SelectObjectData(ObjectData obj)
        {
            bool find = false;
            foreach (DataGridViewRow row in this.gridData.Rows)
            {
                if ((ObjectData)row.Tag == obj)
                {
                    if (!row.Displayed)
                    {
                        this.gridData.FirstDisplayedCell = row.Cells[0];
                    }
                    
                    ObjectData od = (ObjectData)row.Tag;
                    this.SetDetailInfoData(od);
                    if (!row.Selected)
                    {
                        row.Selected = true;
                        this.gridData.CurrentCell = row.Cells[0];
                    }
                    
                    find = true;
                    
                    break;
                }
            }
            
            this.gridData.Focus();
            return find;
        }
        
        public void SetTableFont(Font font)
        {
            this.gridData.StateCommon.DataCell.Content.Font = font;
        }
        
        public void InvalidateDetailInfo()
        {
            this.detailInfo.UpdateData();
        }
        
        private void SetDetailInfoData(ObjectData data)
        {
            this.detailInfo.Data = data;
        }
        
        private void UpdateHistoryButtons()
        {
            this.buttonBack.Enabled = !this.history.IsFirst;
            this.buttonForward.Enabled = !this.history.IsLast;
        }
        
        private void LoadEIPlugins()
        {
            this.importPlugins = new List<TransformData>();
            this.importPlugins.Add(new ImportData(this.Database));
            
            this.exportPlugins = new List<TransformData>();
            this.exportPlugins.Add(new ExportData(this.Database));
            
            foreach (TransformData td in this.exportPlugins)
            {
                ToolStripMenuItem itemButton = new ToolStripMenuItem(td.Name);
                itemButton.Tag = td;
                itemButton.Click += new EventHandler(this.ItemExportButtonClick);
                this.toolExport.DropDownItems.Add(itemButton);
            }
            
            foreach (TransformData td in this.importPlugins)
            {
                ToolStripMenuItem itemButton = new ToolStripMenuItem(td.Name);
                itemButton.Tag = td;
                itemButton.Click += new EventHandler(this.ItemImportButtonClick);
                this.toolImport.DropDownItems.Add(itemButton);
            }
        }
        
        private void FormCollectionList_ObjectDataSelected(object sender, EventArgs e)
        {
            ObjectData obj = (ObjectData)sender;
            this.BeginUpdate();
            try
            {
                App.Folder.SelectFolder(obj);
            }
            finally
            {
                this.EndUpdate();
            }
            
            this.SelectObjectData(obj);
            this.StoreHistory();
        }
        
        private void FormCollectionList_ImageDataSelected(object sender, EventArgs e)
        {
            FormImageViewer viewer = new FormImageViewer((string)sender);
            viewer.Show();
        }
        
        private void UpdateObjectData(DataGridViewRow row, ObjectData objectData)
        {
            if (this.filter == null)
            {
                if (this.folder == null || string.IsNullOrEmpty(this.filterText))
                {
                    App.Folder.CreateTree(this.folder);
                    this.detailInfo.UpdateData();
                }
                else
                {
                    if (!objectData.Filter(this.folder, this.filterText))
                    {
                        this.gridData.Rows.Remove(row);
                        App.Folder.UpdateFilteredFolders(objectData);
                        if (this.gridData.Rows.Count == 0)
                        {
                            this.SetDetailInfoData(null);
                            App.Folder.DeleteFilterFolder(this.folder, this.filterText);
                        }
                    }
                    else
                    {
                        this.detailInfo.UpdateData();
                    }
                }
            }
            else
            {
                if (!objectData.Filter(this.filter))
                {
                    this.gridData.Rows.Remove(row);
                    if (this.gridData.Rows.Count == 0)
                    {
                        this.SetDetailInfoData(null);
                    }
                }
                else
                {
                    this.detailInfo.UpdateData();
                }
            }
            
            row.Cells[0].Value = objectData[SystemProperty.Name];
        }
        
        private void Edit(int rowIndex)
        {
            DataGridViewRow row = this.gridData.Rows[rowIndex];
            if (row.Tag != null)
            {
                ObjectData data = (ObjectData)row.Tag;
                FormDataAbstract form;
                if (!string.IsNullOrEmpty(data.ObjectClass.Form))
                {
                    XmlDocument doc = new XmlDocument();
                    try
                    {
                        doc.LoadXml(data.ObjectClass.Form);
                        form = new FormUserData(this, Database, doc);
                    }
                    catch (XmlException)
                    {
                        form = new FormDataObject(this, Database);
                    }
                }
                else
                {
                    form = new FormDataObject(this, Database);
                }
                
                if (form.ModifyObjectData(data))
                {
                    this.UpdateObjectData(row, data);
                }
            }
        }
        
        private int AddRow(ObjectData d)
        {
            DataGridViewRow viewRow = new DataGridViewRow();
            viewRow.Tag = d;
            int row = this.gridData.Rows.Add(viewRow);
            this.gridData.Rows[row].Cells[0].Value = d[SystemProperty.Name];
            return row;
        }
        
        private void UpdateActions()
        {
            this.buttonEdit.Enabled = this.gridData.SelectedRows.Count > 0;
            this.buttonDelete.Enabled = this.buttonEdit.Enabled;
            
            this.menuItemEdit.Enabled = this.buttonEdit.Enabled;
            this.menuItemDelete.Enabled = this.buttonEdit.Enabled;
        }
        
        private void BeginUpdate()
        {
            this.updated++;
        }
        
        private void EndUpdate()
        {
            if (this.updated > 0)
            {
                this.updated--;
            }
        }
        
        private bool IsUpdated()
        {
            return this.updated > 0;
        }
        
        private void GridDataCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Edit(e.RowIndex);
        }
        
        private void GridDataSelectionChanged(object sender, EventArgs e)
        {
            if (!this.IsUpdated())
            {
                if (this.gridData.SelectedRows.Count > 0)
                {
                    ObjectData od = (ObjectData)this.gridData.SelectedRows[0].Tag;
                    this.SetDetailInfoData(od);
                    this.StoreHistory();
                }
                
                this.UpdateActions();
            }
        }
        
        private void ButtonAddClick(object sender, EventArgs e)
        {
            this.Add();
            this.UpdateActions();
        }
        
        private void ButtonEditClick(object sender, EventArgs e)
        {
            this.Edit();
            this.UpdateActions();
        }
        
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            this.Delete();
            this.UpdateActions();
        }
        
        private void GridDataKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.Edit();
                    e.Handled = true;
                    break;
                case Keys.Delete:
                    this.Delete();
                    e.Handled = true;
                    break;
                case Keys.Insert:
                    this.Add();
                    e.Handled = true;
                    break;
            }

            this.UpdateActions();
        }
        
        private void ButtonBackClick(object sender, EventArgs e)
        {
            HistoryPoint hp = this.history.Back();
            this.BeginUpdate();
            try
            {
                if (hp.Folder == null && string.IsNullOrEmpty(hp.Category))
                {
                    App.Folder.SelectFolder(hp.FilterFolder);
                }
                else
                {
                    App.Folder.SelectFolder(hp.Folder, hp.FilterText, hp.Category);
                }
                
                this.SelectObjectData(hp.ObjectData);
                this.UpdateHistoryButtons();
            }
            finally
            {
                this.EndUpdate();
            }
        }
        
        private void ButtonForwardClick(object sender, EventArgs e)
        {
            HistoryPoint hp = this.history.Forward();
            this.BeginUpdate();
            try
            {
                if (hp.Folder == null && string.IsNullOrEmpty(hp.Category))
                {
                    App.Folder.SelectFolder(hp.FilterFolder);
                }
                else
                {
                    App.Folder.SelectFolder(hp.Folder, hp.FilterText, hp.Category);
                }
                
                this.SelectObjectData(hp.ObjectData);
                this.UpdateHistoryButtons();
            }
            finally
            {
                this.EndUpdate();
            }
        }
        
        private void ItemExportButtonClick(object sender, EventArgs e)
        {
            ToolStripMenuItem itemButton = (ToolStripMenuItem)sender;
            TransformData td = (TransformData)itemButton.Tag;
            this.saveFileDialog.Filter = td.FilterString;
            this.saveFileDialog.DefaultExt = td.ShortExtension;
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                td.Execute(this.saveFileDialog.FileName);
            }
        }
        
        private void ItemImportButtonClick(object sender, EventArgs e)
        {
            ToolStripMenuItem itemButton = (ToolStripMenuItem)sender;
            TransformData td = (TransformData)itemButton.Tag;
            this.openFileDialog.Filter = td.FilterString;
            this.openFileDialog.DefaultExt = td.ShortExtension;
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (td.Execute(this.openFileDialog.FileName))
                {
                    this.UpdateDataList();
                }
            }
        }
    }
}
