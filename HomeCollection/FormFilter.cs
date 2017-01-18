//-----------------------------------------------------------------------
// <copyright file="FormFilter.cs" company="Sergey Teplyashin">
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
// <time>14:31</time>
// <summary>Defines the FormFilter class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of FormFilter.
    /// </summary>
    public partial class FormFilter : KryptonForm
    {
        private Database database;
        private Filter filter;
        
        private List<FilterItemControl> controls;
        private List<FilterItemPair> items;
        private string filterName;
        private Logical operation;
        
        public FormFilter()
        {
            InitializeComponent();
            
            this.controls = new List<FilterItemControl>();
            this.items = new List<FormFilter.FilterItemPair>();
            this.filterName = string.Empty;
            this.operation = Logical.And;
        }
        
        public Filter Filter
        {
            get { return this.filter; }
        }
        
        public bool Show(Database database, Filter filter)
        {
            this.database = database;
            this.filter = filter;
            
            if (this.filter != null)
            {
                foreach (FilterItem i in this.filter.Items)
                {
                    this.items.Add(new FilterItemPair(i.CopyTo(new FilterItem()), i));
                }
                
                this.filterName = this.filter.Name;
                this.operation = this.filter.LogicalOperation;
            }
            
            this.UpdateFilterItems();
            this.UpdateButtons();
            if (ShowDialog() == DialogResult.OK)
            {
                if (this.filter == null)
                {
                    this.filter = new Filter();
                    foreach (FilterItemPair pair in this.items)
                    {
                        pair.NewItem.CopyTo(this.database.Filters.AddFilterItem(this.filter, false));
                    }
                    
                    this.UpdateFilter();
                }
                else
                {
                    this.UpdateFilter();
                    foreach (FilterItemPair pair in this.items)
                    {
                        if (pair.ExistItem == null)
                        {
                            pair.NewItem.CopyTo(this.database.Filters.AddFilterItem(this.filter, false));
                        }
                        else if (pair.NewItem == null)
                        {
                            this.database.Filters.RemoveFilterItem(this.filter, pair.ExistItem, false);
                        }
                        else
                        {
                            pair.NewItem.CopyTo(pair.ExistItem);
                        }
                    }
                }
                
                if (this.filter.IsNew)
                {
                    this.database.Filters.Add(this.filter);
                }
                else
                {
                    this.database.Filters.Update(this.filter);
                }
                
                return true;
            }
            
            return false;
        }
        
        private void UpdateFilter()
        {
            this.filter.Name = this.textName.Text;
            this.filter.LogicalOperation = this.radioAnd.Checked ? Logical.And : Logical.Or;
        }
        
        private void AddFilterItemControl(FilterItemPair item)
        {
            FilterItemControl control = new FilterItemControl(this.database);
            control.Item = item.NewItem;
            control.Location = new Point(0, this.controls.Count * 26 + 55);
            control.Size = new Size(this.groupFilters.Panel.Width, 26);
            control.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            this.groupFilters.Panel.Controls.Add(control);
            this.controls.Add(control);
        }
        
        private void RemoveFilterItem(FilterItemControl item)
        {
            this.controls.Remove(item);
            this.groupFilters.Panel.Controls.Remove(item);
            Stack<FilterItemPair> deleted = new Stack<FormFilter.FilterItemPair>();
            for (int i = 0; i < this.items.Count; i++)
            {
                FilterItemPair pair = this.items[i];
                if (pair.NewItem == item.Item)
                {
                    pair.NewItem = null;
                }
                
                if (pair.IsEmpty)
                {
                    deleted.Push(pair);
                }
            }
            
            while (deleted.Count > 0)
            {
                this.items.Remove(deleted.Pop());
            }
        }
        
        private void UpdateFilterItems()
        {
            this.radioAnd.Checked = this.operation == Logical.And;
            this.radioOr.Checked = this.operation == Logical.Or;
            this.textName.Text = this.filterName;
            foreach (FilterItemPair item in this.items)
            {
                this.AddFilterItemControl(item);
            }
            
            this.UpdateSizes();
        }
        
        private void UpdateButtons()
        {
            this.buttonMore.Enabled = this.controls.Count < 8;
            this.buttonLess.Enabled = this.controls.Count > 0;
        }
        
        private void UpdateSizes()
        {
            int c = this.controls.Count == 0 ? 0 : this.controls.Count - 1;
            int y = c * 26 + 87;
            this.buttonMore.Location = new Point(this.buttonMore.Location.X, y);
            this.buttonLess.Location = new Point(this.buttonLess.Location.X, y);
            this.buttonClear.Location = new Point(this.buttonClear.Location.X, y);
            
            Size size = new Size(Width, c * 26 + 260);
            Size = new Size(Size.Width < size.Width ? size.Width : Size.Width, Size.Height < size.Height ? size.Height : Size.Height);
            MinimumSize = new Size(MinimumSize.Width, c * 26 + 260);
        }
        
        private void ButtonMoreClick(object sender, EventArgs e)
        {
            FilterItemPair item = new FormFilter.FilterItemPair(new FilterItem(), null);
            this.AddFilterItemControl(item);
            this.items.Add(item);
            this.UpdateButtons();
            this.UpdateSizes();
        }
        
        private void ButtonLessClick(object sender, EventArgs e)
        {
            this.RemoveFilterItem(this.controls[this.controls.Count - 1]);
            this.UpdateButtons();
            this.UpdateSizes();
        }
        
        private void ButtonClearClick(object sender, EventArgs e)
        {
            foreach (FilterItemControl control in this.controls)
            {
                this.groupFilters.Panel.Controls.Remove(control);
            }
            
            this.controls.Clear();
            for (int i = 0; i < this.items.Count; i++)
            {
                /*FilterItemPair pair = this.items[i];
                pair.NewItem = null;*/
                this.items[0].Delete();
            }

            this.UpdateButtons();
            this.UpdateSizes();
        }
        
        private void ButtonOkClick(object sender, EventArgs e)
        {
            foreach (FilterItemControl control in this.controls)
            {
                control.UpdateFilterItem();
            }
        }
        
        private class FilterItemPair
        {
            private FilterItem newItem;
            private FilterItem existItem;
            
            public FilterItemPair(FilterItem newItem, FilterItem existItem)
            {
                this.newItem = newItem;
                this.existItem = existItem;
            }
            
            public FilterItem ExistItem
            {
                get { return this.existItem; }
                set { this.existItem = value; }
            }
            
            public FilterItem NewItem
            {
                get { return this.newItem; }
                set { this.newItem = value; }
            }
            
            public void Delete()
            {
                this.newItem = null;
            }
            
            public bool IsEmpty
            {
                get { return this.newItem == null && this.existItem == null; }
            }
        }
    }
}
