﻿//-----------------------------------------------------------------------
// <copyright file="FormProgress.Designer.cs" company="Sergey Teplyashin">
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
// <date>20.05.2011</date>
// <time>10:45</time>
// <summary>Defines the FormProgress class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Core
{
    partial class FormProgress
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelText = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 34);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(465, 23);
            this.progressBar.TabIndex = 0;
            this.progressBar.Value = 40;
            // 
            // labelText
            // 
            this.labelText.Location = new System.Drawing.Point(12, 12);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(32, 16);
            this.labelText.TabIndex = 1;
            this.labelText.Values.Text = "Text";
            // 
            // FormProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 72);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormProgress";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormProgress";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labelText;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}
