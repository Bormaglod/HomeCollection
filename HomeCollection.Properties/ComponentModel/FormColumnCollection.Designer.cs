//-----------------------------------------------------------------------
// <copyright file="FormColumnCollection.Designer.cs" company="Sergey Teplyashin">
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
// <date>09.02.2011</date>
// <time>14:42</time>
// <summary>Defines the FormColumnCollection class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Properties
{
    partial class FormColumnCollection
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormColumnCollection));
        	this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
        	this.listColumns = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
        	this.buttonAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.buttonDelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.buttonUp = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.buttonDown = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.propertyColumn = new System.Windows.Forms.PropertyGrid();
        	this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
        	this.buttonOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.buttonCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.SuspendLayout();
        	// 
        	// kryptonLabel1
        	// 
        	this.kryptonLabel1.AccessibleDescription = null;
        	this.kryptonLabel1.AccessibleName = null;
        	resources.ApplyResources(this.kryptonLabel1, "kryptonLabel1");
        	this.kryptonLabel1.BackgroundImage = null;
        	this.kryptonLabel1.Font = null;
        	this.kryptonLabel1.Name = "kryptonLabel1";
        	this.kryptonLabel1.Values.ExtraText = resources.GetString("kryptonLabel1.Values.ExtraText");
        	this.kryptonLabel1.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel1.Values.ImageTransparentColor")));
        	this.kryptonLabel1.Values.Text = resources.GetString("kryptonLabel1.Values.Text");
        	// 
        	// listColumns
        	// 
        	this.listColumns.AccessibleDescription = null;
        	this.listColumns.AccessibleName = null;
        	resources.ApplyResources(this.listColumns, "listColumns");
        	this.listColumns.BackgroundImage = null;
        	this.listColumns.Name = "listColumns";
        	this.listColumns.SelectedIndexChanged += new System.EventHandler(this.ListColumnsSelectedIndexChanged);
        	// 
        	// buttonAdd
        	// 
        	this.buttonAdd.AccessibleDescription = null;
        	this.buttonAdd.AccessibleName = null;
        	resources.ApplyResources(this.buttonAdd, "buttonAdd");
        	this.buttonAdd.BackgroundImage = null;
        	this.buttonAdd.Font = null;
        	this.buttonAdd.Name = "buttonAdd";
        	this.buttonAdd.Values.ExtraText = resources.GetString("buttonAdd.Values.ExtraText");
        	this.buttonAdd.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdd.Values.Image")));
        	this.buttonAdd.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonAdd.Values.ImageTransparentColor")));
        	this.buttonAdd.Values.Text = resources.GetString("buttonAdd.Values.Text");
        	this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
        	// 
        	// buttonDelete
        	// 
        	this.buttonDelete.AccessibleDescription = null;
        	this.buttonDelete.AccessibleName = null;
        	resources.ApplyResources(this.buttonDelete, "buttonDelete");
        	this.buttonDelete.BackgroundImage = null;
        	this.buttonDelete.Font = null;
        	this.buttonDelete.Name = "buttonDelete";
        	this.buttonDelete.Values.ExtraText = resources.GetString("buttonDelete.Values.ExtraText");
        	this.buttonDelete.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Values.Image")));
        	this.buttonDelete.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonDelete.Values.ImageTransparentColor")));
        	this.buttonDelete.Values.Text = resources.GetString("buttonDelete.Values.Text");
        	this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
        	// 
        	// buttonUp
        	// 
        	this.buttonUp.AccessibleDescription = null;
        	this.buttonUp.AccessibleName = null;
        	resources.ApplyResources(this.buttonUp, "buttonUp");
        	this.buttonUp.BackgroundImage = null;
        	this.buttonUp.Font = null;
        	this.buttonUp.Name = "buttonUp";
        	this.buttonUp.Values.ExtraText = resources.GetString("buttonUp.Values.ExtraText");
        	this.buttonUp.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonUp.Values.Image")));
        	this.buttonUp.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonUp.Values.ImageTransparentColor")));
        	this.buttonUp.Values.Text = resources.GetString("buttonUp.Values.Text");
        	this.buttonUp.Click += new System.EventHandler(this.ButtonUpClick);
        	// 
        	// buttonDown
        	// 
        	this.buttonDown.AccessibleDescription = null;
        	this.buttonDown.AccessibleName = null;
        	resources.ApplyResources(this.buttonDown, "buttonDown");
        	this.buttonDown.BackgroundImage = null;
        	this.buttonDown.Font = null;
        	this.buttonDown.Name = "buttonDown";
        	this.buttonDown.Values.ExtraText = resources.GetString("buttonDown.Values.ExtraText");
        	this.buttonDown.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonDown.Values.Image")));
        	this.buttonDown.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonDown.Values.ImageTransparentColor")));
        	this.buttonDown.Values.Text = resources.GetString("buttonDown.Values.Text");
        	this.buttonDown.Click += new System.EventHandler(this.ButtonDownClick);
        	// 
        	// propertyColumn
        	// 
        	this.propertyColumn.AccessibleDescription = null;
        	this.propertyColumn.AccessibleName = null;
        	resources.ApplyResources(this.propertyColumn, "propertyColumn");
        	this.propertyColumn.BackgroundImage = null;
        	this.propertyColumn.Font = null;
        	this.propertyColumn.Name = "propertyColumn";
        	// 
        	// kryptonLabel2
        	// 
        	this.kryptonLabel2.AccessibleDescription = null;
        	this.kryptonLabel2.AccessibleName = null;
        	resources.ApplyResources(this.kryptonLabel2, "kryptonLabel2");
        	this.kryptonLabel2.BackgroundImage = null;
        	this.kryptonLabel2.Font = null;
        	this.kryptonLabel2.Name = "kryptonLabel2";
        	this.kryptonLabel2.Values.ExtraText = resources.GetString("kryptonLabel2.Values.ExtraText");
        	this.kryptonLabel2.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel2.Values.ImageTransparentColor")));
        	this.kryptonLabel2.Values.Text = resources.GetString("kryptonLabel2.Values.Text");
        	// 
        	// buttonOK
        	// 
        	this.buttonOK.AccessibleDescription = null;
        	this.buttonOK.AccessibleName = null;
        	resources.ApplyResources(this.buttonOK, "buttonOK");
        	this.buttonOK.BackgroundImage = null;
        	this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.buttonOK.Font = null;
        	this.buttonOK.Name = "buttonOK";
        	this.buttonOK.Values.ExtraText = resources.GetString("buttonOK.Values.ExtraText");
        	this.buttonOK.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Values.Image")));
        	this.buttonOK.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonOK.Values.ImageTransparentColor")));
        	this.buttonOK.Values.Text = resources.GetString("buttonOK.Values.Text");
        	this.buttonOK.Click += new System.EventHandler(this.ButtonOKClick);
        	// 
        	// buttonCancel
        	// 
        	this.buttonCancel.AccessibleDescription = null;
        	this.buttonCancel.AccessibleName = null;
        	resources.ApplyResources(this.buttonCancel, "buttonCancel");
        	this.buttonCancel.BackgroundImage = null;
        	this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.buttonCancel.Font = null;
        	this.buttonCancel.Name = "buttonCancel";
        	this.buttonCancel.Values.ExtraText = resources.GetString("buttonCancel.Values.ExtraText");
        	this.buttonCancel.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Values.Image")));
        	this.buttonCancel.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonCancel.Values.ImageTransparentColor")));
        	this.buttonCancel.Values.Text = resources.GetString("buttonCancel.Values.Text");
        	// 
        	// FormColumnCollection
        	// 
        	this.AcceptButton = this.buttonOK;
        	this.AccessibleDescription = null;
        	this.AccessibleName = null;
        	resources.ApplyResources(this, "$this");
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackgroundImage = null;
        	this.CancelButton = this.buttonCancel;
        	this.Controls.Add(this.buttonCancel);
        	this.Controls.Add(this.buttonOK);
        	this.Controls.Add(this.kryptonLabel2);
        	this.Controls.Add(this.propertyColumn);
        	this.Controls.Add(this.buttonDown);
        	this.Controls.Add(this.buttonUp);
        	this.Controls.Add(this.buttonDelete);
        	this.Controls.Add(this.buttonAdd);
        	this.Controls.Add(this.listColumns);
        	this.Controls.Add(this.kryptonLabel1);
        	this.DoubleBuffered = true;
        	this.Font = null;
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Icon = null;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "FormColumnCollection";
        	this.ShowIcon = false;
        	this.ShowInTaskbar = false;
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private ComponentFactory.Krypton.Toolkit.KryptonListBox listColumns;
        private System.Windows.Forms.PropertyGrid propertyColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonOK;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonDown;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonUp;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonAdd;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}
