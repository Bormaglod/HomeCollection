//-----------------------------------------------------------------------
// <copyright file="ExportData.cs" company="Sergey Teplyashin">
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
// <date>13.05.2011</date>
// <time>12:40</time>
// <summary>Defines the ExportData class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Core
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using ComponentLib.Core.Xml;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of ExportData.
    /// </summary>
    public class ExportData : TransformData
    {
        private const string name = "Export to XML";
        private const string filterName = "XML File (*.xml)";
        private const string ext = "*.xml";
        
        public ExportData(Database database) : base(database)
        {
        }
        
        public static void CreateXmlTree(Database database, XmlDocument doc, XmlElement root)
        {
            ObjectData[] datas = database.Objects.Collection.ToArray();
            foreach (ObjectData d in datas)
            {
                XmlElement elem = doc.CreateElement(root, "record", "class_id", d.ObjectClass.Identifier.ToString());
                foreach (Field f in d.ObjectClass.FieldsBase)
                {
                    object od = d[f];
                    if (!f.IsEmptyData(od))
                    {
                        XmlElement field = doc.CreateElement(elem, "field", "name", f.Name);
                        switch (f.FieldType)
                        {
                            case FieldType.List:
                                string val = string.Empty;
                                foreach (ObjectData di in ((ListData)od).Objects)
                                {
                                    val += di.ToString() + ";";
                                }
                                
                                val = val.TrimEnd(new char[] { ';' });
                                if (!string.IsNullOrEmpty(val))
                                {
                                    doc.AddAttribute(field, "value", val);
                                }
                                
                                break;
                            case FieldType.Table:
                                TableData td = (TableData)od;
                                foreach (Row row in td.Rows)
                                {
                                    XmlElement rowXml = doc.CreateElement(field, "row");
                                    foreach (Cell cell in row.Cells)
                                    {
                                        XmlElement cellXml = doc.CreateElement(rowXml, "cell");
                                        doc.AddAttribute(cellXml, "column", cell.Column.Name);
                                        doc.AddAttribute(cellXml, "value", cell.Data.ToString());
                                    }
                                }
                                
                                break;
                            case FieldType.Image:
                                ImageData id = (ImageData)od;
                                doc.AddAttribute(field, "ref_path", id.ReferencePath);
                                foreach (string s in id.Images)
                                {
                                    doc.CreateElement(field, "item", "path", s);
                                }
                                
                                break;
                            case FieldType.Reference:
                                if (od.GetType() != typeof(int))
                                {
                                    doc.AddAttribute(field, "value", od.ToString());
                                }
                                
                                break;
                            default:
                                doc.AddAttribute(field, "value", od.ToString());
                                break;
                        }
                    }
                }
            }
        }
        
        public override void CreateXmlDocument()
        {
            base.CreateXmlDocument();
            Document.AppendChild(Document.CreateXmlDeclaration("1.0", "UTF-8", string.Empty));
            XmlElement dat = Document.CreateElement((XmlElement)null, "records");
            CreateXmlTree(Database, Document, dat);
        }
        
        protected override string GetFilterName()
        {
            return filterName;
        }
        
        protected override string GetExtension()
        {
            return ext;
        }
        
        protected override string GetName()
        {
            return name;
        }
        
        protected override bool Execute()
        {
            CreateXmlDocument();
            Save(FileName);
            return true;
        }
    }
}
