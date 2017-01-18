//-----------------------------------------------------------------------
// <copyright file="FolderCollection.cs" company="Sergey Teplyashin">
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
// <date>25.02.2011</date>
// <time>9:39</time>
// <summary>Defines the FolderCollection class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ComponentLib.Data;
    using Db4objects.Db4o.Linq;
    
    #endregion
    
    /// <summary>
    /// Description of FolderCollection.
    /// </summary>
    public class FolderCollection : BaseCollection<Folder>
    {
        public FolderCollection(Database data) : base(data)
        {
            Database.DatabaseOpened += new EventHandler<EventArgs>(this.Database_DatabaseOpened);
        }

        public Folder Create(string folderName, string folderCategory)
        {
            Folder folder = new Folder(folderName, folderCategory);
            Add(folder);
            return folder;
        }

        public Folder GetFolder(string folderName, string folderCategory)
        {
            IEnumerable<Folder> folders = from Folder f in Database.Data
                                          where (f.Category == folderCategory) && (f.Name == folderName)
                                          select f;
            return folders.FirstOrDefault();
        }
        
        public IEnumerable<Folder> GetFolders(string category)
        {
            return from Folder f in Database.Data
                   where f.Category == category
                   select f;
        }
        
        public bool Contains(string folderName, string category)
        {
            IEnumerable<Folder> folders = from Folder f in Database.Data
                                          where (f.Category == category) && (f.Name == folderName)
                                          select f;
            return folders.Count() > 0;
        }
        
        public override void ObjectRemoving(object removingObject)
        {
            ObjectClass objectClass = removingObject as ObjectClass;
            if (objectClass != null)
            {
                IEnumerable<Folder> folders = from Folder f in Database.Data
                    where (f.Classes.Contains(objectClass))
                    select f;
                
                foreach (Folder folder in folders)
                {
                    folder.RemoveClass(objectClass);
                    if (folder.Classes.Count() == 0)
                    {
                        Remove(folder);
                    }
                    else
                    {
                        Update(folder);
                    }
                }
            }
        }
        
        private void Database_DatabaseOpened(object sender, EventArgs e)
        {
            Database.Classes.FieldModified += new EventHandler<FieldModifiedEventArgs>(this.Database_Classes_FieldModified);
        }
        
        private void Database_Classes_FieldModified(object sender, FieldModifiedEventArgs e)
        {
            if (e.Action == ObjectAction.Delete)
            {
                IEnumerable<Folder> folders = from Folder f in Database.Data
                    where (f.Group == e.Field)
                    select f;
                
                foreach (Folder folder in folders)
                {
                    folder.Group = null;
                    Update(folder);
                }
            }
        }
    }
}
