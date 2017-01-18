//-----------------------------------------------------------------------
// <copyright file="FormSelectClass.cs" company="TSV Home Enterprises">
//     Copyright (c) TSV Home Enterprises. All rights reserved.
// </copyright>
// <author>Тепляшин Сергей Васильевич</author>
// <date>17.03.2011</date>
// <time>10:29</time>
// <summary>Defines the ? class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class FormSelectClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectClass));
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.comboClasses = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.buttonOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.checkAllClasses = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.comboClasses)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            resources.ApplyResources(this.kryptonLabel1, "kryptonLabel1");
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Values.Text = resources.GetString("kryptonLabel1.Values.Text");
            // 
            // comboClasses
            // 
            this.comboClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClasses.DropDownWidth = 325;
            resources.ApplyResources(this.comboClasses, "comboClasses");
            this.comboClasses.Name = "comboClasses";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Values.Image")));
            this.buttonOK.Values.Text = resources.GetString("buttonOK.Values.Text");
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Values.Image")));
            this.buttonCancel.Values.Text = resources.GetString("buttonCancel.Values.Text");
            // 
            // checkAllClasses
            // 
            this.checkAllClasses.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            resources.ApplyResources(this.checkAllClasses, "checkAllClasses");
            this.checkAllClasses.Name = "checkAllClasses";
            this.checkAllClasses.Values.Text = resources.GetString("checkAllClasses.Values.Text");
            this.checkAllClasses.CheckedChanged += new System.EventHandler(this.CheckAllClassesCheckedChanged);
            // 
            // FormSelectClass
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.checkAllClasses);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboClasses);
            this.Controls.Add(this.kryptonLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelectClass";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.comboClasses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkAllClasses;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonOK;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboClasses;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}
