//-----------------------------------------------------------------------
// <copyright file="FormSelectMultipleObjectData.Designer.cs" company="Sergey Teplyashin">
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
// <date>13.04.2011</date>
// <time>10:18</time>
// <summary>Defines the FormSelectMultipleObjectData class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class FormSelectMultipleObjectData
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectMultipleObjectData));
        	this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
        	this.listObjects = new ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox();
        	this.buttonSelectAll = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.buttonDeselectAll = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.buttonOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.buttonCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.buttonAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.SuspendLayout();
        	// 
        	// kryptonLabel1
        	// 
        	resources.ApplyResources(this.kryptonLabel1, "kryptonLabel1");
        	this.kryptonLabel1.Name = "kryptonLabel1";
        	this.kryptonLabel1.Values.Text = resources.GetString("kryptonLabel1.Values.Text");
        	// 
        	// listObjects
        	// 
        	resources.ApplyResources(this.listObjects, "listObjects");
        	this.listObjects.CheckOnClick = true;
        	this.listObjects.Name = "listObjects";
        	// 
        	// buttonSelectAll
        	// 
        	resources.ApplyResources(this.buttonSelectAll, "buttonSelectAll");
        	this.buttonSelectAll.Name = "buttonSelectAll";
        	this.buttonSelectAll.TabStop = false;
        	this.buttonSelectAll.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonSelectAll.Values.Image")));
        	this.buttonSelectAll.Values.Text = resources.GetString("buttonSelectAll.Values.Text");
        	this.buttonSelectAll.Click += new System.EventHandler(this.ButtonSelectAllClick);
        	// 
        	// buttonDeselectAll
        	// 
        	resources.ApplyResources(this.buttonDeselectAll, "buttonDeselectAll");
        	this.buttonDeselectAll.Name = "buttonDeselectAll";
        	this.buttonDeselectAll.TabStop = false;
        	this.buttonDeselectAll.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeselectAll.Values.Image")));
        	this.buttonDeselectAll.Values.Text = resources.GetString("buttonDeselectAll.Values.Text");
        	this.buttonDeselectAll.Click += new System.EventHandler(this.ButtonDeselectAllClick);
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
        	// buttonAdd
        	// 
        	resources.ApplyResources(this.buttonAdd, "buttonAdd");
        	this.buttonAdd.Name = "buttonAdd";
        	this.buttonAdd.TabStop = false;
        	this.buttonAdd.Values.Text = resources.GetString("buttonAdd.Values.Text");
        	this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
        	// 
        	// FormSelectMultipleObjectData
        	// 
        	this.AcceptButton = this.buttonOK;
        	resources.ApplyResources(this, "$this");
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.buttonCancel;
        	this.Controls.Add(this.buttonAdd);
        	this.Controls.Add(this.buttonCancel);
        	this.Controls.Add(this.buttonOK);
        	this.Controls.Add(this.buttonDeselectAll);
        	this.Controls.Add(this.buttonSelectAll);
        	this.Controls.Add(this.listObjects);
        	this.Controls.Add(this.kryptonLabel1);
        	this.DoubleBuffered = true;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "FormSelectMultipleObjectData";
        	this.ShowIcon = false;
        	this.ShowInTaskbar = false;
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonAdd;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonSelectAll;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonDeselectAll;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox listObjects;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}
