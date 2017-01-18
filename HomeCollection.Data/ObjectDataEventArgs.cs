//-----------------------------------------------------------------------
// <copyright file="ObjectDataEventArgs.cs" company="Sergey Teplyashin">
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
// <date>02.06.2011</date>
// <time>8:25</time>
// <summary>Defines the ObjectDataEventArgs class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    
    #endregion
    
    /// <summary>
    /// Description of ObjectDataEventArgs.
    /// </summary>
    public class ObjectDataEventArgs : EventArgs
    {
        private Field field;
        private ObjectData objectData;
        private string valueData;
        private bool creating;
        private bool created;
        
        public ObjectDataEventArgs(Field field, string valueData, bool creating)
        {
            this.field = field;
            this.valueData = valueData;
            this.creating = creating;
        }
        
        public Field Field
        {
            get { return this.field; }
        }
        
        public ObjectData ObjectData
        {
            get { return this.objectData; }
            set { this.objectData = value; }
        }
        
        public string ValueData
        {
            get { return this.valueData; }
        }
        
        public bool Creating
        {
            get { return this.creating; }
        }
        
        public bool Created
        {
            get { return this.created; }
            set { this.created = value; }
        }
    }
}
