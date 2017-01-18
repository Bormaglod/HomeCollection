//-----------------------------------------------------------------------
// <copyright file="FormColumnCollection.cs" company="Sergey Teplyashin">
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
// <date>09.02.2011</date>
// <time>14:42</time>
// <summary>Defines the FormColumnCollection class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Properties
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using HomeCollection.Data;
    
    #endregion

    /// <summary>
    /// Description of FormColumnCollection.
    /// </summary>
    public partial class FormColumnCollection : KryptonForm
    {
        private List<ColumnProperty> collection;
        private Database database;
        
        public FormColumnCollection(Database data, List<ColumnProperty> listData)
        {
            this.InitializeComponent();
        
            this.database = data;
            this.collection = new List<ColumnProperty>();
            foreach (ColumnProperty column in listData)
            {
                ColumnProperty c = column.CopyTo(new ColumnProperty());
                this.collection.Add(c);
                this.listColumns.Items.Add(c);
            }
            
            if (this.listColumns.Items.Count > 0)
            {
                this.listColumns.SelectedIndex = 0;
            }
            
            this.UpdateButtons();
        }
        
        public List<ColumnProperty> Collection
        {
            get { return this.collection; }
        }
        
        private void UpdateButtons()
        {
            this.buttonDelete.Enabled = this.listColumns.SelectedIndex != -1;
            this.buttonUp.Enabled = this.buttonDelete.Enabled && this.listColumns.SelectedIndex > 0;
            this.buttonDown.Enabled = this.buttonDelete.Enabled && this.listColumns.SelectedIndex < this.listColumns.Items.Count - 1;
        }
        
        private void ColumnNameModified(object sender, EventArgs e)
        {
            ColumnPropertyProxy column = (ColumnPropertyProxy)sender;
            bool find = false;
            foreach (ColumnProperty c in this.listColumns.Items)
            {
                if (c != column.Column)
                {
                    if (c.Name == column.Name)
                    {
                        find = true;
                        break;
                    }
                }
            }
            
            if (find)
            {
                KryptonMessageBox.Show(Strings.UniqueColumnName, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                column.Name = this.GenerateUniqueName(column.Name);
            }
            
            this.listColumns.Refresh();
        }
        
        private string GenerateUniqueName(string name)
        {
            int n = 0;
            bool find;
            string newName;
            
            do
            {
                n++;
                find = false;
                newName = name + n.ToString();
            
                foreach (ColumnProperty c in this.listColumns.Items)
                {
                    if (c.Name == newName)
                    {
                        find = true;
                        break;
                    }
                }
            }
            while (find);
            
            return newName;
        }
        
        private void ButtonAddClick(object sender, EventArgs e)
        {
            ColumnProperty column = new ColumnProperty(this.GenerateUniqueName(Strings.Column));
            this.listColumns.Items.Add(column);
            
            if (this.listColumns.SelectedIndex == -1)
            {
                this.listColumns.SelectedIndex = 0;
            }
            
            this.UpdateButtons();
        }
        
        private void ListColumnsSelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnProperty cp = (ColumnProperty)this.listColumns.SelectedItem;
            ColumnPropertyProxy proxy = new ColumnPropertyProxy(this.database, cp);
            proxy.ColumnNameModified += new EventHandler<EventArgs>(this.ColumnNameModified);
            this.propertyColumn.SelectedObject = proxy;
            this.UpdateButtons();
        }
        
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (this.listColumns.SelectedIndex != -1)
            {
                int index = this.listColumns.SelectedIndex;
               
                this.listColumns.Items.Remove(this.listColumns.SelectedItem);
                
                if (this.listColumns.Items.Count == 0)
                {
                    index = -1;
                }
                else if (this.listColumns.Items.Count == 1)
                {
                    index = 0;
                }
                else if (index == this.listColumns.Items.Count)
                {
                    index = this.listColumns.Items.Count - 1;
                }
                
                this.listColumns.SelectedIndex = index;
            }
        }
        
        private void ButtonUpClick(object sender, EventArgs e)
        {
            if (this.listColumns.SelectedIndex > 0)
            {
                ColumnProperty sel = (ColumnProperty)this.listColumns.SelectedItem;
                int newPos = this.listColumns.SelectedIndex - 1;
                this.listColumns.Items.Remove(sel);
                this.listColumns.Items.Insert(newPos, sel);
                this.listColumns.SelectedItem = sel;
            }
        }
        
        private void ButtonDownClick(object sender, EventArgs e)
        {
            if (this.listColumns.SelectedIndex != -1 && this.listColumns.SelectedIndex < this.listColumns.Items.Count - 1)
            {
                ColumnProperty sel = (ColumnProperty)this.listColumns.SelectedItem;
                int newPos = this.listColumns.SelectedIndex + 1;
                this.listColumns.Items.Remove(sel);
                this.listColumns.Items.Insert(newPos, sel);
                this.listColumns.SelectedItem = sel;
            }
        }
        
        private void ButtonOKClick(object sender, EventArgs e)
        {
            this.collection.Clear();
            this.collection.AddRange(this.listColumns.Items.OfType<ColumnProperty>());
        }
    }
}
