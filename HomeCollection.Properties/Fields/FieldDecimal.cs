//-----------------------------------------------------------------------
// <copyright file="FieldDecimal.cs" company="Sergey Teplyashin">
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
// <time>13:53</time>
// <summary>Defines the FieldDecimal class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Properties
{
    #region Using directives
    
    using System;
    using System.ComponentModel;
    using System.Reflection;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of FieldDataDecimal.
    /// </summary>
    public class FieldDecimal : AbstractField
    {
        public FieldDecimal(FieldProxy proxy) : base(proxy)
        {
            this.UpdateReadOnlyAttributes();
        }
        
        [LocalizedDisplayName("DefaultValue")]
        public decimal DefaultValue
        {
            get
            {
                return this.Proxy.Property.DefaultValue.AsDecimal;
            }
            
            set
            {
                this.Proxy.Property.DefaultValue.AsDecimal = value;
                UpdateField();
            }
        }
        
        [LocalizedDisplayName("Decimal")]
        [DefaultValue(0)]
        public int DecimalPlaces
        {
            get
            {
                return this.Property.DecimalPlaces;
            }
            
            set
            {
                this.Property.DecimalPlaces = value;
                UpdateField();
            }
        }
        
        [LocalizedDisplayName("Maximum")]
        [DefaultValue(typeof(decimal), "100")]
        [ReadOnly(true)]
        public decimal Maximum
        {
            get
            {
                return this.Property.Maximum;
            }
            
            set
            {
                this.Property.Maximum = value;
                UpdateField();
            }
        }
        
        [LocalizedDisplayName("Minimum")]
        [DefaultValue(typeof(decimal), "0")]
        [ReadOnly(true)]
        public decimal Minimum
        {
            get
            {
                return this.Property.Minimum;
            }
            
            set
            {
                this.Property.Minimum = value;
                UpdateField();
            }
        }
        
        [LocalizedDisplayName("Increment")]
        [DefaultValue(typeof(decimal), "1")]
        public decimal Increment
        {
            get
            {
                return this.Property.Increment;
            }
            
            set
            {
                this.Property.Increment = value;
                UpdateField();
            }
        }
        
        [LocalizedDisplayName("Thousands")]
        [DefaultValue(false)]
        [TypeConverter(typeof(BooleanDefaultConverter))]
        public bool Thousands
        {
            get
            {
                return this.Property.Thousands;
            }
            
            set
            {
                this.Property.Thousands = value;
                UpdateField();
            }
        }
        
        [LocalizedDisplayName("Prefix")]
        public string Prefix
        {
            get
            {
                return this.Property.Prefix;
            }
            
            set
            {
                this.Property.Prefix = value;
                UpdateField();
            }
        }
        
        [LocalizedDisplayName("Suffix")]
        public string Suffix
        {
            get
            {
                return this.Property.Suffix;
            }
            
            set
            {
                this.Property.Suffix = value;
                UpdateField();
            }
        }
        
        [LocalizedDisplayName("Bounds")]
        [DefaultValue(false)]
        [TypeConverter(typeof(BooleanDefaultConverter))]
        [RefreshProperties(RefreshProperties.All)]
        public bool Bounds
        {
            get
            {
                return this.Property.Bounds;
            }
            
            set
            {
                this.Property.Bounds = value;
                UpdateField();
                this.UpdateReadOnlyAttributes();
            }
        }
        
        private NumberProperty Property
        {
            get
            {
                return (NumberProperty)this.Proxy.Property.Data;
            }
        }
        
        public override FieldType GetFieldType()
        {
            return FieldType.Number;
        }
        
        private void UpdateReadOnlyAttributes()
        {
            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this.GetType())["Maximum"];
            ReadOnlyAttribute attribute = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
            FieldInfo fieldToChange = attribute.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldToChange.SetValue(attribute, !this.Property.Bounds);
            
            descriptor = TypeDescriptor.GetProperties(this.GetType())["Minimum"];
            attribute = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
            fieldToChange = attribute.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldToChange.SetValue(attribute, !this.Property.Bounds);
        }
    }
}
