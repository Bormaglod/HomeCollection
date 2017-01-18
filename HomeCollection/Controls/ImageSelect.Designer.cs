//-----------------------------------------------------------------------
// <copyright file="ImageSelect.Designer.cs" company="Sergey Teplyashin">
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
// <time>10:13</time>
// <summary>Defines the ImageSelect class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class ImageSelect
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageSelect));
        	this.groupImage = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
        	this.buttonSpecHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
        	this.buttonSpecHeaderGroup2 = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
        	this.pictureBox1 = new System.Windows.Forms.PictureBox();
        	this.buttonSelectImage = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.buttonClearImage = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.panelButtons = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
        	this.buttonAddFromInternet = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.buttonAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
        	this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
        	this.panelImages = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
        	this.gridImages = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
        	this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
        	this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        	((System.ComponentModel.ISupportInitialize)(this.groupImage)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.groupImage.Panel)).BeginInit();
        	this.groupImage.Panel.SuspendLayout();
        	this.groupImage.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.panelButtons)).BeginInit();
        	this.panelButtons.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
        	this.kryptonPanel2.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.panelImages)).BeginInit();
        	this.panelImages.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.gridImages)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// groupImage
        	// 
        	this.groupImage.AccessibleDescription = null;
        	this.groupImage.AccessibleName = null;
        	resources.ApplyResources(this.groupImage, "groupImage");
        	this.groupImage.BackgroundImage = null;
        	this.groupImage.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
        	        	        	this.buttonSpecHeaderGroup1,
        	        	        	this.buttonSpecHeaderGroup2});
        	this.groupImage.Font = null;
        	this.groupImage.HeaderVisibleSecondary = false;
        	this.groupImage.Name = "groupImage";
        	// 
        	// groupImage.Panel
        	// 
        	this.groupImage.Panel.AccessibleDescription = null;
        	this.groupImage.Panel.AccessibleName = null;
        	resources.ApplyResources(this.groupImage.Panel, "groupImage.Panel");
        	this.groupImage.Panel.BackgroundImage = null;
        	this.groupImage.Panel.Controls.Add(this.pictureBox1);
        	this.groupImage.Panel.Font = null;
        	this.groupImage.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
        	this.groupImage.StateCommon.HeaderPrimary.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	// 
        	// buttonSpecHeaderGroup1
        	// 
        	resources.ApplyResources(this.buttonSpecHeaderGroup1, "buttonSpecHeaderGroup1");
        	this.buttonSpecHeaderGroup1.ContextMenuStrip = null;
        	this.buttonSpecHeaderGroup1.KryptonContextMenu = null;
        	this.buttonSpecHeaderGroup1.ToolTipImage = null;
        	this.buttonSpecHeaderGroup1.UniqueName = "BECCF6D229F144D64890708D30B594A5";
        	this.buttonSpecHeaderGroup1.Click += new System.EventHandler(this.ButtonSelectImageClick);
        	// 
        	// buttonSpecHeaderGroup2
        	// 
        	resources.ApplyResources(this.buttonSpecHeaderGroup2, "buttonSpecHeaderGroup2");
        	this.buttonSpecHeaderGroup2.ContextMenuStrip = null;
        	this.buttonSpecHeaderGroup2.KryptonContextMenu = null;
        	this.buttonSpecHeaderGroup2.ToolTipImage = null;
        	this.buttonSpecHeaderGroup2.UniqueName = "8703794D2EB24DC52788C1F5B3FE2A7F";
        	this.buttonSpecHeaderGroup2.Click += new System.EventHandler(this.ButtonClearImageClick);
        	// 
        	// pictureBox1
        	// 
        	this.pictureBox1.AccessibleDescription = null;
        	this.pictureBox1.AccessibleName = null;
        	resources.ApplyResources(this.pictureBox1, "pictureBox1");
        	this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
        	this.pictureBox1.BackgroundImage = null;
        	this.pictureBox1.Font = null;
        	this.pictureBox1.Image = global::HomeCollection.Resources.photo;
        	this.pictureBox1.ImageLocation = null;
        	this.pictureBox1.Name = "pictureBox1";
        	this.pictureBox1.TabStop = false;
        	// 
        	// buttonSelectImage
        	// 
        	this.buttonSelectImage.AccessibleDescription = null;
        	this.buttonSelectImage.AccessibleName = null;
        	resources.ApplyResources(this.buttonSelectImage, "buttonSelectImage");
        	this.buttonSelectImage.BackgroundImage = null;
        	this.buttonSelectImage.Font = null;
        	this.buttonSelectImage.Name = "buttonSelectImage";
        	this.buttonSelectImage.Values.ExtraText = resources.GetString("buttonSelectImage.Values.ExtraText");
        	this.buttonSelectImage.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonSelectImage.Values.ImageTransparentColor")));
        	this.buttonSelectImage.Values.Text = resources.GetString("buttonSelectImage.Values.Text");
        	this.buttonSelectImage.Click += new System.EventHandler(this.ButtonSelectImageClick);
        	// 
        	// buttonClearImage
        	// 
        	this.buttonClearImage.AccessibleDescription = null;
        	this.buttonClearImage.AccessibleName = null;
        	resources.ApplyResources(this.buttonClearImage, "buttonClearImage");
        	this.buttonClearImage.BackgroundImage = null;
        	this.buttonClearImage.Font = null;
        	this.buttonClearImage.Name = "buttonClearImage";
        	this.buttonClearImage.Values.ExtraText = resources.GetString("buttonClearImage.Values.ExtraText");
        	this.buttonClearImage.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonClearImage.Values.ImageTransparentColor")));
        	this.buttonClearImage.Values.Text = resources.GetString("buttonClearImage.Values.Text");
        	this.buttonClearImage.Click += new System.EventHandler(this.ButtonClearImageClick);
        	// 
        	// panelButtons
        	// 
        	this.panelButtons.AccessibleDescription = null;
        	this.panelButtons.AccessibleName = null;
        	resources.ApplyResources(this.panelButtons, "panelButtons");
        	this.panelButtons.BackgroundImage = null;
        	this.panelButtons.Controls.Add(this.buttonAddFromInternet);
        	this.panelButtons.Controls.Add(this.buttonAdd);
        	this.panelButtons.Controls.Add(this.buttonSelectImage);
        	this.panelButtons.Controls.Add(this.buttonClearImage);
        	this.panelButtons.Font = null;
        	this.panelButtons.Name = "panelButtons";
        	this.panelButtons.StateCommon.Color1 = System.Drawing.Color.Transparent;
        	// 
        	// buttonAddFromInternet
        	// 
        	this.buttonAddFromInternet.AccessibleDescription = null;
        	this.buttonAddFromInternet.AccessibleName = null;
        	resources.ApplyResources(this.buttonAddFromInternet, "buttonAddFromInternet");
        	this.buttonAddFromInternet.BackgroundImage = null;
        	this.buttonAddFromInternet.Font = null;
        	this.buttonAddFromInternet.Name = "buttonAddFromInternet";
        	this.buttonAddFromInternet.Values.ExtraText = resources.GetString("buttonAddFromInternet.Values.ExtraText");
        	this.buttonAddFromInternet.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonAddFromInternet.Values.ImageTransparentColor")));
        	this.buttonAddFromInternet.Values.Text = resources.GetString("buttonAddFromInternet.Values.Text");
        	this.buttonAddFromInternet.Click += new System.EventHandler(this.ButtonAddFromInternetClick);
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
        	this.buttonAdd.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonAdd.Values.ImageTransparentColor")));
        	this.buttonAdd.Values.Text = resources.GetString("buttonAdd.Values.Text");
        	this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
        	// 
        	// kryptonPanel2
        	// 
        	this.kryptonPanel2.AccessibleDescription = null;
        	this.kryptonPanel2.AccessibleName = null;
        	resources.ApplyResources(this.kryptonPanel2, "kryptonPanel2");
        	this.kryptonPanel2.BackgroundImage = null;
        	this.kryptonPanel2.Controls.Add(this.groupImage);
        	this.kryptonPanel2.Controls.Add(this.panelImages);
        	this.kryptonPanel2.Font = null;
        	this.kryptonPanel2.Name = "kryptonPanel2";
        	this.kryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Transparent;
        	// 
        	// panelImages
        	// 
        	this.panelImages.AccessibleDescription = null;
        	this.panelImages.AccessibleName = null;
        	resources.ApplyResources(this.panelImages, "panelImages");
        	this.panelImages.BackgroundImage = null;
        	this.panelImages.Controls.Add(this.gridImages);
        	this.panelImages.Font = null;
        	this.panelImages.Name = "panelImages";
        	this.panelImages.StateCommon.Color1 = System.Drawing.Color.Transparent;
        	// 
        	// gridImages
        	// 
        	this.gridImages.AccessibleDescription = null;
        	this.gridImages.AccessibleName = null;
        	this.gridImages.AllowUserToAddRows = false;
        	this.gridImages.AllowUserToDeleteRows = false;
        	this.gridImages.AllowUserToOrderColumns = true;
        	this.gridImages.AllowUserToResizeColumns = false;
        	this.gridImages.AllowUserToResizeRows = false;
        	resources.ApplyResources(this.gridImages, "gridImages");
        	this.gridImages.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
        	this.gridImages.BackgroundImage = null;
        	this.gridImages.ColumnHeadersVisible = false;
        	this.gridImages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.Column1});
        	this.gridImages.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.gridImages.Font = null;
        	this.gridImages.MultiSelect = false;
        	this.gridImages.Name = "gridImages";
        	this.gridImages.ReadOnly = true;
        	this.gridImages.RowHeadersVisible = false;
        	this.gridImages.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
        	this.gridImages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
        	this.gridImages.StateCommon.Background.Color1 = System.Drawing.Color.Transparent;
        	this.gridImages.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
        	this.gridImages.SelectionChanged += new System.EventHandler(this.GridImagesSelectionChanged);
        	// 
        	// Column1
        	// 
        	resources.ApplyResources(this.Column1, "Column1");
        	this.Column1.Name = "Column1";
        	this.Column1.ReadOnly = true;
        	// 
        	// openFileDialog1
        	// 
        	resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
        	// 
        	// ImageSelect
        	// 
        	this.AccessibleDescription = null;
        	this.AccessibleName = null;
        	resources.ApplyResources(this, "$this");
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackgroundImage = null;
        	this.Controls.Add(this.kryptonPanel2);
        	this.Controls.Add(this.panelButtons);
        	this.Font = null;
        	this.Name = "ImageSelect";
        	this.SizeChanged += new System.EventHandler(this.ImageSelectSizeChanged);
        	((System.ComponentModel.ISupportInitialize)(this.groupImage.Panel)).EndInit();
        	this.groupImage.Panel.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.groupImage)).EndInit();
        	this.groupImage.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.panelButtons)).EndInit();
        	this.panelButtons.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
        	this.kryptonPanel2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.panelImages)).EndInit();
        	this.panelImages.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.gridImages)).EndInit();
        	this.ResumeLayout(false);
        }
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonAddFromInternet;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup groupImage;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecHeaderGroup2;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelButtons;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonAdd;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridImages;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelImages;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonSelectImage;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonClearImage;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
