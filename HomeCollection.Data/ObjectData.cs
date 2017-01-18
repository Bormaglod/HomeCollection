//-----------------------------------------------------------------------
// <copyright file="ObjectData.cs" company="Sergey Teplyashin">
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
// <date>28.02.2011</date>
// <time>9:50</time>
// <summary>Defines the ObjectData class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using ComponentLib.Core;
    using ComponentLib.Data;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of ObjectData.
    /// </summary>
    public class ObjectData : BaseObject
    {
        #region private fields
        
        /// <summary>
        /// Шаблон, на основе которого создан объект.
        /// </summary>
        private ObjectClass objectClass;
        
        /// <summary>
        /// Список значений атрибутов объекта.
        /// <para>Text      - string;</para>
        /// <para>Memo      - string;</para>
        /// <para>Select    - int;</para>
        /// <para>Number    - decimal;</para>
        /// <para>List      - <see cref="ListData"></see>;</para>
        /// <para>Boolean   - bool;</para>
        /// <para>Url       - string;</para>
        /// <para>Date      - DateTime;</para>
        /// <para>Table     - <see cref="TableData"></see>;</para>
        /// <para>Image     - <see cref="ImageData"></see>;</para>
        /// <para>Raiting   - decimal;</para>
        /// <para>Reference - <see cref="ObjectData"></see>.</para>
        /// </summary>
        [Cascade]
        private Dictionary<Field, object> data;
        
        #endregion
        
        /// <summary>
        /// Initializes a new instance of the ObjectClass class.
        /// </summary>
        /// <param name="objectClass">Шаблон, на основе которого создается объект.</param>
        public ObjectData(ObjectClass objectClass)
        {
            this.data = new Dictionary<Field, object>();
            this.objectClass = objectClass;
            this.CreateDataFields(this.objectClass);
        }
        
        #region public events
        
        public event EventHandler<ObjectDataEventArgs> ReferencedObjectData;
        
        #endregion
        
        #region public property
        
        /// <summary>
        /// Gets or sets template.
        /// </summary>
        /// <value><para>Шаблон, на основе которого создан объект.</para>
        /// <para>Установить шаблон можно только при условии ObjectClass = null.</para></value>
        public ObjectClass ObjectClass
        {
            get
            {
                return this.objectClass;
            }
            
            set
            {
                if (this.objectClass == null)
                {
                    this.objectClass = value;
                    this.CreateDataFields(this.objectClass);
                }
                else
                {
                    throw new Exception(Strings.CanNotChangeClass);
                }
            }
        }
        
        /// <summary>
        /// Gets attribute list.
        /// </summary>
        /// <value>Список атрибутов используемых в объекте и сгруппированных по категории.</value>
        public IEnumerable<IGrouping<string, Field>> GroupingFields
        {
            get
            {
                return from Field field in this.data.Keys
                       group field by field.Category;
            }
        }
        
        public IEnumerable<Field> Fields
        {
            get { return this.data.Keys.OfType<Field>(); }
        }
        
        /// <summary>
        /// Gets the value attribute.
        /// </summary>
        /// <value>
        /// Возвращает значение атрибута. Тип возвращаемого значения зависит от типа атрибута:
        /// <para>Text      - string;</para>
        /// <para>Memo      - string;</para>
        /// <para>Select    - int;</para>
        /// <para>Number    - decimal;</para>
        /// <para>List      - <see cref="ListData"></see>;</para>
        /// <para>Boolean   - bool;</para>
        /// <para>Url       - string;</para>
        /// <para>Date      - DateTime;</para>
        /// <para>Table     - <see cref="TableData"></see>;</para>
        /// <para>Image     - <see cref="ImageData"></see>;</para>
        /// <para>Raiting   - decimal;</para>
        /// <para>Reference - <see cref="ObjectData"></see>.</para>
        /// </value>
        public object this[Field field]
        {
            get { return this.data[field]; }
            set { this.data[field] = value; }
        }
        
        /// <summary>
        /// Gets the value attribute.
        /// </summary>
        /// <value>
        /// Возвращает значение атрибута по его имени. Тип возвращаемого значения зависит от типа атрибута:
        /// <para>Text      - string;</para>
        /// <para>Memo      - string;</para>
        /// <para>Select    - int;</para>
        /// <para>Number    - decimal;</para>
        /// <para>List      - <see cref="ListData"></see>;</para>
        /// <para>Boolean   - bool;</para>
        /// <para>Url       - string;</para>
        /// <para>Date      - DateTime;</para>
        /// <para>Table     - <see cref="TableData"></see>;</para>
        /// <para>Image     - <see cref="ImageData"></see>;</para>
        /// <para>Raiting   - decimal;</para>
        /// <para>Reference - <see cref="ObjectData"></see>.</para>
        /// </value>
        public object this[string fieldName]
        {
            get { return this[this.GetField(fieldName)]; }
            set { this[this.GetField(fieldName)] = value; }
        }
        
        public object this[SystemProperty prop]
        {
            get
            {
                if (prop != SystemProperty.Custom)
                {
                    return this[this.GetField(prop)];
                }
            
                return null;
            }
            
            set
            {
                if (prop != SystemProperty.Custom)
                {
                    this[this.GetField(prop)] = value;
                }
                else
                {
                    throw new FieldNotFoundException(Strings.FieldNotDefined);
                }
            }
        }
        
        #endregion
        
        #region internal property
        
        /// <summary>
        /// Список значений атрибутов объекта.
        /// </summary>
        internal Dictionary<Field, object> Values
        {
            get { return data; }
        }
        
        #endregion
        
        #region public methods
        
        public object ConvertFromString(string fieldName, string value)
        {
            return this.ConvertFromString(fieldName, value, null);
        }
        
        public object ConvertFromString(string fieldName, string value, IFormatProvider provider)
        {
            Field f = this.GetField(fieldName);
            if (!string.IsNullOrEmpty(value))
            {
                switch (f.FieldType)
                {
                    case FieldType.Text:
                        return value;
                    case FieldType.Memo:
                        return value;
                    case FieldType.Select:
                        List<string> coll = (List<string>)f.Data;
                        return coll.IndexOf(value);
                    case FieldType.Number:
                        return provider == null ? Convert.ToDecimal(value) : Convert.ToDecimal(value, provider);
                    case FieldType.List:
                        string[] ls = value.Split(new char[] { ';' });
                        ListData ld = new ListData();
                        foreach (string s in ls)
                        {
                            bool created = false;
                            ObjectData od = this.GetReferenceData(f, s, ref created);
                            if (od != null)
                            {
                                ld.Objects.Add(od);
                            }
                        }
                        
                        return ld;
                    case FieldType.Boolean:
                        return provider == null ? Convert.ToBoolean(value) : Convert.ToBoolean(value, provider);
                    case FieldType.Url:
                        return value;
                    case FieldType.Date:
                        return provider == null ? Convert.ToDateTime(value) : Convert.ToDateTime(value, provider);
                    case FieldType.Table:
                        
                        break;
                    case FieldType.Image:
                        
                        break;
                    case FieldType.Rating:
                        return provider == null ? Convert.ToDecimal(value) : Convert.ToDecimal(value, provider);
                    case FieldType.Reference:
                        if (this.ReferencedObjectData != null)
                        {
                            bool created = false;
                            return this.GetReferenceData(f, value, ref created);
                        }
                        
                        break;
                    default:
                        throw new Exception("Invalid value for FieldType");
                }
            }
            
            return f.GetStandardDefaultValue();
        }
        
        public string ConvertToString(string fieldName)
        {
            return this.ConvertToString(fieldName, null);
        }
        
        public string ConvertToString(string fieldName, IFormatProvider provider)
        {
            Field f = this.GetField(fieldName);
            switch (f.FieldType)
            {
                case FieldType.Text:
                    return this[f].ToString();
                case FieldType.Memo:
                    return this[f].ToString();
                case FieldType.Select:
                    List<string> coll = (List<string>)f.Data;
                    int idx = (int)this[f];
                    return idx == -1 ? string.Empty : coll[idx];
                case FieldType.Number:
                    decimal n = Convert.ToDecimal(this[f]);
                    return provider == null ? n.ToString() : n.ToString(provider);
                case FieldType.List:
                    return ConvertExtension.ToString(((ListData)this[fieldName]).Objects, ";");
                case FieldType.Boolean:
                    bool b = Convert.ToBoolean(this[f]);
                    return provider == null ? b.ToString() : b.ToString(provider);
                case FieldType.Url:
                    return this[f].ToString();
                case FieldType.Date:
                    DateTime d = Convert.ToDateTime(this[f]);
                    return provider == null ? d.ToString() : d.ToString(provider);
                case FieldType.Table:
                    
                    break;
                case FieldType.Image:
                    
                    break;
                case FieldType.Rating:
                    decimal r = Convert.ToDecimal(this[f]);
                    return provider == null ? r.ToString() : r.ToString(provider);
                case FieldType.Reference:
                    return this[f].ToString();
                default:
                    throw new Exception("Invalid value for FieldType");
            }
            
            return string.Empty;
        }
        
        public override string ToString()
        {
            return (string)this[SystemProperty.Name];
        }
        
        /// <summary>
        /// Метод удаляет значения атрибутов зависимых от объекта objectData.
        /// </summary>
        /// <param name="objectData">Объект, от которого зависят удаляемые значения атрбутов.</param>
        public void RemoveDependenceData(ObjectData objectData)
        {
            List<Field> flds = this.data.Keys.ToList();
            foreach (Field f in flds)
            {
                switch (f.FieldType)
                {
                    case FieldType.List:
                        ListData ld = (ListData)this.data[f];
                        if (ld.Objects.Contains(objectData))
                        {
                            ld.Objects.Remove(objectData);
                        }
                        
                        break;
                    case FieldType.Table:
                        TableData td = (TableData)this.data[f];
                        td.RemoveDependence(objectData);
                        break;
                    case FieldType.Reference:
                        if (this.data[f].GetType() != typeof(int) && (ObjectData)this.data[f] == objectData)
                        {
                            this.data[f] = (int)0;
                        }
                        
                        break;
                }
            }
        }
        
        /// <summary>
        /// Метод добавляет значение атрибута.
        /// </summary>
        /// <param name="field">Атрибут, значение которого добавляется.</param>
        public void AddField(Field field)
        {
            if (field != null)
            {
                if (field.IsDefaultProperty)
                {
                    this.data.Add(field, field.DefaultValue.Value);
                }
                else
                {
                    this.data.Add(field, field.GetStandardDefaultValue());
                }
            }
        }
        
        /// <summary>
        /// Метод возвращает true, если объект удовлетворяет соответствующим условиям.
        /// </summary>
        /// <param name="folder">Папка (может быть null).</param>
        /// <param name="filterText">Искомый текст.</param>
        /// <returns></returns>
        public bool Filter(Folder folder, string filterText)
        {
            if (folder != null)
            {
                if (!folder.Classes.Contains(this.objectClass))
                {
                    return false;
                }
            }
            
            if (folder != null && folder.Group != null)
            {
                if (string.IsNullOrEmpty(filterText))
                {
                    return true;
                }
                else
                {
                    if (this.data.Keys.Contains(folder.Group))
                    {
                        return this.CheckFilter(folder, filterText);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return true;
            }
        }
        
        /// <summary>
        /// Метод возвращает true, если объект удовлетворяет соответствующим условиям.
        /// </summary>
        /// <param name="filterValue">Фильтр, условиям которого должен удолвлетворять объект.</param>
        /// <returns>true, если объект удовлетворяет соответствующим условиям.</returns>
        public bool Filter(Filter filterValue)
        {
            bool equal = filterValue.LogicalOperation == Logical.And;
            foreach (FilterItem item in filterValue.Items)
            {
                bool e = true;
                if (item.ObjectClass != null)
                {
                    if (this.objectClass != item.ObjectClass && !this.objectClass.HasBaseClass(item.ObjectClass, MoveDirection.Up, true))
                    {
                        e = false;
                    }
                }
                
                if (e && item.Field != null)
                {
                    e = this.objectClass.FieldsBase.Contains(item.Field);
                }
                
                if (e && !string.IsNullOrEmpty(item.Filter))
                {
                    e = this.ContainsText(item.Field, item.Filter, item.Operation);
                }
                
                if (filterValue.LogicalOperation == Logical.And)
                {
                    equal = equal && e;
                }
                else
                {
                    equal = equal || e;
                }
            }
            
            return equal;
        }
        
        public ObjectData GetReferenceData(Field field, string value, ref bool created)
        {
            ObjectDataEventArgs e = new ObjectDataEventArgs(field, value, true);
            if (this.ReferencedObjectData != null)
            {
                this.ReferencedObjectData(this, e);
            }

            created = e.Created;
            return e.ObjectData;
        }
        
        #endregion
        
        #region internal methods
        
        /// <summary>
        /// Метод удаляет значение атрибута.
        /// </summary>
        /// <param name="field">Атрибут, значение которого удаляется.</param>
        internal void RemoveField(Field field)
        {
            this.data.Remove(field);
        }
        
        #endregion
        
        #region private methods
        
        private bool CheckFilter(Folder folder, string filterText)
        {
            object value = this.data[folder.Group];
            
            if (string.IsNullOrEmpty(filterText))
            {
                return true;
            }
            
            if (folder.GroupMethod != -1)
            {
                switch (folder.Group.FieldType)
                {
                    case FieldType.Date:
                        DateTime dt = (DateTime)value;
                        switch (folder.GroupMethod)
                        {
                            case 0:
                                DateTime d1 = DateTime.Parse(filterText, DateTimeFormatInfo.CurrentInfo);
                                return d1 == dt;
                            case 1:
                                DateTime d = DateTime.Parse(filterText, DateTimeFormatInfo.CurrentInfo);
                                return d.Month == dt.Month && d.Year == dt.Year;
                            case 2:
                                return int.Parse(filterText, CultureInfo.CurrentCulture) == dt.Year;
                        }
                        
                        break;
                    case FieldType.Text:
                        string text = value as string;
                        if (text == null)
                        {
                            text = string.Empty;
                        }
                        
                        if (folder.GroupMethod == 1)
                        {
                            if (text.Length == 0)
                            {
                                return false;
                            }
                            else
                            {
                                return text.Substring(0, 1) == filterText;
                            }
                        }
                        else
                        {
                            return text == filterText;
                        }
                }
            }
            else
            {
                switch (folder.Group.FieldType)
                {
                    case FieldType.Select:
                        int idx = ((List<string>)folder.Group.Data).IndexOf(filterText);
                        return idx == (int)value;
                    case FieldType.Number:
                        return decimal.Parse(filterText, CultureInfo.CurrentCulture) == (decimal)value;
                    case FieldType.Rating:
                        return decimal.Parse(filterText, CultureInfo.CurrentCulture) == (decimal)value;
                    case FieldType.Reference:
                        if (value is int)
                        {
                            return false;
                        }
                        else
                        {
                            ObjectData d = (ObjectData)value;
                            return d[SystemProperty.Name].ToString() == filterText;
                        }
                        
                    case FieldType.List:
                        ListData l = (ListData)value;
                        foreach (ObjectData od in l.Objects)
                        {
                            if (od[SystemProperty.Name].ToString() == filterText)
                            {
                                return true;
                            }
                        }
                        
                        return false;
                    case FieldType.Url:
                        return ((string)value).ToLowerInvariant() == filterText.ToLowerInvariant();
                }
            }

            return true;
        }
        
        private bool CheckFilter(Field field, FilterOperation filterOperation, string filterText)
        {
            object value = this.data[field];
            
            if (field.IsEmptyData(value))
            {
                return false;
            }
            
            if (string.IsNullOrEmpty(filterText))
            {
                return true;
            }
            
            switch (field.FieldType)
            {
                case FieldType.Date:
                    DateTime dt = (DateTime)value;
                    return Utils.CompareText(dt.ToString(), filterText, filterOperation);

                case FieldType.Text:
                    string text = value as string;
                    if (text == null)
                    {
                        text = string.Empty;
                    }
                    
                    return Utils.CompareText(text, filterText, filterOperation);
                
                case FieldType.Select:
                    int val = (int)value;
                    if (val == -1)
                    {
                        return false;
                    }
                    else
                    {
                        text = ((List<string>)field.Data)[(int)value];
                        return Utils.CompareText(text, filterText, filterOperation);
                    }
                    
                case FieldType.Reference:
                    if (value is int)
                    {
                        return false;
                    }
                    else
                    {
                        ObjectData d = (ObjectData)value;
                        return Utils.CompareText(d[SystemProperty.Name].ToString(), filterText, filterOperation);
                    }
                    
                case FieldType.List:
                    ListData l = (ListData)value;
                    foreach (ObjectData od in l.Objects)
                    {
                        if (Utils.CompareText(od[SystemProperty.Name].ToString(), filterText, filterOperation))
                        {
                            return true;
                        }
                    }
                    
                    return false;
                    
                case FieldType.Boolean:
                    text = (bool)value ? Strings.Yes : Strings.No;
                    return Utils.CompareText(text, filterText, filterOperation);
                
                case FieldType.Table:
                    TableData td = (TableData)value;
                    foreach (Row row in td.Rows)
                    {
                        foreach (Cell cell in row.Cells)
                        {
                            if (Utils.CompareText(cell.Data.ToString(), filterText, filterOperation))
                            {
                                return true;
                            }
                        }
                    }
                    
                    return false;
                    
                default:
                    return Utils.CompareText(value.ToString(), filterText, filterOperation);
            }
        }
        
        private bool ContainsText(Field field, string text, FilterOperation oper)
        {
            if (field != null)
            {
                return this.CheckFilter(field, oper, text);
            }
            else
            {
                foreach (Field f in this.data.Keys)
                {
                    if (this.CheckFilter(f, oper, text))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        /// <summary>
        /// Метод добавляет значения атрибтов шаблона obj, в т.ч. базовых.
        /// </summary>
        /// <param name="obj">Шаблон, атрибуты которого используются для добавления.</param>
        private void CreateDataFields(ObjectClass obj)
        {
            if (obj.BaseClass != null)
            {
                this.CreateDataFields(obj.BaseClass);
            }
            
            foreach (Field f in obj.Fields)
            {
                this.AddField(f);
            }
        }
        
        /// <summary>
        /// Метод возвращает атрибут используемый в объекте по его имени.
        /// </summary>
        /// <param name="fieldName">Имя атрибута.</param>
        /// <returns>Атрибут используемый в объекте по его имени.</returns>
        private Field GetField(string fieldName)
        {
            return this.data.Keys.FirstOrDefault(f => f.Name == fieldName);
        }
        
        /// <summary>
        /// Метод возвращает атрибут используемый в объекте по его представлению. Возвращается первый из найденных.
        /// </summary>
        /// <param name="prop">Представление атрибута.</param>
        /// <returns>Атрибут используемый в объекте по его представлению. Возвращается первый из найденных.</returns>
        private Field GetField(SystemProperty prop)
        {
            return this.data.Keys.FirstOrDefault(f => f.SystemProperty == prop);
        }
        
        #endregion
    }
}
