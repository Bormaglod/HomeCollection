//-----------------------------------------------------------------------
// <copyright file="ImportExecutorData.cs" company="Sergey Teplyashin">
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
// <date>17.05.2011</date>
// <time>14:55</time>
// <summary>Defines the ImportExecutorData class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Core
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Timers;
    using System.Xml;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of ImportDataExecutor.
    /// </summary>
    public class ImportExecutorData : ImportExecutor
    {
        private List<UpdatedReferenceData> updatedData;
        
        public ImportExecutorData(Database database, XmlDocument doc, string xmlPath) : base(database, doc, xmlPath)
        {
            this.updatedData = new List<UpdatedReferenceData>();
        }
        
        public void ExecuteImport()
        {
            ShowProgress(Strings.ImportRecord, Strings.Import);
            try
            {
                XmlNodeList listNodes = Document.SelectNodes(XmlPath);
                Start(listNodes.Count);
                this.updatedData.Clear();
                foreach (XmlNode node in listNodes)
                {
                    XmlAttribute attr = node.Attributes["class_id"];
                    NextMessage(string.Empty);
                    if (attr != null)
                    {
                        Guid guid = new Guid(attr.Value);
                        ObjectClass objectClass = Database.Classes[guid];
                        if (objectClass != null)
                        {
                            ObjectData obj = new ObjectData(objectClass);
                            foreach (XmlNode fieldNode in node.ChildNodes)
                            {
                                this.SetValueData(obj, fieldNode);
                            }
                            
                            UpdateMessage(obj[SystemProperty.Name].ToString());
                            Database.Objects.Update(obj);
                            Wait();
                        }
                    }
                }
                
                this.UpdateReferenceData();
            }
            finally
            {
                StopProgress();
            }
        }
        
        private void SetValueData(ObjectData obj, XmlNode node)
        {
            XmlAttribute attr = node.Attributes["name"];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                Field field = obj.ObjectClass.FindField(attr.Value, true);
                attr = node.Attributes["value"];
                if (field != null && (attr != null || field.FieldType == FieldType.Image || field.FieldType == FieldType.Table))
                {
                    string valueData = attr != null ? attr.Value : string.Empty;
                    switch (field.FieldType)
                    {
                        case FieldType.Boolean:
                            obj[field] = bool.Parse(valueData);
                            break;
                        case FieldType.Date:
                            obj[field] = DateTime.Parse(valueData);
                            break;
                        case FieldType.Image:
                            attr = node.Attributes["ref_path"];
                            string refPath = attr == null ? string.Empty : attr.Value;
                            //attr = node.Attributes["ref_data"];
                            //bool refData = attr == null ? true : bool.Parse(attr.Value);
                            ImageData id = new ImageData(refPath);
                            //id.ReferenceData = refData;
                            foreach (XmlNode item in node.ChildNodes)
                            {
                                attr = item.Attributes["path"];
                                if (attr != null)
                                {
                                    id.AddImage(attr.Value);
                                }
                            }
                            obj[field] = id;
                            
                            break;
                        case FieldType.List:
                            this.updatedData.Add(new UpdatedReferenceData(node, obj, field, valueData));
                            break;
                        case FieldType.Number:
                            obj[field] = decimal.Parse(valueData);
                            break;
                        case FieldType.Rating:
                            obj[field] = decimal.Parse(valueData);
                            break;
                        case FieldType.Reference:
                            this.updatedData.Add(new UpdatedReferenceData(node, obj, field, valueData));
                            break;
                        case FieldType.Select:
                            obj[field] = int.Parse(valueData);
                            break;
                        case FieldType.Table:
                            this.updatedData.Add(new UpdatedReferenceData(node, obj, field, valueData));
                            break;
                        default:
                            obj[field] = valueData;
                            break;
                    }
                }
            }
        }

        private void UpdateReferenceData()
        {
            ObjectData od;
            foreach (UpdatedReferenceData urd in this.updatedData)
            {
                switch (urd.Field.FieldType)
                {
                    case FieldType.List:
                        ListData values = (ListData)urd.Data[urd.Field];
                        values.Objects.Clear();
                        foreach (string v in urd.ValueData.Split(new char[] { ';' }))
                        {
                            od = this.GetReferenceData((ObjectClass)urd.Field.Data, v);
                            if (od != null)
                            {
                                values.Objects.Add(od);
                            }
                        }
                        
                        break;
                    case FieldType.Reference:
                        od = this.GetReferenceData((ObjectClass)urd.Field.Data, urd.ValueData);
                        if (od == null)
                        {
                            urd.Data[urd.Field] = 0;
                        }
                        else
                        {
                            urd.Data[urd.Field] = od;
                        }
                        
                        break;
                    case FieldType.Table:
                        TableData td = (TableData)urd.Data[urd.Field];
                        foreach (XmlNode rowNode in urd.Node.ChildNodes)
                        {
                            Row row = new Row();
                            td.Rows.Add(row);
                            foreach (XmlNode cellNode in rowNode.ChildNodes)
                            {
                                XmlAttribute attr = cellNode.Attributes["column"];
                                if (attr == null)
                                {
                                    continue;
                                }
                                
                                ColumnProperty cp = td.GetColumn(attr.Value);
                                if (cp == null)
                                {
                                    continue;
                                }
                                
                                attr = cellNode.Attributes["value"];
                                if (attr == null || string.IsNullOrEmpty(attr.Value))
                                {
                                    continue;
                                }
                                
                                if (cp.Reference == null)
                                {
                                    row.Cells.Add(new Cell(cp, attr.Value));
                                }
                                else
                                {
                                    od = this.GetReferenceData(cp.Reference, attr.Value);
                                    if (od != null)
                                    {
                                        row.Cells.Add(new Cell(cp, od));
                                    }
                                }
                            }
                        }
                        
                        break;
                }
                
                Database.Objects.Update(urd.Data);
            }
        }
        
        private ObjectData GetReferenceData(ObjectClass objectClass, string valueData)
        {
            IEnumerable<ObjectData> list =Database.Objects.GetData(objectClass);
            foreach (ObjectData od in list)
            {
                if (od[SystemProperty.Name].ToString() == valueData)
                {
                    return od;
                }
            }
            
            return null;
        }
    }
}
