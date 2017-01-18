//-----------------------------------------------------------------------
// <copyright file="HistoryPoint.cs" company="Sergey Teplyashin">
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
// <date>27.03.2012</date>
// <time>13:03</time>
// <summary>Defines the HistoryPoint class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using HomeCollection.Data;
    
    #endregion
    
    /// <summary>
    /// Description of HistoryPoint.
    /// </summary>
    internal class HistoryPoint
    {
        private Folder folder;
        private string category;
        private string filterText;
        private ObjectData objectData;
        private Filter filterFolder;
        
        public HistoryPoint(Folder folder, Filter filterFolder, string category, string filterText, ObjectData objectData)
        {
            this.filterFolder = filterFolder;
            this.folder = folder;
            this.category = category;
            this.filterText = filterText;
            this.objectData = objectData;
        }
        
        public Folder Folder
        {
            get { return this.folder; }
        }
        
        public string Category
        {
            get { return this.category; }
        }
        
        public string FilterText
        {
            get { return this.filterText; }
        }
        
        public ObjectData ObjectData
        {
            get { return this.objectData; }
        }
        
        public Filter FilterFolder
        {
            get { return this.filterFolder; }
        }
        
        public bool Equal(HistoryPoint point)
        {
            return point.Folder == this.Folder && point.Category == this.Category && point.FilterFolder == this.FilterFolder;
        }
        
        public void ChangeObject(ObjectData newObject)
        {
            this.objectData = newObject;
        }
    }
}
