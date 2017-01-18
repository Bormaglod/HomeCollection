//-----------------------------------------------------------------------
// <copyright file="UpdatedReferenceData.cs" company="Sergey Teplyashin">
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
// <date>29.03.2012</date>
// <time>11:45</time>
// <summary>Defines the UpdatedReferenceData class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Core
{
    #region Using directives
    
    using System;
    using System.Xml;
    using HomeCollection.Data;
    
    #endregion
    
    /// <summary>
    /// Description of UpdatedReferenceData.
    /// </summary>
    internal class UpdatedReferenceData
    {
        private ObjectData data;
        private Field field;
        private string valueData;
        private XmlNode node;
        
        public UpdatedReferenceData(XmlNode node, ObjectData data, Field field, string valueData)
        {
            this.node = node;
            this.data = data;
            this.field = field;
            this.valueData = valueData;
        }
        
        public ObjectData Data
        {
            get { return this.data; }
        }
        
        public Field Field
        {
            get { return this.field; }
        }
        
        public string ValueData
        {
            get { return this.valueData; }
        }
        
        public XmlNode Node
        {
            get { return this.node; }
        }
    }
}
