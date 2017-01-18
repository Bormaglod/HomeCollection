//-----------------------------------------------------------------------
// <copyright file="FormUserData.Designer.cs" company="Sergey Teplyashin">
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
// <date>03.05.2011</date>
// <time>14:46</time>
// <summary>Defines the FormUserData class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class FormUserData
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserData));
        	this.buttonOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.buttonCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.SuspendLayout();
        	// 
        	// buttonOK
        	// 
        	resources.ApplyResources(this.buttonOK, "buttonOK");
        	this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.buttonOK.Name = "buttonOK";
        	this.buttonOK.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Values.Image")));
        	this.buttonOK.Values.Text = resources.GetString("buttonOK.Values.Text");
        	// 
        	// buttonCancel
        	// 
        	resources.ApplyResources(this.buttonCancel, "buttonCancel");
        	this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.buttonCancel.Name = "buttonCancel";
        	this.buttonCancel.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Values.Image")));
        	this.buttonCancel.Values.Text = resources.GetString("buttonCancel.Values.Text");
        	// 
        	// FormUserData
        	// 
        	this.AcceptButton = this.buttonOK;
        	resources.ApplyResources(this, "$this");
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.buttonCancel;
        	this.Controls.Add(this.buttonCancel);
        	this.Controls.Add(this.buttonOK);
        	this.KeyPreview = true;
        	this.Name = "FormUserData";
        	this.ShowIcon = false;
        	this.ShowInTaskbar = false;
        	this.ResumeLayout(false);
        }
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonCancel;
    }
}
