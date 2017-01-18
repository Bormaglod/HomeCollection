//-----------------------------------------------------------------------
// <copyright file="TableData.cs" company="Sergey Teplyashin">
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
// <time>9:13</time>
// <summary>Defines the TableData class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using ComponentLib.Data;
    
    #endregion
    
    /// <summary>
    /// Description of TableData.
    /// </summary>
    [Cascade]
    public class TableData
    {
        private Field field;
        
        [Cascade]
        private List<Row> rows;
        
        public TableData(Field field)
        {
            this.field = field;
            this.rows = new List<Row>();
        }
        
        public Field Field
        {
            get { return this.field; }
        }
        
        public IEnumerable<ColumnProperty> Columns
        {
            get { return (IEnumerable<ColumnProperty>)this.field.Data; }
        }
        
        public List<Row> Rows
        {
            get { return this.rows; }
        }
        
        public int RowCount
        {
            get { return this.rows.Count; }
        }
        
        public int ColumnCount
        {
            get { return this.Columns.Count(); }
        }
        
        public Cell First
        {
            get
            {
                foreach (Row row in this.rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        return cell;
                    }
                }
                
                return null;
            }
        }
        
        public Row this[int row]
        {
            get { return this.rows[row]; }
        }
        
        public ColumnProperty GetColumn(string nameColumn)
        {
            return this.Columns.FirstOrDefault(c => c.Name == nameColumn);
        }
        
        public Row AddRow()
        {
            Row row = new Row();
            this.rows.Add(row);
            return row;
        }
        
        internal void RemoveDependence(ObjectData objectData)
        {
            foreach (Row row in this.rows)
            {
                foreach (Cell cell in row.Cells)
                {
                    ObjectData od = cell.Data as ObjectData;
                    if (od != null && od == objectData)
                    {
                        cell.Data = null;
                    }
                }
            }
        }
    }
}
