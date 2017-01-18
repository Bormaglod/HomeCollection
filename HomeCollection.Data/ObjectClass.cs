//-----------------------------------------------------------------------
// <copyright file="ObjectClass.cs" company="Sergey Teplyashin">
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
// <time>13:22</time>
// <summary>Defines the ObjectClass class.</summary>
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
    /// Description of ObjectClass.
    /// </summary>
    public class ObjectClass : BaseObject
    {
        public const ObjectClass Root = null;
        
        #region private fields
        
        /// <summary>
        /// Уникальный идентификатор шаблона.
        /// </summary>
        private Guid guid;
        
        /// <summary>
        /// Базовый шаблон или null, если текущий шаблон корневой.
        /// </summary>
        private ObjectClass baseClass;
        
        /// <summary>
        /// Наименование шаблона.
        /// </summary>
        private string name;
        
        /// <summary>
        /// Категория к которой принадлежит шаблон.
        /// </summary>
        private string category;
        
        /// <summary>
        /// Список атрибутов (полей) шаблона.
        /// </summary>
        [Cascade]
        private List<Field> fields;
        
        /// <summary>
        /// Флаг, определяющий возможность создавать объекты на основе этого шаблона.
        /// </summary>
        private bool creatingObjects;
        
        /// <summary>
        /// Текст в формате XML, описывающей форму для редактирования объектов, созданных 
        /// на основе данного шаблона.
        /// </summary>
        private string form;
        
        #endregion
        
        /// <summary>
        /// Initializes a new instance of the ObjectClass class.
        /// </summary>
        /// <param name="className">Наименование шаблона.</param>
        /// <param name="guid">Уникальный идентификатор шаблона.</param>
        /// <param name="baseClass">Базовый шаблон.</param>
        /// <param name="classCategory">Наименование категории шаблона.</param>
        public ObjectClass(string className, Guid guid, ObjectClass baseClass, string classCategory)
        {
            this.guid = guid;
            this.name = className;
            this.baseClass = baseClass;
            this.category = classCategory;
            this.fields = new List<Field>();
            this.creatingObjects = true;
            this.form = string.Empty;
            if (this.baseClass == null)
            {
                this.AddField(new Field(this, Strings.Name, FieldType.Text, SystemProperty.Name));
            }
        }
        
        #region public property
        
        /// <summary>
        /// Gets the base template.
        /// </summary>
        /// <value>Базовый шаблон для текущего.</value>
        public ObjectClass BaseClass
        {
            get { return this.baseClass; }
        }
        
        /// <summary>
        /// Gets or sets the name template.
        /// </summary>
        /// <value>Наименование шаблона.</value>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        
        /// <summary>
        /// Gets or sets the categrory template.
        /// </summary>
        /// <value>Категория к которой принадлежит шаблон.</value>
        public string Category
        {
            get { return this.category; }
            set { this.category = value; }
        }
        
        /// <summary>
        /// Gets the unique identifer template.
        /// </summary>
        /// <value>Уникальный идентификатор шаблона.</value>
        public Guid Identifier
        {
            get { return this.guid; }
        }
        
        /// <summary>
        /// Gets or sets the flag creating objects.
        /// </summary>
        /// <value>Флаг, определяющий возможность создавать объекты на основе этого шаблона.</value>
        public bool CreatingObjects
        {
            get { return this.creatingObjects; }
            set { this.creatingObjects = value; }
        }
        
        /// <summary>
        /// Gets the enumerable list attributes without base template attributes.
        /// </summary>
        /// <value>Список атрибутов принадлежащих данному шаблону, без учета атрибутов базового шаблона.</value>
        public IEnumerable<Field> Fields
        {
            get
            {
                return from Field field in this.fields
                       orderby field.Order
                       select field;
            }
        }
        
        /// <summary>
        /// Gets the enumerable list attributes with base template attributes.
        /// </summary>
        /// <value>Список атрибутов принадлежащих данному шаблону, с учета атрибутов базового шаблона.</value>
        public IEnumerable<Field> FieldsBase
        {
            get
            {
                List<Field> f = new List<Field>();
                f.AddRange(this.Fields);
                if (this.baseClass != null)
                {
                    f.AddRange(this.baseClass.FieldsBase);
                }
                
                return f;
            }
        }
        
        /// <summary>
        /// Gets the list attributes grouping by category.
        /// </summary>
        /// <value>Список атрибутов шаблона (с учетом атрибутов базового шаблона), сгруппированные по категориям.</value>
        public IEnumerable<IGrouping<string, Field>> FieldsCategory
        {
            get
            {
                return from field in this.FieldsBase
                       orderby field.Order
                       group field by field.Category;
            }
        }
        
        /// <summary>
        /// Gets or sets XML text described form object.
        /// </summary>
        /// <value>Текст в формате XML, описывающей форму для редактирования объектов, созданных 
        /// на основе данного шаблона.</value>
        public string Form
        {
            get { return this.form; }
            set { this.form = value; }
        }
        
        public Field this[int index]
        {
            get { return this.fields[index]; }
        }
        
        public Field this[string fieldName]
        {
            get { return this.FindField(fieldName, false); }
        }
        
        public Field this[SystemProperty sys]
        {
            get { return this.fields.FirstOrDefault(f => f.SystemProperty == sys); }
        }
        
        #endregion
        
        #region public methods
        
        /// <summary>
        /// Метод ищет атрибут в шаблоне по его имени и возвращает его, если он существует или null, если атрибут
        /// в шаблоне отсутствует.
        /// </summary>
        /// <param name="fieldName">Имя искомого атрибута.</param>
        /// <param name="withBase">true, если поиск надо осуществлять с учетом базового шаблона.</param>
        /// <returns>Атрибут шаблона или null, если атрибут в шаблоне отсутствует.</returns>
        public Field FindField(string fieldName, bool withBase)
        {
            IEnumerable<Field> list = withBase ? this.FieldsBase : this.Fields;
            foreach (Field f in list)
            {
                if (f.Name == fieldName)
                {
                    return f;
                }
            }
            
            return null;
        }
        
        /// <summary>
        /// Метод изменяет порядок атрибутов в шаблоне путем передвижения на одну позицию в одну или в другую
        /// сторону.
        /// </summary>
        /// <param name="field">Изменяемый атрибут.</param>
        /// <param name="dir">Направление изменения позиции атрибута. Если dir > 0, номер позиции атрибута
        /// увеличивается на 1, в других случаях на -1. Контроля границ не предусмотрено.</param>
        public void MoveField(Field field, int dir)
        {
            int d = dir > 0 ? 1 : -1;
            if (this.fields.Contains(field))
            {
                int new_val = field.Order + d;
                
                foreach (Field f in this.fields)
                {
                    if (f.Order == new_val)
                    {
                        f.Order -= d;
                        field.Order += d;
                        break;
                    }
                }
            }
        }
        
        /// <summary>
        /// Метод возвращает список атрибутов (в т.ч. и из базовых шаблонов), которые зависят
        /// от шаблона obj.
        /// </summary>
        /// <param name="obj">Шаблон, для которого создается список зависимых атрибутов.</param>
        /// <returns>Список атрибутов (в т.ч. и из базовых шаблонов), которые зависят
        /// от шаблона obj.</returns>
        public IEnumerable<Field> DependenceFields(ObjectClass obj)
        {
            List<Field> fieldList = new List<Field>();
            this.CreateDependenceFields(obj, fieldList);
            return fieldList;
        }
        
        /// <summary>
        /// Метод возвращает true, если базовый шаблон соответствует baseClass.
        /// </summary>
        /// <param name="baseClass"></param>
        /// <returns>true, если базовый шаблон соответствует baseClass.</returns>
        public bool HasBaseClass(ObjectClass baseClass)
        {
            return this.baseClass == baseClass;
        }
        
        public bool HasBaseClass(ObjectClass baseClass, MoveDirection dir, bool hierarchy)
        {
            if (hierarchy)
            {
                if (dir == MoveDirection.Up)
                {
                    ObjectClass o = this;
                    while (o.baseClass != baseClass && o.baseClass != null)
                    {
                        o = o.baseClass;
                    }
                    
                    return o.baseClass == baseClass;
                }
                else
                {
                    ObjectClass o = baseClass;
                    while (o != this && o != null)
                    {
                        o = o.baseClass;
                    }
                    
                    return o == this;
                }
            }
            else
            {
                return this.HasBaseClass(baseClass);
            }
        }
        
        public override string ToString()
        {
            return this.Name;
        }
        
        #endregion
        
        #region internal methods
        
        internal void AddField(Field field)
        {
            field.Order = this.fields.Count + (this.baseClass != null ? this.baseClass.FieldsBase.Count() : 0);
            field.ObjectClass = this;
            this.fields.Add(field);
        }
        
        internal void AddFields(IEnumerable<Field> fields)
        {
            int order = this.fields.Count + (this.baseClass != null ? this.baseClass.FieldsBase.Count() : 0);
            foreach (Field field in fields)
            {
                field.Order = order++;
                field.ObjectClass = this;
                this.fields.Add(field);
            }
        }
        
        /// <summary>
        /// Метод удаляет атрибут из шаблона.
        /// </summary>
        /// <param name="field">Удаляемый атрибут.</param>
        internal void RemoveField(Field field)
        {
            this.fields.Remove(field);
        }
        
        #endregion
        
        #region private methods
            
        /// <summary>
        /// Метод создает список атрибутов (в т.ч. от базовых) зависимых от шаблона obj.
        /// </summary>
        /// <param name="obj">Шаблон для которого ищутся зависимости.</param>
        /// <param name="list">Список, в который добавляются зависимые от obj атрибуты.</param>
        private void CreateDependenceFields(ObjectClass obj, List<Field> list)
        {
            foreach (Field field in this.fields)
            {
                if (field.DependenceClass(obj))
                {
                    list.Add(field);
                }
            }
            
            if (this.baseClass != null)
            {
                this.baseClass.CreateDependenceFields(obj, list);
            }
        }
        
        #endregion
    }
}
