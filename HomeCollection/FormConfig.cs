//-----------------------------------------------------------------------
// <copyright file="FormConfig.cs" company="Sergey Teplyashin">
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
// <time>14:57</time>
// <summary>Defines the FormConfig class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using System.Xml;
    using ComponentFactory.Krypton.Toolkit;
    using HomeCollection.Core;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    using HomeCollection.Properties;
    
    #endregion

    /// <summary>
    /// Description of FormConfig.
    /// </summary>
    public partial class FormConfig : ToolWindow
    {
        private ToolStripMenuItem selectedItem;
        
        public FormConfig(IApplication app, Database data) : base(app, data)
        {
            this.InitializeComponent();
            this.LoadTemplates();
        }
        
        /// <summary>
        /// Процедура вызывается при открытии файла БД.
        /// При этом создается список категорий шаблонов, устанавливается первая категория из 
        /// списка и создается дерево шаблонов данной категории.
        /// </summary>
        public override void DatabaseOpened()
        {
            base.DatabaseOpened();
            
            this.CreateCategoriesList();
        }
        
        public void CreateCategoriesList()
        {
            this.toolComboCategory.Items.Clear();
            this.toolComboCategory.Sorted = true;
            this.menuItemCategory.DropDownItems.Clear();
            foreach (string cat in Database.Classes.ClassCategories)
            {
                this.toolComboCategory.Items.Add(cat);
                
                ToolStripMenuItem item = new ToolStripMenuItem(cat);
                item.Click += new EventHandler(this.CategoryItemClick);
                this.menuItemCategory.DropDownItems.Add(item);
            }
            
            if (this.toolComboCategory.Items.Count > 0)
            {
                this.toolComboCategory.SelectedIndex = 0;
            }
        }
        
        protected void OnFieldGroupModified(Field field)
        {
            App.Folder.UpdateFieldGroup(field);
            App.DataCollection.UpdateDetailInfo();
        }
        
        protected void OnFieldDeleted(Field field)
        {
        }
        
        protected void OnDeleteClasses(IEnumerable<ObjectClass> classes)
        {
            App.Folder.DeleteClasses(classes);
            App.DataCollection.UpdateDataList();
        }
        
        private TreeNode CreateClassNode(TreeNode node, ObjectClass obj, int imageIndex)
        {
            TreeNode n = node.Nodes.Add(obj.Name);
            n.ImageIndex = imageIndex;
            n.SelectedImageIndex = 1;
            ObjectClassProxy proxy = new ObjectClassProxy(obj, Database);
            proxy.ClassNameModified += new EventHandler<EventArgs>(this.proxy_ClassNameModified);
            proxy.ClassCategoryModified += new EventHandler<EventArgs>(this.proxy_ClassCategoryModified);
            proxy.ClassCreatingModified += new EventHandler<EventArgs>(this.proxy_ClassCreatingModified);
            n.Tag = proxy;
            
            TreeNode child = n.Nodes.Add(Strings.BaseTemplate);
            child.ImageIndex = 0;
            child.SelectedImageIndex = 0;
            
            if (obj.BaseClass != null)
            {
                this.CreateClassNode(child, obj.BaseClass, 1);
            }
            
            this.CreateFields(n, obj);
            
            return n;
        }
        
        private void CreateFields(TreeNode root, ObjectClass obj)
        {
            foreach (Field fd in obj.Fields)
            {
                this.CreateFieldNode(root, obj, fd);
            }
        }
        
        private void CreateFieldNode(TreeNode root, ObjectClass obj, Field field)
        {
            TreeNode f_node = root.Nodes.Add(field.Name);
            f_node.ImageIndex = 2;
            f_node.Tag = field;
        }
        
        private void CreateClassesTree()
        {
            this.propertyGrid1.SelectedObject = null;
            
            string cat = (string)this.toolComboCategory.SelectedItem;
            
            this.treeClasses.BeginUpdate();
            try
            {
                this.treeClasses.Nodes.Clear();
                TreeNode node = this.treeClasses.Nodes.Add(Strings.TemplateCollection);
                node.ImageIndex = 0;

                if (!string.IsNullOrEmpty(cat))
                {
                    foreach (ObjectClass c in Database.Classes.GetClasses(cat))
                    {
                        bool hbc = Database.Classes.HasBaseClass(c);
                        if (this.toolButtonAllClasses.Checked || !hbc)
                        {
                            this.CreateClassNode(node, c, hbc ? 3 : 1);
                        }
                    }
                    
                    node.Expand();
                }
                
                this.UpdateButtons();
            }
            finally
            {
                this.treeClasses.EndUpdate();
            }
        }
        
        private void CategoryItemClick(object sender, EventArgs e)
        {
            this.toolComboCategory.SelectedItem = ((ToolStripMenuItem)sender).Text;
        }
        
        /// <summary>
        /// Возвращает элемент дерева, соответствующий шаблону obj.
        /// </summary>
        /// <param name="root">Элемент дерева, с которога начинается поиск.</param>
        /// <param name="obj">Исковый шаблон.</param>
        /// <returns>Элемент дерева, соответствующий шаблону obj.</returns>
        private TreeNode GetNode(TreeNode root, ObjectClass obj)
        {
            foreach (TreeNode node in root.Nodes)
            {
                if (node.Tag is ObjectClassProxy)
                {
                    ObjectClassProxy proxy = (ObjectClassProxy)node.Tag;
                    if (proxy != null && proxy.ObjectClass == obj)
                    {
                        return node;
                    }
                }
                    
                TreeNode result = this.GetNode(node, obj);
                if (result != null)
                {
                    return result;
                }
            }
            
            return null;
        }
        
        private void CreateNodes(IList<TreeNode> list, TreeNode root, ObjectClass obj)
        {
            foreach (TreeNode node in root.Nodes)
            {
                if (node.Tag is ObjectClassProxy)
                {
                    ObjectClassProxy proxy = (ObjectClassProxy)node.Tag;
                    if (proxy != null && proxy.ObjectClass == obj)
                    {
                        list.Add(node);
                    }
                }
                    
                this.CreateNodes(list, node, obj);
            }
        }
        
        private IList<TreeNode> GetNodes(TreeNode root, ObjectClass obj)
        {
            List<TreeNode> result = new List<TreeNode>();
            this.CreateNodes(result, root, obj);
            return result;
        }
        
        /// <summary>
        /// Создает список элементов дерева, содержащих атрибут field.
        /// </summary>
        /// <param name="list">Список, который необходимо заполнить.</param>
        /// <param name="root">Элемент дерева, с которога начинается поиск.</param>
        /// <param name="field">Искомый атрибут.</param>
        private void CreateNodes(IList<TreeNode> list, TreeNode root, Field field)
        {
            foreach (TreeNode node in root.Nodes)
            {
                if (node.Tag is Field)
                {
                    Field prop = (Field)node.Tag;
                    if (prop == field)
                    {
                        list.Add(node);
                    }
                }
                    
                this.CreateNodes(list, node, field);
            }
        }
        
        /// <summary>
        /// Возвращает список элементов дерева, содержащих атрибут field.
        /// </summary>
        /// <param name="root">Список, который необходимо заполнить.</param>
        /// <param name="field">Искомый атрибут.</param>
        /// <returns>Список элементов дерева, содержащих атрибут field.</returns>
        private IList<TreeNode> GetNodes(TreeNode root, Field field)
        {
            List<TreeNode> result = new List<TreeNode>();
            this.CreateNodes(result, root, field);
            return result;
        }
        
        private TreeNode GetBaseClassNode(TreeNode node)
        {
            foreach (TreeNode n in node.Nodes)
            {
                if (n.ImageIndex == 0)
                {
                    return n.Nodes.Count == 0 ? null : n.Nodes[0];
                }
            }
            
            return null;
        }
        
        private void UpdateTreeFields(TreeNodeCollection nodes)
        {
            this.CreateClassesTree();
        }
        
        private void proxy_ClassNameModified(object sender, EventArgs e)
        {
            ObjectClass obj = (ObjectClass)sender;
            TreeNode node = this.GetNode(this.treeClasses.Nodes[0], obj);
            if (node != null)
            {
                node.Text = obj.Name;
            }
        }
        
        private void proxy_ClassCreatingModified(object sender, EventArgs e)
        {
            App.Folder.UpdateCategories();
        }
        
        // FIXME: Если изменяется категория корневого класса, и осуществляется выделение следующего/предыдущего - пропадает текст категории в свойствах класса. Хотя повторное выделение класса или свойства, возвращает текст на место.
        private void proxy_ClassCategoryModified(object sender, EventArgs e)
        {
            ObjectClass obj = (ObjectClass)sender;
            string currentCat = (string)this.toolComboCategory.SelectedItem;
            if (!this.toolComboCategory.Items.Contains(obj.Category))
            {
                this.toolComboCategory.Items.Add(obj.Category);
            }
            
            IEnumerable<ObjectClass> classes = this.Database.Classes.GetClasses(obj, currentCat);
            if (classes.Count() == 0)
            {
                TreeNode node = null;
                if (this.treeClasses.SelectedNode.NextNode != null)
                {
                    node = this.treeClasses.SelectedNode.NextNode;
                }
                else if (this.treeClasses.SelectedNode.PrevNode != null)
                {
                    node = this.treeClasses.SelectedNode.PrevNode;
                }
                
                this.treeClasses.Nodes.Remove(this.treeClasses.SelectedNode);
                this.treeClasses.SelectedNode = node;
            }
            
            IEnumerable<string> cats = this.Database.Classes.ClassCategories;
            Stack<string> dels = new Stack<string>();
            foreach (string cat in this.toolComboCategory.Items)
            {
                if (!cats.Contains(cat))
                {
                    dels.Push(cat);
                }
            }
            
            while (dels.Count > 0)
            {
                this.toolComboCategory.Items.Remove(dels.Pop());
            }
            
            App.Folder.UpdateCategories();
        }
        
        private void proxy_FieldNameModified(object sender, EventArgs e)
        {
            Field field = (Field)sender;
            foreach (TreeNode node in this.GetNodes(this.treeClasses.Nodes[0], field))
            {
                node.Text = field.Name;
            }
        }
        
        private void proxy_FieldTypeModified(object sender, EventArgs e)
        {
            Field field = sender as Field;
            this.OnFieldGroupModified(field);
        }
        
        private void proxy_FieldModified(object sender, EventArgs e)
        {
            Field field = sender as Field;
            this.OnFieldGroupModified(field);
        }
        
        private void proxy_FieldGroupModified(object sender, EventArgs e)
        {
            this.OnFieldGroupModified((Field)sender);
        }
        
        private void UpdateButtons()
        {
            bool enable = this.treeClasses.SelectedNode != null;
            bool fieldEnable = enable;
            bool classEnable = enable;
            bool up = false;
            bool down = false;
            if (enable)
            {
                classEnable = this.treeClasses.SelectedNode.Tag is ObjectClassProxy;
                fieldEnable = this.treeClasses.SelectedNode.Tag is Field;
                if (fieldEnable)
                {
                    Field field = (Field)this.treeClasses.SelectedNode.Tag;
                    fieldEnable = field.SystemProperty == SystemProperty.Custom;
                    up = this.treeClasses.SelectedNode.PrevNode != null && this.treeClasses.SelectedNode.PrevNode.SelectedImageIndex != 0;
                    down = this.treeClasses.SelectedNode.NextNode != null;
                }
            }
            
            this.toolButtonDeleteField.Enabled = fieldEnable;
            this.toolButtonDeleteClass.Enabled = classEnable;
            this.toolButtonUp.Enabled = fieldEnable && up;
            this.toolButtonDown.Enabled = fieldEnable && down;
        }
        
        private void ImportConfiguration(string fileName)
        {
            ImportConfiguration import = new ImportConfiguration(this.Database);
            if (string.IsNullOrEmpty(fileName))
            {
                this.importFileDialog.Filter = import.FilterString;
                this.importFileDialog.DefaultExt = import.ShortExtension;
                if (this.importFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = this.importFileDialog.FileName;
                }
            }
            
            if (!string.IsNullOrEmpty(fileName))
            {
                if (import.Execute(fileName, MainForm.Config.App.View.LocalCode))
                {
                    string selCat = (string)this.toolComboCategory.SelectedItem;
                    this.CreateCategoriesList();
                    if (string.IsNullOrEmpty(selCat))
                    {
                        if (this.toolComboCategory.Items.Count > 0)
                        {
                            this.toolComboCategory.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        this.toolComboCategory.SelectedItem = selCat;
                    }
                    
                    App.Folder.UpdateCategories();
                }
            }
        }
        
        private void LoadTemplates()
        {
            string dir = Path.GetDirectoryName(Application.ExecutablePath) + @"\Templates\" + MainForm.Config.App.View.LocalCode.Substring(0, 2);
            if (Directory.Exists(dir))
            {
                foreach (string file in Directory.GetFiles(dir))
                {
                    XmlDocument doc = new XmlDocument();
                    try
                    {
                        doc.Load(file);
                        foreach (XmlNode node in doc.ChildNodes)
                        {
                            if (node.Name == "config")
                            {
                                XmlAttribute desc = node.Attributes["title"];
                                if (desc != null)
                                {
                                    ToolStripMenuItem itemButton = new ToolStripMenuItem(desc.Value);
                                    itemButton.Tag = file;
                                    this.toolButtonImport.DropDownItems.Add(itemButton);
                                    
                                    ToolStripMenuItem itemMenu = new ToolStripMenuItem(desc.Value);
                                    itemMenu.Tag = file;
                                    this.menuItemImport.DropDownItems.Add(itemMenu);
                                    
                                    itemButton.Click += new EventHandler(this.LoadTemplate);
                                    itemMenu.Click += new EventHandler(this.LoadTemplate);
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
        
        private void LoadTemplate(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            this.ImportConfiguration((string)item.Tag);
        }
        
        private void TreeClassesAfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is Field)
            {
                Field field = (Field)e.Node.Tag;
                FieldProxy proxy = new FieldProxy(field.ObjectClass, field, Database);
                proxy.FieldNameModified += new EventHandler<EventArgs>(this.proxy_FieldNameModified);
                proxy.FieldTypeModified += new EventHandler<EventArgs>(this.proxy_FieldTypeModified);
                proxy.FieldGroupModified += new EventHandler<EventArgs>(this.proxy_FieldGroupModified);
                proxy.FieldModified += new EventHandler<EventArgs>(this.proxy_FieldModified);
                this.propertyGrid1.SelectedObject = proxy;
            }
            else
            {
                this.propertyGrid1.SelectedObject = e.Node.Tag;
            }
            
            this.UpdateButtons();
        }
        
        private void ToolComboCategorySelectedIndexChanged(object sender, EventArgs e)
        {
            this.CreateClassesTree();
            foreach (ToolStripMenuItem item in this.menuItemCategory.DropDownItems)
            {
                if (item.Text == (string)this.toolComboCategory.SelectedItem)
                {
                    if (this.selectedItem != item)
                    {
                        if (this.selectedItem != null)
                        {
                            this.selectedItem.Checked = false;
                        }
                        
                        this.selectedItem = item;
                        
                        if (this.selectedItem != null)
                        {
                            this.selectedItem.Checked = true;
                        }
                    }
                }
            }
        }
        
        private void ToolButtonCreateClassClick(object sender, EventArgs e)
        {
            FormClassProperty form = new FormClassProperty();
            form.Database = Database;
            ObjectClass o = form.GetNewClass();
            if (o != null)
            {
                Database.Classes.Add(o);
                if (o.BaseClass != null)
                {
                    TreeNode find = null;
                    foreach (TreeNode node in this.treeClasses.Nodes[0].Nodes)
                    {
                        ObjectClassProxy proxy = (ObjectClassProxy)node.Tag;
                        if (proxy != null && proxy.ObjectClass == o.BaseClass)
                        {
                            find = node;
                            break;
                        }
                    }
                    
                    if (find != null)
                    {
                        this.treeClasses.BeginUpdate();
                        this.treeClasses.Nodes.Remove(find);
                        this.treeClasses.EndUpdate();
                    }
                }
                
                if (o.Category == (string)this.toolComboCategory.SelectedItem)
                {
                    this.CreateClassNode(this.treeClasses.Nodes[0], o, 1);
                }
                else
                {
                    if (!this.toolComboCategory.Items.Contains(o.Category))
                    {
                        this.toolComboCategory.Items.Add(o.Category);
                        App.Folder.AddCategory(o.Category);
                    }
                }
                
                if (this.toolComboCategory.SelectedItem == null && this.toolComboCategory.Items.Count > 0)
                {
                    this.toolComboCategory.SelectedItem = this.toolComboCategory.Items[0];
                }
            }
        }
        
        private void ToolButtonCreateFieldClick(object sender, EventArgs e)
        {
            TreeNode node = this.treeClasses.SelectedNode;
            ObjectClassProxy oc = null;
            while (node != null && oc == null)
            {
                oc = node.Tag as ObjectClassProxy;
                node = node.Parent;
            }
            
            FormFieldProperty form = new FormFieldProperty();
            form.Database = Database;
            Field field = form.GetNewField(oc == null ? null : oc.ObjectClass);
            if (field != null)
            {
                Database.Classes.Update(form.Template);
                foreach (TreeNode n in this.GetNodes(this.treeClasses.Nodes[0], form.Template))
                {
                    this.CreateFieldNode(n, form.Template, field);
                }
            }
        }
        
        private void ToolButtonDeleteFieldClick(object sender, EventArgs e)
        {
            if (KryptonMessageBox.Show(Strings.ConfirmDeleteField, Strings.Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Field prop = (Field)this.treeClasses.SelectedNode.Tag;
                Database.Classes.RemoveField(prop);
                this.treeClasses.SelectedNode.Parent.Nodes.Remove(this.treeClasses.SelectedNode);
                this.OnFieldDeleted(prop);
            }
        }
        
        private void ToolButtonDeleteClassClick(object sender, EventArgs e)
        {
            if (KryptonMessageBox.Show(Strings.ConfirmDeleteClass, Strings.Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<ObjectClass> deleted = new List<ObjectClass>();
                ObjectClassProxy proxy = (ObjectClassProxy)this.treeClasses.SelectedNode.Tag;
                foreach (ObjectClass obj in Database.Classes.GetHierarchyClasses(proxy.ObjectClass, MoveDirection.Up))
                {
                    deleted.Add(obj);
                    Database.Classes.Remove(obj);
                }
                
                this.OnDeleteClasses(deleted);
                
                TreeNode node = this.GetBaseClassNode(this.treeClasses.SelectedNode);
                
                TreeNode cur = this.treeClasses.SelectedNode;
                while (cur.Parent.Parent != null)
                {
                    cur = cur.Parent;
                }
                
                this.UpdateTreeFields(this.treeClasses.Nodes);
                
                if (Database.Classes.GetClasses(proxy.Category).Count() == 0)
                {
                    this.toolComboCategory.Items.Remove(proxy.Category);
                    App.Folder.UpdateCategories();
                }
            }
        }
        
        private void ContextMenuStrip1Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool enable = this.treeClasses.SelectedNode != null;
            bool fieldEnable = enable;
            bool classEnable = enable;
            int order = -1;
            int max = -1;
            if (enable)
            {
                classEnable = this.treeClasses.SelectedNode.Tag is ObjectClassProxy;
                fieldEnable = this.treeClasses.SelectedNode.Tag is Field;
                if (fieldEnable)
                {
                    Field field = (Field)this.treeClasses.SelectedNode.Tag;
                    fieldEnable = field.SystemProperty == SystemProperty.Custom;
                    order = field.Order;
                    max = field.ObjectClass.Fields.Count() - 1;
                }
            }
            
            this.menuItemDeleteField.Enabled = fieldEnable;
            this.menuItemDeleteClass.Enabled = classEnable;
            this.menuItemUp.Enabled = fieldEnable && order > 0;
            this.menuItemDown.Enabled = fieldEnable && order < max;
        }
        
        private void ToolButtonUpClick(object sender, EventArgs e)
        {
            Field prop = (Field)this.treeClasses.SelectedNode.Tag;
            prop.ObjectClass.MoveField(prop, -1);
            Database.Classes.Update(prop.ObjectClass);

            int index = this.treeClasses.SelectedNode.Index - 1;
            TreeNode node = this.treeClasses.SelectedNode;
            TreeNode nodes = node.Parent;
            nodes.Nodes.Remove(node);
            nodes.Nodes.Insert(index, node);
            this.treeClasses.SelectedNode = node;
        }
        
        private void ToolButtonImportButtonClick(object sender, EventArgs e)
        {
            this.ImportConfiguration(string.Empty);
        }
        
        private void ToolButtonExportClick(object sender, EventArgs e)
        {
            ExportConfiguration export = new ExportConfiguration(this.Database);
            this.exportFileDialog.Filter = export.FilterString;
            this.exportFileDialog.DefaultExt = export.ShortExtension;
            if (this.exportFileDialog.ShowDialog() == DialogResult.OK)
            {
                export.Execute(this.exportFileDialog.FileName);
            }
        }
        
        private void ToolButtonAllClassesClick(object sender, EventArgs e)
        {
            this.toolButtonAllClasses.Checked = !this.toolButtonAllClasses.Checked;
            this.CreateClassesTree();
        }
        
        private void ToolButtonDownClick(object sender, EventArgs e)
        {
            Field prop = (Field)this.treeClasses.SelectedNode.Tag;
            prop.ObjectClass.MoveField(prop, 1);
            Database.Classes.Update(prop.ObjectClass);

            int index = this.treeClasses.SelectedNode.Index + 1;
            TreeNode node = this.treeClasses.SelectedNode;
            TreeNode nodes = node.Parent;
            nodes.Nodes.Remove(node);
            nodes.Nodes.Insert(index, node);
            this.treeClasses.SelectedNode = node;
        }
    }
}
