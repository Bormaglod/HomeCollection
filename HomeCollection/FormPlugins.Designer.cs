//-----------------------------------------------------------------------
// <copyright file="FormPlugins.Designer.cs" company="Sergey Teplyashin">
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
// <date>30.05.2011</date>
// <time>9:19</time>
// <summary>Defines the FormPlugins class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class FormPlugins
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlugins));
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.listPlugins = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.gridPluginInfo = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.ColumnPropertyName = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.ColumnPropertyValue = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.textDescription = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonUpdate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPluginInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonSplitContainer1
            // 
            resources.ApplyResources(this.kryptonSplitContainer1, "kryptonSplitContainer1");
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.listPlugins);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.gridPluginInfo);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.textDescription);
            // 
            // listPlugins
            // 
            resources.ApplyResources(this.listPlugins, "listPlugins");
            this.listPlugins.Name = "listPlugins";
            this.listPlugins.SelectedIndexChanged += new System.EventHandler(this.ListPluginsSelectedIndexChanged);
            // 
            // gridPluginInfo
            // 
            this.gridPluginInfo.AllowUserToAddRows = false;
            this.gridPluginInfo.AllowUserToDeleteRows = false;
            this.gridPluginInfo.AllowUserToResizeColumns = false;
            this.gridPluginInfo.AllowUserToResizeRows = false;
            this.gridPluginInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                                    this.ColumnPropertyName,
                                    this.ColumnPropertyValue});
            resources.ApplyResources(this.gridPluginInfo, "gridPluginInfo");
            this.gridPluginInfo.MultiSelect = false;
            this.gridPluginInfo.Name = "gridPluginInfo";
            this.gridPluginInfo.ReadOnly = true;
            this.gridPluginInfo.RowHeadersVisible = false;
            this.gridPluginInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPluginInfo.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.gridPluginInfo.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
                                    | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
                                    | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            // 
            // ColumnPropertyName
            // 
            this.ColumnPropertyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPropertyName.FillWeight = 33.05786F;
            resources.ApplyResources(this.ColumnPropertyName, "ColumnPropertyName");
            this.ColumnPropertyName.Name = "ColumnPropertyName";
            this.ColumnPropertyName.ReadOnly = true;
            // 
            // ColumnPropertyValue
            // 
            this.ColumnPropertyValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPropertyValue.FillWeight = 66.94215F;
            resources.ApplyResources(this.ColumnPropertyValue, "ColumnPropertyValue");
            this.ColumnPropertyValue.Name = "ColumnPropertyValue";
            this.ColumnPropertyValue.ReadOnly = true;
            // 
            // textDescription
            // 
            resources.ApplyResources(this.textDescription, "textDescription");
            this.textDescription.Name = "textDescription";
            this.textDescription.ReadOnly = true;
            // 
            // buttonClose
            // 
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Values.Text = resources.GetString("buttonClose.Values.Text");
            // 
            // buttonUpdate
            // 
            resources.ApplyResources(this.buttonUpdate, "buttonUpdate");
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Values.Text = resources.GetString("buttonUpdate.Values.Text");
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdateClick);
            // 
            // FormPlugins
            // 
            this.AcceptButton = this.buttonClose;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Controls.Add(this.buttonClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPlugins";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPluginInfo)).EndInit();
            this.ResumeLayout(false);
        }
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonUpdate;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textDescription;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ColumnPropertyValue;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ColumnPropertyName;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridPluginInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox listPlugins;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonClose;
    }
}
