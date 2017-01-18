//-----------------------------------------------------------------------
// <copyright file="UrlProperty.cs" company="Sergey Teplyashin">
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
// <time>9:43</time>
// <summary>Defines the UrlProperty class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of UrlProperty.
    /// </summary>
    public class UrlProperty
    {
        private UrlType type;
        
        public UrlProperty()
        {
            this.type = UrlType.Select;
        }
        
        public UrlProperty(UrlType urlType)
        {
            this.type = urlType;
        }
        
        public UrlProperty(string urlType)
        {
            this.type = Parse(urlType);
        }
        
        public UrlType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        
        public static UrlType Parse(string typeName)
        {
            if (typeName == "file")
            {
                return UrlType.File;
            }
            
            if (typeName == "folder")
            {
                return UrlType.Folder;
            }
            
            if (typeName == "url")
            {
                return UrlType.Url;
            }
            
            return UrlType.Select;
        }
        
        public static UrlProperty Get(Field field)
        {
            return (UrlProperty)field.Data;
        }
    }
}
