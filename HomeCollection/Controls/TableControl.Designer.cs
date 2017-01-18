//-----------------------------------------------------------------------
// <copyright file="TableControl.Designer.cs" company="Sergey Teplyashin">
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
// <date>22.02.2011</date>
// <time>10:24</time>
// <summary>Defines the TableControl class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class TableControl
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
        	this.grid = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
        	((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// grid
        	// 
        	this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.grid.Location = new System.Drawing.Point(0, 0);
        	this.grid.Name = "grid";
        	this.grid.Size = new System.Drawing.Size(426, 295);
        	this.grid.TabIndex = 0;
        	// 
        	// TableControl
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.grid);
        	this.Name = "TableControl";
        	this.Size = new System.Drawing.Size(426, 295);
        	((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
        	this.ResumeLayout(false);
        }
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView grid;
    }
}
