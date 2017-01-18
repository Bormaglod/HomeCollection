//-----------------------------------------------------------------------
// <copyright file="FormFilter.Designer.cs" company="Sergey Teplyashin">
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
// <date>28.04.2011</date>
// <time>14:31</time>
// <summary>Defines the FormFilter class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class FormFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFilter));
            this.groupFilters = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.radioAnd = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.radioOr = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.buttonClear = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonLess = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonMore = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonOk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupFilters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupFilters.Panel)).BeginInit();
            this.groupFilters.Panel.SuspendLayout();
            this.groupFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupFilters
            // 
            resources.ApplyResources(this.groupFilters, "groupFilters");
            this.groupFilters.Name = "groupFilters";
            // 
            // groupFilters.Panel
            // 
            resources.ApplyResources(this.groupFilters.Panel, "groupFilters.Panel");
            this.groupFilters.Panel.Controls.Add(this.kryptonPanel1);
            this.groupFilters.Panel.Controls.Add(this.buttonClear);
            this.groupFilters.Panel.Controls.Add(this.buttonLess);
            this.groupFilters.Panel.Controls.Add(this.buttonMore);
            this.groupFilters.Values.Description = resources.GetString("groupFilters.Values.Description");
            this.groupFilters.Values.Heading = resources.GetString("groupFilters.Values.Heading");
            this.groupFilters.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("groupFilters.Values.ImageTransparentColor")));
            // 
            // kryptonPanel1
            // 
            resources.ApplyResources(this.kryptonPanel1, "kryptonPanel1");
            this.kryptonPanel1.Controls.Add(this.radioAnd);
            this.kryptonPanel1.Controls.Add(this.radioOr);
            this.kryptonPanel1.Name = "kryptonPanel1";
            // 
            // radioAnd
            // 
            resources.ApplyResources(this.radioAnd, "radioAnd");
            this.radioAnd.Name = "radioAnd";
            this.radioAnd.Values.ExtraText = resources.GetString("radioAnd.Values.ExtraText");
            this.radioAnd.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("radioAnd.Values.ImageTransparentColor")));
            this.radioAnd.Values.Text = resources.GetString("radioAnd.Values.Text");
            // 
            // radioOr
            // 
            resources.ApplyResources(this.radioOr, "radioOr");
            this.radioOr.Name = "radioOr";
            this.radioOr.Values.ExtraText = resources.GetString("radioOr.Values.ExtraText");
            this.radioOr.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("radioOr.Values.ImageTransparentColor")));
            this.radioOr.Values.Text = resources.GetString("radioOr.Values.Text");
            // 
            // buttonClear
            // 
            resources.ApplyResources(this.buttonClear, "buttonClear");
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Values.ExtraText = resources.GetString("buttonClear.Values.ExtraText");
            this.buttonClear.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonClear.Values.ImageTransparentColor")));
            this.buttonClear.Values.Text = resources.GetString("buttonClear.Values.Text");
            this.buttonClear.Click += new System.EventHandler(this.ButtonClearClick);
            // 
            // buttonLess
            // 
            resources.ApplyResources(this.buttonLess, "buttonLess");
            this.buttonLess.Name = "buttonLess";
            this.buttonLess.Values.ExtraText = resources.GetString("buttonLess.Values.ExtraText");
            this.buttonLess.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonLess.Values.ImageTransparentColor")));
            this.buttonLess.Values.Text = resources.GetString("buttonLess.Values.Text");
            this.buttonLess.Click += new System.EventHandler(this.ButtonLessClick);
            // 
            // buttonMore
            // 
            resources.ApplyResources(this.buttonMore, "buttonMore");
            this.buttonMore.Name = "buttonMore";
            this.buttonMore.Values.ExtraText = resources.GetString("buttonMore.Values.ExtraText");
            this.buttonMore.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonMore.Values.ImageTransparentColor")));
            this.buttonMore.Values.Text = resources.GetString("buttonMore.Values.Text");
            this.buttonMore.Click += new System.EventHandler(this.ButtonMoreClick);
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
            // buttonOk
            // 
            resources.ApplyResources(this.buttonOk, "buttonOk");
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Values.ExtraText = resources.GetString("buttonOk.Values.ExtraText");
            this.buttonOk.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonOk.Values.Image")));
            this.buttonOk.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonOk.Values.ImageTransparentColor")));
            this.buttonOk.Values.Text = resources.GetString("buttonOk.Values.Text");
            this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
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
            // FormFilter
            // 
            this.AcceptButton = this.buttonOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.groupFilters);
            this.Name = "FormFilter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.groupFilters.Panel)).EndInit();
            this.groupFilters.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupFilters)).EndInit();
            this.groupFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radioOr;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radioAnd;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox groupFilters;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonOk;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textName;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonMore;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonLess;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonClear;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}
