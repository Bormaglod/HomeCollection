//-----------------------------------------------------------------------
// <copyright file="FormAbout.cs" company="Sergey Teplyashin">
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
// <date>23.01.2011</date>
// <time>13:27</time>
// <summary>Defines the MainForm class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using ComponentLib.Core;
    
    #endregion
    
    /// <summary>
    /// Description of FormAbout.
    /// </summary>
    public partial class FormAbout : KryptonForm
    {
        public FormAbout()
        {
            this.InitializeComponent();
            
            Assembly current = Assembly.GetExecutingAssembly();
            AssemblyName name = current.GetName();
            this.textVersion.Text = string.Format("{0}.{1}.{2}", name.Version.Major, name.Version.Minor, name.Version.Build);
            this.textBuild.Text = name.Version.Revision.ToString();
            this.listViewAbout.Items[0].SubItems.Add(name.Version.ToString());
            this.listViewAbout.Items[1].SubItems.Add(Environment.Version.ToString());
            this.listViewAbout.Items[2].SubItems.Add(Environment.OSVersion.VersionString);
            
            string cultureName = null;
            try
            {
                cultureName = CultureInfo.CurrentCulture.Name;
                this.listViewAbout.Items[3].SubItems.Add(string.Format("{0} ({1})", CultureInfo.CurrentCulture.DisplayName, cultureName));
            }
            catch { }
            
            Process p = Process.GetCurrentProcess();
            this.listViewAbout.Items[4].SubItems.Add(string.Format("{0} kb", p.WorkingSet64 / 1024));
            this.listViewAbout.Items[5].SubItems.Add(string.Format("{0} kb", GC.GetTotalMemory(false) / 1024));
            
            this.listViewVersions.BeginUpdate();
            try
            {
                foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
                {
                    AssemblyName n = a.GetName();
                    ListViewItem item = this.listViewVersions.Items.Add(n.Name);
                    item.SubItems.Add(n.Version.ToString());
                    try
                    {
                        item.SubItems.Add(a.Location);
                    }
                    catch (NotSupportedException)
                    {
                        item.SubItems.Add("dynamic");
                    }
                }
            }
            finally
            {
                this.listViewVersions.EndUpdate();
            }
            
            this.listViewVersions.Sort();
            if (System.IO.File.Exists("license.rtf"))
            {
                this.textLicense.LoadFile("license.rtf");
            }
        }
        
        private void ButtonCopyClick(object sender, EventArgs e)
        {
            StringBuilder versionInfo = new StringBuilder();
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                AssemblyName name = a.GetName();
                versionInfo.Append(name.Name);
                versionInfo.Append(",");
                versionInfo.Append(name.Version.ToString());
                versionInfo.Append(",");
                try
                {
                    versionInfo.Append(a.Location);
                }
                catch (NotSupportedException)
                {
                    versionInfo.Append("dynamic");
                }
                
                versionInfo.Append(Environment.NewLine);
            }
            
            ClipboardWrapper.SetDataObject(versionInfo.ToString());
        }
        
        private void PictureBox2Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "http://sourceforge.net/donate/index.php?group_id=763932";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.Start();
        }
    }
}
