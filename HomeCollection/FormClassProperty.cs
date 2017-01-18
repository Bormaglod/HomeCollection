//-----------------------------------------------------------------------
// <copyright file="FormClassProperty.cs" company="Sergey Teplyashin">
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
// <date>10.02.2011</date>
// <time>11:32</time>
// <summary>Defines the FormClassProperty class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using HomeCollection.Data;
    
    #endregion
    
    /// <summary>
    /// Description of FormClassProperty.
    /// </summary>
    public partial class FormClassProperty : KryptonForm
    {
        private Database database;
        
        public FormClassProperty()
        {
            this.InitializeComponent();
        }
        
        public Database Database
        {
            get
            {
                return this.database;
            }
            
            set
            {
                this.database = value;
                this.CreateObjectClassList();
            
                foreach (string s in this.database.Classes.ClassCategories)
                {
                    this.comboCategory.Items.Add(s);
                }
            }
        }
        
        public ObjectClass GetNewClass()
        {
            if (ShowDialog() == DialogResult.OK)
            {
                return this.database.Classes.Create(this.textName.Text, (ObjectClass)this.comboBase.SelectedItem, this.comboCategory.Text);
            }
            else
            {
                return null;
            }
        }
        
        private void CreateObjectClassList()
        {
            IEnumerable<ObjectClass> classes;
            if (string.IsNullOrEmpty(this.comboCategory.Text))
            {
                classes = this.database.Classes.Collection;
            }
            else
            {
                classes = this.database.Classes.GetClasses(this.comboCategory.Text);
            }
            
            this.comboBase.Items.Clear();
            foreach (ObjectClass o in classes)
            {
                this.comboBase.Items.Add(o);
            }
        }
        
        private void ButtonOKClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textName.Text) || string.IsNullOrEmpty(this.comboCategory.Text))
            {
                DialogResult = DialogResult.None;
            }
        }
        
        private void ButtonSpecAny1Click(object sender, EventArgs e)
        {
            this.comboBase.SelectedIndex = -1;
            this.CreateObjectClassList();
        }
        
        private void ButtonSpecAny2Click(object sender, EventArgs e)
        {
            this.comboCategory.Text = string.Empty;
            this.CreateObjectClassList();
        }
        
        private void ComboBaseSelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (this.comboBase.SelectedIndex == -1)
            {
                this.comboCategory.Enabled = true;
            }
            else
            {
                this.comboCategory.SelectedItem = ((ObjectClass)this.comboBase.SelectedItem).Category;
                this.comboCategory.Enabled = false;
            }*/
        }
        
        private void ComboCategoryTextUpdate(object sender, EventArgs e)
        {
            this.CreateObjectClassList();
        }
        
        private void ComboCategorySelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBase.SelectedIndex == -1)
            {
                this.CreateObjectClassList();
            }
        }
    }
}
