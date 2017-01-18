//-----------------------------------------------------------------------
// <copyright file="FieldProxy.cs" company="Sergey Teplyashin">
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
// <date>04.02.2011</date>
// <time>9:37</time>
// <summary>Defines the FieldProxy class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Properties
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of FieldProxy.
    /// </summary>
    public class FieldProxy
    {
        private ObjectClass objectClass;
        private Field fieldProperty;
        private Database database;
        private AbstractField fieldType;
            
        public FieldProxy(ObjectClass obj, Field prop, Database data)
        {
            this.objectClass = obj;
            this.fieldProperty = prop;
            this.database = data;
            
            this.CreateFieldType();
            this.UpdateReadOnlyAttributes();
        }
        
        public event EventHandler<EventArgs> FieldNameModified;
        
        public event EventHandler<EventArgs> FieldTypeModified;
        
        public event EventHandler<EventArgs> FieldGroupModified;
        
        public event EventHandler<EventArgs> FieldModified;
        
        [Browsable(false)]
        public Field Property
        {
            get { return this.fieldProperty; }
        }
        
        [Browsable(false)]
        public Database Database
        {
            get { return this.database; }
        }
        
        [Browsable(false)]
        public ObjectClass ObjectClass
        {
            get { return this.objectClass; }
        }
        
        [LocalizedDisplayName("Name")]
        [LocalizedCategory("General")]
        public string Name
        {
            get
            {
                return this.fieldProperty.Name;
            }
            
            set
            {
                this.fieldProperty.Name = value;
                Database.Classes.Update(this.objectClass);
                this.OnFieldNameModified();
            }
        }
        
        [LocalizedCategory("View")]
        [LocalizedDisplayName("Evaluated")]
        [RefreshProperties(RefreshProperties.All)]
        [ReadOnly(true)]
        public bool Evaluated
        {
            get
            {
                return this.fieldProperty.Evaluated;
            }
            
            set
            {
                this.fieldProperty.Evaluated = value;
                Database.Classes.Update(this.objectClass);
                this.UpdateReadOnlyAttributes();
            }
        }
        
        [LocalizedCategory("View")]
        [LocalizedDisplayName("Expression")]
        [ReadOnly(true)]
        public string Expression
        {
            get
            {
                return this.fieldProperty.Expression;
            }
            
            set
            {
                this.fieldProperty.Expression = value;
                Database.Classes.Update(this.objectClass);
            }
        }
        
        [LocalizedDisplayName("Group")]
        [LocalizedCategory("General")]
        [TypeConverter(typeof(BooleanDefaultConverter))]
        [ReadOnly(true)]
        [DefaultValue(false)]
        public bool Group
        {
            get
            {
                return this.fieldProperty.Group;
            }
            
            set
            {
                try
                {
                    this.fieldProperty.Group = value;
                    Database.Classes.Update(this.objectClass);
                    this.OnFieldGroupModified();
                }
                catch (Exception e)
                {
                    KryptonMessageBox.Show(e.Message, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        [LocalizedDisplayName("Description")]
        [LocalizedCategory("General")]
        public string Comment
        {
            get
            {
                return this.fieldProperty.Comment;
            }
            
            set
            {
                this.fieldProperty.Comment = value;
                Database.Classes.Update(this.objectClass);
            }
        }
        
        [LocalizedDisplayName("Category")]
        [LocalizedCategory("General")]
        [TypeConverter(typeof(FieldCategoryConverter))]
        [ReadOnly(true)]
        public string Category
        {
            get
            {
                return this.fieldProperty.Category;
            }
            
            set
            {
                this.fieldProperty.Category = value;
                Database.Classes.Update(this.objectClass);
            }
        }
        
        [LocalizedDisplayName("Type")]
        [LocalizedCategory("General")]
        [TypeConverter(typeof(FieldPropertyConverter))]
        [RefreshProperties(RefreshProperties.All)]
        [ReadOnly(false)]
        public AbstractField FieldDataType
        {
            get
            {
                if (this.fieldType.GetFieldType() != this.fieldProperty.FieldType)
                {
                    this.CreateFieldType();
                }
                
                return this.fieldType;
            }
            
            set
            {
                if (this.fieldProperty.FieldType != value.GetFieldType())
                {
                    this.fieldType = value;
                    this.fieldType.FieldModified += new EventHandler<EventArgs>(this.FieldDataProxy_FieldModified);
                    this.database.Classes.ChangeFieldType(this.fieldProperty, value.GetFieldType());
                    this.OnFieldTypeModified();
                    this.UpdateReadOnlyAttributes();
                }
            }
        }
        
        private void FieldDataProxy_FieldModified(object sender, EventArgs e)
        {
            this.OnFieldModified();
        }
        
        private void UpdateReadOnlyAttributes()
        {
            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this.GetType())["Category"];
            ReadOnlyAttribute attribute = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
            FieldInfo fieldToChange = attribute.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldToChange.SetValue(attribute, this.Property.IsPageField);
            
            descriptor = TypeDescriptor.GetProperties(this.GetType())["Group"];
            attribute = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
            fieldToChange = attribute.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldToChange.SetValue(attribute, !this.Property.CanGroup);
            
            descriptor = TypeDescriptor.GetProperties(this.GetType())["Evaluated"];
            attribute = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
            fieldToChange = attribute.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldToChange.SetValue(attribute, this.Property.FieldType != FieldType.Text);
            
            descriptor = TypeDescriptor.GetProperties(this.GetType())["Expression"];
            attribute = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
            fieldToChange = attribute.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldToChange.SetValue(attribute, !this.Property.Evaluated);
        }
        
        private void CreateFieldType()
        {
            switch (this.fieldProperty.FieldType)
            {
                case FieldType.Text:
                    this.fieldType = new FieldText(this);
                    break;
                case FieldType.Number:
                    this.fieldType = new FieldDecimal(this);
                    break;
                case FieldType.Date:
                    this.fieldType = new FieldDate(this);
                    break;
                case FieldType.Image:
                    this.fieldType = new FieldImage(this);
                    break;
                case FieldType.Url:
                    this.fieldType = new FieldUrl(this);
                    break;
                case FieldType.Select:
                    this.fieldType = new FieldSelect(this);
                    break;
                case FieldType.Boolean:
                    this.fieldType = new FieldBool(this);
                    break;
                case FieldType.Table:
                    this.fieldType = new FieldTable(this);
                    break;
                case FieldType.Rating:
                    this.fieldType = new FieldRaiting(this);
                    break;
                case FieldType.Reference:
                    this.fieldType = new FieldReference(this);
                    break;
                case FieldType.List:
                    this.fieldType = new FieldList(this);
                    break;
                case FieldType.Memo:
                    this.fieldType = new FieldMemo(this);
                    break;
            }
            
            this.fieldType.FieldModified += new EventHandler<EventArgs>(this.FieldDataProxy_FieldModified);
        }
        
        private void OnFieldNameModified()
        {
            if (this.FieldNameModified != null)
            {
                this.FieldNameModified(this.fieldProperty, new EventArgs());
            }
        }
        
        private void OnFieldTypeModified()
        {
            if (this.FieldTypeModified != null)
            {
                this.FieldTypeModified(this.fieldProperty, new EventArgs());
            }
        }
        
        private void OnFieldGroupModified()
        {
            if (this.FieldGroupModified != null)
            {
                this.FieldGroupModified(this.fieldProperty, new EventArgs());
            }
        }
        
        private void OnFieldModified()
        {
            if (this.FieldModified != null)
            {
                this.FieldModified(this.fieldProperty, new EventArgs());
            }
        }
        
        // FIXME: При двойном клике на свойстве, выскакивает ошибка о невозможности преобразования строки в целое
        /*internal class FieldMethodGroupConverter : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                if (sourceType == typeof(string))
                {
                    return true;
                }
                
                return base.CanConvertFrom(context, sourceType);
            }
            
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
            {
                if (destinationType == typeof(string))
                {
                    return true;
                }
                
                return base.CanConvertTo(context, destinationType);
            }
            
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }
            
            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            {
                return true;
            }
            
            public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
            {
                if (value.GetType() == typeof(string))
                {
                    FieldDataProxy proxy = (FieldDataProxy)context.Instance;
                    string svalue = value as string;
                    return proxy.fieldProperty.ParseMethodGroup(svalue);
                }
                
                return base.ConvertFrom(context, culture, value);
            }
            
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(string))
                {
                    if (value != null)
                    {
                        if (value is int)
                        {
                            FieldDataProxy proxy = (FieldDataProxy)context.Instance;
                            string res = proxy.fieldProperty.ParseMethodGroup(Convert.ToInt32(value));
                            return res;
                        }
                        else
                        {
                            return value;
                        }
                    }
                }
                
                return base.ConvertTo(context, culture, value, destinationType);
            }
            
            public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                FieldDataProxy proxy = (FieldDataProxy)context.Instance;
                IEnumerable<string> c = proxy.fieldProperty.MethodGroupList;
                return new TypeConverter.StandardValuesCollection(c.ToArray());
            }
        }*/
    }
}
