//-----------------------------------------------------------------------
// <copyright file="FormEditor.cs" company="Sergey Teplyashin">
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
// <date>20.06.2011</date>
// <time>12:55</time>
// <summary>Defines the FormEditor class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Properties
{
    #region Using directives
    
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using WeifenLuo.WinFormsUI.Docking;
    
    #endregion
    
    /// <summary>
    /// Description of FormEditor.
    /// </summary>
    public partial class FormEditor : KryptonForm
    {
        private EditorWindow editor;
        
        public FormEditor(string title, string text)
        {
            InitializeComponent();
            this.editor = new EditorWindow(text);
            this.editor.Text = title;
            this.editor.Show(this.dockPanel1, DockState.Document);
            this.editor.Activate();
        }
        
        public string TextCode
        {
            get { return this.editor.TextCode; }
            set { this.editor.TextCode = value; }
        }
        
        private void MenuItemCreateClick(object sender, EventArgs e)
        {
            this.TextCode = string.Empty;
        }
        
        private void MenuItemOpenClick(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.editor.CodeEditor.Open(this.openFileDialog1.FileName);
            }
        }
        
        private void MenuItemSaveClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        
        private void MenuItemCloseClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        
        private void MenuItemUndoClick(object sender, EventArgs e)
        {
            this.editor.CodeEditor.Undo();
        }
        
        private void MenuItemRedoClick(object sender, EventArgs e)
        {
            this.editor.CodeEditor.Redo();
        }
        
        private void MenuItemCutClick(object sender, EventArgs e)
        {
            this.editor.Cut();
        }
        
        private void MenuItemCopyClick(object sender, EventArgs e)
        {
            this.editor.Copy();
        }
        
        private void MenuItemPasteClick(object sender, EventArgs e)
        {
            this.editor.Paste();
        }
        
        private void MenuItemDeleteClick(object sender, EventArgs e)
        {
            this.editor.Delete();
        }
    }
}
