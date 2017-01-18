//-----------------------------------------------------------------------
// <copyright file="FormStringCollection.cs" company="Sergey Teplyashin">
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
// <date>09.02.2011</date>
// <time>9:46</time>
// <summary>Defines the FormStringCollection class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Properties
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    
    #endregion

    /// <summary>
    /// Description of FormStringCollection.
    /// </summary>
    public partial class FormStringCollection : KryptonForm
    {
        private List<string> collection;
        
        public FormStringCollection(List<string> collectionData)
        {
            this.InitializeComponent();
            
            this.collection = new List<string>();
            foreach (string s in collectionData)
            {
                this.collection.Add(s);
                this.listStrings.Items.Add(s);
            }
            
            if (this.listStrings.Items.Count > 0)
            {
                this.listStrings.SelectedIndex = 0;
            }
            
            this.UpdateButtons();
        }
        
        public List<string> Collection
        {
            get { return this.collection; }
        }
        
        private void UpdateButtons()
        {
            this.buttonEdit.Enabled = this.listStrings.SelectedIndex != -1;
            this.buttonDelete.Enabled = this.buttonEdit.Enabled;
            this.buttonUp.Enabled = this.buttonEdit.Enabled && this.listStrings.SelectedIndex > 0;
            this.buttonDown.Enabled = this.buttonEdit.Enabled && this.listStrings.SelectedIndex < this.listStrings.Items.Count - 1;
        }
        
        private void ButtonAddClick(object sender, EventArgs e)
        {
            string res = KryptonInputBox.Show(Strings.InputValue, Strings.Value, string.Empty);
            if (!string.IsNullOrEmpty(res))
            {
                this.listStrings.Items.Add(res);
                this.UpdateButtons();
            }
        }
        
        private void ButtonEditClick(object sender, EventArgs e)
        {
            if (this.listStrings.SelectedIndex != -1)
            {
                string def = (string)this.listStrings.SelectedItem;
                string res = KryptonInputBox.Show(Strings.InputValue, Strings.Value, def);
                if (def != res)
                {
                    this.listStrings.Items[this.listStrings.SelectedIndex] = res;
                }
            }
        }
        
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (this.listStrings.SelectedIndex != -1)
            {
                this.listStrings.Items.RemoveAt(this.listStrings.SelectedIndex);
                this.UpdateButtons();
            }
        }
        
        private void ButtonUpClick(object sender, EventArgs e)
        {
            if (this.listStrings.SelectedIndex > 0)
            {
                string sel = (string)this.listStrings.SelectedItem;
                int newPos = this.listStrings.SelectedIndex - 1;
                this.listStrings.Items.Remove(sel);
                this.listStrings.Items.Insert(newPos, sel);
                this.listStrings.SelectedItem = sel;
            }
        }
        
        private void ButtonDownClick(object sender, EventArgs e)
        {
            if (this.listStrings.SelectedIndex != -1 && this.listStrings.SelectedIndex < this.listStrings.Items.Count - 1)
            {
                string sel = (string)this.listStrings.SelectedItem;
                int newPos = this.listStrings.SelectedIndex + 1;
                this.listStrings.Items.Remove(sel);
                this.listStrings.Items.Insert(newPos, sel);
                this.listStrings.SelectedItem = sel;
            }
        }
        
        private void ButtonOKClick(object sender, EventArgs e)
        {
            this.collection.Clear();
            foreach (string s in this.listStrings.Items)
            {
                this.collection.Add(s);
            }
        }
        
        private void ListStringsSelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateButtons();
        }
    }
}
