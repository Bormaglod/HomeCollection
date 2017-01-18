//-----------------------------------------------------------------------
// <copyright file="FormConfig.Designer.cs" company="Sergey Teplyashin">
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
// <time>14:57</time>
// <summary>Defines the FormConfig class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class FormConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfig));
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.treeClasses = new ComponentLib.Controls.TreeViewColumns();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemCreateClass = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDeleteClass = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemCreateField = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDeleteField = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemUp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemImport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolButtonCreateClass = new System.Windows.Forms.ToolStripButton();
            this.toolButtonDeleteClass = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonCreateField = new System.Windows.Forms.ToolStripButton();
            this.toolButtonDeleteField = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonUp = new System.Windows.Forms.ToolStripButton();
            this.toolButtonDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolComboCategory = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonImport = new System.Windows.Forms.ToolStripSplitButton();
            this.toolButtonExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonAllClasses = new System.Windows.Forms.ToolStripButton();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.importFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.exportFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
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
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.treeClasses);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.propertyGrid1);
            // 
            // treeClasses
            // 
            this.treeClasses.ContextMenuStrip = this.contextMenuStrip1;
            resources.ApplyResources(this.treeClasses, "treeClasses");
            this.treeClasses.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeClasses.HideSelection = false;
            this.treeClasses.HotTracking = true;
            this.treeClasses.ImageList = this.imageList1;
            this.treeClasses.Name = "treeClasses";
            this.treeClasses.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeClassesAfterSelect);
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.menuItemCreateClass,
                                    this.menuItemDeleteClass,
                                    this.toolStripSeparator4,
                                    this.menuItemCreateField,
                                    this.menuItemDeleteField,
                                    this.toolStripSeparator8,
                                    this.menuItemUp,
                                    this.menuItemDown,
                                    this.toolStripSeparator5,
                                    this.menuItemCategory,
                                    this.toolStripSeparator6,
                                    this.menuItemImport,
                                    this.menuItemExport});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1Opening);
            // 
            // menuItemCreateClass
            // 
            this.menuItemCreateClass.Image = global::HomeCollection.Resources.class_add;
            this.menuItemCreateClass.Name = "menuItemCreateClass";
            resources.ApplyResources(this.menuItemCreateClass, "menuItemCreateClass");
            this.menuItemCreateClass.Click += new System.EventHandler(this.ToolButtonCreateClassClick);
            // 
            // menuItemDeleteClass
            // 
            this.menuItemDeleteClass.Image = global::HomeCollection.Resources.class_delete;
            this.menuItemDeleteClass.Name = "menuItemDeleteClass";
            resources.ApplyResources(this.menuItemDeleteClass, "menuItemDeleteClass");
            this.menuItemDeleteClass.Click += new System.EventHandler(this.ToolButtonDeleteClassClick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // menuItemCreateField
            // 
            this.menuItemCreateField.Image = global::HomeCollection.Resources.property_add;
            this.menuItemCreateField.Name = "menuItemCreateField";
            resources.ApplyResources(this.menuItemCreateField, "menuItemCreateField");
            this.menuItemCreateField.Click += new System.EventHandler(this.ToolButtonCreateFieldClick);
            // 
            // menuItemDeleteField
            // 
            this.menuItemDeleteField.Image = global::HomeCollection.Resources.property_delete;
            this.menuItemDeleteField.Name = "menuItemDeleteField";
            resources.ApplyResources(this.menuItemDeleteField, "menuItemDeleteField");
            this.menuItemDeleteField.Click += new System.EventHandler(this.ToolButtonDeleteFieldClick);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // menuItemUp
            // 
            this.menuItemUp.Image = global::HomeCollection.Resources.arrow_up;
            this.menuItemUp.Name = "menuItemUp";
            resources.ApplyResources(this.menuItemUp, "menuItemUp");
            // 
            // menuItemDown
            // 
            this.menuItemDown.Image = global::HomeCollection.Resources.arrow_down;
            this.menuItemDown.Name = "menuItemDown";
            resources.ApplyResources(this.menuItemDown, "menuItemDown");
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // menuItemCategory
            // 
            this.menuItemCategory.Name = "menuItemCategory";
            resources.ApplyResources(this.menuItemCategory, "menuItemCategory");
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // menuItemImport
            // 
            this.menuItemImport.Image = global::HomeCollection.Resources.class_import;
            this.menuItemImport.Name = "menuItemImport";
            resources.ApplyResources(this.menuItemImport, "menuItemImport");
            // 
            // menuItemExport
            // 
            this.menuItemExport.Image = global::HomeCollection.Resources.class_export;
            this.menuItemExport.Name = "menuItemExport";
            resources.ApplyResources(this.menuItemExport, "menuItemExport");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "class.png");
            this.imageList1.Images.SetKeyName(2, "property.png");
            this.imageList1.Images.SetKeyName(3, "class_protect.png");
            // 
            // propertyGrid1
            // 
            resources.ApplyResources(this.propertyGrid1, "propertyGrid1");
            this.propertyGrid1.Name = "propertyGrid1";
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.toolButtonCreateClass,
                                    this.toolButtonDeleteClass,
                                    this.toolStripSeparator1,
                                    this.toolButtonCreateField,
                                    this.toolButtonDeleteField,
                                    this.toolStripSeparator2,
                                    this.toolButtonUp,
                                    this.toolButtonDown,
                                    this.toolStripSeparator7,
                                    this.toolStripLabel1,
                                    this.toolComboCategory,
                                    this.toolStripSeparator3,
                                    this.toolButtonImport,
                                    this.toolButtonExport,
                                    this.toolStripSeparator9,
                                    this.toolButtonAllClasses});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolButtonCreateClass
            // 
            this.toolButtonCreateClass.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonCreateClass.Image = global::HomeCollection.Resources.class_add;
            resources.ApplyResources(this.toolButtonCreateClass, "toolButtonCreateClass");
            this.toolButtonCreateClass.Name = "toolButtonCreateClass";
            this.toolButtonCreateClass.Click += new System.EventHandler(this.ToolButtonCreateClassClick);
            // 
            // toolButtonDeleteClass
            // 
            this.toolButtonDeleteClass.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonDeleteClass.Image = global::HomeCollection.Resources.class_delete;
            resources.ApplyResources(this.toolButtonDeleteClass, "toolButtonDeleteClass");
            this.toolButtonDeleteClass.Name = "toolButtonDeleteClass";
            this.toolButtonDeleteClass.Click += new System.EventHandler(this.ToolButtonDeleteClassClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolButtonCreateField
            // 
            this.toolButtonCreateField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonCreateField.Image = global::HomeCollection.Resources.property_add;
            resources.ApplyResources(this.toolButtonCreateField, "toolButtonCreateField");
            this.toolButtonCreateField.Name = "toolButtonCreateField";
            this.toolButtonCreateField.Click += new System.EventHandler(this.ToolButtonCreateFieldClick);
            // 
            // toolButtonDeleteField
            // 
            this.toolButtonDeleteField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonDeleteField.Image = global::HomeCollection.Resources.property_delete;
            resources.ApplyResources(this.toolButtonDeleteField, "toolButtonDeleteField");
            this.toolButtonDeleteField.Name = "toolButtonDeleteField";
            this.toolButtonDeleteField.Click += new System.EventHandler(this.ToolButtonDeleteFieldClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolButtonUp
            // 
            this.toolButtonUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonUp.Image = global::HomeCollection.Resources.arrow_up;
            resources.ApplyResources(this.toolButtonUp, "toolButtonUp");
            this.toolButtonUp.Name = "toolButtonUp";
            this.toolButtonUp.Click += new System.EventHandler(this.ToolButtonUpClick);
            // 
            // toolButtonDown
            // 
            this.toolButtonDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonDown.Image = global::HomeCollection.Resources.arrow_down;
            resources.ApplyResources(this.toolButtonDown, "toolButtonDown");
            this.toolButtonDown.Name = "toolButtonDown";
            this.toolButtonDown.Click += new System.EventHandler(this.ToolButtonDownClick);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
            // 
            // toolComboCategory
            // 
            this.toolComboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolComboCategory.Name = "toolComboCategory";
            resources.ApplyResources(this.toolComboCategory, "toolComboCategory");
            this.toolComboCategory.SelectedIndexChanged += new System.EventHandler(this.ToolComboCategorySelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolButtonImport
            // 
            this.toolButtonImport.Image = global::HomeCollection.Resources.class_import;
            resources.ApplyResources(this.toolButtonImport, "toolButtonImport");
            this.toolButtonImport.Name = "toolButtonImport";
            this.toolButtonImport.ButtonClick += new System.EventHandler(this.ToolButtonImportButtonClick);
            // 
            // toolButtonExport
            // 
            this.toolButtonExport.Image = global::HomeCollection.Resources.class_export;
            resources.ApplyResources(this.toolButtonExport, "toolButtonExport");
            this.toolButtonExport.Name = "toolButtonExport";
            this.toolButtonExport.Click += new System.EventHandler(this.ToolButtonExportClick);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // toolButtonAllClasses
            // 
            this.toolButtonAllClasses.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolButtonAllClasses, "toolButtonAllClasses");
            this.toolButtonAllClasses.Name = "toolButtonAllClasses";
            this.toolButtonAllClasses.Click += new System.EventHandler(this.ToolButtonAllClassesClick);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonSplitContainer1);
            resources.ApplyResources(this.kryptonPanel1, "kryptonPanel1");
            this.kryptonPanel1.Name = "kryptonPanel1";
            // 
            // importFileDialog
            // 
            this.importFileDialog.DefaultExt = "xml";
            resources.ApplyResources(this.importFileDialog, "importFileDialog");
            // 
            // exportFileDialog
            // 
            this.exportFileDialog.DefaultExt = "xml";
            resources.ApplyResources(this.exportFileDialog, "exportFileDialog");
            // 
            // FormConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.toolStrip1);
            this.HideOnClose = true;
            this.Name = "FormConfig";
            this.TabText = "";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton toolButtonAllClasses;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.SaveFileDialog exportFileDialog;
        private System.Windows.Forms.OpenFileDialog importFileDialog;
        private System.Windows.Forms.ToolStripMenuItem menuItemDown;
        private System.Windows.Forms.ToolStripMenuItem menuItemUp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolButtonDown;
        private System.Windows.Forms.ToolStripButton toolButtonUp;
        private System.Windows.Forms.ToolStripMenuItem menuItemExport;
        private System.Windows.Forms.ToolStripMenuItem menuItemImport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem menuItemCategory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menuItemDeleteField;
        private System.Windows.Forms.ToolStripMenuItem menuItemCreateField;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuItemDeleteClass;
        private System.Windows.Forms.ToolStripMenuItem menuItemCreateClass;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolButtonImport;
        private System.Windows.Forms.ToolStripButton toolButtonExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolButtonCreateClass;
        private System.Windows.Forms.ToolStripButton toolButtonDeleteClass;
        private System.Windows.Forms.ToolStripButton toolButtonCreateField;
        private System.Windows.Forms.ToolStripButton toolButtonDeleteField;
        private System.Windows.Forms.ToolStripComboBox toolComboCategory;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentLib.Controls.TreeViewColumns treeClasses;
    }
}
