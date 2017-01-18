//-----------------------------------------------------------------------
// <copyright file="DetailInfoControl.cs" company="Sergey Teplyashin">
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
// <date>18.03.2011</date>
// <time>10:04</time>
// <summary>Defines the DetailInfoControl class.</summary>
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
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using HomeCollection.AddIns;
    using HomeCollection.Core;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    
    #endregion

    /// <summary>
    /// Description of DetailInfoControl.
    /// </summary>
    public partial class DetailInfoControl : UserControl
    {
        private ObjectData objectData;
        private Database database;
        private IEnumerable<DataPlugin> plugins;
        private IDataCollection collection;
        
        public DetailInfoControl(Database database, IDataCollection collection)
        {
            this.InitializeComponent();
            
            this.database = database;
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            this.collection = collection;
        }
        
        public event EventHandler<EventArgs> ObjectDataSelected;
        
        public event EventHandler<EventArgs> ImageDataSelected;

        public ObjectData Data
        {
            get
            {
                return this.objectData;
            }
            
            set
            {
                this.objectData = value;
                if (this.objectData != null)
                {
                    this.objectData.ReferencedObjectData -= new EventHandler<ObjectDataEventArgs>(this.DetailInfoControl_ReferencedObjectData);
                    this.objectData.ReferencedObjectData += new EventHandler<ObjectDataEventArgs>(this.DetailInfoControl_ReferencedObjectData);
                }
                
                this.CreateCards();
                this.CreatePlugins();
            }
        }
        
        private void CreatePlugins()
        {
            if (this.objectData == null)
            {
                this.plugins = null;
            }
            else
            {
                this.plugins = Plugins.GetPlugins(this.objectData.ObjectClass.Identifier);
                this.menuPluginItems.Items.Clear();
                if (this.plugins.Count() > 1)
                {
                    foreach (DataPlugin ip in this.plugins)
                    {
                        KryptonContextMenuItem item = new KryptonContextMenuItem();
                        item.Text = ip.GetName();
                        item.Tag = ip;
                        item.Click += new EventHandler(this.MenuPluginClick);
                        this.menuPluginItems.Items.Add(item);
                    }
                    
                    this.buttonSpecPlugin.Tag = null;
                    this.buttonSpecPlugin.KryptonContextMenu = this.menuPlugin;
                }
                else
                {
                    if (this.plugins.Count() != 0)
                    {
                        this.buttonSpecPlugin.Tag = this.plugins.First();
                        this.buttonSpecPlugin.KryptonContextMenu = null;
                    }
                }
            }
            
            this.buttonSpecPlugin.Visible = this.plugins != null && this.plugins.Count() > 0;
        }
        
        public DataCard this[string category]
        {
            get
            {
                foreach (Control c in this.kryptonHeaderGroup1.Panel.Controls)
                {
                    DataCard dc = (DataCard)c;
                    if (dc.CategoryName == category)
                    {
                        return dc;
                    }
                }
                
                return null;
            }
        }
        
        public void UpdateData()
        {
            this.CreateCards();
        }
        
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            foreach (Control c in this.kryptonHeaderGroup1.Panel.Controls)
            {
                DataCard dc = c as DataCard;
                if (dc != null)
                {
                    dc.UpdateHeight();
                    dc.Invalidate();
                }
            }
        }
        
        private void DetailInfoControl_ReferencedObjectData(object sender, ObjectDataEventArgs e)
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
        
        private void CardObjectDataSelected(object sender, EventArgs e)
        {
            if (this.ObjectDataSelected != null)
            {
                this.ObjectDataSelected(sender, e);
            }
        }
        
        private void CardImageDataSelected(object sender, EventArgs e)
        {
            if (this.ImageDataSelected != null)
            {
                this.ImageDataSelected(sender, e);
            }
        }
        
        private void CreateCards()
        {
            this.kryptonHeaderGroup1.Panel.Controls.Clear();
            if (this.objectData != null)
            {
                this.kryptonHeaderGroup1.HeaderVisiblePrimary = true;
                this.kryptonHeaderGroup1.ValuesPrimary.Heading = this.objectData[SystemProperty.Name].ToString();
                this.kryptonHeaderGroup1.Panel.AutoScroll = false;
            
                ObjectClass oc = database.Classes[this.objectData.ObjectClass.Identifier];
                Field[] fields = oc.FieldsBase.ToArray();
                
                Stack<DataCard> cards = new Stack<DataCard>();
                foreach (var category in oc.FieldsCategory)
                {
                    DataCard card = new DataCard(this.database, category.Key);
                    card.ObjectDataSelected += new EventHandler<EventArgs>(this.CardObjectDataSelected);
                    card.ImageDataSelected += new EventHandler<EventArgs>(this.CardImageDataSelected);
                    
                    card.BeginUpdate();
                    foreach (Field field in category)
                    {
                        object d = this.objectData[field];
                        if (!field.IsEmptyData(d))
                        {
                            card.AddValue(field, d);
                        }
                    }
                    
                    if (card.CountValues != 0)
                    {
                        cards.Push(card);
                    }
                    
                    card.EndUpdate();
                }
                
                while (cards.Count > 0)
                {
                    DataCard dc = cards.Pop();
                    dc.Dock = DockStyle.Top;
                    this.kryptonHeaderGroup1.Panel.Controls.Add(dc);
                    if (cards.Count > 0)
                    {
                        KryptonPanel p = new KryptonPanel();
                        p.Dock = DockStyle.Top;
                        p.Height = 6;
                        p.StateCommon.Color1 = Color.Transparent;
                        this.kryptonHeaderGroup1.Panel.Controls.Add(p);
                    }
                    
                    dc.UpdateHeight();
                }
            }
            else
            {
                this.kryptonHeaderGroup1.HeaderVisiblePrimary = false;
            }
            
            this.kryptonHeaderGroup1.Panel.AutoScroll = true;
        }
        
        private void ExecutePlugin(DataPlugin plugin)
        {
            plugin.SetCurrentGuid(this.objectData.ObjectClass.Identifier);
            foreach (string attr in plugin.GetNeededAttributes())
            {
                plugin.SetData(attr, this.objectData.ConvertToString(attr, CultureInfo.InvariantCulture));
            }
            
            plugin.Execute();
            foreach (string attr in plugin.GetChangedAttributes())
            {
                this.objectData[attr] = this.objectData.ConvertFromString(attr, plugin.GetData(attr), CultureInfo.InvariantCulture);
            }
            
            this.database.Objects.Update(this.objectData);
            this.collection.UpdateCurrentData();
        }
        
        private void MenuPluginClick(object sender, EventArgs e)
        {
            KryptonContextMenuItem item = sender as KryptonContextMenuItem;
            DataPlugin ip = item.Tag as DataPlugin;
            if (item != null)
            {
                this.ExecutePlugin(ip);
            }
        }
        
        private void ButtonSpecPluginClick(object sender, EventArgs e)
        {
            ButtonSpecHeaderGroup hg = sender as ButtonSpecHeaderGroup;
            DataPlugin ip = hg.Tag as DataPlugin;
            if (ip != null)
            {
                this.ExecutePlugin(ip);
            }
        }
    }
}
