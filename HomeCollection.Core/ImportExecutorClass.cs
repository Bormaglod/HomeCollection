//-----------------------------------------------------------------------
// <copyright file="ImportExecutorClass.cs" company="Sergey Teplyashin">
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
// <date>16.05.2011</date>
// <time>9:12</time>
// <summary>Defines the ImportExecutorClass class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Core
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Timers;
    using System.Xml;
    using ComponentLib.Core.Xml;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of ImportClasses.
    /// </summary>
    public class ImportExecutorClass : ImportExecutor
    {
        private List<ImportObjectClass> classes;
        
        public ImportExecutorClass(Database database, XmlDocument doc, string xmlPath) : base(database, doc, xmlPath)
        {
            this.classes = new List<ImportObjectClass>();
            this.LoadClasses();
        }
        
        public IEnumerable<ImportObjectClass> Items
        {
            get { return this.classes; }
        }
        
        public ImportObjectClass this[Guid guid]
        {
            get { return this.classes.Find(c => c.Identifier == guid); }
        }
        
        public ImportObjectClass this[string classOriginalName]
        {
            get { return this.classes.Find(c => c.OriginalName == classOriginalName); }
        }
        
        public void ExecuteImport()
        {
            XmlNodeList listNodes = Document.SelectNodes(XmlPath + "/category/class");
            ShowProgress(Strings.ImportConfiguration, Strings.Import);
            try
            {
                Start(this.classes.Count + listNodes.Count);
                foreach (ImportObjectClass ic in this.classes)
                {
                    NextMessage(string.Format(Strings.ImportTemplate, ic.Name));
                    this.ImportClass(ic);
                    Wait();
                }
                
                this.ImportFields(listNodes);
            }
            finally
            {
                StopProgress();
            }
        }
        
        public int CountClassesByName(string name, bool original)
        {
            return this.classes.Count(c => (original ? c.OriginalName : c.Name) == name);
        }
        
        public int CountClassesById(Guid id)
        {
            return this.classes.Count(c => c.Identifier == id);
        }
        
        public int CountErrors(ErrorClasses err)
        {
            return this.classes.Count(c => c.Error == err);
        }
        
        private void ImportClass(ImportObjectClass ic)
        {
            ObjectClass oc = Database.Classes[ic.Identifier];
            if (oc == null)
            {
                ObjectClass baseClass = null;
                ImportObjectClass ic_base = ic.BaseGuid == Guid.Empty ? this[ic.BaseName] : this[ic.BaseGuid];
                if (ic_base == null)
                {
                    baseClass = ic.BaseGuid == Guid.Empty ? Database.Classes[ic.BaseName] : Database.Classes[ic.BaseGuid];
                }
                else
                {
                    if (ic.HasBaseClass())
                    {
                        this.ImportClass(ic_base);
                    }
                    
                    baseClass = ic.HasBaseClass() ? Database.Classes[ic_base.Identifier] : null;
                }
                
                ObjectClass obj = Database.Classes.Create(ic.Name, ic.Identifier, baseClass, ic.Category);
                if (ic.GroupName)
                {
                    obj[SystemProperty.Name].Group = true;
                }
                
                obj.CreatingObjects = ic.Creating;
                Database.Classes.Update(obj);
            }
        }
        
        private void ImportFields(XmlNodeList listNodes)
        {
            foreach (XmlNode node in listNodes)
            {
                XmlAttribute attr = node.Attributes["name"];
                NextMessage(string.Format(Strings.ImportAttributes, attr == null ? Strings.NoName : attr.Value));
                if (attr == null)
                {
                    continue;
                }
                
                ImportObjectClass ic = this[attr.Value];
                if (ic.Error == ErrorClasses.ExistClassId)
                {
                    continue;
                }
                
                ObjectClass oc = Database.Classes[ic.Identifier];
                foreach (XmlNode fieldNode in node.ChildNodes)
                {
                    if (fieldNode.NodeType == XmlNodeType.Element)
                    {
                        this.ImportField(fieldNode, oc);
                    }
                }
                
                Database.Classes.Update(oc);
                Wait();
            }
        }
        
        private string ConvertXmlToString(string text)
        {
            StringBuilder builder = new StringBuilder((int)(text.Length * 1.1));
            
            int idx = 0;
            int t = 0;
            while (idx < text.Length)
            {
                if (text[idx] == '<')
                {
                    if (text[idx + 1] == '/')
                    {
                        builder.Append("\n");
                        builder.Append(char.Parse("\t"), --t);
                    }
                    else
                    {
                        if (t > 0)
                        {
                            builder.Append("\n");
                        }
                            
                        builder.Append(char.Parse("\t"), t++);
                    }
                }
                
                builder.Append(text[idx++]);
                if (idx > 1 && text[idx - 2] == '/' && text[idx - 1] == '>')
                {
                    t--;
                }
            }
            
            return builder.ToString();
        }
        
        private void ImportField(XmlNode fieldNode, ObjectClass obj)
        {
            XmlAttribute attr = null;
            if (fieldNode.Name == "forms")
            {
                obj.Form = this.ConvertXmlToString(fieldNode.InnerXml);
                return;
            }
            
            if (fieldNode.Name == "fieldname")
            {
                attr = fieldNode.Attributes["expression"];
                if (attr != null)
                {
                    obj[SystemProperty.Name].Evaluated = true;
                    obj[SystemProperty.Name].Expression = attr.Value;
                }
                
                return;
            }
            
            attr = fieldNode.Attributes["name"];
            if (attr == null)
            {
                return;
            }
            
            string fieldName = attr.Value;
            attr = fieldNode.Attributes["type"];
            if (attr == null)
            {
                return;
            }
            
            FieldType fieldType = Utils.Parse(attr.Value);
            Field field = this.Database.Classes.AddField(obj, fieldName, fieldType);
            
            attr = fieldNode.Attributes["category"];
            if (attr != null)
            {
                field.Category = attr.Value;
            }
            
            attr = fieldNode.Attributes["group"];
            if (attr != null)
            {
                field.Group = bool.Parse(attr.Value);
            }
            
            field.Comment = fieldNode.AttributeValueOrDefault("comment");
            
            attr = fieldNode.Attributes["expression"];
            if (attr != null && field.FieldType == FieldType.Text)
            {
                field.Evaluated = true;
                field.Expression = attr.Value;
            }
            
            attr = fieldNode.Attributes["order"];
            if (attr != null)
            {
                field.Order = int.Parse(attr.Value);
            }
            
            switch (fieldType)
            {
                case FieldType.Url:
                    attr = fieldNode.Attributes["method"];
                    if (attr != null)
                    {
                        UrlProperty.Get(field).Type = UrlProperty.Parse(attr.Value);
                    }
                    
                    break;
                case FieldType.Text:
                    XmlAttribute xmlTextDef = fieldNode.Attributes["default"];
                    if (xmlTextDef != null)
                    {
                        field.DefaultValue.AsText = xmlTextDef.Value;
                    }
                    
                    break;
                case FieldType.Select:
                    XmlAttribute xmlValues = fieldNode.Attributes["values"];
                    if (xmlValues != null)
                    {
                        List<string> sc = (List<string>)field.Data;
                        sc.AddRange(xmlValues.Value.Split(new char[] { ';' }));
                        XmlAttribute xmlValuesDef = fieldNode.Attributes["default"];
                        if (xmlValuesDef != null)
                        {
                            field.DefaultValue.AsInteger = sc.IndexOf(xmlValuesDef.Value);
                        }
                    }
                    
                    break;
                case FieldType.Number:
                    attr = fieldNode.Attributes["default"];
                    if (attr != null)
                    {
                        field.DefaultValue.AsDecimal = decimal.Parse(attr.Value);
                    }
                    
                    NumberProperty prop = (NumberProperty)field.Data;
                    attr = fieldNode.Attributes["decimal"];
                    if (attr != null)
                    {
                        prop.DecimalPlaces = int.Parse(attr.Value);
                    }
                    
                    attr = fieldNode.Attributes["maximum"];
                    if (attr != null)
                    {
                        prop.Maximum = decimal.Parse(attr.Value);
                        prop.Bounds = true;
                    }
                    
                    attr = fieldNode.Attributes["minimum"];
                    if (attr != null)
                    {
                        prop.Minimum = decimal.Parse(attr.Value);
                        prop.Bounds = true;
                    }
                    
                    attr = fieldNode.Attributes["increment"];
                    if (attr != null)
                    {
                        prop.Increment = decimal.Parse(attr.Value);
                    }
                    
                    attr = fieldNode.Attributes["thousands"];
                    if (attr != null)
                    {
                        prop.Thousands = bool.Parse(attr.Value);
                    }
                    
                    prop.Prefix = fieldNode.AttributeValueOrDefault("prefix");
                    prop.Suffix = fieldNode.AttributeValueOrDefault("suffix");
                    
                    break;
                case FieldType.List:
                    XmlAttribute xmlListRef = fieldNode.Attributes["ref_guid"];
                    if (xmlListRef != null)
                    {
                        ListProperty.Get(field).Reference = Database.Classes[new Guid(xmlListRef.Value)];
                    }
                    else
                    {
                        xmlListRef = fieldNode.Attributes["reference"];
                        if (xmlListRef != null)
                        {
                            ImportObjectClass ic_list = this[xmlListRef.Value];
                            ListProperty.Get(field).Reference = Database.Classes[ic_list.Identifier];
                        }
                    }
                    
                    break;
                case FieldType.Boolean:
                    XmlAttribute xmlBoolDef = fieldNode.Attributes["default"];
                    if (xmlBoolDef != null)
                    {
                        field.DefaultValue.AsBoolean = bool.Parse(xmlBoolDef.Value);
                    }
                    
                    break;
                case FieldType.Date:
                    XmlAttribute xmlDateDef = fieldNode.Attributes["default"];
                    if (xmlDateDef != null)
                    {
                        field.DefaultValue.AsDateTime = DateTime.Parse(xmlDateDef.Value);
                    }
                    
                    attr = fieldNode.Attributes["time"];
                    if (attr != null)
                    {
                        DateProperty.Get(field).ViewTime = bool.Parse(attr.Value);
                    }
                    
                    break;
                case FieldType.Table:
                    XmlAttribute xmlTableCols = fieldNode.Attributes["columns"];
                    List<ColumnProperty> list = new List<ColumnProperty>();
                    if (xmlTableCols != null)
                    {
                        foreach (string col in xmlTableCols.Value.Split(new char[] { ';' }))
                        {
                            list.Add(new ColumnProperty(col));
                        }
                    }
                    else
                    {
                        foreach (XmlNode xmlColumn in fieldNode.ChildNodes)
                        {
                            XmlAttribute xmlColName = xmlColumn.Attributes["name"];
                            if (xmlColName != null)
                            {
                                string colName = xmlColName.Value;
                                ColumnProperty cp = new ColumnProperty(colName);
                                XmlAttribute xmlColRef = xmlColumn.Attributes["ref_guid"];
                                if (xmlColRef != null)
                                {
                                    cp.Reference = Database.Classes[new Guid(xmlColRef.Value)];
                                }
                                else
                                {
                                    xmlColRef = xmlColumn.Attributes["reference"];
                                    if (xmlColRef != null)
                                    {
                                        ImportObjectClass c_ref = this[xmlColRef.Value];
                                        cp.Reference = Database.Classes[c_ref.Identifier];
                                    }
                                }
                                
                                attr = xmlColumn.Attributes["width"];
                                if (attr != null)
                                {
                                    cp.Width = int.Parse(attr.Value);
                                }
                                
                                attr = xmlColumn.Attributes["min_width"];
                                if (attr != null)
                                {
                                    cp.MinWidth = int.Parse(attr.Value);
                                }
                                
                                attr = xmlColumn.Attributes["visible"];
                                if (attr != null)
                                {
                                    cp.Visible = bool.Parse(attr.Value);
                                }
                                
                                attr = xmlColumn.Attributes["resizable"];
                                if (attr != null)
                                {
                                    cp.Resizable = bool.Parse(attr.Value);
                                }
                                
                                attr = xmlColumn.Attributes["frozen"];
                                if (attr != null)
                                {
                                    cp.Frozen = bool.Parse(attr.Value);
                                }
                                
                                attr = xmlColumn.Attributes["div_width"];
                                if (attr != null)
                                {
                                    cp.DividerWidth = int.Parse(attr.Value);
                                }
                                
                                attr = xmlColumn.Attributes["auto_size"];
                                if (attr != null)
                                {
                                    cp.AutoSize = bool.Parse(attr.Value);
                                }
                                
                                attr = xmlColumn.Attributes["fill_weight"];
                                if (attr != null)
                                {
                                    cp.FillWeight = int.Parse(attr.Value);
                                }
                                
                                list.Add(cp);
                            }
                        }
                    }
                    
                    ((List<ColumnProperty>)field.Data).AddRange(list);
                    break;
                case FieldType.Rating:
                    XmlAttribute xmlRaitDef = fieldNode.Attributes["default"];
                    if (xmlRaitDef != null)
                    {
                        field.DefaultValue.AsDecimal = decimal.Parse(xmlRaitDef.Value);
                    }
                    
                    break;
                case FieldType.Reference:
                    XmlAttribute xmlRef = fieldNode.Attributes["ref_guid"];
                    if (xmlRef != null)
                    {
                        ReferenceProperty.Get(field).Reference = Database.Classes[new Guid(xmlRef.Value)];
                    }
                    else
                    {
                        xmlRef = fieldNode.Attributes["reference"];
                        if (xmlRef != null)
                        {
                            ImportObjectClass ic_ref = this[xmlRef.Value];
                            ReferenceProperty.Get(field).Reference = Database.Classes[ic_ref.Identifier];
                        }
                    }
                    
                    break;
            }
        }
        
        private void LoadClasses()
        {
            foreach (XmlNode node in Document.SelectNodes(XmlPath + "/category/class"))
            {
                ImportObjectClass ic = new ImportObjectClass(node);
                if (ic.CorrectName)
                {
                    this.classes.Add(ic);
                }
            }
        }
    }
}
