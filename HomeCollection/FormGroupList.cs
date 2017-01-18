//-----------------------------------------------------------------------
// <copyright file="FormGroupList.cs" company="Sergey Teplyashin">
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
// <date>02.02.2011</date>
// <time>13:46</time>
// <summary>Defines the FormGroupList class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using ComponentLib.Controls;
    using HomeCollection.Core;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    
    #endregion

    /// <summary>
    /// Description of FormGroupList.
    /// </summary>
    public partial class FormGroupList : ToolWindow, IFolder
    {
        private bool historyUpdated;
        private bool init;
        private bool updated;
        
        public FormGroupList(IApplication app, Database data) : base(app, data)
        {
            InitializeComponent();
            
            this.historyUpdated = true;
        }
        
        public TreeNode RootNode
        {
            get { return this.treeObjects.Nodes[0]; }
        }
        
        public bool IsFilter
        {
            get { return this.barCategories.Buttons.IndexOf(this.barCategories.SelectedButton) == this.barCategories.Buttons.Count - 1; }
        }
        
        public Folder CurrentFolder
        {
            get
            {
                if (this.treeObjects.SelectedNode != null)
                {
                    return this.treeObjects.SelectedNode.Tag as Folder;
                }
                
                return null;
            }
        }
        
        public Filter CurrentFilter
        {
            get
            {
                if (this.treeObjects.SelectedNode != null)
                {
                    return this.treeObjects.SelectedNode.Tag as Filter;
                }
                
                return null;
            }
        }
        
        #region IFolder
        
        public string CurrentCategory
        {
            get { return kryptonHeader.Values.Heading; }
        }
        
        public void CreateTree(Folder folder)
        {
            if (folder == null)
            {
                this.CreateTree();
            }
            else
            {
                updated = true;
                foreach (TreeNode node in treeObjects.Nodes[0].Nodes)
                {
                    Folder f = (Folder)node.Tag;
                    
                    bool find = false;
                    foreach (ObjectClass oc in folder.Classes)
                    {
                        if (f.Group != null && f.Group.DependenceClass(oc))
                        {
                            find = true;
                            break;
                        }
                    }
                    
                    if (folder == f || find)
                    {
                        this.CreateGroupFolders(node, f);
                    }
                }
                
                updated = false;
            }
        }
        
        public void SelectFolder(ObjectData objectData)
        {
            this.historyUpdated = false;
            bool find = false;
            if (objectData.ObjectClass.Category != this.CurrentCategory)
            {
                this.ChangeCategory(objectData.ObjectClass.Category);
            }
            
            foreach (TreeNode node in this.treeObjects.Nodes[0].Nodes)
            {
                Folder folder = (Folder)node.Tag;
                if (folder.Classes.Contains(objectData.ObjectClass))
                {
                    this.treeObjects.SelectedNode = node;
                    find = true;
                    break;
                }
            }
            
            if (!find)
            {
                this.treeObjects.SelectedNode = this.treeObjects.Nodes[0];
            }
            
            this.historyUpdated = true;
        }
        
        public void SelectFolder(Filter filter)
        {
            this.historyUpdated = false;
            try
            {
                this.ChangeCategory(Strings.Filters);
                TreeNode find = null;
                foreach (TreeNode node in this.treeObjects.Nodes[0].Nodes)
                {
                    Filter f = node.Tag as Filter;
                    if (f != null && f == filter)
                    {
                        find = node;
                    }
                }
                
                if (find == null)
                {
                    find = this.treeObjects.Nodes[0];
                }
                
                this.treeObjects.SelectedNode = find;
            }
            finally
            {
                this.historyUpdated = true;
            }
        }
        
        public void SelectFolder(Folder folder, string filter, string category)
        {
            this.historyUpdated = false;
            try
            {
                if (!string.IsNullOrEmpty(category) && category != this.CurrentCategory)
                {
                    this.ChangeCategory(category);
                }
                
                TreeNode find = null;
                foreach (TreeNode node in this.treeObjects.Nodes[0].Nodes)
                {
                    Folder f = node.Tag as Folder;

                    if (f != null && f == folder)
                    {
                        find = node;
                        if (!string.IsNullOrEmpty(filter))
                        {
                            foreach (TreeNode filterNode in node.Nodes)
                            {
                                if (filterNode.Text == filter)
                                {
                                    find = filterNode;
                                    break;
                                }
                            }
                        }
                        
                        break;
                    }
                }
                
                if (find == null)
                {
                    find = this.treeObjects.Nodes[0];
                }
                
                this.treeObjects.SelectedNode = find;
            }
            finally
            {
                this.historyUpdated = true;
            }
        }
        
        public void DeleteFilterFolder(Folder folder, string filter)
        {
            foreach (TreeNode node in treeObjects.Nodes[0].Nodes)
            {
                Folder f = (Folder)node.Tag;
                if (folder == f)
                {
                    if (node.Nodes.ContainsKey(filter))
                    {
                        node.Nodes.RemoveByKey(filter);
                    }
                }
                else
                {
                    if (node.Nodes.ContainsKey(filter) && f.Intersect(folder).Count() > 0)
                    {
                        this.CreateGroupFolders(node, f);
                    }
                }
            }
        }
        
        public void UpdateFilteredFolders(ObjectData obj)
        {
            foreach (TreeNode node in treeObjects.Nodes[0].Nodes)
            {
                Folder folder = (Folder)node.Tag;
                if (folder.Classes.Contains(obj.ObjectClass))
                {
                    this.CreateFilterNodes(node, folder, obj);
                }
            }
        }
        
        public void AddCategory(string category)
        {
            if (Database.Classes.GetClasses(category, true).Count() == 0)
            {
                return;
            }
            
            this.barCategories.Buttons.Add(category);
            int h = this.barCategories.Buttons.Count * (this.barCategories.ButtonHeight + 1) + 1;
            this.barCategories.Height = h;
        }
        
        public void UpdateCategories()
        {
            this.init = true;
            
            try
            {
                // Список всех категорий
                IEnumerable<string> cats = this.Database.Classes.ClassCategories;
                
                // Сюда запишем кнопки подлежащие удалению
                Stack<OutlookBarButton> dels = new Stack<OutlookBarButton>();
                
                // Найдем кнопки, ссылающиеся на отсутствющие категории
                foreach (OutlookBarButton b in this.barCategories.Buttons)
                {
                    // Если кнопка ссылается на отсутсвующую категорию или в категории нет
                    // классов, объекты которых можно создать, то запишем ее в стек с дальнейшем удалением
                    if (!cats.Contains(b.Text) || Database.Classes.GetClasses(b.Text, true).Count() == 0)
                    {
                        dels.Push(b);
                    }
                }
                
                // Удалим ненужные кнопки
                while (dels.Count > 0)
                {
                    this.barCategories.Buttons.Remove(dels.Pop());
                }
                
                // Теперь добавим кнопки для вновь созданных категорий
                foreach (string cat in this.Database.Classes.ClassCategories)
                {
                    bool find = false;
                    foreach (OutlookBarButton b in this.barCategories.Buttons)
                    {
                        if (b.Text == cat)
                        {
                            find = true;
                            break;
                        }
                    }
                    
                    if (!find)
                    {
                        this.AddCategory(cat);
                    }
                }

                this.barCategories.Buttons.Add(Strings.Filters);
                
                if (this.barCategories.SelectedButton == null)
                {
                    if (this.barCategories.Buttons.Count > 0)
                    {
                        this.barCategories.SelectedButton = this.barCategories.Buttons[0];
                    }
                }
                
                if (this.barCategories.Buttons.Count == 0)
                {
                    kryptonHeader.Values.Heading = string.Empty;
                    this.barCategories.Visible = false;
                }
                else
                {
                    this.barCategories.Visible = true;
                    int h = this.barCategories.Buttons.Count * (this.barCategories.ButtonHeight + 1) + 1;
                    this.barCategories.Height = h;
                }
                
                this.UpdateButtons();
            }
            finally
            {
                this.init = false;
            }
            
            this.CreateTree();
            this.DoFolderSelect();
        }
        
        public void UpdateFieldGroup(Field field)
        {
            Folder folder = this.CurrentFolder;
            if (folder != null)
            {
                if (field.Group)
                {
                    this.AddGroupMenuItem(folder, field);
                }
                else
                {
                    ToolStripMenuItem find = null;
                    foreach (ToolStripMenuItem item in toolGroup.DropDownItems)
                    {
                        if ((Field)item.Tag == field)
                        {
                            find = item;
                            break;
                        }
                    }
                    
                    if (find != null)
                    {
                        ToolStripMenuItem ch = null;
                        
                        foreach (ToolStripMenuItem item in find.DropDownItems)
                        {
                            if (item.Checked)
                            {
                                ch = item;
                                break;
                            }
                        }
                        
                        if (find.Checked || ch != null)
                        {
                            ((ToolStripMenuItem)toolGroup.DropDownItems[0]).Checked = true;
                        }
                        
                        toolGroup.DropDownItems.Remove(find);
                    }
                }
            }
            
            foreach (TreeNode node in this.treeObjects.Nodes[0].Nodes)
            {
                Folder f = (Folder)node.Tag;
                if (f.Group == field)
                {
                    f.Group = null;
                    Database.Folders.Update(f);
                    if (node.Nodes.Contains(this.treeObjects.SelectedNode))
                    {
                        this.treeObjects.SelectedNode = node;
                    }
                                
                    this.CreateGroupFolders(node, f);
                }
            }
        }
        
        public void DeleteClasses(IEnumerable<ObjectClass> classes)
        {
            Stack<TreeNode> nodes = new Stack<TreeNode>();
            foreach (TreeNode node in treeObjects.Nodes[0].Nodes)
            {
                Folder f = (Folder)node.Tag;
                if (f.Classes.Count() == 0)
                {
                    nodes.Push(node);
                }
            }
            
            while (nodes.Count > 0)
            {
                nodes.Pop().Remove();
            }
        }
        
        #endregion
        
        private void CreateTree()
        {
            if (this.init)
            {
                return;
            }
        
            updated = true;
            treeObjects.BeginUpdate();
            treeObjects.Nodes.Clear();
            if (this.barCategories.SelectedButton != null)
            {
                string category = kryptonHeader.Values.Heading;
                TreeNode root = treeObjects.Nodes.Add(string.Format(Strings.AllObjects, category));
                root.ImageIndex = 0;
                root.SelectedImageIndex = 0;
                
                if (this.IsFilter)
                {
                    foreach (Filter filter in Database.Filters.Collection)
                    {
                        this.AddFilterNode(filter);
                    }
                }
                else
                {
                    foreach (Folder f in Database.Folders.GetFolders(category))
                    {
                        this.CreateNode(f);
                    }
                }
                
                root.ExpandAll();
                
                treeObjects.SelectedNode = root;
            }
            
            treeObjects.EndUpdate();
            updated = false;
        }
        
        private void UpdateButtons()
        {
            toolEditFolder.Enabled = (treeObjects.SelectedNode != null) && (treeObjects.SelectedNode.Parent != null) && (treeObjects.SelectedNode.Parent.Parent == null);
            toolDeleteFolder.Enabled = toolEditFolder.Enabled;
            toolGroup.Enabled = !this.IsFilter;
        }
        
        private void DoFolderSelect()
        {
            this.UpdateButtons();
            if (IsFilter)
            {
                this.FolderSelect(this.CurrentFilter);
            }
            else
            {
                this.FolderSelect(this.CurrentFolder);
                this.CreateGroupList(this.CurrentFolder);
            }
            
            if (this.historyUpdated)
            {
                App.DataCollection.StoreHistory();
            }
        }
        
        private void FolderSelect(Filter filter)
        {
            App.DataCollection.UpdateDataList(filter);
        }
        
        private void FolderSelect(Folder folder)
        {
            if (folder == null)
            {
                App.DataCollection.UpdateDataList(this.CurrentCategory);
            }
            else
            {
                if (treeObjects.SelectedNode.Parent == treeObjects.Nodes[0])
                {
                    App.DataCollection.UpdateDataList(folder);
                }
                else
                {
                    App.DataCollection.UpdateDataList(folder, treeObjects.SelectedNode.Text);
                }
            }
        }
        
        private TreeNode CreateNode(Folder f)
        {
            if (f.Category == kryptonHeader.Values.Heading)
            {
                TreeNode root = this.treeObjects.Nodes[0];
            
                TreeNode node = root.Nodes.Add(f.Name);
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
                node.Tag = f;
                if (!root.IsExpanded)
                {
                    root.ExpandAll();
                }
            
                this.CreateGroupFolders(node, f);
                return node;
            }
            else
            {
                return null;
            }
        }
        
        private void CreateGroupList(Folder folder)
        {
            toolGroup.DropDownItems.Clear();
            toolGroup.DropDownItems.Add(new ToolStripMenuItem(Strings.WithoutFilter));
            
            if (folder != null)
            {
                List<ObjectClass> classes = new List<ObjectClass>();
                foreach (ObjectClass obj in folder.Classes)
                {
                    foreach (ObjectClass oc in Database.Classes.GetHierarchyClasses(obj, MoveDirection.Down))
                    {
                        if (!classes.Contains(oc))
                        {
                            classes.Add(oc);
                        }
                    }
                }
                
                bool checkedItem = false;
                foreach (ObjectClass obj in classes)
                {
                    foreach (Field field in obj.Fields)
                    {
                        if (!field.Group)
                        {
                            continue;
                        }
                        
                        checkedItem |= this.AddGroupMenuItem(folder, field);
                    }
                }
                
                ToolStripMenuItem none = (ToolStripMenuItem)toolGroup.DropDownItems[0];
                none.Click += new EventHandler(this.SelectGroupField);
                if (!checkedItem)
                {
                    none.Checked = true;
                }
            }
        }
        
        private void CreateGroupFolders(TreeNode root, Folder folder)
        {
            root.Nodes.Clear();
            if (folder.Group != null)
            {
                ObjectData[] dataList = Database.Objects.GetData(folder.Classes, folder.Group).ToArray();
                foreach (ObjectData od in dataList)
                {
                    this.CreateFilterNodes(root, folder, od);
                }
            }
        }
        
        private void SelectGroupField(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item.Tag == null)
            {
                this.CurrentFolder.Group = null;
            }
            else
            {
                Field field;
                int method;
                if (item.Tag.GetType() == typeof(int))
                {
                    field = (Field)item.OwnerItem.Tag;
                    method = Convert.ToInt32(item.Tag);
                }
                else
                {
                    field = (Field)item.Tag;
                    method = -1;
                }
                
                this.CurrentFolder.Group = field;
                this.CurrentFolder.GroupMethod = method;
            }
            
            Database.Folders.Update(this.CurrentFolder);
            foreach (ToolStripMenuItem i in toolGroup.DropDownItems)
            {
                i.Checked = false;
                foreach (ToolStripMenuItem si in i.DropDownItems)
                {
                    si.Checked = false;
                }
            }
            
            item.Checked = true;
            TreeNode node = treeObjects.SelectedNode;
            while (node.Parent.Parent != null)
            {
                node = node.Parent;
            }
            
            this.CreateGroupFolders(node, this.CurrentFolder);
            this.FolderSelect(this.CurrentFolder);
        }
        
        private bool AddGroupMenuItem(Folder folder, Field field)
        {
            bool checkedItem = false;
            ToolStripMenuItem item = new ToolStripMenuItem(field.Name);
            item.Tag = field;
            toolGroup.DropDownItems.Add(item);

            IEnumerable<string> groups = field.MethodGroupList;
            if (groups.Count() > 0)
            {
                foreach (string method in groups)
                {
                    ToolStripMenuItem subItem = new ToolStripMenuItem(method);
                    int mg = Utils.ParseMethodGroup(method);
                    subItem.Tag = mg;
                    subItem.Click += new EventHandler(this.SelectGroupField);
                    item.DropDownItems.Add(subItem);
                    if (mg == folder.GroupMethod && folder.Group == field)
                    {
                        subItem.Checked = true;
                        checkedItem = true;
                    }
                }
            }
            else
            {
                item.Click += new EventHandler(this.SelectGroupField);
                if (folder.Group == field)
                {
                    item.Checked = true;
                    checkedItem = true;
                }
            }
            
            return checkedItem;
        }
        
        private TreeNode CreateFilteredNode(TreeNode root, string key, Folder folder)
        {
            TreeNode newNode = new TreeNode();
            newNode.Name = key;
            newNode.Text = key;
            newNode.ImageIndex = 1;
            newNode.SelectedImageIndex = 1;
            newNode.Tag = folder;
            root.Nodes.Add(newNode);
            return newNode;
        }
        
        private void CreateFilterNodes(TreeNode root, Folder folder, ObjectData od)
        {
            List<string> list = folder.Group.GetGroupValue(od[folder.Group], folder.GroupMethod);

            foreach (string key in list)
            {
                if (!root.Nodes.ContainsKey(key))
                {
                    TreeNode n = this.CreateFilteredNode(root, key, folder);
                }
            }
        }
        
        private void ChangeCategory(string text)
        {
            foreach (OutlookBarButton button in this.barCategories.Buttons)
            {
                if (button.Text == text)
                {
                    if (this.barCategories.SelectedButton == button)
                    {
                        this.treeObjects.SelectedNode = this.treeObjects.Nodes[0];
                    }
                    else
                    {
                        this.barCategories.SelectedButton = button;
                    }
                    
                    break;
                }
            }
        }
        
        private void AddFilterNode(Filter filter)
        {
            TreeNode node = this.RootNode.Nodes.Add(filter.Name);
            node.Tag = filter;
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
        }
        
        public override void DatabaseOpened()
        {
            try
            {
                this.historyUpdated = false;
                base.DatabaseOpened();
                this.UpdateCategories();
                this.UpdateButtons();
            }
            finally
            {
                this.historyUpdated = true;
            }
        }
        
        private void Edit()
        {
            if (this.IsFilter)
            {
                Filter filter = this.CurrentFilter;
                if (filter != null)
                {
                    FormFilter flt = new FormFilter();
                    if (flt.Show(Database, filter))
                    {
                        this.treeObjects.SelectedNode.Text = filter.Name;
                        App.DataCollection.UpdateDataList();
                    }
                }
            }
            else
            {
                Folder folder = this.CurrentFolder;
                if (folder != null)
                {
                    FormFolder form = new FormFolder();
                    form.Database = Database;
                    if (form.Show(folder, this.CurrentCategory) != null)
                    {
                        this.treeObjects.SelectedNode.Text = folder.Name;
                        App.DataCollection.UpdateDataList();
                    }
                }
            }
        }
        
        private void TreeObjectsAfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!updated)
            {
                this.DoFolderSelect();
            }
        }
        
        private void BarCategoriesSelectButton(object sender, OutlookBar.ButtonSelectEventArgs e)
        {
            if (this.barCategories.SelectedButton == null)
            {
                kryptonHeader.Values.Heading = string.Empty;
            }
            else
            {
                kryptonHeader.Values.Heading = this.barCategories.SelectedButton.Text;
            }
            
            this.CreateTree();
            this.DoFolderSelect();
        }
        
        private void TreeObjectsDoubleClick(object sender, EventArgs e)
        {
            this.Edit();
        }
        
        private void ToolAddFolderClick(object sender, EventArgs e)
        {
            if (this.IsFilter)
            {
                FormFilter flt = new FormFilter();
                if (flt.Show(Database, null))
                {
                    this.AddFilterNode(flt.Filter);
                }
            }
            else
            {
                FormFolder form = new FormFolder();
                form.Database = Database;
                Folder folder = form.Show(null, this.CurrentCategory);
                if (folder != null)
                {
                    TreeNode node = this.CreateNode(folder);
                    this.CreateGroupFolders(node, folder);
                }
            }
        }
        
        private void ToolEditFolderClick(object sender, EventArgs e)
        {
            this.Edit();
        }
        
        private void ToolDeleteFolderClick(object sender, EventArgs e)
        {
            if (this.IsFilter)
            {
                Filter filter = this.CurrentFilter;
                if (filter != null)
                {
                    if (KryptonMessageBox.Show(string.Format(Strings.ConfirmDeleteFilter, filter.Name), Strings.Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Database.Filters.Remove(filter);
                        this.treeObjects.Nodes.Remove(this.treeObjects.SelectedNode);
                    }
                }
            }
            else
            {
                Folder folder = this.CurrentFolder;
                if (folder != null)
                {
                    if (KryptonMessageBox.Show(string.Format(Strings.ConfirmDeleteFolder, folder.Name), Strings.Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Database.Folders.Remove(folder);
                        this.treeObjects.Nodes.Remove(this.treeObjects.SelectedNode);
                    }
                }
            }
        }
    }
}
