//-----------------------------------------------------------------------
// <copyright file="ColumnProperty.cs" company="Sergey Teplyashin">
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
// <time>13:27</time>
// <summary>Defines the ColumnProperty class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    using ComponentLib.Data;
    
    #endregion
    
    /// <summary>
    /// Description of ColumnData.
    /// </summary>
    [Cascade]
    public class ColumnProperty
    {
        private string name;
        private int width;
        private int minWidth;
        private bool visible;
        private bool resizable;
        private bool frozen;
        private int dividerWidth;
        private bool autoSize;
        private int fillWeight;
        private ObjectClass reference;
        
        public ColumnProperty(string name)
        {
            this.name = name;
            this.width = 100;
            this.minWidth = 5;
            this.visible = true;
            this.resizable = true;
            this.dividerWidth = 5;
            this.fillWeight = 100;
        }
        
        public ColumnProperty() : this(Strings.Column)
        {
        }
        
        public ColumnProperty(string name, ObjectClass reference) : this(name)
        {
            this.reference = reference;
        }
        
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        
        public ObjectClass Reference
        {
            get { return this.reference; }
            set { this.reference = value; }
        }
        
        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }
        
        public int MinWidth
        {
            get { return this.minWidth; }
            set { this.minWidth = value; }
        }
        
        public bool Visible
        {
            get { return this.visible; }
            set { this.visible = value; }
        }
        
        public bool Resizable
        {
            get { return this.resizable; }
            set { this.resizable = value; }
        }
        
        public bool Frozen
        {
            get { return this.frozen; }
            set { this.frozen = value; }
        }
        
        public int DividerWidth
        {
            get { return this.dividerWidth; }
            set { this.dividerWidth = value; }
        }
        
        public bool AutoSize
        {
            get { return this.autoSize; }
            set { this.autoSize = value; }
        }
        
        public int FillWeight
        {
            get { return this.fillWeight; }
            set { this.fillWeight = value; }
        }
        
        public ColumnProperty CopyTo(ColumnProperty column)
        {
            column.name = this.name;
            column.width = this.width;
            column.minWidth = this.minWidth;
            column.visible = this.visible;
            column.resizable = this.resizable;
            column.frozen = this.frozen;
            column.dividerWidth = this.dividerWidth;
            column.autoSize = this.autoSize;
            column.fillWeight = this.fillWeight;
            column.reference = this.reference;
            
            return column;
        }
        
        public override string ToString()
        {
            return this.Name;
        }
    }
}
