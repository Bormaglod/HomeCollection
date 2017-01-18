//-----------------------------------------------------------------------
// <copyright file="Row.cs" company="Sergey Teplyashin">
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
// <date>25.04.2012</date>
// <time>8:33</time>
// <summary>Defines the Row class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ComponentLib.Data;
    
    #endregion
    
    /// <summary>
    /// Description of Row.
    /// </summary>
    [Cascade]
    public class Row
    {
        [Cascade]
        private List<Cell> cells;
        
        public Row()
        {
            this.cells = new List<Cell>();
        }
        
        public List<Cell> Cells
        {
            get { return this.cells; }
        }
        
        public Cell this[ColumnProperty column]
        {
            get { return this.cells.FirstOrDefault(c => c.Column == column); }
        }
        
        public Cell AddCell(ColumnProperty column, object data)
        {
            Cell cell = new Cell(column, data);
            this.cells.Add(cell);
            return cell;
        }
    }
}
