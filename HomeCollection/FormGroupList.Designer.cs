//-----------------------------------------------------------------------
// <copyright file="FormGroupList.Designer.cs" company="Sergey Teplyashin">
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
// <time>13:46</time>
// <summary>Defines the FormGroupList class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class FormGroupList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGroupList));
            ComponentLib.Controls.OutlookBarButton outlookBarButton1 = new ComponentLib.Controls.OutlookBarButton();
            ComponentLib.Controls.OutlookBarButton outlookBarButton2 = new ComponentLib.Controls.OutlookBarButton();
            ComponentLib.Controls.OutlookBarButton outlookBarButton3 = new ComponentLib.Controls.OutlookBarButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.kryptonHeader = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAddFolder = new System.Windows.Forms.ToolStripButton();
            this.toolEditFolder = new System.Windows.Forms.ToolStripButton();
            this.toolDeleteFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolGroup = new System.Windows.Forms.ToolStripSplitButton();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.treeObjects = new ComponentLib.Controls.TreeViewColumns();
            this.barCategories = new ComponentLib.Controls.OutlookBar();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.menuItemAdd.Image = global::HomeCollection.Resources.folder_add;
            this.menuItemAdd.Name = "menuItemAdd";
            resources.ApplyResources(this.menuItemAdd, "menuItemAdd");
            this.menuItemAdd.Click += new System.EventHandler(this.ToolAddFolderClick);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.Image = global::HomeCollection.Resources.folder_edit;
            this.menuItemEdit.Name = "menuItemEdit";
            resources.ApplyResources(this.menuItemEdit, "menuItemEdit");
            this.menuItemEdit.Click += new System.EventHandler(this.ToolEditFolderClick);
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Image = global::HomeCollection.Resources.folder_delete;
            this.menuItemDelete.Name = "menuItemDelete";
            resources.ApplyResources(this.menuItemDelete, "menuItemDelete");
            this.menuItemDelete.Click += new System.EventHandler(this.ToolDeleteFolderClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "folder_find.png");
            // 
            // kryptonHeader
            // 
            resources.ApplyResources(this.kryptonHeader, "kryptonHeader");
            this.kryptonHeader.Name = "kryptonHeader";
            this.kryptonHeader.StateCommon.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kryptonHeader.Values.Description = resources.GetString("kryptonHeader.Values.Description");
            this.kryptonHeader.Values.Heading = resources.GetString("kryptonHeader.Values.Heading");
            this.kryptonHeader.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonHeader.Values.Image")));
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.toolAddFolder,
                                    this.toolEditFolder,
                                    this.toolDeleteFolder,
                                    this.toolStripSeparator1,
                                    this.toolGroup});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolAddFolder
            // 
            this.toolAddFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAddFolder.Image = global::HomeCollection.Resources.folder_add;
            resources.ApplyResources(this.toolAddFolder, "toolAddFolder");
            this.toolAddFolder.Name = "toolAddFolder";
            this.toolAddFolder.Click += new System.EventHandler(this.ToolAddFolderClick);
            // 
            // toolEditFolder
            // 
            this.toolEditFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEditFolder.Image = global::HomeCollection.Resources.folder_edit;
            resources.ApplyResources(this.toolEditFolder, "toolEditFolder");
            this.toolEditFolder.Name = "toolEditFolder";
            this.toolEditFolder.Click += new System.EventHandler(this.ToolEditFolderClick);
            // 
            // toolDeleteFolder
            // 
            this.toolDeleteFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDeleteFolder.Image = global::HomeCollection.Resources.folder_delete;
            resources.ApplyResources(this.toolDeleteFolder, "toolDeleteFolder");
            this.toolDeleteFolder.Name = "toolDeleteFolder";
            this.toolDeleteFolder.Click += new System.EventHandler(this.ToolDeleteFolderClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolGroup
            // 
            this.toolGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolGroup, "toolGroup");
            this.toolGroup.Name = "toolGroup";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.treeObjects);
            this.kryptonPanel1.Controls.Add(this.barCategories);
            this.kryptonPanel1.Controls.Add(this.kryptonHeader);
            resources.ApplyResources(this.kryptonPanel1, "kryptonPanel1");
            this.kryptonPanel1.Name = "kryptonPanel1";
            // 
            // treeObjects
            // 
            this.treeObjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeObjects.ContextMenuStrip = this.contextMenuStrip1;
            resources.ApplyResources(this.treeObjects, "treeObjects");
            this.treeObjects.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeObjects.HideSelection = false;
            this.treeObjects.HotTracking = true;
            this.treeObjects.ImageList = this.imageList1;
            this.treeObjects.Name = "treeObjects";
            this.treeObjects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeObjectsAfterSelect);
            this.treeObjects.DoubleClick += new System.EventHandler(this.TreeObjectsDoubleClick);
            // 
            // barCategories
            // 
            this.barCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(169)))), ((int)(((byte)(179)))));
            this.barCategories.ButtonHeight = 30;
            outlookBarButton1.Enabled = true;
            outlookBarButton1.Image = null;
            outlookBarButton1.Tag = null;
            outlookBarButton1.Text = "";
            outlookBarButton2.Enabled = true;
            outlookBarButton2.Image = null;
            outlookBarButton2.Tag = null;
            outlookBarButton2.Text = "";
            this.barCategories.Buttons.Add(outlookBarButton1);
            this.barCategories.Buttons.Add(outlookBarButton2);
            this.barCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.barCategories, "barCategories");
            this.barCategories.GradientButtonHoverDark = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(192)))), ((int)(((byte)(91)))));
            this.barCategories.GradientButtonHoverLight = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.barCategories.GradientButtonNormalDark = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.barCategories.GradientButtonNormalLight = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.barCategories.GradientButtonSelectedDark = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(150)))), ((int)(((byte)(21)))));
            this.barCategories.GradientButtonSelectedLight = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            this.barCategories.Name = "barCategories";
            outlookBarButton3.Enabled = true;
            outlookBarButton3.Image = null;
            outlookBarButton3.Tag = null;
            outlookBarButton3.Text = "";
            this.barCategories.SelectedButton = outlookBarButton3;
            this.barCategories.SelectButton += new ComponentLib.Controls.OutlookBar.ButtonSelectEventHandler(this.BarCategoriesSelectButton);
            // 
            // FormGroupList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.toolStrip1);
            this.HideOnClose = true;
            this.Name = "FormGroupList";
            this.TabText = "";
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private ComponentLib.Controls.OutlookBar barCategories;
        private System.Windows.Forms.ToolStripMenuItem menuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem menuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem menuItemAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ComponentLib.Controls.TreeViewColumns treeObjects;
        private System.Windows.Forms.ToolStripButton toolAddFolder;
        private System.Windows.Forms.ToolStripButton toolEditFolder;
        private System.Windows.Forms.ToolStripButton toolDeleteFolder;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ImageList imageList1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader;
    }
}
