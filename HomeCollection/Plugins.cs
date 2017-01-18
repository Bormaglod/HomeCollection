//-----------------------------------------------------------------------
// <copyright file="Plugins.cs" company="Sergey Teplyashin">
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
// <date>11.04.2012</date>
// <time>7:58</time>
// <summary>Defines the Plugins class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.AddIn.Hosting;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using HomeCollection.AddIns;
    
    #endregion
    
    /// <summary>
    /// Description of Plugins.
    /// </summary>
    public class Plugins
    {
        private static List<DataPlugin> plugins = new List<DataPlugin>();
        
        public static void ActivatePlugins()
        {
            if (!File.Exists("PipelineSegments.store"))
            {
                Rebuild();
                return;
            }
            
            foreach (AddInToken addIn in AddInStore.FindAddIns(typeof(DataPlugin), PipelineStoreLocation.ApplicationBase))
            {
                AddInProcess process = new AddInProcess();
                process.KeepAlive = false;
                DataPlugin activeAddIn = addIn.Activate<DataPlugin>(process, AddInSecurityLevel.Host);
                plugins.Add(activeAddIn);
            }
        }
        
        public static IEnumerable<DataPlugin> GetPlugins(Guid guid)
        {
            List<DataPlugin> list = new List<DataPlugin>();
            foreach (DataPlugin plugin in plugins)
            {
                if (plugin.GetObjectClassId().Contains(guid))
                {
                    list.Add(plugin);
                }
            }
            
            return list;
        }
        
        public static void Rebuild()
        {
            string[] messages = AddInStore.Rebuild(PipelineStoreLocation.ApplicationBase);
            if (messages.Length != 0)
            {
                KryptonMessageBox.Show(string.Join("\n", messages),
                                       "AddInStore Warnings", MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning);
            }
        }
    }
}
