//-----------------------------------------------------------------------
// <copyright file="ExportConfiguration.cs" company="Sergey Teplyashin">
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
// <date>15.04.2011</date>
// <time>12:42</time>
// <summary>Defines the ExportConfiguration class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Core
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using ComponentLib.Core.Xml;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of ExportConfiguration.
    /// </summary>
    public class ExportConfiguration : TransformConfiguration
    {
        private const string name = "Export configuration";
        
        public ExportConfiguration(Database database) : base(database)
        {
        }
        
        public override void CreateXmlDocument()
        {
            base.CreateXmlDocument();
            Document.AppendChild(Document.CreateXmlDeclaration("1.0", "UTF-8", string.Empty));
            XmlElement cfg = Document.CreateElement(null, "config", new XmlAttributeElement[] {
                                                        new XmlAttributeElement("title", Database.Information.Title),
                                                        new XmlAttributeElement("author", Database.Information.Author),
                                                        new XmlAttributeElement("license", Database.Information.License),
                                                        new XmlAttributeElement("category", Database.Information.Category),
                                                        new XmlAttributeElement("email", Database.Information.Email),
                                                        new XmlAttributeElement("comment", Database.Information.Comment)
                                                    });
            CreateXmlTree(Database, Document, cfg);
        }
        
        public static void CreateXmlTree(Database database, XmlDocument doc, XmlElement root)
        {
            foreach (string category in database.Classes.ClassCategories)
            {
                XmlElement cat = doc.CreateElement(root, "category", "name", category);
                ExportClasses(database, doc, cat, category);
            }
        }
        
        protected override string GetName()
        {
            return name;
        }
        
        protected override bool Execute()
        {
            this.CreateXmlDocument();
            Save(FileName);
            return true;
        }
        
        private static void ExportClasses(Database database, XmlDocument doc, XmlElement xmlCategory, string category)
        {
            foreach (ObjectClass oc in database.Classes.GetClasses(category))
            {
                XmlElement c = doc.CreateElement(xmlCategory, "class", new XmlAttributeElement[] {
                                                      new XmlAttributeElement("name", oc.Name),
                                                      new XmlAttributeElement("guid", oc.Identifier.ToString()),
                                                      new XmlAttributeElement("creating", oc.CreatingObjects.ToString())
                                                  });
                Field fieldName = oc[SystemProperty.Name];
                if (fieldName != null && fieldName.Group)
                {
                    doc.AddAttribute(c, new XmlAttributeElement("groupname", true.ToString()));
                }
                
                if (oc.BaseClass != null)
                {
                    doc.AddAttribute(c, new XmlAttributeElement("base_guid", oc.BaseClass.Identifier.ToString()));
                }
                
                ExportFields(doc, c, oc);
                if (!string.IsNullOrEmpty(oc.Form))
                {
                    XmlElement e_form = doc.CreateElement(c, "forms");
                    e_form.InnerXml = oc.Form;
                }
            }
        }
        
        private static void ExportFields(XmlDocument doc, XmlElement xmlClass, ObjectClass objectClass)
        {
            foreach (Field field in objectClass.Fields)
            {
                if (field.SystemProperty != SystemProperty.Custom)
                {
                    if (field.Evaluated)
                    {
                        doc.CreateElement(xmlClass, "fieldname", "expression", field.Expression);
                    }
                    
                    continue;
                }
                
                XmlElement f = doc.CreateElement(xmlClass, "field", new XmlAttributeElement[] {
                                                      new XmlAttributeElement("name", field.Name),
                                                      new XmlAttributeElement("type", Utils.Parse(field.FieldType)),
                                                      new XmlAttributeElement("category", field.Category),
                                                      new XmlAttributeElement("comment", field.Comment, string.Empty),
                                                      new XmlAttributeElement("order", field.Order.ToString())
                                                  });
                if (field.Group)
                {
                    doc.AddAttribute(f, new XmlAttributeElement("group", true.ToString()));
                }
                
                if (field.Evaluated)
                {
                    doc.AddAttribute(f, new XmlAttributeElement("expression", field.Expression));
                }
                
                ExportField(doc, f, field);
            }
        }
        
        private static void ExportField(XmlDocument doc, XmlElement f, Field field)
        {
            switch (field.FieldType)
            {
                case FieldType.Url:
                    UrlProperty uprop = (UrlProperty)field.Data;
                    switch (uprop.Type)
                    {
                        case UrlType.File:
                            doc.AddAttribute(f, new XmlAttributeElement("method", "file"));
                            break;
                        case UrlType.Folder:
                            doc.AddAttribute(f, new XmlAttributeElement("method", "folder"));
                            break;
                        case UrlType.Url:
                            doc.AddAttribute(f, new XmlAttributeElement("method", "url"));
                            break;
                    }
                    
                    break;
                case FieldType.Text:
                    if (field.DefaultValue.Enabled)
                    {
                        doc.AddAttribute(f, new XmlAttributeElement("default", field.DefaultValue.AsText, string.Empty));
                    }
                    
                    break;
                case FieldType.Select:
                    List<string> sc = (List<string>)field.Data;
                    string selectValues = string.Empty;
                    foreach (string s in sc)
                    {
                        if (selectValues.Length != 0)
                        {
                            selectValues += ";";
                        }
                        
                        selectValues += s;
                    }
                    
                    doc.AddAttribute(f, new XmlAttributeElement("values", selectValues));
                    if (field.DefaultValue.Enabled)
                    {
                        doc.AddAttribute(f, new XmlAttributeElement("default", field.DefaultValue.Value.ToString(), (-1).ToString()));
                    }
                    
                    break;
                case FieldType.Number:
                    if (field.DefaultValue.Enabled)
                    {
                        doc.AddAttribute(f, new XmlAttributeElement("default", field.DefaultValue.Value.ToString(), (0).ToString()));
                    }
                    
                    NumberProperty prop = field.Data as NumberProperty;
                    if (prop != null)
                    {
                        doc.AddAttributes(f, new XmlAttributeElement[] {
                                               new XmlAttributeElement("decimal", prop.DecimalPlaces.ToString(), (0).ToString()),
                                               new XmlAttributeElement("increment", prop.Increment.ToString(), (1).ToString()),
                                               new XmlAttributeElement("thousands", prop.Thousands.ToString(), false.ToString()),
                                               new XmlAttributeElement("prefix", prop.Prefix, string.Empty),
                                               new XmlAttributeElement("suffix", prop.Suffix, string.Empty)
                                           });
                        if (prop.Bounds)
                        {
                            doc.AddAttributes(f, new XmlAttributeElement[] {
                                               new XmlAttributeElement("maximum", prop.Maximum.ToString()),
                                               new XmlAttributeElement("minimum", prop.Minimum.ToString())
                                           });
                        }
                    }
                    
                    break;
                case FieldType.List:
                    ListProperty listRef = field.Data as ListProperty;
                    if (listRef != null)
                    {
                        doc.AddAttribute(f, new XmlAttributeElement("ref_guid", listRef.Reference.Identifier.ToString()));
                    }
                    
                    break;
                case FieldType.Boolean:
                    if (field.DefaultValue.Enabled)
                    {
                        doc.AddAttribute(f, new XmlAttributeElement("default", field.DefaultValue.Value.ToString()));
                    }
                    
                    break;
                case FieldType.Date:
                    if (field.DefaultValue.Enabled)
                    {
                        doc.AddAttribute(f, new XmlAttributeElement("default", field.DefaultValue.Value.ToString(), DateTime.MinValue.ToString()));
                        DateProperty dprop = field.Data as DateProperty;
                        if (dprop != null)
                        {
                            doc.AddAttribute(f, new XmlAttributeElement("time", dprop.ViewTime.ToString(), false.ToString()));
                        }
                    }
                    
                    break;
                case FieldType.Rating:
                    if (field.DefaultValue.Enabled)
                    {
                        doc.AddAttribute(f, new XmlAttributeElement("default", field.DefaultValue.Value.ToString(), (0).ToString()));
                    }
                    
                    break;
                case FieldType.Reference:
                    ReferenceProperty reference = field.Data as ReferenceProperty;
                    if (reference != null)
                    {
                        doc.AddAttribute(f, new XmlAttributeElement("ref_guid", reference.Reference.Identifier.ToString()));
                    }
                    
                    break;
                case FieldType.Table:
                    List<ColumnProperty> list = (List<ColumnProperty>)field.Data;
                    foreach (ColumnProperty cp in list)
                    {
                        XmlElement c = doc.CreateElement(f, "column", "name", cp.Name);
                        if (cp.Reference != null)
                        {
                            doc.AddAttribute(c, new XmlAttributeElement("ref_guid", cp.Reference.Identifier.ToString()));
                        }
                    }
                    
                    break;
            }
        }
    }
}
