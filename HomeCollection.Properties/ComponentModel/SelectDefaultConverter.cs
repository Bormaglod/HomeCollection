//-----------------------------------------------------------------------
// <copyright file="SelectDefaultConverter.cs" company="Sergey Teplyashin">
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
// <time>12:10</time>
// <summary>Defines the SelectDefaultConverter class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Properties
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    #endregion

    // FIXME: При двойном клике на свойстве, выскакивает ошибка о невозможности преобразования строки в целое    
    /// <summary>
    /// Description of SelectDefaultConverter.
    /// </summary>
    internal class SelectDefaultConverter : TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        
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
                return ((FieldSelect)context.Instance).Values.IndexOf((string)value);
            }
            
            return base.ConvertFrom(context, culture, value);
        }
        
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value is int)
                {
                    return (int)value == -1 ? string.Empty : ((FieldSelect)context.Instance).Values[(int)value];
                }
                else
                {
                    return value;
                }
            }
            
            return base.ConvertTo(context, culture, value, destinationType);
        }
        
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            List<string> list = new List<string>();
            foreach (string s in ((FieldSelect)context.Instance).Values)
            {
                list.Add(s);
            }
            
            TypeConverter.StandardValuesCollection svc = new TypeConverter.StandardValuesCollection(list);
            return svc;
        }
    }
}
