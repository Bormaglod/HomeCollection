//-----------------------------------------------------------------------
// <copyright file="FormClassProperty.Designer.cs" company="Sergey Teplyashin">
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
// <date>10.02.2011</date>
// <time>11:32</time>
// <summary>Defines the FormClassProperty class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class FormClassProperty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClassProperty));
            this.buttonCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.comboBase = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.comboCategory = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.buttonSpecAny2 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.comboBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Values.ExtraText = resources.GetString("buttonCancel.Values.ExtraText");
            this.buttonCancel.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Values.Image")));
            this.buttonCancel.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonCancel.Values.ImageTransparentColor")));
            this.buttonCancel.Values.Text = resources.GetString("buttonCancel.Values.Text");
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Values.ExtraText = resources.GetString("buttonOK.Values.ExtraText");
            this.buttonOK.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Values.Image")));
            this.buttonOK.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonOK.Values.ImageTransparentColor")));
            this.buttonOK.Values.Text = resources.GetString("buttonOK.Values.Text");
            this.buttonOK.Click += new System.EventHandler(this.ButtonOKClick);
            // 
            // kryptonLabel3
            // 
            resources.ApplyResources(this.kryptonLabel3, "kryptonLabel3");
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Values.ExtraText = resources.GetString("kryptonLabel3.Values.ExtraText");
            this.kryptonLabel3.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel3.Values.ImageTransparentColor")));
            this.kryptonLabel3.Values.Text = resources.GetString("kryptonLabel3.Values.Text");
            // 
            // kryptonLabel2
            // 
            resources.ApplyResources(this.kryptonLabel2, "kryptonLabel2");
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Values.ExtraText = resources.GetString("kryptonLabel2.Values.ExtraText");
            this.kryptonLabel2.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel2.Values.ImageTransparentColor")));
            this.kryptonLabel2.Values.Text = resources.GetString("kryptonLabel2.Values.Text");
            // 
            // kryptonLabel1
            // 
            resources.ApplyResources(this.kryptonLabel1, "kryptonLabel1");
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Values.ExtraText = resources.GetString("kryptonLabel1.Values.ExtraText");
            this.kryptonLabel1.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel1.Values.ImageTransparentColor")));
            this.kryptonLabel1.Values.Text = resources.GetString("kryptonLabel1.Values.Text");
            // 
            // textName
            // 
            resources.ApplyResources(this.textName, "textName");
            this.textName.Name = "textName";
            // 
            // comboBase
            // 
            resources.ApplyResources(this.comboBase, "comboBase");
            this.comboBase.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
                                    this.buttonSpecAny1});
            this.comboBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBase.DropDownWidth = 266;
            this.comboBase.Name = "comboBase";
            this.comboBase.SelectedIndexChanged += new System.EventHandler(this.ComboBaseSelectedIndexChanged);
            // 
            // buttonSpecAny1
            // 
            resources.ApplyResources(this.buttonSpecAny1, "buttonSpecAny1");
            this.buttonSpecAny1.UniqueName = "5A8D4B61330A464957BBB9E6F05E83D0";
            this.buttonSpecAny1.Click += new System.EventHandler(this.ButtonSpecAny1Click);
            // 
            // comboCategory
            // 
            resources.ApplyResources(this.comboCategory, "comboCategory");
            this.comboCategory.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
                                    this.buttonSpecAny2});
            this.comboCategory.DropDownWidth = 266;
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.SelectedIndexChanged += new System.EventHandler(this.ComboCategorySelectedIndexChanged);
            this.comboCategory.TextUpdate += new System.EventHandler(this.ComboCategoryTextUpdate);
            // 
            // buttonSpecAny2
            // 
            resources.ApplyResources(this.buttonSpecAny2, "buttonSpecAny2");
            this.buttonSpecAny2.UniqueName = "D0BE192C9AAF42188C8C0F34599EF17F";
            this.buttonSpecAny2.Click += new System.EventHandler(this.ButtonSpecAny2Click);
            // 
            // FormClassProperty
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.comboCategory);
            this.Controls.Add(this.comboBase);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormClassProperty";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.comboBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny2;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboCategory;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboBase;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonCancel;
    }
}
