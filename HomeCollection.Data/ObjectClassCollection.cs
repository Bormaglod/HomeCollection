//-----------------------------------------------------------------------
// <copyright file="ObjectClassCollection.cs" company="Sergey Teplyashin">
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
// <date>24.02.2011</date>
// <time>13:32</time>
// <summary>Defines the ObjectClassCollection class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ComponentLib.Data;
    using Db4objects.Db4o.Linq;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of ObjectClassCollection.
    /// </summary>
    public class ObjectClassCollection : BaseCollection<ObjectClass>
    {
        public ObjectClassCollection(Database data) : base(data)
        {
        }
        
        public event EventHandler<FieldModifiedEventArgs> FieldTypeModified;
        
        public event EventHandler<FieldModifiedEventArgs> FieldModified;
        
        #region public property
        
        /// <summary>
        /// Gets the enumerable list template categories.
        /// </summary>
        /// <value>Возвращает список всех категорий шаблонов.</value>
        public IEnumerable<string> ClassCategories
        {
            get
            {
                List<string> cats = new List<string>();
                
                foreach (ObjectClass obj in Collection)
                {
                    if (!cats.Contains(obj.Category))
                    {
                        cats.Add(obj.Category);
                    }
                }
                
                return cats;
            }
        }
        
        /// <summary>
        /// Gets the template by name.
        /// </summary>
        /// <param name="name">Имя шаблона.</param>
        /// <value>Возвращает шаблон по его имени.</value>
        public ObjectClass this[string name]
        {
            get
            {
                IEnumerable<ObjectClass> objs = from ObjectClass c in Database.Data
                                         where c.Name == name
                                         select c;
                return objs.FirstOrDefault();
            }
        }
        
        public ObjectClass this[Guid guid]
        {
            get
            {
                IEnumerable<ObjectClass> objs =  from ObjectClass c in Database.Data
                                         where c.Identifier == guid
                                         select c;
                return objs.FirstOrDefault();
            }
        }
        
        #endregion

        #region public methods
        
        public ObjectClass Create(string className, ObjectClass baseClass, string classCategory)
        {
            return this.Create(className, Guid.NewGuid(), baseClass, classCategory);
        }
        
        public ObjectClass Create(string className, Guid guid, ObjectClass baseClass, string classCategory)
        {
            ObjectClass objectClass = new ObjectClass(className, guid, baseClass, classCategory);
            Add(objectClass);
            return objectClass;
        }
        
        public Field AddField(ObjectClass objectClass, string fieldName, FieldType fieldType)
        {
            Field field = new Field(objectClass, fieldName, fieldType);
            this.AddField(objectClass, field);
            return field;
        }
        
        public void AddField(ObjectClass objectClass, Field field)
        {
            objectClass.AddField(field);
            Update(objectClass);
            this.OnFieldModified(field, ObjectAction.Add);
        }
        
        public void AddFields(ObjectClass objectClass, IEnumerable<Field> fields)
        {
            objectClass.AddFields(fields);
            Update(objectClass);
            foreach (Field f in fields)
            {
                this.OnFieldModified(f, ObjectAction.Add);
            }
        }
        
        public void RemoveField(Field field)
        {
            this.RemoveField(field, true);
        }
        
        public void RemoveField(ObjectClass objectClass, string fieldName)
        {
            this.RemoveField(objectClass[fieldName], true);
        }
        
        public IEnumerable<string> GetFieldCategories(ObjectClass objectClass)
        {
            List<string> cats = new List<string>();
            
            IEnumerable<Field> fields = 
                from Field prop in Database.Data
                where prop.ObjectClass.Category == objectClass.Category
                select prop;
            
            foreach (Field f in fields)
            {
                if (!cats.Contains(f.Category))
                {
                    cats.Add(f.Category);
                }
            }
            
            return cats;
        }
        
        /// <summary>
        /// Возвращает список шаблонов, имеющих категорию <c>category</c>.
        /// </summary>
        /// <param name="category">Категория шаблона.</param>
        /// <returns>Список шаблонов, имеющих категорию <c>category</c>.</returns>
        public IEnumerable<ObjectClass> GetClasses(string category)
        {
            return from ObjectClass c in Database.Data
                   where c.Category == category
                   select c;
        }
        
        /// <summary>
        /// Возвращает список шаблонов, имеющих категорию category с возможностью создания объектов.
        /// </summary>
        /// <param name="category">Категория шаблона.</param>
        /// <returns>Список шаблонов, имеющих категорию category.</returns>
        public IEnumerable<ObjectClass> GetClasses(string category, bool creating)
        {
            return from ObjectClass c in Database.Data
                   where c.Category == category && c.CreatingObjects == creating
                   select c;
        }
        
        /// <summary>
        /// Возвращает список шаблонов, основанных на baseClass.
        /// </summary>
        /// <param name="baseClass">Базовый шаблон.</param>
        /// <returns>Список шаблонов, основанных на базовом.</returns>
        public IEnumerable<ObjectClass> GetClasses(ObjectClass baseClass)
        {
            return from ObjectClass c in Database.Data
                   where c.HasBaseClass(baseClass)
                   select c;
        }
        
        /// <summary>
        /// Возвращает список классов, основанных на baseClass и имеющих категорию category.
        /// </summary>
        /// <param name="baseClass">Базовый шаблон.</param>
        /// <param name="category">Категория шаблона.</param>
        /// <returns>Список классов, основанных на базовом шаблоне и имеющих категорию category.</returns>
        public IEnumerable<ObjectClass> GetClasses(ObjectClass baseClass, string category)
        {
            return from ObjectClass c in Database.Data
                   where c.HasBaseClass(baseClass) && (c.Category == category)
                   select c;
        }
        
        public IEnumerable<ObjectClass> GetHierarchyClasses(ObjectClass baseClass, MoveDirection dir)
        {
            return from ObjectClass c in Database.Data
                   where c.HasBaseClass(baseClass, dir, true) || c == baseClass
                   select c;
        }
        
        /// <summary>
        /// Определяет, существуют ли шаблоны, имеющие в качестве базового baseClass
        /// </summary>
        /// <param name="baseClass">базовый шаблон.</param>
        /// <returns>true, если существует хотя бы один шаблон, имеющий в качестве базового baseClass,
        /// false - такого шаблона нет.</returns>
        public bool HasBaseClass(ObjectClass baseClass)
        {
            return this.GetClasses(baseClass).Count() > 0;
        }
        
        /// <summary>
        /// Метод изменяет тип атрибута и но не сохраняет атрибут на диске.
        /// Для сохранения необходимо воспользоваться методом <c>Update.</c>
        /// </summary>
        /// <param name="field">Изменяемый атрибут.</param>
        /// <param name="newType">Новый тип атрибута.</param>
        /// <seealso cref="Update"></seealso>
        public void ChangeFieldType(Field field, FieldType newType)
        {
            if (field != null && field.FieldType != newType)
            {
                if (field.Data != null)
                {
                    this.Database.Data.Delete(field.Data);
                }
                
                field.InternalChangeFieldType(newType);
                this.OnFieldTypeModified(field);
            }
        }
        
        /// <summary>
        /// Изменяет категорию шаблона.
        /// </summary>
        /// <param name="objectClass">Шаблон, категорию которого необходимо изменить.</param>
        /// <param name="category">Новая категория шаблона.</param>
        public void ModifyCategory(ObjectClass objectClass, string category)
        {
            if (Database.Opened && objectClass.Category != category)
            {
                string oldCategory = objectClass.Category;
                objectClass.Category = category;
                Update(objectClass);
                
                foreach (Folder folder in Database.Folders.Collection)
                {
                    if (folder.Category == oldCategory)
                    {
                        Folder f = Database.Folders.GetFolder(folder.Name, category);
                        if (f == null)
                        {
                            f = Database.Folders.Create(folder.Name, category);
                        }
                        
                        if (folder.Classes.Contains(objectClass))
                        {
                            folder.RemoveClass(objectClass);
                            f.AddClass(objectClass);
                            Database.Folders.Update(folder);
                            Database.Folders.Update(f);
                        }
                        
                        if (folder.Classes.Count() == 0)
                        {
                            Database.Folders.Remove(folder);
                        }
                    }
                }
            }
        }
        
        public override void Remove(ObjectClass removedElement)
        {
            IEnumerable<Field> fields = from Field field in Database.Data
                where field.DependenceClass(removedElement)
                select field;
            
            List<ObjectClass> updatedClasses = new List<ObjectClass>();
            foreach (Field field in fields)
            {
                field.ClearDependence(removedElement);
                if (!updatedClasses.Contains(field.ObjectClass))
                {
                    updatedClasses.Add(field.ObjectClass);
                }
            }
            
            foreach (ObjectClass obj in updatedClasses)
            {
                Update(obj);
            }
            
            base.Remove(removedElement);
        }
        
        #endregion
        
        #region internal methods
        
        internal void RemoveField(Field field, bool updateObjectClass)
        {
            if (field == null || field.ObjectClass == null)
            {
                return;
            }
            
            this.OnFieldModified(field, ObjectAction.Delete);
            /*foreach (IExtCollection collection in this.Database.Collections)
            {
                if (!ReferenceEquals(this, collection))
                {
                    collection.ObjectRemoving(field);
                }
            }*/
            
            field.ObjectClass.RemoveField(field);
            switch (field.FieldType)
            {
                case FieldType.Select:
                case FieldType.Number:
                case FieldType.List:
                case FieldType.Url:
                case FieldType.Date:
                case FieldType.Reference:
                    this.Database.Data.Delete(field.Data);
                    break;
                case FieldType.Table:
                    foreach (ColumnProperty col in (List<ColumnProperty>)field.Data)
                    {
                        this.Database.Data.Delete(col);
                    }
                    
                    this.Database.Data.Delete(field.Data);
                    break;
            }
            
            this.Database.Data.Delete(field.DefaultValue);
            this.Database.Data.Delete(field);
            if (updateObjectClass)
            {
                Update(field.ObjectClass);
            }
        }
        
        #endregion
        
        #region private methods
        
        private void OnFieldModified(Field field, ObjectAction action)
        {
            if (this.FieldModified != null)
            {
                this.FieldModified(this, new FieldModifiedEventArgs(field, action));
            }
        }
        
        private void OnFieldTypeModified(Field field)
        {
            if (this.FieldTypeModified != null)
            {
                this.FieldTypeModified(this, new FieldModifiedEventArgs(field, ObjectAction.Modify));
            }
        }
        
        #endregion
        
        /*/// <summary>
        /// Возвращает список шаблонов, основанных на baseClass.
        /// </summary>
        /// <param name="baseClass">Базовый шаблон.</param>
        /// <returns>Список шаблонов, основанных на базовом.</returns>
        public IEnumerable<ObjectClass> GetClasses(ObjectClass baseClass)
        {
            return from ObjectClass c in Database.Data
                   where c.HasBaseClass(baseClass)
                   select c;
        }
        
        public IEnumerable<ObjectClass> GetHierarchyClasses(ObjectClass baseClass, MoveDirection dir)
        {
            return from ObjectClass c in Database.Data
                   where c.HasBaseClass(baseClass, dir, true) || c == baseClass
                   select c;
        }*/
        
        
        
        /*/// <summary>
        /// Возвращает список шаблонов, имеющих категорию category с возможностью создания объектов.
        /// </summary>
        /// <param name="category">Категория шаблона.</param>
        /// <returns>Список шаблонов, имеющих категорию category.</returns>
        public IEnumerable<ObjectClass> GetClassesCreating(string category)
        {
            return from ObjectClass c in Database.Data
                   where c.Category == category && c.CreatingObjects
                   select c;
        }
        
        /// <summary>
        /// Возвращает список классов, основанных на baseClass и имеющих категорию category.
        /// </summary>
        /// <param name="baseClass">Базовый шаблон.</param>
        /// <param name="category">Категория шаблона.</param>
        /// <returns>Список классов, основанных на базовом шаблоне и имеющих категорию category.</returns>
        public IEnumerable<ObjectClass> GetClasses(ObjectClass baseClass, string category)
        {
            return from ObjectClass c in Database.Data
                   where c.HasBaseClass(baseClass) && (c.Category == category)
                   select c;
        }
        
        public IEnumerable<ObjectClass> GetClasses(Field field)
        {
            return from ObjectClass c in Database.Data
                   where c.Fields.Contains(field)
                   select c;
        }*/
    }
}
