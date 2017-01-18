//-----------------------------------------------------------------------
// <copyright file="FilterItemControl.cs" company="Sergey Teplyashin">
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
// <date>28.04.2011</date>
// <time>14:44</time>
// <summary>Defines the FilterItemControl class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of FilterItemControl.
    /// </summary>
    public partial class FilterItemControl : UserControl
    {
        private FilterItem item;
        private Database database;
        
        public FilterItemControl()
        {
            InitializeComponent();
        }
        
        public FilterItemControl(Database database) : this()
        {
            this.database = database;
        }
        
        public FilterItem Item
        {
            get
            {
                return this.item;
            }
            
            set
            {
                this.item = value;
                this.UpdateFilterItemControl();
            }
        }
        
        public void UpdateFilterItem()
        {
            this.item.ObjectClass = this.comboClass.SelectedIndex > 0 ? (ObjectClass)this.comboClass.SelectedItem : null;
            this.item.Field = this.comboField.SelectedIndex > 0 ? (Field)this.comboField.SelectedItem : null;
            this.item.Operation = (FilterOperation)this.comboOperation.SelectedIndex;
            this.item.Filter = this.textFilter.Text;
        }
        
        private void UpdateFilterItemControl()
        {
            if (this.item != null)
            {
                this.comboClass.Items.Clear();
                this.comboClass.Items.Add(Strings.AnyClass);
                foreach (ObjectClass oc in this.database.Classes.Collection)
                {
                    this.comboClass.Items.Add(oc);
                }
                
                if (this.item.ObjectClass == null)
                {
                    this.comboClass.SelectedIndex = 0;
                }
                else
                {
                    this.comboClass.SelectedItem = this.item.ObjectClass;
                }
                
                this.comboOperation.SelectedIndex = (int)this.item.Operation;
                this.textFilter.Text = this.item.Filter;
            }
        }
        
        private void ComboClassSelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboField.Items.Clear();
            this.comboField.Items.Add(Strings.AnyField);
            if (this.comboClass.SelectedIndex == 0)
            {
                this.comboField.SelectedIndex = 0;
                this.comboField.Enabled = false;
            }
            else
            {
                ObjectClass oc = (ObjectClass)this.comboClass.SelectedItem;
                foreach (Field f in oc.FieldsBase)
                {
                    this.comboField.Items.Add(f);
                }
                
                this.comboField.Enabled = true;
                if (this.item.Field == null)
                {
                    this.comboField.SelectedIndex = 0;
                }
                else
                {
                    this.comboField.SelectedItem = this.item.Field;
                }
            }
        }
    }
}
