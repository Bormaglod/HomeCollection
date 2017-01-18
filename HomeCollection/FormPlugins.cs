//-----------------------------------------------------------------------
// <copyright file="FormPlugins.cs" company="Sergey Teplyashin">
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
// <date>30.05.2011</date>
// <time>9:19</time>
// <summary>Defines the FormPlugins class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.AddIn.Hosting;
    using System.AddIn.Pipeline;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using HomeCollection.AddIns;
    
    #endregion
    
    /// <summary>
    /// Description of FormPlugins.
    /// </summary>
    public partial class FormPlugins : KryptonForm
    {
        public FormPlugins()
        {
            InitializeComponent();
            if (!File.Exists("PipelineSegments.store"))
            {
                Plugins.Rebuild();
            }
        }
        
        public void ShowPlugins()
        {
            this.BuildListPlugins();
            ShowDialog();
        }
        
        private void AddRow(string name, string val)
        {
            int r = this.gridPluginInfo.Rows.Add();
            this.gridPluginInfo[0, r].Value = name;
            this.gridPluginInfo[1, r].Value = val;
        }
        
        private void BuildListPlugins()
        {
            this.listPlugins.Items.Clear();
            foreach (var addIn in AddInStore.FindAddIns(typeof(DataPlugin), PipelineStoreLocation.ApplicationBase))
            {
                this.listPlugins.Items.Add(addIn);
            }
            
            if (this.listPlugins.Items.Count > 0)
            {
                this.listPlugins.SelectedItem = this.listPlugins.Items[0];
            }
        }
        
        private void ListPluginsSelectedIndexChanged(object sender, EventArgs e)
        {
            this.gridPluginInfo.Rows.Clear();
            if (this.listPlugins.SelectedIndex != -1)
            {
                AddInToken token = this.listPlugins.SelectedItem as AddInToken;
                if (token != null)
                {
                    this.AddRow(Strings.Name, token.Name);
                    this.AddRow(Strings.Copyright, token.Publisher);
                    this.AddRow(Strings.Version, token.Version);
                    this.textDescription.Text = token.Description;
                }
            }
            else
            {
                this.textDescription.Text = string.Empty;
            }
        }
        
        private void ButtonUpdateClick(object sender, EventArgs e)
        {
            Plugins.Rebuild();
            this.BuildListPlugins();
        }
    }
}
