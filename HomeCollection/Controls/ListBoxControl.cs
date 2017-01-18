//-----------------------------------------------------------------------
// <copyright file="ListBoxControl.cs" company="Sergey Teplyashin">
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
// <date>21.02.2011</date>
// <time>12:55</time>
// <summary>Defines the ListBoxControl class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using HomeCollection.Core;
    using HomeCollection.Data;
    
    #endregion

    /// <summary>
    /// Description of ListBoxControl.
    /// </summary>
    public partial class ListBoxControl : UserControl
    {
        private IDataCollection collection;
        private Database database;
        private Field field;
        private List<ObjectData> addedItems;
        private bool smallButtons;
        
        public ListBoxControl(IDataCollection collection, Database database, ObjectData obj, Field field)
        {
            InitializeComponent();
        
            this.addedItems = new List<ObjectData>();
            this.collection = collection;
            this.database = database;
            this.field = field;
            foreach (ObjectData d in ((ListData)obj[field]).Objects)
            {
                this.list.Items.Add(d);
            }
            
            if (this.list.Items.Count > 0)
            {
                this.list.SelectedIndex = 0;
            }
            
            this.UpdateButtons();
        }
        
        public event EventHandler<DataItemsEventArgs> DataItemsAdded;
        
        public IEnumerable ListData
        {
            get { return this.list.Items; }
        }
        
        public bool SmallButtons
        {
            get
            {
                return this.smallButtons;
            }
            
            set
            {
                this.smallButtons = value;
                if (this.smallButtons)
                {
                    this.panelButtons.Size = new Size(31, this.panelButtons.Height);
                    this.buttonAdd.Text = string.Empty;
                    this.buttonDelete.Text = string.Empty;
                }
                else
                {
                    this.panelButtons.Size = new Size(90, this.panelButtons.Height);
                    this.buttonAdd.Text = Resources.ResourceManager.GetString("buttonAdd.Values.Text");
                    this.buttonDelete.Text = Resources.ResourceManager.GetString("buttonDelete.Values.Text");
                }
            }
        }
        
        public bool Exist(ObjectData data)
        {
            return this.list.Items.IndexOf(data) != -1;
        }
        
        public void SelectData(ObjectData data)
        {
            this.list.SelectedItem = data;
        }
        
        public void AddItem(ObjectData data)
        {
            this.list.Items.Add(data);
        }
        
        private void UpdateButtons()
        {
            this.buttonDelete.Enabled = this.list.SelectedIndex != -1;
            this.buttonAdd.Enabled = this.field.Data != null;
        }
        
        private void form_DataItemAdded(object sender, DataItemEventArgs e)
        {
            this.addedItems.Add(e.Data);
        }
        
        private void ButtonAddClick(object sender, EventArgs e)
        {
            this.addedItems.Clear();
            FormSelectMultipleObjectData form = new FormSelectMultipleObjectData(this.collection, this.database, ListProperty.Get(this.field).Reference);
            form.DataItemAdded += new EventHandler<DataItemEventArgs>(this.form_DataItemAdded);
            foreach (ObjectData od in form.GetObjectData())
            {
                if (!this.list.Items.Contains(od))
                {
                    this.list.Items.Add(od);
                    if (this.DataItemsAdded != null)
                    {
                        this.DataItemsAdded(this, new DataItemsEventArgs(this.addedItems));
                    }
                }
            }
            
            if (this.list.Items.Count == 1)
            {
                this.UpdateButtons();
            }
        }
        
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            this.list.Items.RemoveAt(this.list.SelectedIndex);
        }
        
        private void ListSelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateButtons();
        }
    }
}
