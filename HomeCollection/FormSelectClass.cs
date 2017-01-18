//-----------------------------------------------------------------------
// <copyright file="FormSelectClass.cs" company="Sergey Teplyashin">
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
// <date>17.03.2011</date>
// <time>10:29</time>
// <summary>Defines the FormSelectClass class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using HomeCollection.Data;
    
    #endregion
    
    /// <summary>
    /// Description of FormSelectClass.
    /// </summary>
    public partial class FormSelectClass : KryptonForm
    {
        private string category;
        private Folder folder;
        private Database data;
        
        public FormSelectClass(Database data, string category, Folder folder)
        {
            InitializeComponent();
        
            this.data = data;
            this.category = category;
            this.folder = folder;
            this.UpdateListClasses();
        }
        
        public ObjectClass Selected
        {
            get { return (ObjectClass)this.comboClasses.SelectedItem; }
        }
        
        private void UpdateListClasses()
        {
            IEnumerable<ObjectClass> classes;
            if (this.checkAllClasses.Checked)
            {
                classes = this.data.Classes.Collection;
            }
            else if (this.folder == null)
            {
                if (string.IsNullOrEmpty(this.category))
                {
                    classes = this.data.Classes.Collection;
                }
                else
                {
                    classes = this.data.Classes.GetClasses(this.category);
                }
            }
            else
            {
                classes = this.folder.Classes;
            }
            
            this.comboClasses.Items.Clear();
            foreach (ObjectClass oc in classes)
            {
                if (oc.CreatingObjects)
                {
                    this.comboClasses.Items.Add(oc);
                }
            }
        }
        
        private void CheckAllClassesCheckedChanged(object sender, EventArgs e)
        {
            this.UpdateListClasses();
        }
    }
}
