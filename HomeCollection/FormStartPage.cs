//-----------------------------------------------------------------------
// <copyright file="FormStartPage.cs" company="Sergey Teplyashin">
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
// <date>26.01.2011</date>
// <time>13:13</time>
// <summary>Defines the FormStartPage class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    //using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    //using Db4objects.Db4o;
    //using Db4objects.Db4o.Linq;
    using ComponentLib.Core;
    using HomeCollection.Core;
    using HomeCollection.Data;
    
    #endregion

    /// <summary>
    /// Description of FormStartPage.
    /// </summary>
    public partial class FormStartPage : ToolWindow
    {
        private ObjectAccessCollection<File> files;
        
        public FormStartPage(IApplication app, Database data, ObjectAccessCollection<File> lastFiles) : base(app, data)
        {
            InitializeComponent();
        
            this.files = lastFiles;
            this.CreateLastFilesButtons();
        }
        
        public void CreateLastFilesButtons()
        {
            this.dataLastFiles.Rows.Clear();
            Stack<File> deleting = new Stack<File>();
            foreach (File f in this.files)
            {
                if (System.IO.File.Exists(f.FileName))
                {
                    int row = this.dataLastFiles.Rows.Add();
                    this.dataLastFiles.Rows[row].Cells["ColumnName"].Value = f.ShortFileName;
                    this.dataLastFiles.Rows[row].Cells["ColumnOpened"].Value = f.AccessTime.ToString();
                    this.dataLastFiles.Rows[row].Cells["ColumnLocation"].Value = f.FileName;
                    this.dataLastFiles.Rows[row].Cells["ColumnAction"].Value = Strings.Open;
                    this.dataLastFiles.Rows[row].Tag = f;
                }
                else
                {
                    deleting.Push(f);
                }
            }
            
            while (deleting.Count > 0)
            {
                this.files.Remove(deleting.Pop());
            }
        }
        
        private void ButtonCreateClick(object sender, EventArgs e)
        {
            App.CreateDatabase();
        }
        
        private void ButtonOpenClick(object sender, EventArgs e)
        {
            App.OpenDatabase(null);
        }
        
        private void DataLastFilesCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                File file = (File)this.dataLastFiles.Rows[e.RowIndex].Tag;
                App.OpenDatabase(file);
            }
        }
    }
}
