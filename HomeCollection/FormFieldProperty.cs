//-----------------------------------------------------------------------
// <copyright file="FormFieldProperty.cs" company="Sergey Teplyashin">
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
// <date>10.02.2011</date>
// <time>12:37</time>
// <summary>Defines the FormFieldProperty class.</summary>
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
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of FormFieldProperty.
    /// </summary>
    public partial class FormFieldProperty : KryptonForm
    {
        private Database database;
        
        public FormFieldProperty()
        {
            InitializeComponent();
        }
        
        public Database Database
        {
            get
            {
                return this.database;
            }
            
            set
            {
                this.database = value;
                this.CreateObjectClassList();
                foreach (string fname in Utils.GetFieldTypeNames())
                {
                    this.comboType.Items.Add(fname);
                }
            }
        }
        
        public ObjectClass Template
        {
            get { return (ObjectClass)this.comboTemplate.SelectedItem; }
        }
        
        public Field GetNewField(ObjectClass objectClass)
        {
            this.comboTemplate.SelectedItem = objectClass;
            if (ShowDialog() == DialogResult.OK)
            {
                return this.database.Classes.AddField(Template, this.textName.Text, EnumDescription.GetFieldType((string)this.comboType.SelectedItem));
            }
            else
            {
                return null;
            }
        }
        
        private void CreateObjectClassList()
        {
            this.comboTemplate.Items.Clear();
            foreach (ObjectClass o in this.database.Classes.Collection)
            {
                this.comboTemplate.Items.Add(o);
            }
        }
        
        private void ButtonOKClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textName.Text) || this.comboTemplate.SelectedIndex == -1)
            {
                DialogResult = DialogResult.None;
            }
        }
    }
}
