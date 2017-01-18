//-----------------------------------------------------------------------
// <copyright file="FormSelectMultipleObjectData.cs" company="Sergey Teplyashin">
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
// <date>13.04.2011</date>
// <time>10:18</time>
// <summary>Defines the FormSelectMultipleObjectData class.</summary>
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
    using HomeCollection.Core;
    
    #endregion

    // TODO: Need localizable
    /// <summary>
    /// Description of FormSelectMultipleObjectData.
    /// </summary>
    public partial class FormSelectMultipleObjectData : KryptonForm
    {
        private ObjectClass objectClass;
        private Database database;
        private IDataCollection collection;
        
        public FormSelectMultipleObjectData(IDataCollection collection, Database database, ObjectClass obj)
        {
            InitializeComponent();
            
            this.objectClass = obj;
            this.database = database;
            this.collection = collection;
            
            foreach (ObjectData d in this.database.Objects.GetData(obj))
            {
                this.listObjects.Items.Add(d);
            }
            
            Text = this.objectClass.Name;
        }
        
        public event EventHandler<DataItemEventArgs> DataItemAdded;
        
        public IEnumerable<ObjectData> GetObjectData()
        {
            List<ObjectData> list = new List<ObjectData>();
            if (ShowDialog() == DialogResult.OK)
            {
                foreach (ObjectData od in this.listObjects.CheckedItems)
                {
                    list.Add(od);
                }
            }
            
            return list;
        }
        
        private void ButtonSelectAllClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listObjects.Items.Count; i++)
            {
                this.listObjects.SetItemChecked(i, true);
            }
        }
        
        private void ButtonDeselectAllClick(object sender, EventArgs e)
        {
        	for (int i = 0; i < this.listObjects.Items.Count; i++)
            {
                this.listObjects.SetItemChecked(i, false);
            }
        }
        
        private void ButtonAddClick(object sender, EventArgs e)
        {
            ObjectData d = this.collection.Add(this.objectClass, false);
            if (d != null)
            {
                int n = this.listObjects.Items.Add(d);
                this.listObjects.SetItemChecked(n, true);
                if (this.DataItemAdded != null)
                {
                    this.DataItemAdded(this, new DataItemEventArgs(d));
                }
            }
        }
    }
}
