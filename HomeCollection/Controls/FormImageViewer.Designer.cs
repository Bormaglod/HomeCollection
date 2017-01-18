//-----------------------------------------------------------------------
// <copyright file="FormImageViewer.Designer.cs" company="Sergey Teplyashin">
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
// <date>23.03.2011</date>
// <time>13:29</time>
// <summary>Defines the FormImageViewer class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class FormImageViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImageViewer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonBestFit = new System.Windows.Forms.ToolStripButton();
            this.buttonActualSize = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelImage = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelImage)).BeginInit();
            this.panelImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.buttonBestFit,
                                    this.buttonActualSize});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // buttonBestFit
            // 
            this.buttonBestFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonBestFit, "buttonBestFit");
            this.buttonBestFit.Image = global::HomeCollection.Resources.actual_size;
            this.buttonBestFit.Name = "buttonBestFit";
            this.buttonBestFit.Click += new System.EventHandler(this.ButtonBestFitClick);
            // 
            // buttonActualSize
            // 
            this.buttonActualSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonActualSize.Image = global::HomeCollection.Resources.best_fit;
            resources.ApplyResources(this.buttonActualSize, "buttonActualSize");
            this.buttonActualSize.Name = "buttonActualSize";
            this.buttonActualSize.Click += new System.EventHandler(this.ButtonActualSizeClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // panelImage
            // 
            resources.ApplyResources(this.panelImage, "panelImage");
            this.panelImage.Controls.Add(this.pictureBox1);
            this.panelImage.Name = "panelImage";
            this.panelImage.Resize += new System.EventHandler(this.PanelImageResize);
            // 
            // FormImageViewer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelImage);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormImageViewer";
            this.ShowIcon = false;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelImage)).EndInit();
            this.panelImage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelImage;
        private System.Windows.Forms.ToolStripButton buttonBestFit;
        private System.Windows.Forms.ToolStripButton buttonActualSize;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}
