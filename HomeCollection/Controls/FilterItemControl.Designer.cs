//-----------------------------------------------------------------------
// <copyright file="FilterItemControl.Designer.cs" company="Sergey Teplyashin">
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
// <time>14:44</time>
// <summary>Defines the FilterItemControl class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class FilterItemControl
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
            this.comboClass = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.comboField = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.textFilter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.comboOperation = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.comboClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboOperation)).BeginInit();
            this.SuspendLayout();
            // 
            // comboClass
            // 
            this.comboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClass.DropDownWidth = 121;
            this.comboClass.Items.AddRange(new object[] {
                                    "<Любой шаблон>"});
            this.comboClass.Location = new System.Drawing.Point(3, 3);
            this.comboClass.Name = "comboClass";
            this.comboClass.Size = new System.Drawing.Size(121, 20);
            this.comboClass.TabIndex = 0;
            this.comboClass.SelectedIndexChanged += new System.EventHandler(this.ComboClassSelectedIndexChanged);
            // 
            // comboField
            // 
            this.comboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboField.DropDownWidth = 121;
            this.comboField.Items.AddRange(new object[] {
                                    "<Любое поле>"});
            this.comboField.Location = new System.Drawing.Point(130, 3);
            this.comboField.Name = "comboField";
            this.comboField.Size = new System.Drawing.Size(121, 20);
            this.comboField.TabIndex = 1;
            // 
            // textFilter
            // 
            this.textFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                                    | System.Windows.Forms.AnchorStyles.Right)));
            this.textFilter.Location = new System.Drawing.Point(384, 3);
            this.textFilter.Name = "textFilter";
            this.textFilter.Size = new System.Drawing.Size(146, 20);
            this.textFilter.TabIndex = 2;
            // 
            // comboOperation
            // 
            this.comboOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOperation.DropDownWidth = 121;
            this.comboOperation.Items.AddRange(new object[] {
                                    "содержит",
                                    "не содержит",
                                    "равно",
                                    "не равно"});
            this.comboOperation.Location = new System.Drawing.Point(257, 3);
            this.comboOperation.Name = "comboOperation";
            this.comboOperation.Size = new System.Drawing.Size(121, 20);
            this.comboOperation.TabIndex = 3;
            // 
            // FilterItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.comboOperation);
            this.Controls.Add(this.textFilter);
            this.Controls.Add(this.comboField);
            this.Controls.Add(this.comboClass);
            this.Name = "FilterItemControl";
            this.Size = new System.Drawing.Size(533, 26);
            ((System.ComponentModel.ISupportInitialize)(this.comboClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboOperation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboClass;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboOperation;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboField;
    }
}
