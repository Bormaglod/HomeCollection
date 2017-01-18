//-----------------------------------------------------------------------
// <copyright file="SimpleImageSelect.Designer.cs" company="Sergey Teplyashin">
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
// <date>17.06.2011</date>
// <time>11:22</time>
// <summary>Defines the SimpleImageSelect class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class SimpleImageSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleImageSelect));
            this.buttonEdit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonAddFromWeb = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonDelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonRight = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonLeft = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(3, 3);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(25, 25);
            this.buttonEdit.TabIndex = 0;
            this.buttonEdit.TabStop = false;
            this.buttonEdit.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonEdit.Values.Image")));
            this.buttonEdit.Values.Text = "";
            this.buttonEdit.Click += new System.EventHandler(this.ButtonEditClick);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(34, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(25, 25);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.TabStop = false;
            this.buttonAdd.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdd.Values.Image")));
            this.buttonAdd.Values.Text = "";
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // buttonAddFromWeb
            // 
            this.buttonAddFromWeb.Location = new System.Drawing.Point(65, 3);
            this.buttonAddFromWeb.Name = "buttonAddFromWeb";
            this.buttonAddFromWeb.Size = new System.Drawing.Size(25, 25);
            this.buttonAddFromWeb.TabIndex = 2;
            this.buttonAddFromWeb.TabStop = false;
            this.buttonAddFromWeb.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddFromWeb.Values.Image")));
            this.buttonAddFromWeb.Values.Text = "";
            this.buttonAddFromWeb.Click += new System.EventHandler(this.ButtonAddFromWebClick);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(96, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(25, 25);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.TabStop = false;
            this.buttonDelete.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Values.Image")));
            this.buttonDelete.Values.Text = "";
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // buttonRight
            // 
            this.buttonRight.Location = new System.Drawing.Point(65, 34);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(25, 25);
            this.buttonRight.TabIndex = 1;
            this.buttonRight.TabStop = false;
            this.buttonRight.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonRight.Values.Image")));
            this.buttonRight.Values.Text = "";
            this.buttonRight.Click += new System.EventHandler(this.ButtonRightClick);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(34, 34);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(25, 25);
            this.buttonLeft.TabIndex = 0;
            this.buttonLeft.TabStop = false;
            this.buttonLeft.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonLeft.Values.Image")));
            this.buttonLeft.Values.Text = "";
            this.buttonLeft.Click += new System.EventHandler(this.ButtonLeftClick);
            // 
            // SimpleImageSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAddFromWeb);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonEdit);
            this.DoubleBuffered = true;
            this.Name = "SimpleImageSelect";
            this.Size = new System.Drawing.Size(124, 64);
            this.Click += new System.EventHandler(this.SimpleImageSelectClick);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SimpleImageSelectPaint);
            this.Resize += new System.EventHandler(this.SimpleImageSelectResize);
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonLeft;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonRight;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonEdit;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonAdd;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonAddFromWeb;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonDelete;
    }
}
