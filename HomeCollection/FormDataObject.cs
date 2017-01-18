//-----------------------------------------------------------------------
// <copyright file="FormDataObject.cs" company="Sergey Teplyashin">
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
// <date>15.02.2011</date>
// <time>9:10</time>
// <summary>Defines the FormDataObject class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using HomeCollection.Core;
    using HomeCollection.Data;
    
    #endregion

    /// <summary>
    /// Description of FormDataObject.
    /// </summary>
    public partial class FormDataObject : FormDataAbstract
    {
        public FormDataObject(IDataCollection collection, Database data/*, IEnumerable<IImportPlugin> plugins*/) : base(collection, data/*, plugins*/)
        {
            InitializeComponent();
        }
        
        protected override void CreateControls()
        {
            this.tabCategories.TabPages.Clear();
            ObjectClass oc = Data.Classes[Obj.ObjectClass.Identifier];
            Field[] fields = oc.FieldsBase.ToArray();
            foreach (var category in oc.FieldsCategory)
            {
                TabPage page = new TabPage(category.Key);
                page.UseVisualStyleBackColor = true;
                page.Padding = new Padding(this.tabCommon.Padding.All);
                this.tabCategories.TabPages.Add(page);
                
                TableLayoutPanel panel = new TableLayoutPanel();
                panel.Dock = DockStyle.Fill;
                panel.ColumnCount = category.Count() == 1 ? 2 : 4;
                
                int row = category.Count() / 2;
                if (category.Count() % 2 != 0)
                {
                    row++;
                }
                
                panel.RowCount = row;
                
                row = 0;
                int col = 0;
                foreach (Field field in category)
                {
                    KryptonLabel label = new KryptonLabel();
                    label.Text = field.Name;
                    
                    panel.Controls.Add(label, col, row);
                    panel.Controls.Add(AddFieldControl(field), col + 1, row++);
                    
                    if (row == panel.RowCount)
                    {
                        row = 0;
                        col = 2;
                    }
                }
                
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                
                page.Controls.Add(panel);
            }
            
            TableLayoutPanel cur_panel = (TableLayoutPanel)this.tabCategories.SelectedTab.Controls[0];
            this.SelectFirstControl(cur_panel.Controls);
        }
        
        protected override Control CreateControl(Field field)
        {
            Control result = base.CreateControl(field);
            result.Dock = DockStyle.Fill;
            result.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            if (field.IsPageField)
            {
                result.Anchor |= AnchorStyles.Bottom;
            }
            
            return result;
        }
    }
}
