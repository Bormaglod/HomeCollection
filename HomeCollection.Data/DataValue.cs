//-----------------------------------------------------------------------
// <copyright file="DataValue.cs" company="Sergey Teplyashin">
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
// <date>24.04.2012</date>
// <time>11:51</time>
// <summary>Defines the DataValue class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    
    #endregion
    
    /// <summary>
    /// Description of DataValue.
    /// </summary>
    public class DataValue
    {
        private Field field;
        
        public DataValue(Field field)
        {
            this.field = field;
        }
        
        public List<string> Select
        {
            get { return (List<string>)this.field.Data; }
        }
        
        public NumberProperty Number
        {
            get { return (NumberProperty)this.field.Data; }
        }
        
        public ListProperty List
        {
            get { return ListProperty.Get(this.field); }
        }
        
        public UrlProperty Url
        {
            get { return UrlProperty.Get(this.field); }
        }
        
        public DateProperty Date
        {
            get { return DateProperty.Get(this.field); }
        }
        
        public List<ColumnProperty> Table
        {
            get { return (List<ColumnProperty>)this.field.Data; }
        }
        
        public ReferenceProperty Reference
        {
            get { return ReferenceProperty.Get(this.field); }
        }
    }
}
