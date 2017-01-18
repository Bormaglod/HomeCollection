//-----------------------------------------------------------------------
// <copyright file="DetailInfoControl.Designer.cs" company="Sergey Teplyashin">
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
// <date>18.03.2011</date>
// <time>10:04</time>
// <summary>Defines the DetailInfoControl class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class DetailInfoControl
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailInfoControl));
        	this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
        	this.buttonSpecPlugin = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
        	this.menuPlugin = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
        	this.menuPluginItems = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
        	((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
        	this.kryptonHeaderGroup1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// kryptonHeaderGroup1
        	// 
        	this.kryptonHeaderGroup1.AccessibleDescription = null;
        	this.kryptonHeaderGroup1.AccessibleName = null;
        	resources.ApplyResources(this.kryptonHeaderGroup1, "kryptonHeaderGroup1");
        	this.kryptonHeaderGroup1.BackgroundImage = null;
        	this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
        	        	        	this.buttonSpecPlugin});
        	this.kryptonHeaderGroup1.Font = null;
        	this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
        	this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
        	// 
        	// kryptonHeaderGroup1.Panel
        	// 
        	this.kryptonHeaderGroup1.Panel.AccessibleDescription = null;
        	this.kryptonHeaderGroup1.Panel.AccessibleName = null;
        	resources.ApplyResources(this.kryptonHeaderGroup1.Panel, "kryptonHeaderGroup1.Panel");
        	this.kryptonHeaderGroup1.Panel.BackgroundImage = null;
        	this.kryptonHeaderGroup1.Panel.Font = null;
        	// 
        	// buttonSpecPlugin
        	// 
        	resources.ApplyResources(this.buttonSpecPlugin, "buttonSpecPlugin");
        	this.buttonSpecPlugin.ContextMenuStrip = null;
        	this.buttonSpecPlugin.KryptonContextMenu = null;
        	this.buttonSpecPlugin.ToolTipImage = null;
        	this.buttonSpecPlugin.UniqueName = "C1E1954EF52B497DA584833FC243EC0E";
        	this.buttonSpecPlugin.Click += new System.EventHandler(this.ButtonSpecPluginClick);
        	// 
        	// menuPlugin
        	// 
        	this.menuPlugin.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
        	        	        	this.menuPluginItems});
        	// 
        	// DetailInfoControl
        	// 
        	this.AccessibleDescription = null;
        	this.AccessibleName = null;
        	resources.ApplyResources(this, "$this");
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackgroundImage = null;
        	this.Controls.Add(this.kryptonHeaderGroup1);
        	this.Font = null;
        	this.Name = "DetailInfoControl";
        	((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
        	this.kryptonHeaderGroup1.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems menuPluginItems;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu menuPlugin;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecPlugin;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
    }
}
