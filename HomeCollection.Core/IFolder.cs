//-----------------------------------------------------------------------
// <copyright file="IFolder.cs" company="Sergey Teplyashin">
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
// <date>14.04.2011</date>
// <time>12:40</time>
// <summary>Defines the IFolder interface.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Core
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using HomeCollection.Data;
    
    #endregion
    
    /// <summary>
    /// Description of IFolder.
    /// </summary>
    public interface IFolder
    {
        string CurrentCategory { get; }
            
        void AddCategory(string category);
        void UpdateCategories();
        
        void CreateTree(Folder folder);
        void SelectFolder(ObjectData objectData);
        void SelectFolder(Folder folder, string filter, string category);
        void SelectFolder(Filter filter);
        void DeleteFilterFolder(Folder folder, string filter);
        void UpdateFilteredFolders(ObjectData obj);
        
        void UpdateFieldGroup(Field field);
        void DeleteClasses(IEnumerable<ObjectClass> classes);
    }
}
