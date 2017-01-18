//-----------------------------------------------------------------------
// <copyright file="FieldSelect.cs" company="Sergey Teplyashin">
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
// <date>08.02.2011</date>
// <time>14:39</time>
// <summary>Defines the FieldSelect class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Properties
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Drawing.Design;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of FieldDataSelect.
    /// </summary>
    public class FieldSelect : AbstractField
    {
        public FieldSelect(FieldProxy proxy) : base(proxy)
        {
        }
        
        [LocalizedDisplayName("Values")]
        [Editor(typeof(StringCollectionEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(StringCollectionConverter))]
        public List<string> Values
        {
            get
            {
                return this.Proxy.Property.DataValue.Select;
            }
            
            set
            {
                List<string> list = (List<string>)this.Proxy.Property.Data;
                list.Clear();
                list.AddRange(value);
                UpdateField();
                OnFieldModified();
            }
        }
        
        [LocalizedDisplayName("DefaultValue")]
        [TypeConverter(typeof(SelectDefaultConverter))]
        public int DefaultValue
        {
            get
            {
                return this.Proxy.Property.DefaultValue.AsInteger;
            }
            
            set
            {
                this.Proxy.Property.DefaultValue.AsInteger = value;
                UpdateField();
            }
        }
        
        public override FieldType GetFieldType()
        {
            return FieldType.Select;
        }
    }
}
