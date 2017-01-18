//-----------------------------------------------------------------------
// <copyright file="FieldConverter.cs" company="Sergey Teplyashin">
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
// <date>11.02.2011</date>
// <time>10:09</time>
// <summary>Defines the FieldConverter class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Properties
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using HomeCollection.Data;
    
    #endregion
    
    /// <summary>
    /// Description of FieldConverter.
    /// </summary>
    public class FieldConverter : TypeConverter
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
                AbstractField f = (AbstractField)context.Instance;
                    
                foreach (ObjectClass c in f.Proxy.Database.Classes.Collection)
                {
                    string s = value as string;
                    if (s != null && c.Name == s)
                    {
                        return c;
                    }
                }
                    
                return null;
            }
              
             return base.ConvertFrom(context, culture, value);
        }
            
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                ObjectClass oc = value as ObjectClass;
                if (oc != null)
                {
                    return oc.Name;
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
            List<ObjectClass> list = new List<ObjectClass>();
            AbstractField f = (AbstractField)context.Instance;
                
            list.AddRange(f.Proxy.Database.Classes.Collection);
                
            TypeConverter.StandardValuesCollection svc = new TypeConverter.StandardValuesCollection(list);
            return svc;
        }
    }
}
