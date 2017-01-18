//-----------------------------------------------------------------------
// <copyright file="MainForm.Designer.cs" company="Sergey Teplyashin">
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
// <date>24.02.2012</date>
// <time>13:08</time>
// <summary>Defines the MainForm class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLastFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemPlugins = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPalettes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPaletteSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPaletteOffice2003 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemPalette2007Blue = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPalette2007Silver = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPalette2007Black = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemPalette2010Blue = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPalette2010Silver = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPalette2010Black = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemPaletteSparkleBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPaletteSparkleOrange = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPaletteSparklePurple = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPanels = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemViewToolBar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemViewStatusBar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemConfigureShortcuts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemConfigureToolbars = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemConfigure = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolButtonCreate = new System.Windows.Forms.ToolStripButton();
            this.toolButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonConfig = new System.Windows.Forms.ToolStripButton();
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.timerBackup = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveBackupDialog = new System.Windows.Forms.SaveFileDialog();
            this.commandClearData = new ComponentFactory.Krypton.Toolkit.KryptonTaskDialogCommand();
            this.commandCreateNew = new ComponentFactory.Krypton.Toolkit.KryptonTaskDialogCommand();
            this.restoreBackupDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dockPanel1);
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuMain);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripMain);
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            resources.ApplyResources(this.dockPanel1, "dockPanel1");
            this.dockPanel1.DockBackColor = System.Drawing.SystemColors.Control;
            this.dockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockPanel1.Name = "dockPanel1";
            dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
            tabGradient1.EndColor = System.Drawing.SystemColors.Control;
            tabGradient1.StartColor = System.Drawing.SystemColors.Control;
            tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin1.TabGradient = tabGradient1;
            autoHideStripSkin1.TextFont = new System.Drawing.Font("Tahoma", 8.25F);
            dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
            tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
            dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
            tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
            dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
            dockPaneStripSkin1.TextFont = new System.Drawing.Font("Tahoma", 8.25F);
            tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
            tabGradient5.EndColor = System.Drawing.SystemColors.Control;
            tabGradient5.StartColor = System.Drawing.SystemColors.Control;
            tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
            dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
            tabGradient6.EndColor = System.Drawing.SystemColors.InactiveCaption;
            tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
            dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
            tabGradient7.EndColor = System.Drawing.Color.Transparent;
            tabGradient7.StartColor = System.Drawing.Color.Transparent;
            tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
            dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
            dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
            this.dockPanel1.Skin = dockPanelSkin1;
            // 
            // menuMain
            // 
            resources.ApplyResources(this.menuMain, "menuMain");
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.menuFile,
                                    this.сервисToolStripMenuItem,
                                    this.menuCustom,
                                    this.menuHelp});
            this.menuMain.Name = "menuMain";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.menuItemCreate,
                                    this.menuItemOpen,
                                    this.menuItemLastFiles,
                                    this.toolStripSeparator1,
                                    this.menuItemSaveAs,
                                    this.toolStripSeparator2,
                                    this.menuItemClose,
                                    this.menuItemExit});
            this.menuFile.Name = "menuFile";
            resources.ApplyResources(this.menuFile, "menuFile");
            this.menuFile.Tag = "1^File";
            // 
            // menuItemCreate
            // 
            this.menuItemCreate.Image = global::HomeCollection.Resources._1302369651_document_letter_new;
            this.menuItemCreate.Name = "menuItemCreate";
            resources.ApplyResources(this.menuItemCreate, "menuItemCreate");
            this.menuItemCreate.Tag = "1^Create";
            this.menuItemCreate.Click += new System.EventHandler(this.MenuItemCreateClick);
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Image = global::HomeCollection.Resources._1302363505_book_open_text_image;
            this.menuItemOpen.Name = "menuItemOpen";
            resources.ApplyResources(this.menuItemOpen, "menuItemOpen");
            this.menuItemOpen.Tag = "1^Open";
            this.menuItemOpen.Click += new System.EventHandler(this.MenuItemOpenClick);
            // 
            // menuItemLastFiles
            // 
            this.menuItemLastFiles.Name = "menuItemLastFiles";
            resources.ApplyResources(this.menuItemLastFiles, "menuItemLastFiles");
            this.menuItemLastFiles.Tag = "1^LastFiles";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Tag = "1";
            // 
            // menuItemSaveAs
            // 
            resources.ApplyResources(this.menuItemSaveAs, "menuItemSaveAs");
            this.menuItemSaveAs.Image = global::HomeCollection.Resources.disk;
            this.menuItemSaveAs.Name = "menuItemSaveAs";
            this.menuItemSaveAs.Tag = "0^SaveAs";
            this.menuItemSaveAs.Click += new System.EventHandler(this.MenuItemSaveAsClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Tag = "0";
            // 
            // menuItemClose
            // 
            this.menuItemClose.Image = global::HomeCollection.Resources._1293958733_gtk_close;
            this.menuItemClose.Name = "menuItemClose";
            resources.ApplyResources(this.menuItemClose, "menuItemClose");
            this.menuItemClose.Tag = "0^Close";
            this.menuItemClose.Click += new System.EventHandler(this.MenuItemCloseClick);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Image = global::HomeCollection.Resources._1293961166_exit;
            this.menuItemExit.Name = "menuItemExit";
            resources.ApplyResources(this.menuItemExit, "menuItemExit");
            this.menuItemExit.Tag = "1^Exit";
            this.menuItemExit.Click += new System.EventHandler(this.MenuItemExitClick);
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.menuItemBackup,
                                    this.menuItemRestore,
                                    this.toolStripSeparator7,
                                    this.menuItemPlugins});
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            resources.ApplyResources(this.сервисToolStripMenuItem, "сервисToolStripMenuItem");
            this.сервисToolStripMenuItem.Tag = "0^Service";
            // 
            // menuItemBackup
            // 
            this.menuItemBackup.Name = "menuItemBackup";
            resources.ApplyResources(this.menuItemBackup, "menuItemBackup");
            this.menuItemBackup.Tag = "0^Save";
            this.menuItemBackup.Click += new System.EventHandler(this.MenuItemBackupClick);
            // 
            // menuItemRestore
            // 
            this.menuItemRestore.Name = "menuItemRestore";
            resources.ApplyResources(this.menuItemRestore, "menuItemRestore");
            this.menuItemRestore.Tag = "0^Restore";
            this.menuItemRestore.Click += new System.EventHandler(this.MenuItemRestoreClick);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            this.toolStripSeparator7.Tag = "0";
            // 
            // menuItemPlugins
            // 
            this.menuItemPlugins.Name = "menuItemPlugins";
            resources.ApplyResources(this.menuItemPlugins, "menuItemPlugins");
            this.menuItemPlugins.Tag = "0^Plugins";
            this.menuItemPlugins.Click += new System.EventHandler(this.MenuItemPluginsClick);
            // 
            // menuCustom
            // 
            this.menuCustom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.menuItemPalettes,
                                    this.menuItemPanels,
                                    this.toolStripSeparator6,
                                    this.menuItemViewToolBar,
                                    this.menuItemViewStatusBar,
                                    this.toolStripSeparator3,
                                    this.menuItemConfigureShortcuts,
                                    this.menuItemConfigureToolbars,
                                    this.menuItemConfigure});
            this.menuCustom.Name = "menuCustom";
            resources.ApplyResources(this.menuCustom, "menuCustom");
            this.menuCustom.Tag = "1^Configure";
            // 
            // menuItemPalettes
            // 
            this.menuItemPalettes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.menuItemPaletteSystem,
                                    this.menuItemPaletteOffice2003,
                                    this.toolStripSeparator15,
                                    this.menuItemPalette2007Blue,
                                    this.menuItemPalette2007Silver,
                                    this.menuItemPalette2007Black,
                                    this.toolStripSeparator16,
                                    this.menuItemPalette2010Blue,
                                    this.menuItemPalette2010Silver,
                                    this.menuItemPalette2010Black,
                                    this.toolStripSeparator17,
                                    this.menuItemPaletteSparkleBlue,
                                    this.menuItemPaletteSparkleOrange,
                                    this.menuItemPaletteSparklePurple});
            this.menuItemPalettes.Name = "menuItemPalettes";
            resources.ApplyResources(this.menuItemPalettes, "menuItemPalettes");
            this.menuItemPalettes.Tag = "1^UserInterface";
            // 
            // menuItemPaletteSystem
            // 
            this.menuItemPaletteSystem.Name = "menuItemPaletteSystem";
            resources.ApplyResources(this.menuItemPaletteSystem, "menuItemPaletteSystem");
            this.menuItemPaletteSystem.Tag = "0";
            this.menuItemPaletteSystem.Click += new System.EventHandler(this.ChangePalette);
            // 
            // menuItemPaletteOffice2003
            // 
            this.menuItemPaletteOffice2003.Name = "menuItemPaletteOffice2003";
            resources.ApplyResources(this.menuItemPaletteOffice2003, "menuItemPaletteOffice2003");
            this.menuItemPaletteOffice2003.Tag = "1";
            this.menuItemPaletteOffice2003.Click += new System.EventHandler(this.ChangePalette);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            resources.ApplyResources(this.toolStripSeparator15, "toolStripSeparator15");
            // 
            // menuItemPalette2007Blue
            // 
            this.menuItemPalette2007Blue.Name = "menuItemPalette2007Blue";
            resources.ApplyResources(this.menuItemPalette2007Blue, "menuItemPalette2007Blue");
            this.menuItemPalette2007Blue.Tag = "2";
            this.menuItemPalette2007Blue.Click += new System.EventHandler(this.ChangePalette);
            // 
            // menuItemPalette2007Silver
            // 
            this.menuItemPalette2007Silver.Name = "menuItemPalette2007Silver";
            resources.ApplyResources(this.menuItemPalette2007Silver, "menuItemPalette2007Silver");
            this.menuItemPalette2007Silver.Tag = "3";
            this.menuItemPalette2007Silver.Click += new System.EventHandler(this.ChangePalette);
            // 
            // menuItemPalette2007Black
            // 
            this.menuItemPalette2007Black.Name = "menuItemPalette2007Black";
            resources.ApplyResources(this.menuItemPalette2007Black, "menuItemPalette2007Black");
            this.menuItemPalette2007Black.Tag = "4";
            this.menuItemPalette2007Black.Click += new System.EventHandler(this.ChangePalette);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            resources.ApplyResources(this.toolStripSeparator16, "toolStripSeparator16");
            // 
            // menuItemPalette2010Blue
            // 
            this.menuItemPalette2010Blue.Name = "menuItemPalette2010Blue";
            resources.ApplyResources(this.menuItemPalette2010Blue, "menuItemPalette2010Blue");
            this.menuItemPalette2010Blue.Tag = "5";
            this.menuItemPalette2010Blue.Click += new System.EventHandler(this.ChangePalette);
            // 
            // menuItemPalette2010Silver
            // 
            this.menuItemPalette2010Silver.Name = "menuItemPalette2010Silver";
            resources.ApplyResources(this.menuItemPalette2010Silver, "menuItemPalette2010Silver");
            this.menuItemPalette2010Silver.Tag = "6";
            this.menuItemPalette2010Silver.Click += new System.EventHandler(this.ChangePalette);
            // 
            // menuItemPalette2010Black
            // 
            this.menuItemPalette2010Black.Name = "menuItemPalette2010Black";
            resources.ApplyResources(this.menuItemPalette2010Black, "menuItemPalette2010Black");
            this.menuItemPalette2010Black.Tag = "7";
            this.menuItemPalette2010Black.Click += new System.EventHandler(this.ChangePalette);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            resources.ApplyResources(this.toolStripSeparator17, "toolStripSeparator17");
            // 
            // menuItemPaletteSparkleBlue
            // 
            this.menuItemPaletteSparkleBlue.Name = "menuItemPaletteSparkleBlue";
            resources.ApplyResources(this.menuItemPaletteSparkleBlue, "menuItemPaletteSparkleBlue");
            this.menuItemPaletteSparkleBlue.Tag = "8";
            this.menuItemPaletteSparkleBlue.Click += new System.EventHandler(this.ChangePalette);
            // 
            // menuItemPaletteSparkleOrange
            // 
            this.menuItemPaletteSparkleOrange.Name = "menuItemPaletteSparkleOrange";
            resources.ApplyResources(this.menuItemPaletteSparkleOrange, "menuItemPaletteSparkleOrange");
            this.menuItemPaletteSparkleOrange.Tag = "9";
            this.menuItemPaletteSparkleOrange.Click += new System.EventHandler(this.ChangePalette);
            // 
            // menuItemPaletteSparklePurple
            // 
            this.menuItemPaletteSparklePurple.Name = "menuItemPaletteSparklePurple";
            resources.ApplyResources(this.menuItemPaletteSparklePurple, "menuItemPaletteSparklePurple");
            this.menuItemPaletteSparklePurple.Tag = "10";
            this.menuItemPaletteSparklePurple.Click += new System.EventHandler(this.ChangePalette);
            // 
            // menuItemPanels
            // 
            this.menuItemPanels.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.menuItemEditor,
                                    this.menuItemInfo,
                                    this.menuItemConfig,
                                    this.menuItemGroups});
            this.menuItemPanels.Name = "menuItemPanels";
            resources.ApplyResources(this.menuItemPanels, "menuItemPanels");
            this.menuItemPanels.Tag = "0^Panels";
            // 
            // menuItemEditor
            // 
            this.menuItemEditor.Name = "menuItemEditor";
            resources.ApplyResources(this.menuItemEditor, "menuItemEditor");
            this.menuItemEditor.Tag = "0^Editor";
            this.menuItemEditor.Click += new System.EventHandler(this.MenuItemEditorClick);
            // 
            // menuItemInfo
            // 
            this.menuItemInfo.Name = "menuItemInfo";
            resources.ApplyResources(this.menuItemInfo, "menuItemInfo");
            this.menuItemInfo.Tag = "0^Record";
            this.menuItemInfo.Click += new System.EventHandler(this.MenuItemInfoClick);
            // 
            // menuItemConfig
            // 
            this.menuItemConfig.Name = "menuItemConfig";
            resources.ApplyResources(this.menuItemConfig, "menuItemConfig");
            this.menuItemConfig.Tag = "0^Configurator";
            this.menuItemConfig.Click += new System.EventHandler(this.MenuItemConfigClick);
            // 
            // menuItemGroups
            // 
            this.menuItemGroups.Name = "menuItemGroups";
            resources.ApplyResources(this.menuItemGroups, "menuItemGroups");
            this.menuItemGroups.Tag = "0^Groups";
            this.menuItemGroups.Click += new System.EventHandler(this.MenuItemGroupsClick);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            this.toolStripSeparator6.Tag = "1";
            // 
            // menuItemViewToolBar
            // 
            this.menuItemViewToolBar.Name = "menuItemViewToolBar";
            resources.ApplyResources(this.menuItemViewToolBar, "menuItemViewToolBar");
            this.menuItemViewToolBar.Tag = "0^ViewToolBar";
            this.menuItemViewToolBar.Click += new System.EventHandler(this.MenuItemViewToolBarClick);
            // 
            // menuItemViewStatusBar
            // 
            this.menuItemViewStatusBar.Name = "menuItemViewStatusBar";
            resources.ApplyResources(this.menuItemViewStatusBar, "menuItemViewStatusBar");
            this.menuItemViewStatusBar.Tag = "0^ViewStatusBar";
            this.menuItemViewStatusBar.Click += new System.EventHandler(this.MenuItemViewStatusBarClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Tag = "0";
            // 
            // menuItemConfigureShortcuts
            // 
            this.menuItemConfigureShortcuts.Name = "menuItemConfigureShortcuts";
            resources.ApplyResources(this.menuItemConfigureShortcuts, "menuItemConfigureShortcuts");
            this.menuItemConfigureShortcuts.Tag = "1^Shortcuts";
            this.menuItemConfigureShortcuts.Click += new System.EventHandler(this.MenuItemConfigureShortcutsClick);
            // 
            // menuItemConfigureToolbars
            // 
            this.menuItemConfigureToolbars.Name = "menuItemConfigureToolbars";
            resources.ApplyResources(this.menuItemConfigureToolbars, "menuItemConfigureToolbars");
            this.menuItemConfigureToolbars.Tag = "1^Toolbar";
            this.menuItemConfigureToolbars.Click += new System.EventHandler(this.MenuItemConfigureToolbarsClick);
            // 
            // menuItemConfigure
            // 
            this.menuItemConfigure.Image = global::HomeCollection.Resources.configure;
            this.menuItemConfigure.Name = "menuItemConfigure";
            resources.ApplyResources(this.menuItemConfigure, "menuItemConfigure");
            this.menuItemConfigure.Tag = "1^Config";
            this.menuItemConfigure.Click += new System.EventHandler(this.MenuItemConfigureClick);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.menuItemHelp,
                                    this.toolStripSeparator4,
                                    this.menuItemAbout});
            this.menuHelp.Name = "menuHelp";
            resources.ApplyResources(this.menuHelp, "menuHelp");
            this.menuHelp.Tag = "1^Help";
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Image = global::HomeCollection.Resources._1293959226_Manual;
            this.menuItemHelp.Name = "menuItemHelp";
            resources.ApplyResources(this.menuItemHelp, "menuItemHelp");
            this.menuItemHelp.Tag = "1^Help";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            resources.ApplyResources(this.menuItemAbout, "menuItemAbout");
            this.menuItemAbout.Tag = "1^About";
            this.menuItemAbout.Click += new System.EventHandler(this.MenuItemAboutClick);
            // 
            // toolStripMain
            // 
            resources.ApplyResources(this.toolStripMain, "toolStripMain");
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.toolButtonCreate,
                                    this.toolButtonOpen,
                                    this.toolStripSeparator5,
                                    this.toolButtonConfig});
            this.toolStripMain.Name = "toolStripMain";
            // 
            // toolButtonCreate
            // 
            this.toolButtonCreate.Image = global::HomeCollection.Resources._1302369651_document_letter_new;
            resources.ApplyResources(this.toolButtonCreate, "toolButtonCreate");
            this.toolButtonCreate.Name = "toolButtonCreate";
            this.toolButtonCreate.Click += new System.EventHandler(this.MenuItemCreateClick);
            // 
            // toolButtonOpen
            // 
            this.toolButtonOpen.Image = global::HomeCollection.Resources._1302363505_book_open_text_image;
            resources.ApplyResources(this.toolButtonOpen, "toolButtonOpen");
            this.toolButtonOpen.Name = "toolButtonOpen";
            this.toolButtonOpen.Click += new System.EventHandler(this.MenuItemOpenClick);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // toolButtonConfig
            // 
            this.toolButtonConfig.Image = global::HomeCollection.Resources.configure;
            resources.ApplyResources(this.toolButtonConfig, "toolButtonConfig");
            this.toolButtonConfig.Name = "toolButtonConfig";
            this.toolButtonConfig.Click += new System.EventHandler(this.MenuItemConfigureClick);
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Silver;
            // 
            // timerBackup
            // 
            this.timerBackup.Tick += new System.EventHandler(this.TimerBackupTick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "hcd";
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // saveBackupDialog
            // 
            this.saveBackupDialog.DefaultExt = "xml";
            resources.ApplyResources(this.saveBackupDialog, "saveBackupDialog");
            // 
            // commandClearData
            // 
            this.commandClearData.DialogResult = System.Windows.Forms.DialogResult.None;
            resources.ApplyResources(this.commandClearData, "commandClearData");
            // 
            // commandCreateNew
            // 
            this.commandCreateNew.DialogResult = System.Windows.Forms.DialogResult.None;
            resources.ApplyResources(this.commandCreateNew, "commandCreateNew");
            // 
            // restoreBackupDialog
            // 
            this.restoreBackupDialog.DefaultExt = "xml";
            resources.ApplyResources(this.restoreBackupDialog, "restoreBackupDialog");
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.ToolStripMenuItem menuItemConfigureToolbars;
        private System.Windows.Forms.ToolStripMenuItem menuItemConfigureShortcuts;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaletteSparklePurple;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaletteSparkleOrange;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaletteSparkleBlue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripMenuItem menuItemPalette2010Black;
        private System.Windows.Forms.ToolStripMenuItem menuItemPalette2010Silver;
        private System.Windows.Forms.ToolStripMenuItem menuItemPalette2010Blue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripMenuItem menuItemPalette2007Black;
        private System.Windows.Forms.ToolStripMenuItem menuItemPalette2007Silver;
        private System.Windows.Forms.ToolStripMenuItem menuItemPalette2007Blue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaletteOffice2003;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaletteSystem;
        private System.Windows.Forms.ToolStripMenuItem menuItemPalettes;
        private System.Windows.Forms.ToolStripMenuItem menuItemPlugins;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.OpenFileDialog restoreBackupDialog;
        private ComponentFactory.Krypton.Toolkit.KryptonTaskDialogCommand commandCreateNew;
        private ComponentFactory.Krypton.Toolkit.KryptonTaskDialogCommand commandClearData;
        private System.Windows.Forms.SaveFileDialog saveBackupDialog;
        private System.Windows.Forms.ToolStripMenuItem menuItemRestore;
        private System.Windows.Forms.ToolStripMenuItem menuItemBackup;
        private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemEditor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem menuItemGroups;
        private System.Windows.Forms.ToolStripMenuItem menuItemInfo;
        private System.Windows.Forms.ToolStripMenuItem menuItemConfig;
        private System.Windows.Forms.ToolStripMenuItem menuItemPanels;
        private System.Windows.Forms.ToolStripButton toolButtonConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolButtonOpen;
        private System.Windows.Forms.ToolStripButton toolButtonCreate;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuItemViewStatusBar;
        private System.Windows.Forms.ToolStripMenuItem menuItemViewToolBar;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemClose;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuItemLastFiles;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem menuItemCreate;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Timer timerBackup;
        private System.Windows.Forms.ToolStripMenuItem menuCustom;
        private System.Windows.Forms.ToolStripMenuItem menuItemConfigure;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
    }
}
