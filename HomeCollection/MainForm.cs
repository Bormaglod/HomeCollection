//-----------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Sergey Teplyashin">
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
// <date>24.02.2011</date>
// <time>13:08</time>
// <summary>Defines the MainForm class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.AddIn.Hosting;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Serialization;
    using ComponentFactory.Krypton.Toolkit;
    using ComponentLib.Core;
    using ComponentLib.Core.Xml;
    using ComponentLib.Forms;
    using HomeCollection.AddIns;
    using HomeCollection.Config;
    using HomeCollection.Core;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    using WeifenLuo.WinFormsUI.Docking;
    
    #endregion

    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : KryptonForm, IApplication
    {
        private static string appDir;
        private static ConfigData config;
        
        private Database database;
        private List<ToolWindow> windows;
        private ObjectAccessCollection<File> lastFiles;
        
        private FormStartPage formStartPage;
        private FormGroupList formGroupList;
        private FormCollectionList formCollectionList;
        private FormConfig formConfig;
        
        private Dictionary<Command, ToolStripMenuItem> menuCommands;
        private CommandCollection commands;
        private ToolbarCommandCollection toolbars;
        
        public MainForm()
        {
            this.LoadConfiguration();
            CultureInfo ci = new CultureInfo(Config.App.View.LocalCode);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            
            this.InitializeComponent();
            this.GetPaletteMenuItem(Config.App.View.Mode).Checked = true;
            this.kryptonManager1.GlobalPaletteMode = Config.App.View.Mode;
            
            this.Size = new Size(Config.App.Main.Width, Config.App.Main.Height);
            this.database = new Database();
            this.CreateCommands();
            Plugins.ActivatePlugins();
            this.windows = new List<ToolWindow>();
            this.lastFiles = new ObjectAccessCollection<File>();
            this.lastFiles.LoadFromXml(AppDir + @"\LastFiles.xml", "Files");
            this.CreateStarterPage();
            
            this.UpdateMenuLastFiles();
            this.CreateToolbarButtons();
            this.UpdateToolbarAndMenu();
            
            if (Config.App.General.LoadLastOpened)
            {
                if (this.lastFiles.Last != null)
                {
                    this.OpenDatabase(this.lastFiles.Last);
                }
            }
            
            this.UpdateBackupTimer();
        }
        
        public static string AppDir
        {
            get { return appDir; }
        }
        
        public static ConfigData Config
        {
            get { return config; }
        }
        
        #region IApplication implementation
        
        public IDataCollection DataCollection
        {
            get { return this.formCollectionList; }
        }
        
        public IFolder Folder
        {
            get { return this.formGroupList; }
        }
        
        public bool CreateDatabase()
        {
            FormProperty form = new FormProperty();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (this.database.Opened)
                {
                    this.CloseCurrentDatabase(false);
                }
                
                this.CreateToolWindows();
                this.LoadWindowLayout();
                this.database.Create(form.FileName, form.Info);
                this.DatabaseOpened();
                
                File file = this.AddLastOpenedFile(form.FileName);
                file.Title = form.Info.Title;
                
                this.UpdateMenuLastFiles();
                Text = Strings.HomeCollection + " - " + file.ShortFileName;
                
                this.UpdateToolbarAndMenu();
                return true;
            }
            
            return false;
        }
        
        public void OpenDatabase(File file)
        {
            if (file == null)
            {
                if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    file = this.AddLastOpenedFile(this.openFileDialog.FileName);
                }
            }
            else
            {
                file.AccessTime = DateTime.Now;
            }
            
            if (file != null)
            {
                bool creatingStarterPage = this.database.Opened;
                try
                {
                    if (this.database.Opened)
                    {
                        this.CloseCurrentDatabase(false);
                    }
                    
                    if (!System.IO.File.Exists(file.FileName))
                    {
                        throw new System.IO.FileNotFoundException();
                    }
                    
                    this.CreateToolWindows();
                    this.database.Open(file.FileName);
                    this.DatabaseOpened();
                    this.LoadWindowLayout();
                    this.UpdateMenuLastFiles();
                    Text = Strings.HomeCollection + " - " + file.ShortFileName;
                }
                catch (Exception)
                {
                    KryptonMessageBox.Show(string.Format(Strings.ErrorOpen, file.FileName), Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.CreateStarterPage();
                    //throw;
                }
            }
            
            this.UpdateToolbarAndMenu();
        }
        
        public void CloseChildWindow(ToolWindow win)
        {
            this.UpdateToolbarAndMenu();
        }
        
        #endregion
        
        private void DatabaseOpened()
        {
            foreach (ToolWindow win in this.windows)
            {
                win.DoDatabaseOpened();
            }
        }
        
        private void CreateCommands()
        {
            this.menuCommands = new Dictionary<Command, ToolStripMenuItem>();
            this.commands = new CommandCollection("HomeCollection", FileNames.CommandsFile, this.CreateDefaultCommands());
            this.toolbars = new ToolbarCommandCollection("HomeCollection", "Default", commands, FileNames.ToolBarsFile, this.CreateDefaultToolbar(this.commands));
        }
        
        private IEnumerable<Command> CreateDefaultCommands()
        {
            return new Command[] {
                                       new Command("File", "Create", "document_letter_new", Keys.Control | Keys.N),
                                       new Command("File", "Open", "book_open_text_image", Keys.Control | Keys.O),
                                       new Command("File", "SaveAs", "disk", Keys.None),
                                       new Command("File", "Close", "close", Keys.Control | Keys.F4),
                                       new Command("File", "Exit", "exit", Keys.None),

                                       new Command("Service", "Save"),
                                       new Command("Service", "Restore"),
                                       new Command("Service", "Plugins"),

                                       new Command("Configure", "ViewToolBar"),
                                       new Command("Configure", "ViewStatusBar"),
                                       new Command("Configure", "Shortcuts"),
                                       new Command("Configure", "Toolbar"),
                                       new Command("Configure", "Config", "configure", Keys.None),

                                       new Command("Help", "Help", "manual", Keys.None),
                                       new Command("Help", "About")
                                   };
        }
        
        private IEnumerable<ToolbarCommand> CreateDefaultToolbar(CommandCollection commands)
        {
            return new ToolbarCommand[] {
                                       new ToolbarCommand(commands.GetCommand("File.Create"), 0),
                                       new ToolbarCommand(commands.GetCommand("File.Open"), 1),
                                       new ToolbarCommand(new Command(), 2),
                                       new ToolbarCommand(commands.GetCommand("Configure.Config"), 3)
                                   };
        }
        
        private void LoadConfiguration()
        {
            #if DEBUG
            appDir = string.Format(@"C:\Documents and Settings\{0}\Application Data\HomeCollection", Environment.UserName);
            #else
            appDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\HomeCollection";
            #endif
            if (!System.IO.Directory.Exists(appDir))
            {
                System.IO.Directory.CreateDirectory(appDir);
            }
            
            if (System.IO.File.Exists(appDir + @"\HomeCollection.xml"))
            {
                XmlSerializer dsr = new XmlSerializer(typeof(ConfigData));
                System.IO.FileStream openStream = new System.IO.FileStream(appDir + @"\HomeCollection.xml", System.IO.FileMode.Open);
                try
                {
                    config = (ConfigData)dsr.Deserialize(openStream);
                }
                finally
                {
                    openStream.Close();
                }
            }
            else
            {
                config = new ConfigData();
                config.Defaults();
            }
        }
        
        private void SaveConfiguration()
        {
            if (this.windows.Count > 0)
            {
                this.dockPanel1.SaveAsXml(appDir + "\\" + Strings.CurrentSchema);
            }
            
            MainForm.Config.App.Main.Width = this.Size.Width;
            MainForm.Config.App.Main.Height = this.Size.Height;
            XmlSerializer sr = new XmlSerializer(config.GetType());
            System.IO.FileStream stream = new System.IO.FileStream(appDir + @"\HomeCollection.xml", System.IO.FileMode.Create);
            try
            {
                sr.Serialize(stream, config);
            }
            finally
            {
                stream.Close();
            }
            
            this.lastFiles.SaveToXml(AppDir + @"\LastFiles.xml", "Files");
            this.commands.SaveToXml();
            this.toolbars.SaveToXml();
        }
        
        private void CreateStarterPage()
        {
            this.formStartPage = new FormStartPage(this, this.database, this.lastFiles);
            this.formStartPage.Show(this.dockPanel1, DockState.Document);
            this.UpdateToolbarAndMenu();
        }
        
        private void UpdateMenuLastFiles()
        {
            this.menuItemLastFiles.DropDownItems.Clear();
            foreach (File f in this.lastFiles)
            {
                if (System.IO.File.Exists(f.FileName))
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(string.Format("{0} ({1})", f.Title, f.ShortFileName));
                    item.Tag = f;
                    item.Click += new EventHandler(this.SelectLastFile);
                    this.menuItemLastFiles.DropDownItems.Add(item);
                }
            }
        }
        
        private void CreateToolbarButtons()
        {
            this.toolStripMain.Items.Clear();
            this.toolStripMain.Visible = database.Opened && MainForm.Config.App.Main.ViewToolBar && this.toolbars.Count > 0;
            foreach (ToolbarCommand cmd in this.toolbars.Commands)
            {
                if (cmd.Command.IsSeparator)
                {
                    this.toolStripMain.Items.Add(new ToolStripSeparator());
                }
                else
                {
                    ToolStripMenuItem menu = this.menuCommands[cmd.Command];
                    ToolStripButton button = new ToolStripButton(menu.Text);
                    button.Image = CommandImageCollection.GetImage(cmd.Command.ImageKey);
                    this.toolStripMain.Items.Add(button);
                    button.Click += delegate { menu.PerformClick(); };
                    menu.Image = CommandImageCollection.GetImage(cmd.Command.ImageKey);
                }
            }
        }
        
        private void SelectLastFile(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            this.OpenDatabase((File)item.Tag);
        }
        
        private void CloseCurrentDatabase(bool createStarterPage)
        {
            this.SaveConfiguration();
            if (this.database != null)
            {
                this.database.Close();
            }
            
            foreach (ToolWindow w in this.windows)
            {
                w.Close();
            }
            
            this.windows.Clear();
            this.formCollectionList = null;
            this.formConfig = null;
            this.formGroupList = null;
            if (createStarterPage)
            {
                this.CreateStarterPage();
            }
            
            this.UpdateToolbarAndMenu();
        }
        
        private bool GetMenuVisible(ToolStripItem root, ToolStripItem item)
        {
            if (item.Tag == null)
            {
                return true;
            }
            else
            {
                string[] items = item.Tag.ToString().Split(new char[] { '^' });
                int view = int.Parse(items[0], CultureInfo.InvariantCulture);
                if (items.Length > 1 && root != null)
                {
                    ToolStripMenuItem menuItem = (ToolStripMenuItem)item;
                    string category = root.Tag.ToString().Split(new char[] { '^' })[1];
                    Command cmd = this.commands.GetCommand(string.Format("{0}.{1}", category, items[1]));
                    if (cmd != null)
                    {
                        this.menuCommands.Add(cmd, menuItem);
                        menuItem.ShortcutKeys = cmd.ShortcutKey;
                    }
                }
                
                return view == 1 || database.Opened;
            }
        }
        
        private void UpdateToolbarAndMenu()
        {
            this.menuCommands.Clear();
            this.toolStripMain.Visible = database.Opened && MainForm.Config.App.Main.ViewToolBar;
            this.statusStrip1.Visible = database.Opened && MainForm.Config.App.Main.ViewStatusBar;
            
            foreach (ToolStripItem item in this.menuMain.Items)
            {
                bool rootMenuVisible = this.GetMenuVisible(null, item);
                item.Visible = rootMenuVisible;
                ToolStripMenuItem menuItem = item as ToolStripMenuItem;
                if (menuItem != null)
                {
                    foreach (ToolStripItem subitem in menuItem.DropDown.Items)
                    {
                        bool subMenuVisible = this.GetMenuVisible(item, subitem) && rootMenuVisible;
                        subitem.Visible = subMenuVisible;
                        subitem.Enabled = subMenuVisible;
                    }
                }
            }
            
            if (this.formCollectionList != null)
            {
                this.formCollectionList.PanelInfoVisible = Config.App.Main.ViewInfoBar;
            }
            
            this.menuItemViewToolBar.Checked = MainForm.Config.App.Main.ViewToolBar;
            this.menuItemViewStatusBar.Checked = MainForm.Config.App.Main.ViewStatusBar;
            
            this.menuItemEditor.Checked = this.formCollectionList != null && !this.formCollectionList.IsHidden;
            this.menuItemConfig.Checked = this.formConfig != null && !this.formConfig.IsHidden;
            this.menuItemGroups.Checked = this.formGroupList != null && !this.formGroupList.IsHidden;
            this.menuItemInfo.Checked = Config.App.Main.ViewInfoBar;
        }
        
        private void CreateToolWindows()
        {
            this.formStartPage.Close();
            
            this.windows.Clear();
            this.windows.Add(this.formCollectionList = new FormCollectionList(this, this.database));
            this.windows.Add(this.formGroupList = new FormGroupList(this, this.database));
            this.windows.Add(this.formConfig = new FormConfig(this, this.database));
        }
        
        private IDockContent GetContent(string persistString)
        {
            foreach (ToolWindow win in this.windows)
            {
                if (persistString == win.GetType().ToString())
                {
                    return win;
                }
            }
            
            return null;
        }
        
        private void LoadWindowLayout()
        {
            string fcur = appDir + "\\" + Strings.CurrentSchema;
            string fdef = appDir + "\\" + Strings.DefaultSchema;
            
            if (System.IO.File.Exists(fcur))
            {
                this.dockPanel1.LoadFromXml(fcur, this.GetContent);
            }
            else if (System.IO.File.Exists(fdef))
            {
                this.dockPanel1.LoadFromXml(fdef, this.GetContent);
            }
            else
            {
                this.formGroupList.Show(this.dockPanel1, DockState.DockLeft);
                this.formCollectionList.Show(this.dockPanel1, DockState.Document);
                this.formConfig.Show(this.dockPanel1, DockState.Document);
                this.formCollectionList.Activate();
            }
        }
        
        private File AddLastOpenedFile(string fileName)
        {
            File file = this.lastFiles.FirstOrDefault(f => f.FileName == fileName);
            if (file != null)
            {
                file.AccessTime = DateTime.Now;
            }
            else
            {
                this.lastFiles.Add(file = new File(fileName));
            }
            
            return file;
        }
        
        private void UpdateBackupTimer()
        {
            if (MainForm.Config.App.General.Backup)
            {
                this.timerBackup.Enabled = MainForm.Config.App.General.BackupMinutes > 0;
                this.timerBackup.Interval = MainForm.Config.App.General.BackupMinutes * 60 * 1000;
            }
            else
            {
                this.timerBackup.Enabled = false;
            }
        }
        
        private ToolStripMenuItem GetPaletteMenuItem(PaletteModeManager mode)
        {
            foreach (ToolStripItem item in this.menuItemPalettes.DropDownItems)
            {
                if (item.Tag != null)
                {
                    int index = Convert.ToInt32(item.Tag);
                    if (index == Config.App.View.GetModeIndex(mode))
                    {
                        return (ToolStripMenuItem)item;
                    }
                }
            }
            
            return null;
        }
        
        private void ExportsFolders(XmlDocument doc, XmlElement root)
        {
            foreach (Folder folder in this.database.Folders.Collection)
            {
                XmlElement f = doc.CreateElement(root, "folder", new XmlAttributeElement[] {
                                                       new XmlAttributeElement("name", folder.Name),
                                                       new XmlAttributeElement("category", folder.Category)
                                                       });
                XmlElement classes = doc.CreateElement(f, "classes");
                foreach (ObjectClass oc in folder.Classes)
                {
                    doc.CreateElement(classes, "class", "guid", oc.Identifier.ToString());
                }
                
                XmlElement groups = doc.CreateElement(f, "group");
                doc.AddAttribute( groups, "method", folder.GroupMethod.ToString());
                if (folder.Group != null)
                {
                    doc.AddAttribute(groups, "class_id", folder.Group.ObjectClass.Identifier.ToString());
                    doc.AddAttribute(groups, "field", folder.Group.Name);
                }
            }
        }
        
        private void ExportFilters(XmlDocument doc, XmlElement root)
        {
            foreach (Filter filter in this.database.Filters.Collection)
            {
                XmlElement f = doc.CreateElement(root, "filter", new XmlAttributeElement[] {
                                                       new XmlAttributeElement("name", filter.Name),
                                                       new XmlAttributeElement("operation", filter.LogicalOperation.ToString())
                                                       });
                XmlElement items = doc.CreateElement(f, "items");
                foreach (FilterItem item in filter.Items)
                {
                    XmlElement i = doc.CreateElement(items, "item");
                    if (item.ObjectClass != null)
                    {
                        doc.AddAttribute(i, "class_id", item.ObjectClass.Identifier.ToString());
                    }
                    
                    if (item.Field != null)
                    {
                        doc.AddAttribute(i, "field", item.Field.Name);
                    }
                    
                    doc.AddAttribute(i, "compare", item.Operation.ToString());
                    doc.AddAttribute(i, "text", item.Filter);
                }
            }
        }
        
        private void ImportFolders(XmlDocument doc)
        {
            foreach (XmlNode node in doc.SelectNodes("/database/folders/folder"))
            {
                XmlAttribute attrName = node.Attributes["name"];
                XmlAttribute attrCat = node.Attributes["category"];
                if (attrCat != null && attrName != null)
                {
                    Folder folder = this.database.Folders.Create(attrName.Value, attrCat.Value);
                    XmlAttribute attr;
                    foreach (XmlNode classNode in node.SelectNodes("classes/class"))
                    {
                        attr = classNode.Attributes["guid"];
                        if (attr != null)
                        {
                            folder.AddClass(this.database.Classes[new Guid(attr.Value)]);
                        }
                    }
                    
                    XmlNode grp = node.SelectSingleNode("group");
                    attr = grp.Attributes["method"];
                    folder.GroupMethod = attr == null ? 0 : int.Parse(attr.Value);
                    attr = grp.Attributes["class_id"];
                    if (attr != null)
                    {
                        ObjectClass objectClass = this.database.Classes[new Guid(attr.Value)];
                        if (objectClass != null)
                        {
                            attr = grp.Attributes["field"];
                            if (attr != null)
                            {
                                Field field = objectClass[attr.Value];
                                folder.Group = field;
                            }
                        }
                    }
                    
                    if (folder.Group == null && folder.GroupMethod > 0)
                    {
                        folder.GroupMethod = 0;
                    }
                    
                    this.database.Folders.Update(folder);
                }
            }
        }
        
        private void ImportFilters(XmlDocument doc)
        {
            foreach (XmlNode node in doc.SelectNodes("/database/filters/filter"))
            {
                XmlAttribute attrName = node.Attributes["name"];
                XmlAttribute attrOp = node.Attributes["operation"];
                if (attrName != null && attrOp != null)
                {
                    Filter filter = new Filter();
                    filter.Name = attrName.Value;
                    filter.LogicalOperation = (Logical)Enum.Parse(typeof(Logical), attrOp.Value, true);
                    
                    foreach (XmlNode filterNode in node.SelectNodes("items/item"))
                    {
                        FilterItem item = this.database.Filters.AddFilterItem(filter, false);
                        XmlAttribute attr = filterNode.Attributes["class_id"];
                        if (attr != null)
                        {
                            item.ObjectClass = this.database.Classes[new Guid(attr.Value)];
                        }
                        
                        attr = filterNode.Attributes["field"];
                        if (attr != null && item.ObjectClass != null)
                        {
                            item.Field = item.ObjectClass.FindField(attr.Value, true);
                        }
                        
                        attr = filterNode.Attributes["compare"];
                        item.Operation = attr == null ? FilterOperation.Contains : (FilterOperation)Enum.Parse(typeof(FilterOperation), attr.Value, true);

                        attr = filterNode.Attributes["text"];
                        item.Filter = attr == null ? string.Empty : attr.Value;
                    }
                    
                    this.database.Filters.Add(filter);
                }
            }
        }

        private void MenuItemBackupClick(object sender, EventArgs e)
        {
            if (this.saveBackupDialog.ShowDialog() == DialogResult.OK)
            {
                XmlDocument doc = new XmlDocument();
                doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", string.Empty));
                XmlElement root = doc.CreateElement("database");
                doc.AppendChild(root);
                XmlElement elem = doc.CreateElement(root, "configuration");
                ExportConfiguration.CreateXmlTree(this.database, doc, elem);
                elem = doc.CreateElement(root, "folders");
                this.ExportsFolders(doc, elem);
                elem = doc.CreateElement(root, "filters");
                this.ExportFilters(doc, elem);
                elem = doc.CreateElement(root, "records");
                ExportData.CreateXmlTree(this.database, doc, elem);
                
                doc.Save(this.saveBackupDialog.FileName);
                KryptonMessageBox.Show(Strings.DataBackuped, Strings.Backup, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void MenuItemRestoreClick(object sender, EventArgs e)
        {
            if (!this.database.IsEmpty)
            {
                KryptonTaskDialog dlg = new KryptonTaskDialog();
                dlg.WindowTitle = Strings.Import;
                dlg.MainInstruction = Strings.ImportData;
                dlg.Content = Strings.DataClear;
                dlg.Icon = MessageBoxIcon.Question;
                dlg.CommonButtons = TaskDialogButtons.OK | TaskDialogButtons.Cancel;
                dlg.RadioButtons.AddRange(new KryptonTaskDialogCommand[] {
                                              this.commandClearData,
                                              this.commandCreateNew
                                          });
                if (dlg.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                
                if (dlg.DefaultRadioButton == this.commandClearData)
                {
                    this.database.Recreate();
                }
                else
                {
                    if (!this.CreateDatabase())
                    {
                        return;
                    }
                }
            }
            
            if (this.restoreBackupDialog.ShowDialog() == DialogResult.OK)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(this.restoreBackupDialog.FileName);
                
                ImportExecutorClass ic = new ImportExecutorClass(this.database, doc, "/database/configuration");
                ic.ExecuteImport();
                
                this.ImportFolders(doc);
                this.ImportFilters(doc);
                
                ImportExecutorData ide = new ImportExecutorData(this.database, doc, "/database/records/record");
                ide.ExecuteImport();
                
                this.formGroupList.UpdateCategories();
                //this.Folders.UpdateCategories();
                this.formConfig.CreateCategoriesList();
                //this.Configuration.CreateCategoriesList();
            }
        }
        
        private void MenuItemPluginsClick(object sender, EventArgs e)
        {
            FormPlugins form = new FormPlugins();
            form.ShowPlugins();
        }
        
        private void MenuItemAboutClick(object sender, EventArgs e)
        {
            FormAbout f = new FormAbout();
            f.ShowDialog();
        }
        
        private void MenuItemConfigureShortcutsClick(object sender, EventArgs e)
        {
            if (ShortcutsDialog.Show(this.menuCommands))
            {
                this.UpdateToolbarAndMenu();
            }
        }
        
        private void MenuItemConfigureToolbarsClick(object sender, EventArgs e)
        {
            if (ToolBarsDialog.Show(this.menuCommands, this.toolbars, this.CreateDefaultToolbar(this.commands)))
            {
                this.CreateToolbarButtons();
            }
        }
        
        private void MenuItemOpenClick(object sender, EventArgs e)
        {
            this.OpenDatabase(null);
        }
        
        private void MenuItemCreateClick(object sender, EventArgs e)
        {
            this.CreateDatabase();
        }
        
        private void MenuItemViewToolBarClick(object sender, EventArgs e)
        {
            MainForm.Config.App.Main.ViewToolBar = !this.menuItemViewToolBar.Checked;
            this.UpdateToolbarAndMenu();
        }
        
        private void MenuItemViewStatusBarClick(object sender, EventArgs e)
        {
            MainForm.Config.App.Main.ViewStatusBar = !this.menuItemViewStatusBar.Checked;
            this.UpdateToolbarAndMenu();
        }
        
        private void MenuItemExitClick(object sender, EventArgs e)
        {
            Close();
        }
        
        private void MenuItemCloseClick(object sender, EventArgs e)
        {
            this.dockPanel1.SaveAsXml(appDir + "\\" + Strings.CurrentSchema);
            this.CloseCurrentDatabase(true);
        }
        
        private void TimerBackupTick(object sender, EventArgs e)
        {
            this.database.Backup();
        }
        
        private void MenuItemConfigureClick(object sender, EventArgs e)
        {
            FormConfigure f = new FormConfigure();
            if (f.ShowConfigure() && this.formCollectionList != null && !this.formCollectionList.IsHidden)
            {
                this.formCollectionList.SetTableFont(f.TableFont);
                this.formCollectionList.InvalidateDetailInfo();
                this.UpdateBackupTimer();
            }
        }
        
        private void MenuItemGroupsClick(object sender, EventArgs e)
        {
            if (this.menuItemGroups.Checked)
            {
                this.formGroupList.Hide();
            }
            else
            {
                this.formGroupList.Show(this.dockPanel1);
            }
        }
        
        private void MenuItemEditorClick(object sender, EventArgs e)
        {
            if (this.menuItemEditor.Checked)
            {
                this.formCollectionList.Hide();
            }
            else
            {
                this.formCollectionList.Show(this.dockPanel1);
            }
        }
        
        private void MenuItemConfigClick(object sender, EventArgs e)
        {
            if (this.menuItemConfig.Checked)
            {
                this.formConfig.Hide();
            }
            else
            {
                this.formConfig.Show(this.dockPanel1);
            }
        }
        
        private void ChangePalette(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            this.GetPaletteMenuItem(Config.App.View.Mode).Checked = false;
            Config.App.View.Mode = Config.App.View.GetMode(Convert.ToInt32(item.Tag));
            kryptonManager1.GlobalPaletteMode = Config.App.View.Mode;
            this.GetPaletteMenuItem(Config.App.View.Mode).Checked = true;
        }
        
        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveConfiguration();
            if (this.database != null)
            {
                this.database.Close();
            }
        }
        
        private void MenuItemInfoClick(object sender, EventArgs e)
        {
            MainForm.Config.App.Main.ViewInfoBar = !this.menuItemInfo.Checked;
            this.UpdateToolbarAndMenu();
        }
        
        void MenuItemSaveAsClick(object sender, EventArgs e)
        {
            
        }
    }
}
