//-----------------------------------------------------------------------
// <copyright file="FormProperty.cs" company="Sergey Teplyashin">
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
// <date>22.11.2010</date>
// <time>10:09</time>
// <summary>Defines the FormProperty class.</summary>
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
    
    public partial class FormProperty : KryptonForm
    {
        private Information info;
        
        public FormProperty()
        {
            this.InitializeComponent();
            
            this.textName.Text = System.Environment.UserName;
            
            this.info = new Information();
            this.info.Date = DateTime.Today;
        }
        
        public Information Info
        {
            get
            {
                return this.info;
            }
            
            set
            {
                this.info = value;
                this.FillControls();
            }
        }
        
        public string FileName
        {
            get { return this.textFileName.Text; }
            set { this.textFileName.Text = value; }
        }
        
        private void FillControls()
        {
            this.textHeader.Text = this.info.Title;
            this.textName.Text = this.info.Author;
            this.textEmail.Text = this.info.Email;
            this.textComment.Text = this.info.Comment;
            this.UpdateComboBox(this.comboCategory, this.info.Category);
            this.UpdateComboBox(this.comboLicense, this.info.License);
            this.textFileName.Enabled = false;
            this.groupCommon.Size = new Size(this.groupCommon.Size.Width, this.groupCommon.Size.Height + 123);
            this.MinimumSize = new Size(this.MinimumSize.Width, this.MinimumSize.Height - 123);
            this.Size = new Size(this.Size.Width, this.Size.Height - 123);
        }
        
        private void UpdateComboBox(KryptonComboBox box, string findText)
        {
            // FIXME: При установке текста в комбо он выделяется, а не должен (причем в стандартном ComboBox такого нет)
            if (string.IsNullOrEmpty(findText))
            {
                box.Text = string.Empty;
            }
            else
            {
                int c = box.FindString(findText);
                if (c != -1)
                {
                    box.SelectedIndex = c;
                    box.SelectionStart = findText.Length;
                    box.SelectionLength = box.Text.Length - box.SelectionStart;
                }
                else
                {
                    box.Text = findText;
                }
            }
        }
        
        private void FillInfo()
        {
            this.info.Title = this.textHeader.Text;
            this.info.Author = this.textName.Text;
            this.info.Email = this.textEmail.Text;
            this.info.Comment = this.textComment.Text;
            this.info.Category = this.comboCategory.Text;
            this.info.License = this.comboLicense.Text;
        }
        
        private void ButtonSpecAny1Click(object sender, EventArgs e)
        {
            this.comboCategory.Text = string.Empty;
        }
        
        private void ButtonSpecAny2Click(object sender, EventArgs e)
        {
            this.comboLicense.Text = string.Empty;
        }
        
        private void ButtonSpecAny3Click(object sender, EventArgs e)
        {
            this.textFileName.Text = string.Empty;
        }
        
        private void ButtonSpecAny4Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textFileName.Text = this.openFileDialog1.FileName;
            }
        }
        
        private void ButtonOKClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.FileName))
            {
                KryptonMessageBox.Show(Strings.ReguiredFileName, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
            else
            {
                this.FillInfo();
            }
        }
    }
}
