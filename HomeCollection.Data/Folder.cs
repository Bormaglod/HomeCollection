//-----------------------------------------------------------------------
// <copyright file="Folder.cs" company="Sergey Teplyashin">
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
// <time>14:57</time>
// <summary>Defines the Folder class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using ComponentLib.Data;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of Folder.
    /// </summary>
    public class Folder : BaseObject
    {
        public const Folder RootFolder = null;
        
        /// <summary>
        /// Наименование папки.
        /// </summary>
        private string name;
        
        /// <summary>
        /// Наименование категории.
        /// </summary>
        private string category;
        
        /// <summary>
        /// Список шаблонов, объекты которых могут храниться в папке.
        /// </summary>
        [Cascade(WithObjects = false)]
        private List<ObjectClass> classes;
        
        /// <summary>
        /// Атрибут шаблона определяющий группировку в папке.
        /// </summary>
        private Field group;
        
        /// <summary>
        /// Метод группировки в папке.
        /// </summary>
        private int methodGroup;
        
        /// <summary>
        /// Initializes a new instance of the ObjectClass class.
        /// </summary>
        /// <param name="folderName">Наименование папки.</param>
        /// <param name="folderCategory">Наименование категории.</param>
        public Folder(string folderName, string folderCategory)
        {
            this.classes = new List<ObjectClass>();
            this.name = folderName;
            this.category = folderCategory;
        }
        
        /// <summary>
        /// Gets or sets folder name.
        /// </summary>
        /// <value>Наименование папки.</value>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        
        /// <summary>
        /// Gets or sets folder category.
        /// </summary>
        /// <value>наименование категории папки.</value>
        public string Category
        {
            get { return this.category; }
            set { this.category = value; }
        }
        
        /// <summary>
        /// Gets or sets group method.
        /// </summary>
        /// <value>
        /// <para>Метод группировки.</para>
        /// <para>FieldType = Text</para>
        /// <para>   - GroupMethod = 0, группировка по наименованию;</para>
        /// <para>   - GroupMethod = 1, группировка по первой букве наименования;</para>
        /// <para>FieldType = Date</para>
        /// <para>   - GroupMethod = 0, группировка по дням;</para>
        /// <para>   - GroupMethod = 1, группировка по месяцам;</para>
        /// <para>   - GroupMethod = 2, группировка по годам;</para>
        /// </value>
        public int GroupMethod
        {
            get { return this.methodGroup; }
            set { this.methodGroup = value; }
        }
        
        /// <summary>
        /// Gets list template.
        /// </summary>
        /// <value>Список шаблонов, объекты которых могут храниться в папке.</value>
        public IEnumerable<ObjectClass> Classes
        {
            get { return this.classes; }
        }
        
        /// <summary>
        /// Gets or sets attribute group.
        /// </summary>
        /// <value>Атрибут шаблона определяющий группировку в папке.</value>
        public Field Group
        {
            get
            {
                return this.group;
            }
            
            set
            {
                if (value == null || this.ContainsClass(value.ObjectClass))
                {
                    this.group = value;
                }
            }
        }
        
        /// <summary>
        /// Метод добавляет шаблон, объекты которого могут храниться в папке.
        /// </summary>
        /// <param name="obj">Добавляемый шаблон.</param>
        public void AddClass(ObjectClass obj)
        {
            this.classes.Add(obj);
        }
        
        /// <summary>
        /// Метод добавляет список шаблонов, объекты которых могут храниться в папке.
        /// </summary>
        /// <param name="list">Список добавляемых шаблонов.</param>
        public void AddRangeClass(IEnumerable list)
        {
            foreach (object o in list)
            {
                this.classes.Add((ObjectClass)o);
            }
        }
        
        /// <summary>
        /// Метод удаляет шаблон, объекты которого могут храниться в папке.
        /// </summary>
        /// <param name="objectClass">Удаляемый шаблон.</param>
        public void RemoveClass(ObjectClass objectClass)
        {
            if (this.group != null && this.group.ObjectClass == objectClass)
            {
                this.group = null;
                this.methodGroup = 0;
            }
            
            this.classes.Remove(objectClass);
        }
        
        /// <summary>
        /// Метод удаляет все шаблоны, папка не будет содержать объектов.
        /// </summary>
        public void ClearClasses()
        {
            this.classes.Clear();
        }
        
        /// <summary>
        /// Метод возвращает список шаблонов присутствующих как в текущей папке, так и в папке folder.
        /// </summary>
        /// <param name="folder"></param>
        /// <returns>Список шаблонов присутствующих как в текущей папке, так и в папке folder.</returns>
        public IEnumerable<ObjectClass> Intersect(Folder folder)
        {
            return folder.Classes.Intersect(folder.Classes);
        }
        
        public override string ToString()
        {
            return this.Name;
        }
        
        internal void UpdateClasses(Database database)
        {
            database.Data.Store(this.classes);
        }
        
        internal void DeleteClasses(Database database)
        {
            database.Data.Delete(this.classes);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectClass"></param>
        /// <returns></returns>
        private bool ContainsClass(ObjectClass objectClass)
        {
            foreach (ObjectClass oc in this.classes)
            {
                if (oc == objectClass || oc.HasBaseClass(objectClass, MoveDirection.Up, true))
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}
