//-----------------------------------------------------------------------
// <copyright file="Utils.cs" company="Sergey Teplyashin">
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
// <date>27.04.2012</date>
// <time>12:18</time>
// <summary>Defines the Utils class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data.Core
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    
    #endregion
    
    /// <summary>
    /// Description of Utils.
    /// </summary>
    public static class Utils
    {
        public static string[] MethodGroupText
        {
            get { return new string[] { Strings.Full, Strings.FirstLetter, Strings.ByDay, Strings.ByMonth, Strings.ByYear }; }
        }
        
        public static IEnumerable<string> GetFieldTypeNames()
        {
            List<string> list = new List<string>();
            
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
                            if (da != null)
                            {
                                list.Add(da.Description);
                                break;
                            }
                        }
                        
                        break;
                    }
                }
            }
            
            return list;
        }
        
        public static string Parse(FieldType fieldType)
        {
            switch (fieldType)
            {
                case FieldType.Boolean:
                    return "boolean";
                case FieldType.Date:
                    return "date";
                case FieldType.Image:
                    return "image";
                case FieldType.List:
                    return "list";
                case FieldType.Memo:
                    return "memo";
                case FieldType.Number:
                    return "number";
                case FieldType.Rating:
                    return "raiting";
                case FieldType.Reference:
                    return "reference";
                case FieldType.Select:
                    return "select";
                case FieldType.Table:
                    return "table";
                case FieldType.Url:
                    return "url";
                default:
                    return "text";
            }
        }
        
        public static FieldType Parse(string fieldTypeName)
        {
            FieldType fieldType = FieldType.Text;
            if (fieldTypeName == "memo")
            {
                fieldType = FieldType.Memo;
            }
            else if (fieldTypeName == "select")
            {
                fieldType = FieldType.Select;
            }
            else if (fieldTypeName == "number")
            {
                fieldType = FieldType.Number;
            }
            else if (fieldTypeName == "list")
            {
                fieldType = FieldType.List;
            }
            else if (fieldTypeName == "boolean")
            {
                fieldType = FieldType.Boolean;
            }
            else if (fieldTypeName == "url")
            {
                fieldType = FieldType.Url;
            }
            else if (fieldTypeName == "date")
            {
                fieldType = FieldType.Date;
            }
            else if (fieldTypeName == "table")
            {
                fieldType = FieldType.Table;
            }
            else if (fieldTypeName == "image")
            {
                fieldType = FieldType.Image;
            }
            else if (fieldTypeName == "raiting")
            {
                fieldType = FieldType.Rating;
            }
            else if (fieldTypeName == "reference")
            {
                fieldType = FieldType.Reference;
            }
            
            return fieldType;
        }
        
        public static int ParseMethodGroup(string value)
        {
            string[] methodGroupText = MethodGroupText;
            for (int i = 0; i < methodGroupText.Length; i++)
            {
                if (methodGroupText[i] == value)
                {
                    if (i < 2)
                    {
                        return i;
                    }
                    else if (i < 5)
                    {
                        return i - 2;
                    }
                }
            }
            
            return -1;
        }
        
        public static bool CompareText(string text1, string text2, FilterOperation filterOperation)
        {
            switch (filterOperation)
            {
                case FilterOperation.Contains:
                    return text1.Contains(text2);
                    
                case FilterOperation.NotContains:
                    return !text1.Contains(text2);
                    
                case FilterOperation.Equal:
                    return text1 == text2;
                    
                case FilterOperation.NotEqual:
                    return text1 != text2;
            }
            
            return false;
        }
    }
}
