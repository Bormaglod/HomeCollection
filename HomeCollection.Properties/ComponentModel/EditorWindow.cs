//-----------------------------------------------------------------------
// <copyright file="EditorWindow.cs" company="Sergey Teplyashin">
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
    #region Using directives
    
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Fireball.Windows.Forms;
    using Fireball.CodeEditor.SyntaxFiles;
    using WeifenLuo.WinFormsUI.Docking;
    
    #endregion

    public partial class EditorWindow : DockContent
    {
        public EditorWindow(string text)
        {
            InitializeComponent();
            CodeEditorSyntaxLoader.SetSyntax(this.codeEditor, SyntaxLanguage.XML);
            this.TextCode = text;
        }
        
        public string TextCode
        {
            get
            {
                string text = string.Empty;
                foreach (string s in this.codeEditor.Document.Lines)
                {
                    text += s + "\n";
                }
                
                return text;
            }

            set
            {
                char separator = char.Parse("\n");
                this.codeEditor.Document.Lines = value.Split(new char[] { separator } );
            }
        }
        
        public CodeEditorControl CodeEditor
        {
            get { return this.codeEditor; }
        }
        
        public void Cut()
        {
            this.codeEditor.Cut();
        }
        
        public void Copy()
        {
            this.codeEditor.Copy();
        }
        
        public void Paste()
        {
            this.codeEditor.Paste();
        }
        
        public void Delete()
        {
            this.codeEditor.Delete();
        }
        
        private void MenuItemCutClick(object sender, EventArgs e)
        {
            this.Cut();
        }
        
        private void MenuItemCopyClick(object sender, EventArgs e)
        {
            this.Copy();
        }
        
        private void MenuItemPasteClick(object sender, EventArgs e)
        {
            this.Paste();
        }
        
        private void MenuItemDeleteClick(object sender, EventArgs e)
        {
            this.Delete();
        }
    }
}
