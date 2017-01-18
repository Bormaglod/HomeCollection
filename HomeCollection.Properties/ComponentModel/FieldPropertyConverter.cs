//-----------------------------------------------------------------------
// <copyright file="FieldPropertyConverter.cs" company="Sergey Teplyashin">
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
// <date>13.04.2012</date>
// <time>11:57</time>
// <summary>Defines the FieldPropertyConverter class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Properties
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of FieldPropertyConverter.
    /// </summary>
    internal class FieldPropertyConverter : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            
            return base.CanConvertFrom(context, sourceType);
        }
        
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            
            return base.CanConvertTo(context, destinationType);
        }
        
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                AbstractField field = null;
                switch (EnumDescription.GetFieldType((string)value))
                {
                    case FieldType.Text:
                        field = new FieldText((FieldProxy)context.Instance);
                        break;
                    case FieldType.Number:
                        field = new FieldDecimal((FieldProxy)context.Instance);
                        break;
                    case FieldType.Date:
                        field = new FieldDate((FieldProxy)context.Instance);
                        break;
                    case FieldType.Image:
                        field = new FieldImage((FieldProxy)context.Instance);
                        break;
                    case FieldType.Url:
                        field = new FieldUrl((FieldProxy)context.Instance);
                        break;
                    case FieldType.Select:
                        field = new FieldSelect((FieldProxy)context.Instance);
                        break;
                    case FieldType.Boolean:
                        field = new FieldBool((FieldProxy)context.Instance);
                        break;
                    case FieldType.Table:
                        field = new FieldTable((FieldProxy)context.Instance);
                        break;
                    case FieldType.Rating:
                        field = new FieldRaiting((FieldProxy)context.Instance);
                        break;
                    case FieldType.Reference:
                        field = new FieldReference((FieldProxy)context.Instance);
                        break;
                    case FieldType.List:
                        field = new FieldList((FieldProxy)context.Instance);
                        break;
                    case FieldType.Memo:
                        field = new FieldMemo((FieldProxy)context.Instance);
                        break;
                }
                
                return field;
            }
            
            return base.ConvertFrom(context, culture, value);
        }
        
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return EnumDescription.GetNameFieldType(((AbstractField)value).GetFieldType());
            }
            
            return base.ConvertTo(context, culture, value, destinationType);
        }
        
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            List<object> stdValues = new List<object>();
            stdValues.Add(new FieldText((FieldProxy)context.Instance));
            stdValues.Add(new FieldDate((FieldProxy)context.Instance));
            stdValues.Add(new FieldDecimal((FieldProxy)context.Instance));
            stdValues.Add(new FieldImage((FieldProxy)context.Instance));
            stdValues.Add(new FieldUrl((FieldProxy)context.Instance));
            stdValues.Add(new FieldBool((FieldProxy)context.Instance));
            stdValues.Add(new FieldSelect((FieldProxy)context.Instance));
            stdValues.Add(new FieldTable((FieldProxy)context.Instance));
            stdValues.Add(new FieldRaiting((FieldProxy)context.Instance));
            stdValues.Add(new FieldReference((FieldProxy)context.Instance));
            stdValues.Add(new FieldMemo((FieldProxy)context.Instance));
            stdValues.Add(new FieldList((FieldProxy)context.Instance));
            return new TypeConverter.StandardValuesCollection(stdValues);
        }
        
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
