//-----------------------------------------------------------------------
// <copyright file="FormImport.Designer.cs" company="Sergey Teplyashin">
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
// <date>16.03.2011</date>
// <time>9:07</time>
// <summary>Defines the FormImport class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Core
{
    partial class FormImport
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImport));
        	this.buttonRename = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.buttonImport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.labelError = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
        	this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
        	this.gridClasses = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
        	this.ColumnClass = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
        	this.ColumnComment = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
        	this.panelInfo = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
        	this.buttonCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
        	this.kryptonPanel1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.gridClasses)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.panelInfo)).BeginInit();
        	this.panelInfo.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// buttonRename
        	// 
        	resources.ApplyResources(this.buttonRename, "buttonRename");
        	this.buttonRename.Name = "buttonRename";
        	this.buttonRename.Values.Text = resources.GetString("buttonRename.Values.Text");
        	this.buttonRename.Click += new System.EventHandler(this.ButtonRenameClick);
        	// 
        	// buttonImport
        	// 
        	resources.ApplyResources(this.buttonImport, "buttonImport");
        	this.buttonImport.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.buttonImport.Name = "buttonImport";
        	this.buttonImport.Values.Text = resources.GetString("buttonImport.Values.Text");
        	this.buttonImport.Click += new System.EventHandler(this.ButtonImportClick);
        	// 
        	// labelError
        	// 
        	resources.ApplyResources(this.labelError, "labelError");
        	this.labelError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
        	this.labelError.Name = "labelError";
        	// 
        	// kryptonPanel1
        	// 
        	resources.ApplyResources(this.kryptonPanel1, "kryptonPanel1");
        	this.kryptonPanel1.Controls.Add(this.gridClasses);
        	this.kryptonPanel1.Controls.Add(this.panelInfo);
        	this.kryptonPanel1.Name = "kryptonPanel1";
        	this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent;
        	// 
        	// gridClasses
        	// 
        	this.gridClasses.AllowUserToAddRows = false;
        	this.gridClasses.AllowUserToDeleteRows = false;
        	this.gridClasses.AllowUserToResizeColumns = false;
        	this.gridClasses.AllowUserToResizeRows = false;
        	this.gridClasses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.ColumnClass,
        	        	        	this.ColumnComment});
        	resources.ApplyResources(this.gridClasses, "gridClasses");
        	this.gridClasses.MultiSelect = false;
        	this.gridClasses.Name = "gridClasses";
        	this.gridClasses.ReadOnly = true;
        	this.gridClasses.RowHeadersVisible = false;
        	this.gridClasses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.gridClasses.StateCommon.Background.Color1 = System.Drawing.Color.Transparent;
        	this.gridClasses.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
        	this.gridClasses.SelectionChanged += new System.EventHandler(this.GridClassesSelectionChanged);
        	// 
        	// ColumnClass
        	// 
        	this.ColumnClass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.ColumnClass.FillWeight = 40.07421F;
        	resources.ApplyResources(this.ColumnClass, "ColumnClass");
        	this.ColumnClass.Name = "ColumnClass";
        	this.ColumnClass.ReadOnly = true;
        	// 
        	// ColumnComment
        	// 
        	this.ColumnComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.ColumnComment.FillWeight = 59.92579F;
        	resources.ApplyResources(this.ColumnComment, "ColumnComment");
        	this.ColumnComment.Name = "ColumnComment";
        	this.ColumnComment.ReadOnly = true;
        	// 
        	// panelInfo
        	// 
        	this.panelInfo.Controls.Add(this.labelError);
        	resources.ApplyResources(this.panelInfo, "panelInfo");
        	this.panelInfo.Name = "panelInfo";
        	this.panelInfo.StateCommon.Color1 = System.Drawing.Color.Transparent;
        	// 
        	// buttonCancel
        	// 
        	resources.ApplyResources(this.buttonCancel, "buttonCancel");
        	this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.buttonCancel.Name = "buttonCancel";
        	this.buttonCancel.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Values.Image")));
        	this.buttonCancel.Values.Text = resources.GetString("buttonCancel.Values.Text");
        	// 
        	// FormImport
        	// 
        	this.AcceptButton = this.buttonImport;
        	resources.ApplyResources(this, "$this");
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.buttonCancel;
        	this.Controls.Add(this.buttonCancel);
        	this.Controls.Add(this.kryptonPanel1);
        	this.Controls.Add(this.buttonImport);
        	this.Controls.Add(this.buttonRename);
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "FormImport";
        	this.ShowIcon = false;
        	this.ShowInTaskbar = false;
        	((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
        	this.kryptonPanel1.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.gridClasses)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.panelInfo)).EndInit();
        	this.panelInfo.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel labelError;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonImport;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonRename;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridClasses;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ColumnComment;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ColumnClass;
    }
}
