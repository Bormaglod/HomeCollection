//-----------------------------------------------------------------------
// <copyright file="TableControl.cs" company="Sergey Teplyashin">
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
// <date>22.02.2011</date>
// <time>10:24</time>
// <summary>Defines the TableControl class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using HomeCollection.Data;
    
    #endregion

    /// <summary>
    /// Description of TableControl.
    /// </summary>
    public partial class TableControl : UserControl
    {
        private Database database;
        private ObjectData obj;
        private Field field;
        
        public TableControl(Database data, ObjectData objectData, Field field)
        {
            InitializeComponent();
        
            this.database = data;
            this.obj = objectData;
            this.field = field;
            this.CreateColumns();
            this.CreateData();
            
            // TODO: Необходима возможность добавления записи из таблицы
        }
        
        public TableData CreateTableData()
        {
            TableData td = new TableData(field);
            //int nrow;
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }
                
                //nrow = row.Index;
                Row trow = td.AddRow();
                foreach (DataGridViewColumn column in grid.Columns)
                {
                    ColumnProperty cp = (ColumnProperty)column.Tag;
                    DataGridViewCell cell = row.Cells[column.Name];
                    if (cell.Value != null)
                    {
                        if (cp.Reference != null)
                        {
                            bool find = false;
                            foreach (ObjectData od in this.database.Objects.GetData(cp.Reference))
                            {
                                if (od.ToString() == cell.Value.ToString())
                                {
                                    //td.AddCell(column.Name, nrow, od);
                                    trow.AddCell(cp, od);
                                    find = true;
                                    break;
                                }
                            }
                            
                            if (!find)
                            {
                                //td.AddCell(column.Name, nrow, string.Empty);
                                trow.AddCell(cp, string.Empty);
                            }
                        }
                        else
                        {
                            //td.AddCell(column.Name, nrow, dgvc.Value);
                            trow.AddCell(cp, cell.Value);
                        }
                    }
                    else
                    {
                        //td.AddCell(column.Name, nrow, string.Empty);
                        trow.AddCell(cp, string.Empty);
                    }
                }
            }
            
            return td;
        }
        
        public void AddDataItem(ObjectData data)
        {
            foreach (ColumnProperty c in (List<ColumnProperty>)this.field.Data)
            {
                if (c.Reference == data.ObjectClass)
                {
                    foreach (DataGridViewColumn col in this.grid.Columns)
                    {
                        if ((ColumnProperty)col.Tag == c)
                        {
                            KryptonDataGridViewComboBoxColumn combo = (KryptonDataGridViewComboBoxColumn)col;
                            if (!combo.Items.Contains(data.ToString()))
                            {
                                combo.Items.Add(data.ToString());
                            }
                            
                            break;
                        }
                    }
                }
            }
        }
        
        private void CreateColumns()
        {
            foreach (ColumnProperty c in (List<ColumnProperty>)this.field.Data)
            {
                DataGridViewColumn col;
                if (c.Reference == null)
                {
                    col = new KryptonDataGridViewTextBoxColumn();
                }
                else
                {
                    col = new KryptonDataGridViewComboBoxColumn();
                    KryptonDataGridViewComboBoxColumn colCombo = (KryptonDataGridViewComboBoxColumn)col;
                    colCombo.DropDownStyle = ComboBoxStyle.DropDownList;
                    ButtonSpecAny b = new ButtonSpecAny();
                    b.Type = PaletteButtonSpecStyle.Close;
                    b.Edge = PaletteRelativeEdgeAlign.Near;
                    b.Click += new EventHandler(this.ClearFieldData);
                    colCombo.ButtonSpecs.Add(b);
                    foreach (ObjectData od in this.database.Objects.GetData(c.Reference))
                    {
                        colCombo.Items.Add(od.ToString());
                    }
                }
                
                col.Tag = c;
                col.Name = c.Name;
                col.HeaderText = c.Name;
                col.Width = c.Width;
                col.MinimumWidth = c.MinWidth;
                col.Visible = c.Visible;
                col.Resizable = c.Resizable ? DataGridViewTriState.True : DataGridViewTriState.False;
                col.Frozen = c.Frozen;
                col.DividerWidth = c.DividerWidth;
                col.AutoSizeMode = c.AutoSize ? DataGridViewAutoSizeColumnMode.Fill : DataGridViewAutoSizeColumnMode.None;
                col.FillWeight = c.FillWeight;
                this.grid.Columns.Add(col);
            }
            
            grid.StateCommon.Background.Color1 = Color.Transparent;
        }
        
        private void ClearFieldData(object sender, EventArgs e)
        {
            ButtonSpecAny b = (ButtonSpecAny)sender;
            KryptonDataGridViewComboBoxCell combo = (KryptonDataGridViewComboBoxCell)b.Owner;
            // FIXME: Значение очищается только после нажатия Enter или потери фокуса
            combo.Value = null;
        }
        
        private void CreateData()
        {
            TableData td = (TableData)this.obj[field];
            foreach (Row row in td.Rows)
            {
                int r = this.grid.Rows.Add();
                foreach (Cell cell in row.Cells)
                {
                    this.grid.Rows[r].Cells[cell.Column.Name].Value = cell.Data.ToString();
                }
            }
        }
    }
}
