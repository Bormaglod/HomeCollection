//-----------------------------------------------------------------------
// <copyright file="FormAbout.Designer.cs" company="Sergey Teplyashin">
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
// <date>23.01.2011</date>
// <time>13:27</time>
// <summary>Defines the MainForm class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.listViewAbout = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.textBuild = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textVersion = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonCopy = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.listViewVersions = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textLicense = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.buttonOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HomeCollection.Resources._1302363065_file_manager;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // kryptonLabel1
            // 
            resources.ApplyResources(this.kryptonLabel1, "kryptonLabel1");
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kryptonLabel1.Values.Text = resources.GetString("kryptonLabel1.Values.Text");
            // 
            // kryptonLabel2
            // 
            resources.ApplyResources(this.kryptonLabel2, "kryptonLabel2");
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Values.Text = resources.GetString("kryptonLabel2.Values.Text");
            // 
            // kryptonLabel3
            // 
            resources.ApplyResources(this.kryptonLabel3, "kryptonLabel3");
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Values.Text = resources.GetString("kryptonLabel3.Values.Text");
            // 
            // kryptonLabel4
            // 
            resources.ApplyResources(this.kryptonLabel4, "kryptonLabel4");
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Values.Text = resources.GetString("kryptonLabel4.Values.Text");
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.kryptonWrapLabel1);
            this.tabPage1.Controls.Add(this.listViewAbout);
            this.tabPage1.Controls.Add(this.textBuild);
            this.tabPage1.Controls.Add(this.kryptonLabel6);
            this.tabPage1.Controls.Add(this.textVersion);
            this.tabPage1.Controls.Add(this.kryptonLabel5);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // kryptonWrapLabel1
            // 
            resources.ApplyResources(this.kryptonWrapLabel1, "kryptonWrapLabel1");
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            // 
            // listViewAbout
            // 
            resources.ApplyResources(this.listViewAbout, "listViewAbout");
            this.listViewAbout.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                    this.columnHeader1,
                                    this.columnHeader2});
            this.listViewAbout.FullRowSelect = true;
            this.listViewAbout.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewAbout.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
                                    ((System.Windows.Forms.ListViewItem)(resources.GetObject("listViewAbout.Items"))),
                                    ((System.Windows.Forms.ListViewItem)(resources.GetObject("listViewAbout.Items1"))),
                                    ((System.Windows.Forms.ListViewItem)(resources.GetObject("listViewAbout.Items2"))),
                                    ((System.Windows.Forms.ListViewItem)(resources.GetObject("listViewAbout.Items3"))),
                                    ((System.Windows.Forms.ListViewItem)(resources.GetObject("listViewAbout.Items4"))),
                                    ((System.Windows.Forms.ListViewItem)(resources.GetObject("listViewAbout.Items5")))});
            this.listViewAbout.MultiSelect = false;
            this.listViewAbout.Name = "listViewAbout";
            this.listViewAbout.UseCompatibleStateImageBehavior = false;
            this.listViewAbout.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // textBuild
            // 
            resources.ApplyResources(this.textBuild, "textBuild");
            this.textBuild.Name = "textBuild";
            // 
            // kryptonLabel6
            // 
            resources.ApplyResources(this.kryptonLabel6, "kryptonLabel6");
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Values.Text = resources.GetString("kryptonLabel6.Values.Text");
            // 
            // textVersion
            // 
            resources.ApplyResources(this.textVersion, "textVersion");
            this.textVersion.Name = "textVersion";
            // 
            // kryptonLabel5
            // 
            resources.ApplyResources(this.kryptonLabel5, "kryptonLabel5");
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Values.Text = resources.GetString("kryptonLabel5.Values.Text");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonCopy);
            this.tabPage2.Controls.Add(this.listViewVersions);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonCopy
            // 
            resources.ApplyResources(this.buttonCopy, "buttonCopy");
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Values.Text = resources.GetString("buttonCopy.Values.Text");
            this.buttonCopy.Click += new System.EventHandler(this.ButtonCopyClick);
            // 
            // listViewVersions
            // 
            resources.ApplyResources(this.listViewVersions, "listViewVersions");
            this.listViewVersions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                    this.columnHeader3,
                                    this.columnHeader4,
                                    this.columnHeader5});
            this.listViewVersions.FullRowSelect = true;
            this.listViewVersions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewVersions.MultiSelect = false;
            this.listViewVersions.Name = "listViewVersions";
            this.listViewVersions.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewVersions.UseCompatibleStateImageBehavior = false;
            this.listViewVersions.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // columnHeader5
            // 
            resources.ApplyResources(this.columnHeader5, "columnHeader5");
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textLicense);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textLicense
            // 
            resources.ApplyResources(this.textLicense, "textLicense");
            this.textLicense.Name = "textLicense";
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Values.Image")));
            this.buttonOK.Values.Text = resources.GetString("buttonOK.Values.Text");
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::HomeCollection.Resources.project_support;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.PictureBox2Click);
            // 
            // FormAbout
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonOK;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.PictureBox pictureBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox textLicense;
        private System.Windows.Forms.TabPage tabPage3;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonCopy;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonOK;
        private System.Windows.Forms.ListView listViewVersions;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView listViewAbout;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textVersion;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textBuild;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
