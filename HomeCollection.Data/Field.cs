//-----------------------------------------------------------------------
// <copyright file="Field.cs" company="Sergey Teplyashin">
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
// <date>01.03.2011</date>
// <time>14:53</time>
// <summary>Defines the Field class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    //using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    //using System.Reflection;
    using ComponentLib.Data;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of Field.
    /// </summary>
    [Cascade]
    public class Field
    {
        #region private fields
        
        /// <summary>
        /// Шаблон которому принадлежит атрибут.
        /// </summary>
        private ObjectClass objectClass;
        
        /// <summary>
        /// Поле задает индекс атрибута в списке атрибутов шаблона.
        /// </summary>
        private int order;
        
        /// <summary>
        /// Представление атрибута (системный или пользовательский).
        /// </summary>
        private SystemProperty system;
        
        /// <summary>
        /// Наименование атрибута.
        /// </summary>
        private string name;
        
        /// <summary>
        /// Тип атрибута.
        /// </summary>
        private FieldType type;
        
        /// <summary>
        /// Описание атрибута.
        /// </summary>
        private string comment;
        
        /// <summary>
        /// Категория атрибута.
        /// </summary>
        private string category;
        
        /// <summary>
        /// <para>Дополнительные данные для описания атрибута. Эти данные различаются в зависимости от типа атрибута:</para>
        /// <para>Text      - null;</para>
        /// <para>Memo      - null;</para>
        /// <para>Select    - List(string);</para>
        /// <para>Number    - <see cref="NumberProperty"></see>;</para>
        /// <para>List      - <see cref="ListProperty"></see>;</para>
        /// <para>Boolean   - null;</para>
        /// <para>Url       - <see cref="UrlProperty"></see>;</para>
        /// <para>Date      - <see cref="DateProperty"></see>;</para>
        /// <para>Table     - List(ColumnProperty);</para>
        /// <para>Image     - null;</para>
        /// <para>Rating    - null;</para>
        /// <para>Reference - <see cref="ReferenceProperty"></see>.</para>
        /// </summary>
        [Cascade]
        private object data;
        
        /// <summary>
        /// Значение атрибута по умолчанию.
        /// </summary>
        [Cascade]
        private DefaultValue defaultValue;
        
        /// <summary>
        /// Флаг, определяющий является ли значение атрибута вычисляемым.
        /// </summary>
        private bool evaluated;
        
        /// <summary>
        /// Выражение для вычисления значения атрибута. Имеет смысл, если evaluated = true.
        /// </summary>
        private string expression;
        
        /// <summary>
        /// true, если значение атрибута может быть использовано в группировке данных.
        /// </summary>
        private bool fieldGroup;
        
        #endregion
        
        public Field(string fieldName, FieldType fieldType) : this(null, fieldName, fieldType, SystemProperty.Custom)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the ObjectClass class.
        /// </summary>
        /// <param name="obj">Шаблон, для которого создается атрибут.</param>
        /// <param name="fieldName">Наименование атрибута.</param>
        /// <param name="fieldType">Тип атрибута.</param>
        internal Field(ObjectClass obj, string fieldName, FieldType fieldType) : this(obj, fieldName, fieldType, SystemProperty.Custom)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the ObjectClass class.
        /// </summary>
        /// <param name="obj">Шаблон, для которого создается атрибут.</param>
        /// <param name="fieldName">аименование атрибута.</param>
        /// <param name="fieldType">Тип атрибута.</param>
        /// <param name="sys">Представление атрибута.</param>
        internal Field(ObjectClass obj, string fieldName, FieldType fieldType, SystemProperty sys)
        {
            this.objectClass = obj;
            this.order = -1;
            this.system = sys;
            this.name = fieldName;
            this.comment = string.Empty;
            this.defaultValue = new DefaultValue(fieldType);
            this.ChangeFieldType(fieldType);
            this.expression = string.Empty;
            this.category = this.IsPageField ? fieldName : Strings.Common;
        }
        
        #region public property
        
        /// <summary>
        /// Gets or sets th order field in template.
        /// </summary>
        /// <value>Поле задает индекс атрибута в списке атрибутов шаблона.</value>
        public int Order
        {
            get { return this.order; }
            set { this.order = value; }
        }
        
        /// <summary>
        /// Gets the view method attribute (system or custom).
        /// </summary>
        /// <value>Представление атрибута (системный или пользовательский).</value>
        public SystemProperty SystemProperty
        {
            get { return this.system; }
        }
        
        /// <summary>
        /// Gets or sets the name attribute.
        /// </summary>
        /// <value>Наименование атрибута.</value>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        
        /// <summary>
        /// Gets or sets the attribute category.
        /// </summary>
        /// <value>Категория атрибута.</value>
        public string Category
        {
            get
            {
                return this.category;
            }
            
            set
            {
                if (!this.IsPageField)
                {
                    this.category = value;
                }
            }
        }
        
        /// <summary>
        /// Gets or sets evaluated flag.
        /// </summary>
        /// <value>Флаг, определяющий является ли значение атрибута вычисляемым.</value>
        public bool Evaluated
        {
            get { return this.evaluated; }
            set { this.evaluated = value; }
        }
        
        /// <summary>
        /// Gets or sets expression string.
        /// </summary>
        /// <value>Выражение для вычисления значения атрибута. Имеет смысл, если Evaluated = true.</value>
        public string Expression
        {
            get { return this.expression; }
            set { this.expression = value; }
        }
        
        /// <summary>
        /// Gets or sets comment for attribute.
        /// </summary>
        /// <value>Описание атрибута.</value>
        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }
        
        /// <summary>
        /// Gets or sets the Group flag.
        /// </summary>
        /// <value><para>true, если значение атрибута может быть использовано в группировке данных. Данные</para>
        /// <para>имеющие тип Memo, Boolean, Table или Image нельзя группировать. Если атрибуту с одним</para>
        /// <para>из этих типов попытаться присвоить значение true, то будет вызвано исключение IncorrectFieldException.</para></value>
        public bool Group
        {
            get
            {
                return this.fieldGroup;
            }
            
            set
            {
                if (!this.CanGroup && value)
                {
                    throw new IncorrectFieldException(Strings.FieldNotGroup);
                }
                
                this.fieldGroup = value;
            }
        }
        
        /// <summary>
        /// Gets the field type.
        /// </summary>
        /// <value>
        /// Тип атрибута.
        /// </value>
        public FieldType FieldType
        {
            get { return this.type; }
        }
        
        /// <summary>
        /// Gets the addidional property for attribute.
        /// </summary>
        /// <value>true, если тип атрибута Table, Image, Memo или List</value>
        public bool IsPageField
        {
            get { return this.type == FieldType.Table || this.type == FieldType.Image || this.type == FieldType.Memo || this.type == FieldType.List; }
        }
        
        /// <summary>
        /// Gets the CanGroup flag.
        /// </summary>
        /// <value>true, если значение атрибута может использоваться в группировке данных. Это невозможно
        /// если тип поля Memo, Boolean, Table или Image.</value>
        public bool CanGroup
        {
            get { return this.type != FieldType.Memo && this.type != FieldType.Boolean && this.type != FieldType.Table && this.type != FieldType.Image; }
        }
        
        /// <summary>
        /// Gets the list method for grouping data.
        /// </summary>
        /// <value><para>Список строк описывающих методы группировки для данных. Используется для</para>
        /// <para>типов Text и Date, для остальных возвращается пустой список.</para></value>
        public IEnumerable<string> MethodGroupList
        {
            get
            {
                List<string> methods = new List<string>();
                switch (this.type)
                {
                    case FieldType.Text:
                        return Utils.MethodGroupText.TakeWhile((method, index) => index >= 0 && index <= 1);
                    case FieldType.Date:
                        return Utils.MethodGroupText.TakeWhile((method, index) => index >= 2 && index <= 4);
                }
                
                return methods;
            }
        }
        
        /// <summary>
        /// Gets the template.
        /// </summary>
        /// <value>Шаблон которому принадлежит атрибут.</value>
        public ObjectClass ObjectClass
        {
            get { return this.objectClass; }
            internal set { this.objectClass = value; }
        }
        
        /// <summary>
        /// Gets the IsDefaultProperty flag.
        /// </summary>
        /// <value>true, если атрибут имеет значение по умолчанию.</value>
        public bool IsDefaultProperty
        {
            get { return this.defaultValue.Enabled; }
        }
        
        /// <summary>
        /// Gets the default value for atrribute.
        /// </summary>
        /// <value>Значение по умолчанию для атрибута.</value>
        public DefaultValue DefaultValue
        {
            get { return this.defaultValue; }
        }
        
        /// <summary>
        /// Gets the additional data for attribute.
        /// </summary>
        /// <value>
        ///     <para>Дополнительные данные для описания атрибута. В зависимости от типа</para>
        ///     <para>атрибута data содержит разные типы объектов:</para>
        ///     <para>Text      - null;</para>
        ///     <para>Memo      - null;</para>
        ///     <para>Select    - List(string);</para>
        ///     <para>Number    - <see cref="NumberProperty"></see>;</para>
        ///     <para>List      - <see cref="ListProperty"></see>;</para>
        ///     <para>Boolean   - null;</para>
        ///     <para>Url       - <see cref="UrlProperty"></see>;</para>
        ///     <para>Date      - <see cref="DateProperty"></see>;</para>
        ///     <para>Table     - List(ColumnProperty);</para>
        ///     <para>Image     - null;</para>
        ///     <para>Rating    - null;</para>
        ///     <para>Reference - <see cref="ReferenceProperty"></see>.</para>
        /// </value>
        public object Data
        {
            get { return this.data; }
        }
        
        public DataValue DataValue
        {
            get { return new DataValue(this); }
        }
        
        #endregion
        
        #region public methods

        /// <summary>
        /// Метод определяет зависимость данного атрибута от шаблона.
        /// </summary>
        /// <param name="obj">Шаблон, для которого определяется записимость атрибута.</param>
        /// <returns>true, если имеется зависимость атрибута от шаблона.</returns>
        public bool DependenceClass(ObjectClass obj)
        {
            switch (this.type)
            {
                case FieldType.List:
                    return obj == this.DataValue.List.Reference;
                case FieldType.Reference:
                    return obj == this.DataValue.Reference.Reference;
                case FieldType.Table:
                    return this.DataValue.Table.Find(c => c.Reference == obj) != null;
            }
            
            return false;
        }
        
        public void ClearDependence(ObjectClass obj)
        {
            switch (this.type)
            {
                case FieldType.List:
                    if (ListProperty.Get(this).Reference == obj)
                    {
                        ListProperty.Get(this).Reference = null;
                    }
                    
                    break;
                case FieldType.Reference:
                    if (ReferenceProperty.Get(this).Reference == obj)
                    {
                        ReferenceProperty.Get(this).Reference = null;
                    }
                    
                    break;
                case FieldType.Table:
                    List<ColumnProperty> columns = (List<ColumnProperty>)this.data;
                    foreach (ColumnProperty column in columns.FindAll(c => c.Reference == obj))
                    {
                        column.Reference = null;
                    }
                    
                    break;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueData"></param>
        /// <returns></returns>
        public bool IsEmptyData(object valueData)
        {
            if (valueData == null)
            {
                return true;
            }
            
            if (string.IsNullOrEmpty(valueData.ToString()))
            {
                return true;
            }
            
            switch (this.type)
            {
                case FieldType.Select:
                    return (int)valueData == -1;
                case FieldType.Number:
                    return (decimal)valueData == 0;
                case FieldType.List:
                    ListData l = valueData as ListData;
                    return l == null || l.Objects.Count == 0;
                case FieldType.Boolean:
                    return !(bool)valueData;
                case FieldType.Date:
                    return (DateTime)valueData == DateTime.MinValue;
                case FieldType.Table:
                    TableData td = valueData as TableData;
                    return td == null || td.RowCount == 0;
                case FieldType.Image:
                    ImageData id = valueData as ImageData;
                    return id == null || id.CountImages == 0;
                case FieldType.Reference:
                    return valueData.GetType() == typeof(int);
            }
            
            return false;
        }
        
        /// <summary>
        /// Метод возвращает значение по умолчанию для типа данного атрибута.
        /// </summary>
        /// <returns>Значение по умолчанию для типа данного атрибута.</returns>
        public object GetStandardDefaultValue()
        {
            switch (this.type)
            {
                case FieldType.Date:
                    return DateTime.MinValue;
                case FieldType.Number:
                    return (decimal)0;
                case FieldType.Rating:
                    return (decimal)0;
                case FieldType.Select:
                    return (int)-1;
                case FieldType.Text:
                    return string.Empty;
                case FieldType.Boolean:
                    return false;
                case FieldType.Memo:
                    return string.Empty;
                case FieldType.Url:
                    return string.Empty;
                case FieldType.Image:
                    return new ImageData();
                case FieldType.List:
                    return new ListData();
                case FieldType.Table:
                    return new TableData(this);
                case FieldType.Reference:
                    return (int)0;
            }
            
            return null;
        }
        
        public List<string> GetGroupValue(object value, int method)
        {
            List<string> res = new List<string>();
            
            if (method != -1)
            {
                switch (this.type)
                {
                    case FieldType.Date:
                        DateTime dt = (DateTime)value;
                        switch (method)
                        {
                            case 0:
                                res.Add(dt.ToString("d", DateTimeFormatInfo.CurrentInfo));
                                break;
                            case 1:
                                res.Add(dt.ToString("y", DateTimeFormatInfo.CurrentInfo));
                                break;
                            case 2:
                                res.Add(dt.ToString("yyyy", DateTimeFormatInfo.CurrentInfo));
                                break;
                        }
                        
                        break;
                    case FieldType.Text:
                        string s = (string)value;
                        res.Add(method == 0 ? value.ToString() : (string.IsNullOrEmpty(s) ? string.Empty : s.Substring(0, 1)));
                        break;
                    default:
                        res.Add(value.ToString());
                        break;
                }
            }
            else
            {
                switch (this.type)
                {
                    case FieldType.Select:
                        int idx = Convert.ToInt32(value, CultureInfo.CurrentCulture);
                        List<string> sc = (List<string>)this.data;
                        if (idx != -1 && sc.Count > 0)
                        {
                            res.Add(sc[idx]);
                        }
                        
                        break;
                    case FieldType.Reference:
                        ObjectData d = value as ObjectData;
                        if (d != null)
                        {
                            res.Add(d[SystemProperty.Name].ToString());
                        }
                        
                        break;
                    case FieldType.List:
                        ListData l = (ListData)value;
                        
                        foreach (ObjectData od in l.Objects)
                        {
                            string s = od[SystemProperty.Name].ToString();
                            if (!string.IsNullOrEmpty(s))
                            {
                                res.Add(s);
                            }
                        }
                        
                        break;
                    case FieldType.Url:
                        string url = value as string;
                        if (!string.IsNullOrEmpty(url))
                        {
                            res.Add(url);
                        }
                        
                        break;
                    default:
                        res.Add(value.ToString());
                        break;
                }
            }
            
            return res;
        }
        
        public override string ToString()
        {
            return this.Name;
        }
        
        #endregion
        
        #region internal methods
        
        /// <summary>
        /// Метод меняет тип атрибута на <c>fieldType</c>.
        /// </summary>
        /// <param name="fieldType">Тип атрибута. Значение можно установить, только при условии SystemProperty = Custom.</param>
        /// <seealso cref="Data"></seealso>
        /// <seealso cref="">ChangeFieldType</seealso>
        internal void InternalChangeFieldType(FieldType fieldType)
        {
            if (this.type != fieldType && this.system == SystemProperty.Custom)
            {
                this.ChangeFieldType(fieldType);
                if (this.IsPageField)
                {
                    this.category = this.name;
                }
                
                if (!this.CanGroup && this.Group)
                {
                    this.Group = false;
                }
                
                this.evaluated = this.type == FieldType.Text;
            }
        }
        
        #endregion
        
        #region private methods
        
        /// <summary>
        /// Процедура создает дополнителные свойства для типа.
        /// </summary>
        /// <seealso cref="Data"></seealso>
        private void CreateDataProperty()
        {
            this.data = null;
            switch (this.type)
            {
                case FieldType.Url:
                    this.data = new UrlProperty();
                    break;
                case FieldType.Number:
                    this.data = new NumberProperty();
                    break;
                case FieldType.Select:
                    this.data = new List<string>();
                    break;
                case FieldType.Table:
                    this.data = new List<ColumnProperty>();
                    break;
                case FieldType.Date:
                    this.data = new DateProperty();
                    break;
                case FieldType.List:
                    this.data = new ListProperty();
                    break;
                case FieldType.Reference:
                    this.data = new ReferenceProperty();
                    break;
            }
        }
        
        /// <summary>
        /// Метод менят тип атрибута на fieldType, при этом значения data и default тоже изменяются на
        /// соответствющие новому типу.
        /// </summary>
        /// <param name="fieldType">Новый тип для данного атрибута.</param>
        private void ChangeFieldType(FieldType fieldType)
        {
            if (this.type != fieldType)
            {
                if (this.defaultValue != null)
                {
                    this.defaultValue.InitializaNewValue(fieldType);
                }
                else
                {
                    this.defaultValue = new DefaultValue(fieldType);
                }
            }
            
            this.type = fieldType;
            this.CreateDataProperty();
        }
        
        #endregion
    }
}
