﻿//-----------------------------------------------------------------------
// <copyright file="FilterItem.cs" company="Sergey Teplyashin">
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
// <time>14:19</time>
// <summary>Defines the FilterItem class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    using ComponentLib.Data;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of FilterItem.
    /// </summary>
    [Cascade]
    public class FilterItem
    {
        private ObjectClass objectClass;
        private Field field;
        private FilterOperation operation;
        private string filter;

        public FilterItem()
        {
            this.filter = string.Empty;
        }
        
        public FilterItem(ObjectClass objectClass, Field field, FilterOperation operation, string filter) : this()
        {
            this.objectClass = objectClass;
            this.field = field;
            this.operation = operation;
            this.filter = filter;
        }

        public ObjectClass ObjectClass
        {
            get { return this.objectClass; }
            set { this.objectClass = value; }
        }
        
        public Field Field
        {
            get { return this.field; }
            set { this.field = value; }
        }
        
        public FilterOperation Operation
        {
            get { return this.operation; }
            set { this.operation = value; }
        }
        
        public string Filter
        {
            get { return this.filter; }
            set { this.filter = value; }
        }
        
        public FilterItem CopyTo(FilterItem item)
        {
            item.ObjectClass = this.ObjectClass;
            item.Field = this.Field;
            item.Operation = this.Operation;
            item.Filter = this.Filter;
            return item;
        }
    }
}
