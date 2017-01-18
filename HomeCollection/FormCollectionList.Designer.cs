//-----------------------------------------------------------------------
// <copyright file="FormCollectionList.Designer.cs" company="Sergey Teplyashin">
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
// <date>02.02.2011</date>
// <time>13:47</time>
// <summary>Defines the FormCollectionList class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class FormCollectionList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCollectionList));
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.gridData = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.ColumnName = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonBack = new System.Windows.Forms.ToolStripButton();
            this.buttonForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonAdd = new System.Windows.Forms.ToolStripButton();
            this.buttonEdit = new System.Windows.Forms.ToolStripButton();
            this.buttonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolImport = new System.Windows.Forms.ToolStripSplitButton();
            this.toolExport = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPreview = new System.Windows.Forms.ToolStripButton();
            this.toolPrint = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.kryptonSplitContainer1, "kryptonSplitContainer1");
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.gridData);
            // 
            // gridData
            // 
            this.gridData.AllowUserToAddRows = false;
            this.gridData.AllowUserToDeleteRows = false;
            this.gridData.AllowUserToOrderColumns = true;
            this.gridData.AllowUserToResizeColumns = false;
            this.gridData.AllowUserToResizeRows = false;
            this.gridData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                                    this.ColumnName});
            this.gridData.ContextMenuStrip = this.contextMenuStrip1;
            resources.ApplyResources(this.gridData, "gridData");
            this.gridData.HideOuterBorders = true;
            this.gridData.MultiSelect = false;
            this.gridData.Name = "gridData";
            this.gridData.ReadOnly = true;
            this.gridData.RowHeadersVisible = false;
            this.gridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDataCellDoubleClick);
            this.gridData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridDataKeyDown);
            this.gridData.SelectionChanged += new System.EventHandler(this.GridDataSelectionChanged);
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.ColumnName, "ColumnName");
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.menuItemAdd,
                                    this.menuItemEdit,
                                    this.menuItemDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // menuItemAdd
            // 
            this.menuItemAdd.Image = global::HomeCollection.Resources.page_white_add;
            this.menuItemAdd.Name = "menuItemAdd";
            resources.ApplyResources(this.menuItemAdd, "menuItemAdd");
            this.menuItemAdd.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.Image = global::HomeCollection.Resources.page_white_edit;
            this.menuItemEdit.Name = "menuItemEdit";
            resources.ApplyResources(this.menuItemEdit, "menuItemEdit");
            this.menuItemEdit.Click += new System.EventHandler(this.ButtonEditClick);
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Image = global::HomeCollection.Resources.page_white_delete;
            this.menuItemDelete.Name = "menuItemDelete";
            resources.ApplyResources(this.menuItemDelete, "menuItemDelete");
            this.menuItemDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.buttonBack,
                                    this.buttonForward,
                                    this.toolStripSeparator3,
                                    this.buttonAdd,
                                    this.buttonEdit,
                                    this.buttonDelete,
                                    this.toolStripSeparator1,
                                    this.toolImport,
                                    this.toolExport,
                                    this.toolStripSeparator2,
                                    this.toolPreview,
                                    this.toolPrint});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // buttonBack
            // 
            this.buttonBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonBack.Image = global::HomeCollection.Resources._1302748602_gtk_go_back_ltr;
            resources.ApplyResources(this.buttonBack, "buttonBack");
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Click += new System.EventHandler(this.ButtonBackClick);
            // 
            // buttonForward
            // 
            this.buttonForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonForward.Image = global::HomeCollection.Resources._1302748619_gtk_go_back_rtl;
            resources.ApplyResources(this.buttonForward, "buttonForward");
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Click += new System.EventHandler(this.ButtonForwardClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // buttonAdd
            // 
            this.buttonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAdd.Image = global::HomeCollection.Resources.page_white_add;
            resources.ApplyResources(this.buttonAdd, "buttonAdd");
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // buttonEdit
            // 
            this.buttonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEdit.Image = global::HomeCollection.Resources.page_white_edit;
            resources.ApplyResources(this.buttonEdit, "buttonEdit");
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Click += new System.EventHandler(this.ButtonEditClick);
            // 
            // buttonDelete
            // 
            this.buttonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDelete.Image = global::HomeCollection.Resources.page_white_delete;
            resources.ApplyResources(this.buttonDelete, "buttonDelete");
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolImport
            // 
            this.toolImport.Image = global::HomeCollection.Resources.table_import;
            resources.ApplyResources(this.toolImport, "toolImport");
            this.toolImport.Name = "toolImport";
            // 
            // toolExport
            // 
            this.toolExport.Image = global::HomeCollection.Resources.table_export;
            resources.ApplyResources(this.toolExport, "toolExport");
            this.toolExport.Name = "toolExport";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolPreview
            // 
            this.toolPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolPreview, "toolPreview");
            this.toolPreview.Image = global::HomeCollection.Resources.report;
            this.toolPreview.Name = "toolPreview";
            // 
            // toolPrint
            // 
            this.toolPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolPrint, "toolPrint");
            this.toolPrint.Image = global::HomeCollection.Resources.printer;
            this.toolPrint.Name = "toolPrint";
            // 
            // FormCollectionList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.HideOnClose = true;
            this.Name = "FormCollectionList";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripButton buttonForward;
        private System.Windows.Forms.ToolStripButton buttonBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem menuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem menuItemAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripButton toolPrint;
        private System.Windows.Forms.ToolStripButton toolPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton toolExport;
        private System.Windows.Forms.ToolStripSplitButton toolImport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonDelete;
        private System.Windows.Forms.ToolStripButton buttonEdit;
        private System.Windows.Forms.ToolStripButton buttonAdd;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridData;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ColumnName;
    }
}
