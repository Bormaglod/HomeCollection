//-----------------------------------------------------------------------
// <copyright file="FormFilter.cs" company="Sergey Teplyashin">
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
// <date>11.02.2011</date>
// <time>15:05</time>
// <summary>Defines the FormFilter class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using HomeCollection.Data;
    
    #endregion
    
    /// <summary>
    /// Description of FormFolder.
    /// </summary>
    public partial class FormFolder : KryptonForm
    {
        private Database database;
        private string cat;
        private bool newFolder;
        
        public FormFolder()
        {
            InitializeComponent();
        }
        
        public Database Database
        {
            get { return this.database; }
            set { this.database = value; }
        }
        
        public Folder Show(Folder folder, string category)
        {
            this.newFolder = folder == null;
            this.cat = category;
            this.CreateListClasses();
            if (folder != null)
            {
                textName.Text = folder.Name;
                foreach (ObjectClass obj in folder.Classes)
                {
                    if (obj.CreatingObjects)
                    {
                        listClasses.SetItemChecked(listClasses.Items.IndexOf(obj), true);
                    }
                }
            }
            
            if (ShowDialog() == DialogResult.OK)
            {
                if (folder == null)
                {
                    folder = Database.Folders.Create(textName.Text, this.cat);
                }
                else
                {
                    folder.Name = textName.Text;
                    folder.ClearClasses();
                }
                
                folder.AddRangeClass(listClasses.CheckedItems);
                this.Database.Folders.Update(folder);
                
                return folder;
            }
            else
            {
                return null;
            }
        }
        
        private void CreateListClasses()
        {
            foreach (ObjectClass obj in this.database.Classes.GetClasses(this.cat))
            {
                listClasses.Items.Add(obj);
            }
        }
        
        private void ButtonOKClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textName.Text))
            {
                KryptonMessageBox.Show(Strings.UnknownNameFolder, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
            else if (this.database.Folders.Contains(this.textName.Text, this.cat) && this.newFolder)
            {
                KryptonMessageBox.Show(Strings.UniqueNameFolder, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
            else if (this.listClasses.CheckedItems.Count == 0)
            {
                KryptonMessageBox.Show(Strings.NotSelectedClassInFolder, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }
    }
}
