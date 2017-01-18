//-----------------------------------------------------------------------
// <copyright file="EditorWindow.Designer.cs" company="Sergey Teplyashin">
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
// <date>25.05.2012</date>
// <time>8:56</time>
// <summary>Defines the EditorWindow class.</summary>
//-----------------------------------------------------------------------
namespace HomeCollection.Properties
{
    partial class EditorWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorWindow));
            Fireball.Windows.Forms.LineMarginRender lineMarginRender2 = new Fireball.Windows.Forms.LineMarginRender();
            this.codeEditor = new Fireball.Windows.Forms.CodeEditorControl();
            this.syntaxDocument = new Fireball.Syntax.SyntaxDocument(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // codeEditor
            // 
            resources.ApplyResources(this.codeEditor, "codeEditor");
            this.codeEditor.ActiveView = Fireball.Windows.Forms.CodeEditor.ActiveView.BottomRight;
            this.codeEditor.AutoListPosition = null;
            this.codeEditor.AutoListSelectedText = "a123";
            this.codeEditor.AutoListVisible = false;
            this.codeEditor.CopyAsRTF = false;
            this.codeEditor.Document = this.syntaxDocument;
            this.codeEditor.InfoTipCount = 1;
            this.codeEditor.InfoTipPosition = null;
            this.codeEditor.InfoTipSelectedIndex = 1;
            this.codeEditor.InfoTipVisible = false;
            lineMarginRender2.Bounds = new System.Drawing.Rectangle(19, 0, 19, 16);
            this.codeEditor.LineMarginRender = lineMarginRender2;
            this.codeEditor.LockCursorUpdate = false;
            this.codeEditor.Name = "codeEditor";
            this.codeEditor.Saved = false;
            this.codeEditor.ShowScopeIndicator = false;
            this.codeEditor.SmoothScroll = false;
            this.codeEditor.SplitviewH = -4;
            this.codeEditor.SplitviewV = -4;
            this.codeEditor.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(234)))));
            this.codeEditor.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // syntaxDocument
            // 
            this.syntaxDocument.Lines = new string[] {
                        ""};
            this.syntaxDocument.MaxUndoBufferSize = 1000;
            this.syntaxDocument.Modified = false;
            this.syntaxDocument.UndoStep = 0;
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.menuItemCut,
                                    this.menuItemCopy,
                                    this.menuItemPaste,
                                    this.menuItemDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // menuItemCut
            // 
            resources.ApplyResources(this.menuItemCut, "menuItemCut");
            this.menuItemCut.Image = global::HomeCollection.Properties.ComponentModel.Resources.cut;
            this.menuItemCut.Name = "menuItemCut";
            this.menuItemCut.Click += new System.EventHandler(this.MenuItemCutClick);
            // 
            // menuItemCopy
            // 
            resources.ApplyResources(this.menuItemCopy, "menuItemCopy");
            this.menuItemCopy.Image = global::HomeCollection.Properties.ComponentModel.Resources.page_white_copy;
            this.menuItemCopy.Name = "menuItemCopy";
            this.menuItemCopy.Click += new System.EventHandler(this.MenuItemCopyClick);
            // 
            // menuItemPaste
            // 
            resources.ApplyResources(this.menuItemPaste, "menuItemPaste");
            this.menuItemPaste.Image = global::HomeCollection.Properties.ComponentModel.Resources.page_white_paste;
            this.menuItemPaste.Name = "menuItemPaste";
            this.menuItemPaste.Click += new System.EventHandler(this.MenuItemPasteClick);
            // 
            // menuItemDelete
            // 
            resources.ApplyResources(this.menuItemDelete, "menuItemDelete");
            this.menuItemDelete.Image = global::HomeCollection.Properties.ComponentModel.Resources._1338097075_DeleteRed;
            this.menuItemDelete.Name = "menuItemDelete";
            this.menuItemDelete.Click += new System.EventHandler(this.MenuItemDeleteClick);
            // 
            // EditorWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.codeEditor);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Name = "EditorWindow";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.ToolStripMenuItem menuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaste;
        private System.Windows.Forms.ToolStripMenuItem menuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem menuItemCut;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Fireball.Syntax.SyntaxDocument syntaxDocument;
        private Fireball.Windows.Forms.CodeEditorControl codeEditor;
    }
}
