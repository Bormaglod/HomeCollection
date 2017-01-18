﻿//-----------------------------------------------------------------------
// <copyright file="FormFilter.Designer.cs" company="Sergey Teplyashin">
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
    partial class FormFolder
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFolder));
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.listClasses = new ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox();
            this.buttonOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            resources.ApplyResources(this.kryptonLabel1, "kryptonLabel1");
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Values.Text = resources.GetString("kryptonLabel1.Values.Text");
            // 
            // textName
            // 
            resources.ApplyResources(this.textName, "textName");
            this.textName.Name = "textName";
            // 
            // kryptonLabel2
            // 
            resources.ApplyResources(this.kryptonLabel2, "kryptonLabel2");
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Values.Text = resources.GetString("kryptonLabel2.Values.Text");
            // 
            // listClasses
            // 
            this.listClasses.CheckOnClick = true;
            resources.ApplyResources(this.listClasses, "listClasses");
            this.listClasses.Name = "listClasses";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Values.Image")));
            this.buttonOK.Values.Text = resources.GetString("buttonOK.Values.Text");
            this.buttonOK.Click += new System.EventHandler(this.ButtonOKClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Values.Image")));
            this.buttonCancel.Values.Text = resources.GetString("buttonCancel.Values.Text");
            // 
            // FormFolder
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.listClasses);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.kryptonLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFolder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox listClasses;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonOK;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}
