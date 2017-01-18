//-----------------------------------------------------------------------
// <copyright file="ListBoxControl.Designer.cs" company="Sergey Teplyashin">
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
// <date>21.02.2011</date>
// <time>12:55</time>
// <summary>Defines the ListBoxControl class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class ListBoxControl
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the control.
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListBoxControl));
        	this.list = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
        	this.panelButtons = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
        	this.buttonDelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.buttonAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
        	((System.ComponentModel.ISupportInitialize)(this.panelButtons)).BeginInit();
        	this.panelButtons.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
        	this.kryptonPanel3.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// list
        	// 
        	resources.ApplyResources(this.list, "list");
        	this.list.Name = "list";
        	this.list.SelectedIndexChanged += new System.EventHandler(this.ListSelectedIndexChanged);
        	// 
        	// panelButtons
        	// 
        	this.panelButtons.Controls.Add(this.buttonDelete);
        	this.panelButtons.Controls.Add(this.buttonAdd);
        	resources.ApplyResources(this.panelButtons, "panelButtons");
        	this.panelButtons.Name = "panelButtons";
        	this.panelButtons.StateCommon.Color1 = System.Drawing.Color.Transparent;
        	// 
        	// buttonDelete
        	// 
        	resources.ApplyResources(this.buttonDelete, "buttonDelete");
        	this.buttonDelete.Name = "buttonDelete";
        	this.buttonDelete.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Values.Image")));
        	this.buttonDelete.Values.Text = resources.GetString("buttonDelete.Values.Text");
        	this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
        	// 
        	// buttonAdd
        	// 
        	resources.ApplyResources(this.buttonAdd, "buttonAdd");
        	this.buttonAdd.Name = "buttonAdd";
        	this.buttonAdd.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdd.Values.Image")));
        	this.buttonAdd.Values.Text = resources.GetString("buttonAdd.Values.Text");
        	this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
        	// 
        	// kryptonPanel3
        	// 
        	this.kryptonPanel3.Controls.Add(this.list);
        	resources.ApplyResources(this.kryptonPanel3, "kryptonPanel3");
        	this.kryptonPanel3.Name = "kryptonPanel3";
        	// 
        	// ListBoxControl
        	// 
        	resources.ApplyResources(this, "$this");
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.kryptonPanel3);
        	this.Controls.Add(this.panelButtons);
        	this.Name = "ListBoxControl";
        	((System.ComponentModel.ISupportInitialize)(this.panelButtons)).EndInit();
        	this.panelButtons.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
        	this.kryptonPanel3.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelButtons;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonAdd;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox list;
    }
}
