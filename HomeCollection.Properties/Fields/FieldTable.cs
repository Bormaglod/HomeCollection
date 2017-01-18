//-----------------------------------------------------------------------
// <copyright file="FieldTable.cs" company="Sergey Teplyashin">
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
// <time>13:46</time>
// <summary>Defines the FieldTable class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Properties
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing.Design;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of FieldTable.
    /// </summary>
    public class FieldTable : AbstractField
    {
        public FieldTable(FieldProxy proxy) : base(proxy)
        {
        }
        
        [LocalizedDisplayName("Columns")]
        [TypeConverter(typeof(StringCollectionConverter))]
        [Editor(typeof(ColumnCollectionEditor), typeof(UITypeEditor))]
        public List<ColumnProperty> Columns
        {
            get
            {
                Field field = (Field)this.Proxy.Property;
                return field.DataValue.Table;
            }
            
            set
            {
                List<ColumnProperty> columns = this.Proxy.Property.DataValue.Table;
                foreach (ColumnProperty column in columns)
                {
                    Proxy.Database.Data.Delete(column);
                }
                
                columns.Clear();
                columns.AddRange(value);
                UpdateField();
                OnFieldModified();
            }
        }
        
        public override FieldType GetFieldType()
        {
            return FieldType.Table;
        }
    }
}
