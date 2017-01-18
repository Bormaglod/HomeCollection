//-----------------------------------------------------------------------
// <copyright file="FilterCollection.cs" company="Sergey Teplyashin">
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
// <time>14:14</time>
// <summary>Defines the FilterCollection class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ComponentLib.Data;
    using Db4objects.Db4o.Linq;
    
    #endregion
    
    /// <summary>
    /// Description of FilterCollection.
    /// </summary>
    public class FilterCollection : BaseCollection<Filter>
    {
        public FilterCollection(Database data) : base(data)
        {
            Database.DatabaseOpened += new EventHandler<EventArgs>(this.Database_DatabaseOpened);
        }
        
        public FilterItem AddFilterItem(Filter filter, bool update)
        {
            FilterItem item = filter.CreateFilterItem();
            if (update)
            {
                Update(filter);
            }
            
            return item;
        }
        
        public void RemoveFilterItem(Filter filter, FilterItem item, bool update)
        {
            this.RemoveFilterItem(filter, item);
            if (update)
            {
                Update(filter);
            }
        }
        
        public override void ObjectRemoving(object removingObject)
        {
            Stack<FilterItem> removing = new Stack<FilterItem>();
            ObjectClass objectClass = removingObject as ObjectClass;
            if (objectClass != null)
            {
                foreach (Filter filter in this.Collection)
                {
                    foreach (FilterItem item in filter.Items)
                    {
                        if (item.ObjectClass == objectClass)
                        {
                            removing.Push(item);
                        }
                    }
                    
                    this.RemoveFilterItems(filter, removing);
                }
                
                return;
            }
        }
        
        private void RemoveFilterItems(Filter filter, Stack<FilterItem> items)
        {
            if (items.Count > 0)
            {
                while (items.Count > 0)
                {
                    this.RemoveFilterItem(filter, items.Pop());
                }
                
                Update(filter);
            }
        }
        
        private void RemoveFilterItem(Filter filter, FilterItem item)
        {
            filter.RemoveFilter(item);
            this.Database.Data.Delete(item);
        }
        
        private void Database_DatabaseOpened(object sender, EventArgs e)
        {
            Database.Classes.FieldModified += new EventHandler<FieldModifiedEventArgs>(this.Database_Classes_FieldModified);
        }
        
        private void Database_Classes_FieldModified(object sender, FieldModifiedEventArgs e)
        {
            if (e.Action == ObjectAction.Delete)
            {
                Stack<FilterItem> removing = new Stack<FilterItem>();
                foreach (Filter filter in this.Collection)
                {
                    foreach (FilterItem item in filter.Items)
                    {
                        if (item.Field == e.Field)
                        {
                            removing.Push(item);
                        }
                    }
                    
                    this.RemoveFilterItems(filter, removing);
                }
            }
        }
    }
}
