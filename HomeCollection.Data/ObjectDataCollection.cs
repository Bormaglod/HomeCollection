//-----------------------------------------------------------------------
// <copyright file="ObjectDataCollection.cs" company="Sergey Teplyashin">
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
// <time>9:52</time>
// <summary>Defines the ObjectDataCollection class.</summary>
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
    /// Description of ObjectDataCollection.
    /// </summary>
    public class ObjectDataCollection : BaseCollection<ObjectData>
    {
        public ObjectDataCollection(Database data) : base(data)
        {
            data.DatabaseOpened += new EventHandler<EventArgs>(this.data_DatabaseOpened);
        }
        
        #region public methods
        
        public IEnumerable<ObjectData> GetData(ObjectClass obj)
        {
            return from ObjectData d in Database.Data
                   where d.ObjectClass == obj
                   select d;
        }
        
        public IEnumerable<ObjectData> GetData(IEnumerable<ObjectClass> classes, Field field)
        {
            ObjectClass[] ac = classes.ToArray();
            return from ObjectData d in Database.Data
                   where ac.Contains(d.ObjectClass) && d.Values.ContainsKey(field)
                   select d;
        }
        
        public ObjectData GetValueData(ObjectClass objectClass, string value)
        {
            return this.GetData(objectClass).FirstOrDefault(od => od[SystemProperty.Name].ToString() == value);
        }
        
        /// <summary>
        /// Метод возвращает список записей соответствующих заявленным параметрам.
        /// </summary>
        /// <param name="classes">Список шаблонов.</param>
        /// <param name="folder">Папка в которой содержатся записи.</param>
        /// <param name="filter">Строка содержащаяся в данных.</param>
        /// <returns>Список записей соответствующих заявленным параметрам.</returns>
        public IEnumerable<ObjectData> GetFilteredData(IEnumerable<ObjectClass> classes, Folder folder, string filter)
        {
            ObjectClass[] ac = classes.ToArray();
            return from ObjectData d in Database.Data
                   where ac.Contains(d.ObjectClass) && d.Filter(folder, filter)
                   select d;
        }
        
        /// <summary>
        /// Метод возвращает список записей соответствующих заявленным параметрам.
        /// </summary>
        /// <param name="filter">Фильтр, которому должны удолвлетворять записи.</param>
        /// <returns>Список записей соответствующих заявленным параметрам.</returns>
        public IEnumerable<ObjectData> GetFilteredData(Filter filter)
        {
            return from ObjectData d in Database.Data
                   where d.Filter(filter)
                   select d;
        }
        
        public override void Remove(ObjectData removedElement)
        {
            foreach (ObjectData od in Collection)
            {
                if (od == removedElement)
                {
                    continue;
                }
                
                od.RemoveDependenceData(removedElement);
                
                Update(od);
            }
            
            base.Remove(removedElement);
        }
        
        public override void ObjectRemoving(object removingObject)
        {
            ObjectClass objectClass = removingObject as ObjectClass;
            if (objectClass != null)
            {
                foreach (ObjectData d in this.GetData(objectClass))
                {
                    Remove(d);
                }
                
                return;
            }
        }
        
        public void ClearData(ObjectData obj)
        {
            Field[] flds = obj.Fields.ToArray();
            foreach (Field f in flds)
            {
                this.RemoveValueData(f, obj[f]);
                obj[f] = f.GetStandardDefaultValue();
            }
        }
        
        #endregion
        
        #region private methods
        
        private void RemoveValueData(Field field, object removedObject)
        {
            switch (field.FieldType)
            {
                case FieldType.List:
                case FieldType.Image:
                    this.Database.Data.Delete(removedObject);
                    break;
                case FieldType.Table:
                    TableData td = (TableData)removedObject;
                    foreach (Row row in td.Rows)
                    {
                        foreach (Cell cell in row.Cells)
                        {
                            this.Database.Data.Delete(cell);
                        }
                        
                        this.Database.Data.Delete(row.Cells);
                        this.Database.Data.Delete(row);
                    }
                    
                    this.Database.Data.Delete(td.Rows);
                    this.Database.Data.Delete(td);
                    break;
            }
        }
        
        private void data_DatabaseOpened(object sender, EventArgs e)
        {
            Database.Classes.FieldTypeModified += new EventHandler<FieldModifiedEventArgs>(this.Database_Classes_FieldTypeModified);
            Database.Classes.FieldModified += new EventHandler<FieldModifiedEventArgs>(this.Database_Classes_FieldModified);
        }
        
        private void Database_Classes_FieldTypeModified(object sender, FieldModifiedEventArgs e)
        {
            foreach (ObjectClass objClass in this.Database.Classes.GetHierarchyClasses(e.Field.ObjectClass, MoveDirection.Up))
            {
                foreach (ObjectData obj in this.GetData(objClass))
                {
                    this.RemoveValueData(e.Field, obj[e.Field]);
                    
                    if (e.Field.IsDefaultProperty)
                    {
                        obj[e.Field] = e.Field.DefaultValue.Value;
                    }
                    else
                    {
                        obj[e.Field] = e.Field.GetStandardDefaultValue();
                    }
                    
                    Update(obj);
                }
            }
        }
        
        private void Database_Classes_FieldModified(object sender, FieldModifiedEventArgs e)
        {
            switch (e.Action)
            {
                case ObjectAction.Add:
                    foreach (ObjectData d in this.GetData(e.Field.ObjectClass))
                    {
                        d.AddField(e.Field);
                        Update(d);
                    }
                    
                    break;
                case ObjectAction.Delete:
                    foreach (ObjectData d in this.GetData(e.Field.ObjectClass))
                    {
                        this.RemoveValueData(e.Field, d[e.Field]);
                        d.RemoveField(e.Field);
                        Update(d);
                    }
                    
                    break;
            }
        }
        
        #endregion
        
        /*public static ObjectData CreateObjectData(ObjectClass objectClass)
        {
            return new ObjectData(objectClass);
        }*/
        
        
        
        /*public IEnumerable<ObjectData> GetData(Guid identifier)
        {
            return from ObjectData d in Database.Data
                   where d.ObjectClass.Identifier == identifier
                   select d;
        }
        
        public IEnumerable<ObjectData> GetData(Field field)
        {
            return from ObjectData d in Database.Data
                   where d.ContainsField(field)
                   select d;
        }*/
        
        
        
        /*public IEnumerable<ObjectData> GetDependenceData(ObjectClass obj)
        {
            return from ObjectData d in Database.Data
                   where d.ObjectClass.DependenceFields(obj).Count() > 0
                   select d;
        }
        
        */
        
        
        
        /*public void AddField(ObjectClass obj, Field field)
        {
            foreach (ObjectClass oc in Database.Classes.GetClasses(obj))
            {
                this.AddField(oc, field);
            }
            
            foreach (ObjectData d in this.GetData(obj))
            {
                d.AddField(field);
                Update(d);
            }
        }
        
        public void InitDataField(Field field)
        {
            foreach (ObjectClass objClass in this.Database.Classes.GetHierarchyClasses(field.ObjectClass, MoveDirection.Up))
            {
                foreach (ObjectData obj in this.GetData(objClass))
                {
                    obj.InitData(field);
                    Update(obj);
                }
            }
        }
        
        public void RemoveField(Field field)
        {
            foreach (ObjectData od in this.GetData(field))
            {
                od.RemoveField(field);
                Update(od);
            }
        }
        
        public void Remove(ObjectClass objectClass)
        {
            foreach (ObjectData d in this.GetDependenceData(objectClass))
            {
                foreach (Field f in d.ObjectClass.DependenceFields(objectClass))
                {
                    if (f.FieldType != FieldType.Table)
                    {
                        d.RemoveField(f);
                    }
                }
                
                Update(d);
            }
            
            foreach (ObjectData d in this.GetData(objectClass))
            {
                this.Remove(d);
            }
        }*/
        
        
        
        
        
    }
}
