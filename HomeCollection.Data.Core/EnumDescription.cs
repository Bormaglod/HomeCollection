//-----------------------------------------------------------------------
// <copyright file="EnumDescription.cs" company="Sergey Teplyashin">
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
// <date>31.05.2011</date>
// <time>10:22</time>
// <summary>Defines the EnumDescription class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data.Core
{
    #region Using directives
    
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    
    #endregion
    
    /// <summary>
    /// Description of EnumDescription.
    /// </summary>
    public static class EnumDescription
    {
        public static string GetNameFieldType(FieldType fieldType)
        {
            Type t = fieldType.GetType();
            
            foreach (FieldInfo fi in t.GetFields())
            {
                if ((fi.FieldType == typeof(FieldType)) && (fi.Name == fieldType.ToString()))
                {
                    object[] op = fi.GetCustomAttributes(true);
                    foreach (object o in op)
                    {
                        DescriptionAttribute da = (DescriptionAttribute)o;
                        if (da != null)
                        {
                            return da.Description;
                        }
                    }
                }
            }
            
            return string.Empty;
        }
        
        public static string GetNameUrlType(UrlType urlType)
        {
            Type t = urlType.GetType();
            
            foreach (FieldInfo fi in t.GetFields())
            {
                if ((fi.FieldType == typeof(UrlType)) && (fi.Name == urlType.ToString()))
                {
                    object[] op = fi.GetCustomAttributes(true);
                    foreach (object o in op)
                    {
                        DescriptionAttribute da = (DescriptionAttribute)o;
                        if (da != null)
                        {
                            return da.Description;
                        }
                    }
                }
            }
            
            return string.Empty;
        }
        
        public static FieldType GetFieldType(string name)
        {
            foreach (FieldType field in Enum.GetValues(typeof(FieldType)))
            {
                Type t = field.GetType();
                
                foreach (FieldInfo fi in t.GetFields())
                {
                    if (fi.FieldType == typeof(FieldType) && (fi.Name == field.ToString()))
                    {
                        object[] op = fi.GetCustomAttributes(true);
                        foreach (object o in op)
                        {
                            DescriptionAttribute da = (DescriptionAttribute)o;
                            if ((da != null) && (da.Description == name))
                            {
                                return field;
                            }
                        }
                    }
                }
            }
            
            return FieldType.Text;
        }
        
        public static UrlType GetUrlType(string name)
        {
            foreach (UrlType field in Enum.GetValues(typeof(UrlType)))
            {
                Type t = field.GetType();
                
                foreach (FieldInfo fi in t.GetFields())
                {
                    if (fi.FieldType == typeof(UrlType) && (fi.Name == field.ToString()))
                    {
                        object[] op = fi.GetCustomAttributes(true);
                        foreach (object o in op)
                        {
                            DescriptionAttribute da = (DescriptionAttribute)o;
                            if ((da != null) && (da.Description == name))
                            {
                                return field;
                            }
                        }
                    }
                }
            }
            
            return UrlType.Select;
        }
        
        public static ICollection GetUrlTypes()
        {
            List<string> list = new List<string>();
            foreach (UrlType ut in UrlType.GetValues(typeof(UrlType)))
            {
                list.Add(GetNameUrlType(ut));
            }
            
            return list;
        }
    }
}
