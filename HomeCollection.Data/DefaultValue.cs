//-----------------------------------------------------------------------
// <copyright file="DefaultValue.cs" company="Sergey Teplyashin">
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
// <date>09.02.2011</date>
// <time>8:52</time>
// <summary>Defines the DefaultValue class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    using System.Globalization;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of DefaultValue.
    /// </summary>
    public class DefaultValue
    {
        private object defaultValue;
        
        /// <summary>
        /// <para>Initializes a new instance of the DefaultValue class.</para>
        /// <para>Класс DefaultValue предназначен для хранения значений по умолчанию для различных типов атрибутов.</para>
        /// </summary>
        /// <param name="fieldType">Тип атрибута для которого создается значение по умолчанию.</param>
        /// <seealso cref="Value"></seealso>
        /// <seealso cref="FieldType"></seealso>
        public DefaultValue(FieldType fieldType)
        {
            this.InitializaNewValue(fieldType);
        }
        
        /// <summary>
        /// Gets or sets default value attribute.
        /// </summary>
        /// <value>
        /// <para>Значение по умолчанию заданное для атрибута. Тип значения зависит от типа атрибута:</para>
        /// <para>Text      - string;</para>
        /// <para>Memo      - null (атрибут не имеет значения по умолчанию);</para>
        /// <para>Select    - int</para>
        /// <para>Number    - decimal;</para>
        /// <para>List      - null (атрибут не имеет значения по умолчанию);</para>
        /// <para>Boolean   - bool;</para>
        /// <para>Url       - null (атрибут не имеет значения по умолчанию);</para>
        /// <para>Date      - DateTime;</para>
        /// <para>Table     - null (атрибут не имеет значения по умолчанию);</para>
        /// <para>Image     - null (атрибут не имеет значения по умолчанию);</para>
        /// <para>Rating    - decimal;</para>
        /// <para>Reference - null (атрибут не имеет значения по умолчанию).</para>
        /// </value>
        public object Value
        {
            get { return this.defaultValue; }
            set { this.defaultValue = value; }
        }
        
        public bool Enabled
        {
            get { return this.defaultValue != null; }
        }
        
        public string TypeValue
        {
            get { return this.defaultValue == null ? "Null" : this.defaultValue.GetType().Name; }
        }
        
        public string AsText
        {
            get { return this.defaultValue.ToString(); }
            set { this.defaultValue = value; }
        }
        
        public decimal AsDecimal
        {
            get { return Convert.ToDecimal(this.defaultValue, CultureInfo.CurrentCulture); }
            set { this.defaultValue = value; }
        }
        
        public DateTime AsDateTime
        {
            get { return Convert.ToDateTime(this.defaultValue, CultureInfo.CurrentCulture); }
            set { this.defaultValue = value; }
        }
        
        public int AsInteger
        {
            get { return Convert.ToInt32(this.defaultValue, CultureInfo.CurrentCulture); }
            set { this.defaultValue = value; }
        }
        
        public bool AsBoolean
        {
            get { return Convert.ToBoolean(this.defaultValue, CultureInfo.CurrentCulture); }
            set { this.defaultValue = value; }
        }
        
        public void InitializaNewValue(FieldType fieldType)
        {
            this.defaultValue = GenerateValue(fieldType);
        }
        
        public static object GenerateValue(FieldType fieldType)
        {
            switch (fieldType)
            {
                case FieldType.Text:
                case FieldType.Memo:
                    return string.Empty;
                case FieldType.Select:
                    return (int)-1;
                case FieldType.Number:
                    return (decimal)0;
                case FieldType.Boolean:
                    return (bool)false;
                case FieldType.Date:
                    return DateTime.MinValue;
                case FieldType.Rating:
                    return (decimal)0;
                default:
                    return null;
            }
        }
    }
}
