//-----------------------------------------------------------------------
// <copyright file="ObjectClassProxy.cs" company="Sergey Teplyashin">
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
// <time>9:32</time>
// <summary>Defines the ObjectClassProxy class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Properties
{
    #region Using directives
    
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing.Design;
    using System.Linq;
    using System.Windows.Forms;
    using HomeCollection.Data;
    
    #endregion
    
    /// <summary>
    /// Description of ObjectClassProxy.
    /// </summary>
    public class ObjectClassProxy
    {
        private ObjectClass objectClass;
        private Database database;
        
        public ObjectClassProxy(ObjectClass obj, Database data)
        {
            this.objectClass = obj;
            this.database = data;
        }
        
        public event EventHandler<EventArgs> ClassNameModified;
        
        public event EventHandler<EventArgs> ClassCategoryModified;
        
        public event EventHandler<EventArgs> ClassCreatingModified;
        
        [Browsable(false)]
        public ObjectClass ObjectClass
        {
            get { return this.objectClass; }
        }
        
        [Browsable(false)]
        public Database Database
        {
            get { return this.database; }
        }
        
        [LocalizedDisplayName("Name")]
        public string Name
        {
            get
            {
                return this.objectClass.Name;
            }
            
            set
            {
                this.objectClass.Name = value;
                this.database.Classes.Update(this.objectClass);
                this.OnClassNameModified();
            }
        }
        
        [LocalizedDisplayName("Category")]
        [TypeConverter(typeof(CategoryClassConverter))]
        public string Category
        {
            get
            {
                return this.objectClass.Category;
            }
            
            set
            {
                if (this.objectClass.Category != value)
                {
                    this.database.Classes.ModifyCategory(this.objectClass, value);
                    this.OnClassCategoryModified();
                }
            }
        }
        
        [LocalizedDisplayName("CreatingObjects")]
        [TypeConverter(typeof(BooleanDefaultConverter))]
        public bool CreatingObjects
        {
            get
            {
                return this.objectClass.CreatingObjects;
            }
            
            set
            {
                this.objectClass.CreatingObjects = value;
                this.database.Classes.Update(this.objectClass);
                this.OnClassCreatingModified();
            }
        }
        
        
        [LocalizedDisplayName("Form")]
        [Editor(typeof(UserFormEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(UserFormConverter))]
        public string Form
        {
            get
            {
                return this.objectClass.Form;
            }
            
            set
            {
                this.objectClass.Form = value;
                this.database.Classes.Update(this.objectClass);
            }
        }
        
        private void OnClassNameModified()
        {
            if (this.ClassNameModified != null)
            {
                this.ClassNameModified(this.objectClass, new EventArgs());
            }
        }
        
        private void OnClassCategoryModified()
        {
            if (this.ClassCategoryModified != null)
            {
                this.ClassCategoryModified(this.objectClass, new EventArgs());
            }
        }
        
        private void OnClassCreatingModified()
        {
            if (this.ClassCreatingModified != null)
            {
                this.ClassCreatingModified(this.objectClass, new EventArgs());
            }
        }
        
        internal class CategoryClassConverter : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                if (sourceType == typeof(string))
                {
                    return true;
                }
                
                return base.CanConvertFrom(context, sourceType);
            }
            
            public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
            {
                string s = value as string;
                if (s != null)
                {
                    return s;
                }
                
                return base.ConvertFrom(context, culture, value);
            }
            
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }
            
            public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                Database data = ((ObjectClassProxy)context.Instance).Database;
                TypeConverter.StandardValuesCollection svc = new TypeConverter.StandardValuesCollection(data.Classes.ClassCategories.ToList());
                return svc;
            }
        }
    }
}
