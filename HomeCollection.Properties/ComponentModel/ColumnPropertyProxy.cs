//-----------------------------------------------------------------------
// <copyright file="ColumnPropertyProxy.cs" company="Sergey Teplyashin">
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
// <date>26.04.2012</date>
// <time>12:42</time>
// <summary>Defines the ColumnPropertyProxy class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Properties
{
    #region Using directives
    
    using System;
    using System.ComponentModel;
    using HomeCollection.Data;
    
    #endregion
    
    /// <summary>
    /// Description of ColumnPropertyProxy.
    /// </summary>
    public class ColumnPropertyProxy
    {
        private Database database;
        private ColumnProperty column;
        
        public ColumnPropertyProxy(Database database, ColumnProperty column)
        {
            this.database = database;
            this.column = column;
        }
        
        public event EventHandler<EventArgs> ColumnNameModified;
        
        [Browsable(false)]
        public Database Database
        {
            get { return this.database; }
        }
        
        [Browsable(false)]
        public ColumnProperty Column
        {
            get { return this.column; }
        }
        
        [LocalizedDisplayName("Name")]
        [LocalizedDescription("NameDesc")]
        [LocalizedCategory("View")]
        public string Name
        {
            get { return this.column.Name; }
            
            set
            {
                if (this.column.Name != value)
                {
                    this.column.Name = value;
                    if (this.ColumnNameModified != null)
                    {
                        this.ColumnNameModified(this, new EventArgs());
                    }
                }
            }
        }
        
        [LocalizedDisplayName("Reference")]
        [LocalizedCategory("View")]
        [TypeConverter(typeof(ObjectClassConverter))]
        public ObjectClass Reference
        {
            get { return this.column.Reference; }
            set { this.column.Reference = value; }
        }
        
        [LocalizedDisplayName("Width")]
        [LocalizedDescription("WidthDesc")]
        [LocalizedCategory("Format")]
        public int Width
        {
            get { return this.column.Width; }
            set { this.column.Width = value; }
        }
        
        [LocalizedDisplayName("MinimumWidth")]
        [LocalizedDescription("MinimumWidthDesc")]
        [LocalizedCategory("Format")]
        public int MinWidth
        {
            get { return this.column.MinWidth; }
            set { this.column.MinWidth = value; }
        }
        
        [LocalizedDisplayName("Visible")]
        [LocalizedDescription("VisibleDesc")]
        [LocalizedCategory("View")]
        [TypeConverter(typeof(BooleanDefaultConverter))]
        public bool Visible
        {
            get { return this.column.Visible; }
            set { this.column.Visible = value; }
        }
        
        [LocalizedDisplayName("Resizable")]
        [LocalizedDescription("ResizableDesc")]
        [LocalizedCategory("Behavior")]
        [TypeConverter(typeof(BooleanDefaultConverter))]
        public bool Resizable
        {
            get { return this.column.Resizable; }
            set { this.column.Resizable = value; }
        }
        
        [LocalizedDisplayName("Frozen")]
        [LocalizedDescription("FrozenDesc")]
        [LocalizedCategory("Format")]
        [TypeConverter(typeof(BooleanDefaultConverter))]
        public bool Frozen
        {
            get { return this.column.Frozen; }
            set { this.column.Frozen = value; }
        }
        
        [LocalizedDisplayName("DividerWidth")]
        [LocalizedDescription("DividerWidthDesc")]
        [LocalizedCategory("Format")]
        public int DividerWidth
        {
            get { return this.column.DividerWidth; }
            set { this.column.DividerWidth = value; }
        }
        
        [LocalizedDisplayName("AutoSize")]
        [LocalizedDescription("AutoSizeDesc")]
        [LocalizedCategory("Format")]
        [TypeConverter(typeof(BooleanDefaultConverter))]
        public bool AutoSize
        {
            get { return this.column.AutoSize; }
            set { this.column.AutoSize = value; }
        }
        
        [LocalizedDisplayName("FillWeight")]
        [LocalizedDescription("FillWeightDesc")]
        [LocalizedCategory("Format")]
        public int FillWeight
        {
            get { return this.column.FillWeight; }
            set { this.column.FillWeight = value; }
        }
        
        public override string ToString()
        {
            return column.Name;
        }

    }
}
