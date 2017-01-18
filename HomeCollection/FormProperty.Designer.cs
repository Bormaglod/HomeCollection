//-----------------------------------------------------------------------
// <copyright file="FormProperty.Designer.cs" company="Sergey Teplyashin">
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
// <date>22.11.2010</date>
// <time>10:09</time>
// <summary>Defines the FormProperty class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class FormProperty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProperty));
            this.groupCommon = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.textFileName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny3 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.buttonSpecAny4 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.comboLicense = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.buttonSpecAny2 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.comboCategory = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.textComment = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textEmail = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textHeader = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.buttonCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.groupCommon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCommon.Panel)).BeginInit();
            this.groupCommon.Panel.SuspendLayout();
            this.groupCommon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // groupCommon
            // 
            this.groupCommon.AccessibleDescription = null;
            this.groupCommon.AccessibleName = null;
            resources.ApplyResources(this.groupCommon, "groupCommon");
            this.groupCommon.BackgroundImage = null;
            this.groupCommon.Font = null;
            this.groupCommon.Name = "groupCommon";
            // 
            // groupCommon.Panel
            // 
            this.groupCommon.Panel.AccessibleDescription = null;
            this.groupCommon.Panel.AccessibleName = null;
            resources.ApplyResources(this.groupCommon.Panel, "groupCommon.Panel");
            this.groupCommon.Panel.BackgroundImage = null;
            this.groupCommon.Panel.Controls.Add(this.textFileName);
            this.groupCommon.Panel.Controls.Add(this.comboLicense);
            this.groupCommon.Panel.Controls.Add(this.comboCategory);
            this.groupCommon.Panel.Controls.Add(this.textComment);
            this.groupCommon.Panel.Controls.Add(this.textEmail);
            this.groupCommon.Panel.Controls.Add(this.textName);
            this.groupCommon.Panel.Controls.Add(this.textHeader);
            this.groupCommon.Panel.Controls.Add(this.kryptonLabel7);
            this.groupCommon.Panel.Controls.Add(this.kryptonLabel6);
            this.groupCommon.Panel.Controls.Add(this.kryptonLabel5);
            this.groupCommon.Panel.Controls.Add(this.kryptonLabel4);
            this.groupCommon.Panel.Controls.Add(this.kryptonLabel3);
            this.groupCommon.Panel.Controls.Add(this.kryptonLabel2);
            this.groupCommon.Panel.Controls.Add(this.kryptonLabel1);
            this.groupCommon.Panel.Font = null;
            this.groupCommon.Values.Description = resources.GetString("groupCommon.Values.Description");
            this.groupCommon.Values.Heading = resources.GetString("groupCommon.Values.Heading");
            this.groupCommon.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("groupCommon.Values.ImageTransparentColor")));
            // 
            // textFileName
            // 
            this.textFileName.AccessibleDescription = null;
            this.textFileName.AccessibleName = null;
            resources.ApplyResources(this.textFileName, "textFileName");
            this.textFileName.BackgroundImage = null;
            this.textFileName.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
                                    this.buttonSpecAny3,
                                    this.buttonSpecAny4});
            this.textFileName.Font = null;
            this.textFileName.Name = "textFileName";
            // 
            // buttonSpecAny3
            // 
            resources.ApplyResources(this.buttonSpecAny3, "buttonSpecAny3");
            this.buttonSpecAny3.ContextMenuStrip = null;
            this.buttonSpecAny3.KryptonContextMenu = null;
            this.buttonSpecAny3.ToolTipImage = null;
            this.buttonSpecAny3.UniqueName = "9B26832005814F25AC9917438E10CFDD";
            this.buttonSpecAny3.Click += new System.EventHandler(this.ButtonSpecAny3Click);
            // 
            // buttonSpecAny4
            // 
            resources.ApplyResources(this.buttonSpecAny4, "buttonSpecAny4");
            this.buttonSpecAny4.ContextMenuStrip = null;
            this.buttonSpecAny4.Image = global::HomeCollection.Resources.folder;
            this.buttonSpecAny4.KryptonContextMenu = null;
            this.buttonSpecAny4.ToolTipImage = null;
            this.buttonSpecAny4.UniqueName = "578244E14AB74497928901008FDF8728";
            this.buttonSpecAny4.Click += new System.EventHandler(this.ButtonSpecAny4Click);
            // 
            // comboLicense
            // 
            this.comboLicense.AccessibleDescription = null;
            this.comboLicense.AccessibleName = null;
            resources.ApplyResources(this.comboLicense, "comboLicense");
            this.comboLicense.BackgroundImage = null;
            this.comboLicense.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
                                    this.buttonSpecAny2});
            this.comboLicense.DropDownWidth = 275;
            this.comboLicense.Font = null;
            this.comboLicense.Items.AddRange(new object[] {
                                    resources.GetString("comboLicense.Items"),
                                    resources.GetString("comboLicense.Items1")});
            this.comboLicense.Name = "comboLicense";
            // 
            // buttonSpecAny2
            // 
            resources.ApplyResources(this.buttonSpecAny2, "buttonSpecAny2");
            this.buttonSpecAny2.ContextMenuStrip = null;
            this.buttonSpecAny2.KryptonContextMenu = null;
            this.buttonSpecAny2.ToolTipImage = null;
            this.buttonSpecAny2.UniqueName = "EEE2BD60E111454862B5366A7EB9DE55";
            this.buttonSpecAny2.Click += new System.EventHandler(this.ButtonSpecAny2Click);
            // 
            // comboCategory
            // 
            this.comboCategory.AccessibleDescription = null;
            this.comboCategory.AccessibleName = null;
            resources.ApplyResources(this.comboCategory, "comboCategory");
            this.comboCategory.BackgroundImage = null;
            this.comboCategory.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
                                    this.buttonSpecAny1});
            this.comboCategory.DropDownWidth = 275;
            this.comboCategory.Font = null;
            this.comboCategory.Items.AddRange(new object[] {
                                    resources.GetString("comboCategory.Items"),
                                    resources.GetString("comboCategory.Items1"),
                                    resources.GetString("comboCategory.Items2"),
                                    resources.GetString("comboCategory.Items3"),
                                    resources.GetString("comboCategory.Items4"),
                                    resources.GetString("comboCategory.Items5")});
            this.comboCategory.Name = "comboCategory";
            // 
            // buttonSpecAny1
            // 
            resources.ApplyResources(this.buttonSpecAny1, "buttonSpecAny1");
            this.buttonSpecAny1.ContextMenuStrip = null;
            this.buttonSpecAny1.KryptonContextMenu = null;
            this.buttonSpecAny1.ToolTipImage = null;
            this.buttonSpecAny1.UniqueName = "15F6E88AA43447A79081D8F1119A98BA";
            this.buttonSpecAny1.Click += new System.EventHandler(this.ButtonSpecAny1Click);
            // 
            // textComment
            // 
            this.textComment.AccessibleDescription = null;
            this.textComment.AccessibleName = null;
            resources.ApplyResources(this.textComment, "textComment");
            this.textComment.BackgroundImage = null;
            this.textComment.Font = null;
            this.textComment.Name = "textComment";
            // 
            // textEmail
            // 
            this.textEmail.AccessibleDescription = null;
            this.textEmail.AccessibleName = null;
            resources.ApplyResources(this.textEmail, "textEmail");
            this.textEmail.BackgroundImage = null;
            this.textEmail.Font = null;
            this.textEmail.Name = "textEmail";
            // 
            // textName
            // 
            this.textName.AccessibleDescription = null;
            this.textName.AccessibleName = null;
            resources.ApplyResources(this.textName, "textName");
            this.textName.BackgroundImage = null;
            this.textName.Font = null;
            this.textName.Name = "textName";
            // 
            // textHeader
            // 
            this.textHeader.AccessibleDescription = null;
            this.textHeader.AccessibleName = null;
            resources.ApplyResources(this.textHeader, "textHeader");
            this.textHeader.BackgroundImage = null;
            this.textHeader.Font = null;
            this.textHeader.Name = "textHeader";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.AccessibleDescription = null;
            this.kryptonLabel7.AccessibleName = null;
            resources.ApplyResources(this.kryptonLabel7, "kryptonLabel7");
            this.kryptonLabel7.BackgroundImage = null;
            this.kryptonLabel7.Font = null;
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Values.ExtraText = resources.GetString("kryptonLabel7.Values.ExtraText");
            this.kryptonLabel7.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel7.Values.ImageTransparentColor")));
            this.kryptonLabel7.Values.Text = resources.GetString("kryptonLabel7.Values.Text");
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.AccessibleDescription = null;
            this.kryptonLabel6.AccessibleName = null;
            resources.ApplyResources(this.kryptonLabel6, "kryptonLabel6");
            this.kryptonLabel6.BackgroundImage = null;
            this.kryptonLabel6.Font = null;
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Values.ExtraText = resources.GetString("kryptonLabel6.Values.ExtraText");
            this.kryptonLabel6.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel6.Values.ImageTransparentColor")));
            this.kryptonLabel6.Values.Text = resources.GetString("kryptonLabel6.Values.Text");
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.AccessibleDescription = null;
            this.kryptonLabel5.AccessibleName = null;
            resources.ApplyResources(this.kryptonLabel5, "kryptonLabel5");
            this.kryptonLabel5.BackgroundImage = null;
            this.kryptonLabel5.Font = null;
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Values.ExtraText = resources.GetString("kryptonLabel5.Values.ExtraText");
            this.kryptonLabel5.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel5.Values.ImageTransparentColor")));
            this.kryptonLabel5.Values.Text = resources.GetString("kryptonLabel5.Values.Text");
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.AccessibleDescription = null;
            this.kryptonLabel4.AccessibleName = null;
            resources.ApplyResources(this.kryptonLabel4, "kryptonLabel4");
            this.kryptonLabel4.BackgroundImage = null;
            this.kryptonLabel4.Font = null;
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Values.ExtraText = resources.GetString("kryptonLabel4.Values.ExtraText");
            this.kryptonLabel4.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel4.Values.ImageTransparentColor")));
            this.kryptonLabel4.Values.Text = resources.GetString("kryptonLabel4.Values.Text");
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.AccessibleDescription = null;
            this.kryptonLabel3.AccessibleName = null;
            resources.ApplyResources(this.kryptonLabel3, "kryptonLabel3");
            this.kryptonLabel3.BackgroundImage = null;
            this.kryptonLabel3.Font = null;
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Values.ExtraText = resources.GetString("kryptonLabel3.Values.ExtraText");
            this.kryptonLabel3.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel3.Values.ImageTransparentColor")));
            this.kryptonLabel3.Values.Text = resources.GetString("kryptonLabel3.Values.Text");
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
            // openFileDialog1
            // 
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.DefaultExt = "hcd";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // FormProperty
            // 
            this.AcceptButton = this.buttonOK;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupCommon);
            this.Font = null;
            this.Icon = null;
            this.Name = "FormProperty";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.groupCommon.Panel)).EndInit();
            this.groupCommon.Panel.ResumeLayout(false);
            this.groupCommon.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupCommon)).EndInit();
            this.groupCommon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboCategory)).EndInit();
            this.ResumeLayout(false);
        }
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox groupCommon;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny2;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny4;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textHeader;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textEmail;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textComment;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboCategory;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboLicense;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textFileName;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonCancel;
    }
}
