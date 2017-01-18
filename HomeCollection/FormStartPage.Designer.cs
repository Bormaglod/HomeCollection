//-----------------------------------------------------------------------
// <copyright file="FormStartPage.Designer.cs" company="Sergey Teplyashin">
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
// <date>26.01.2011</date>
// <time>13:13</time>
// <summary>Defines the FormStartPage class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class FormStartPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStartPage));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dataLastFiles = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.buttonOpen = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonCreate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOpened = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAction = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLastFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            resources.ApplyResources(this.kryptonPanel1, "kryptonPanel1");
            this.kryptonPanel1.Controls.Add(this.dataLastFiles);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.buttonOpen);
            this.kryptonPanel1.Controls.Add(this.buttonCreate);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Name = "kryptonPanel1";
            // 
            // dataLastFiles
            // 
            resources.ApplyResources(this.dataLastFiles, "dataLastFiles");
            this.dataLastFiles.AllowUserToAddRows = false;
            this.dataLastFiles.AllowUserToDeleteRows = false;
            this.dataLastFiles.AllowUserToOrderColumns = true;
            this.dataLastFiles.AllowUserToResizeColumns = false;
            this.dataLastFiles.AllowUserToResizeRows = false;
            this.dataLastFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                                    this.ColumnName,
                                    this.ColumnOpened,
                                    this.ColumnLocation,
                                    this.ColumnAction});
            this.dataLastFiles.MultiSelect = false;
            this.dataLastFiles.Name = "dataLastFiles";
            this.dataLastFiles.ReadOnly = true;
            this.dataLastFiles.RowHeadersVisible = false;
            this.dataLastFiles.RowTemplate.Height = 27;
            this.dataLastFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataLastFiles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataLastFilesCellContentClick);
            // 
            // kryptonLabel2
            // 
            resources.ApplyResources(this.kryptonLabel2, "kryptonLabel2");
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kryptonLabel2.Values.ExtraText = resources.GetString("kryptonLabel2.Values.ExtraText");
            this.kryptonLabel2.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel2.Values.ImageTransparentColor")));
            this.kryptonLabel2.Values.Text = resources.GetString("kryptonLabel2.Values.Text");
            // 
            // buttonOpen
            // 
            resources.ApplyResources(this.buttonOpen, "buttonOpen");
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Values.ExtraText = resources.GetString("buttonOpen.Values.ExtraText");
            this.buttonOpen.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonOpen.Values.Image")));
            this.buttonOpen.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonOpen.Values.ImageTransparentColor")));
            this.buttonOpen.Values.Text = resources.GetString("buttonOpen.Values.Text");
            this.buttonOpen.Click += new System.EventHandler(this.ButtonOpenClick);
            // 
            // buttonCreate
            // 
            resources.ApplyResources(this.buttonCreate, "buttonCreate");
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Values.ExtraText = resources.GetString("buttonCreate.Values.ExtraText");
            this.buttonCreate.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonCreate.Values.Image")));
            this.buttonCreate.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonCreate.Values.ImageTransparentColor")));
            this.buttonCreate.Values.Text = resources.GetString("buttonCreate.Values.Text");
            this.buttonCreate.Click += new System.EventHandler(this.ButtonCreateClick);
            // 
            // kryptonLabel1
            // 
            resources.ApplyResources(this.kryptonLabel1, "kryptonLabel1");
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Values.ExtraText = resources.GetString("kryptonLabel1.Values.ExtraText");
            this.kryptonLabel1.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel1.Values.ImageTransparentColor")));
            this.kryptonLabel1.Values.Text = resources.GetString("kryptonLabel1.Values.Text");
            // 
            // ColumnName
            // 
            resources.ApplyResources(this.ColumnName, "ColumnName");
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnOpened
            // 
            resources.ApplyResources(this.ColumnOpened, "ColumnOpened");
            this.ColumnOpened.Name = "ColumnOpened";
            this.ColumnOpened.ReadOnly = true;
            // 
            // ColumnLocation
            // 
            this.ColumnLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.ColumnLocation, "ColumnLocation");
            this.ColumnLocation.Name = "ColumnLocation";
            this.ColumnLocation.ReadOnly = true;
            // 
            // ColumnAction
            // 
            resources.ApplyResources(this.ColumnAction, "ColumnAction");
            this.ColumnAction.Name = "ColumnAction";
            this.ColumnAction.ReadOnly = true;
            this.ColumnAction.Text = "";
            // 
            // FormStartPage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CloseButton = false;
            this.Controls.Add(this.kryptonPanel1);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.HideOnClose = true;
            this.Name = "FormStartPage";
            this.TabText = "Главная";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLastFiles)).EndInit();
            this.ResumeLayout(false);
        }
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataLastFiles;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn ColumnAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOpened;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonOpen;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonCreate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
    }
}
