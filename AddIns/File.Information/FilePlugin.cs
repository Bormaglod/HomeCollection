//-----------------------------------------------------------------------
// <copyright file="FilePlugin.cs" company="Sergey Teplyashin">
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
// <date>10.04.2012</date>
// <time>12:10</time>
// <summary>Defines the FilePlugin class.</summary>
//-----------------------------------------------------------------------

namespace File.Information
{
    #region Using directives
    
    using Microsoft.Win32;
    using System;
    using System.AddIn;
    using System.Collections.Generic;
    using System.IO;
    using System.Globalization;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using HomeCollection.AddIns;
    
    #endregion
    
    [AddIn("File.Information AddIn", Publisher="Sergey Teplyashin", Version="1.0.0.0", Description="Getting file information")]
    public class FilePlugin : DataPlugin
    {
        private const string pluginName = "Import File Information";
        private Guid guid;
        private List<string> neededAttributes;
        private List<string> changedAttributes;
        private List<Guid> ids;
        private string location;
        private Dictionary<string, string> data;
        
        public FilePlugin()
        {
            this.ids = new List<Guid>();
            this.ids.Add(new Guid("962BB12E-6ED7-40CB-B389-1696A88895C0")); // ru
            this.ids.Add(new Guid("DBC90FE7-71A0-4F9D-8AFD-49C1033E6DC5")); // en
            
            guid = this.ids[0];
            
            this.neededAttributes = new List<string>();
            this.changedAttributes = new List<string>();
            this.UpdateAttributes();
            
            this.data = new Dictionary<string, string>();
        }
        
        public override string GetName()
        {
            return pluginName;
        }
        
        public override IList<Guid> GetObjectClassId()
        {
            return this.ids;
        }
        
        public override string GetLocaleObjectClass(Guid guid)
        {
            if (guid == ids[0])
            {
                return "ru";
            }
            
            if (guid == ids[1])
            {
                return "en";
            }
            
            return string.Empty;
        }
        
        public override bool SetCurrentGuid(Guid guid)
        {
            if (this.ids.Contains(guid))
            {
                if (this.guid != guid)
                {
                    this.guid = guid;
                    this.UpdateAttributes();
                }
                
                return true;
            }
            
            return false;
        }
        
        public override IList<string> GetNeededAttributes()
        {
            return this.neededAttributes;
        }
        
        public override IList<string> GetChangedAttributes()
        {
            return this.changedAttributes;
        }
        
        public override void SetData(string fieldName, string value)
        {
            if (fieldName == this.GetString("Location"))
            {
                this.location = value.Clone().ToString();
            }
        }
        
        public override string GetData(string fieldName)
        {
            if (this.data.ContainsKey(fieldName))
            {
                return this.data[fieldName];
            }
            
            return string.Empty;
        }
        
        public override bool Execute()
        {
            try
            {
                FileInfo fi = new FileInfo(this.location);
                if ((fi.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    KryptonMessageBox.Show(string.Format(this.GetString("FileIsNotFolder"), this.location), this.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.data.Clear();
                    this.data.Add(this.GetString("Name"), fi.Name);
                    this.data.Add(this.GetString("FileType"), this.GetFileType(fi.Name));
                    this.data.Add(this.GetString("Folder"), fi.DirectoryName);
                    this.data.Add(this.GetString("Size"), fi.Length.ToString(CultureInfo.InvariantCulture));
                    this.data.Add(this.GetString("Created"), fi.CreationTime.ToString(CultureInfo.InvariantCulture));
                    this.data.Add(this.GetString("Modified"), fi.LastWriteTime.ToString(CultureInfo.InvariantCulture));
                    this.data.Add(this.GetString("Accessed"), fi.LastAccessTime.ToString(CultureInfo.InvariantCulture));
                    this.data.Add(this.GetString("ReadOnly"), ((fi.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly).ToString(CultureInfo.InvariantCulture));
                    this.data.Add(this.GetString("Hidden"), ((fi.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden).ToString(CultureInfo.InvariantCulture));
                    return true;
                }
            }
            catch (ArgumentNullException)
            {
                KryptonMessageBox.Show(this.GetString("FileNameRequired"), this.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException)
            {
                KryptonMessageBox.Show(this.GetString("FileNameRequired"), this.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Security.SecurityException)
            {
                KryptonMessageBox.Show(this.GetString("SecurityError"), this.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                KryptonMessageBox.Show(this.GetString("AccessError"), this.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (PathTooLongException)
            {
                KryptonMessageBox.Show(this.GetString("PathTooLong"), this.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NotSupportedException)
            {
                KryptonMessageBox.Show(this.GetString("InvalidFileName"), this.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return false;
        }
        
        private string GetFileType(string fileName)
        {
            string ext = System.IO.Path.GetExtension(fileName);
            string userRoot = "HKEY_CLASSES_ROOT";
            string key = userRoot + "\\" + ext;
            string desc = this.DefaultExtDescription(ext);
            
            object e = Registry.GetValue(key, string.Empty, string.Empty);
            if (e != null)
            {
                string extValue = e.ToString();
                if (!string.IsNullOrEmpty(extValue))
                {
                    key = userRoot + "\\" + extValue;
                    object d = Registry.GetValue(key, string.Empty, string.Empty);
                    if (d != null)
                    {
                        string extDesc = d.ToString();
                        if (!string.IsNullOrEmpty(extDesc))
                        {
                            desc = extDesc;
                        }
                    }
                }
            }
            
            return desc;
        }
        
        private string DefaultExtDescription(string ext)
        {
            return ext.Remove(0, 1).ToUpper() + "File";
        }
        
        private string GetString(string name)
        {
            string suffix = string.Empty;
            suffix = this.GetLocaleObjectClass(this.guid);
            return Strings.ResourceManager.GetString(name + "." + suffix);
        }
        
        private void UpdateAttributes()
        {
            this.neededAttributes.Clear();
            this.neededAttributes.Add(this.GetString("Location"));
            
            this.changedAttributes.Clear();
            this.changedAttributes.Add(this.GetString("Name"));
            this.changedAttributes.Add(this.GetString("FileType"));
            this.changedAttributes.Add(this.GetString("Folder"));
            this.changedAttributes.Add(this.GetString("Size"));
            this.changedAttributes.Add(this.GetString("Created"));
            this.changedAttributes.Add(this.GetString("Modified"));
            this.changedAttributes.Add(this.GetString("Accessed"));
            this.changedAttributes.Add(this.GetString("ReadOnly"));
            this.changedAttributes.Add(this.GetString("Hidden"));
        }
    }
}
