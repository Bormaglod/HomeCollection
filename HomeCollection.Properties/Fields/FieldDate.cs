//-----------------------------------------------------------------------
// <copyright file="FieldDate.cs" company="Sergey Teplyashin">
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
// <time>13:54</time>
// <summary>Defines the FieldDate class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Properties
{
    #region Using directives
    
    using System;
    using System.ComponentModel;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of FieldDate.
    /// </summary>
    public class FieldDate : AbstractField
    {
        public FieldDate(FieldProxy proxy) : base(proxy)
        {
        }
        
        [LocalizedDisplayName("DefaultValue")]
        public DateTime DefaultValue
        {
            get
            {
                return this.Proxy.Property.DefaultValue.AsDateTime;
            }
            
            set
            {
                this.Proxy.Property.DefaultValue.AsDateTime = value;
                UpdateField();
            }
        }
        
        [LocalizedDisplayName("Time")]
        [DefaultValue(false)]
        [TypeConverter(typeof(BooleanDefaultConverter))]
        public bool DecimalPlaces
        {
            get
            {
                return this.Property.ViewTime;
            }
            
            set
            {
                this.Property.ViewTime = value;
                UpdateField();
            }
        }
        
        private DateProperty Property
        {
            get { return this.Proxy.Property.DataValue.Date; }
        }
        
        public override FieldType GetFieldType()
        {
            return FieldType.Date;
        }
    }
}
