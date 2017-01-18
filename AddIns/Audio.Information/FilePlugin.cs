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
// <date>13.04.2012</date>
// <time>12:30</time>
// <summary>Defines the FilePlugin class.</summary>
//-----------------------------------------------------------------------

namespace Audio.Information
{
    #region Using directives
    
    using System;
    using System.AddIn;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using HomeCollection.AddIns;
    using TagLib;
    
    #endregion
    
    [AddIn("Audio.Information AddIn", Publisher="Sergey Teplyashin", Version="1.0.0.0", Description="Gathering audio information from file.")]
    public class FilePlugin : DataPlugin
    {
        private const string pluginName = "Import Audio Information";
        private Guid guid;
        private List<string> neededAttributes;
        private List<string> changedAttributes;
        private List<Guid> ids;
        private string location;
        private Dictionary<string, string> data;
        
        public FilePlugin()
        {
            this.ids = new List<Guid>();
            this.ids.Add(new Guid("6A58BEEA-2400-4F5E-8752-A23B47D57754")); // ru
            
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
                var file = TagLib.File.Create(this.location);
                if (file.Properties.MediaTypes == MediaTypes.Audio)
                {
                    this.data.Clear();
                    this.data.Add(this.GetString("Year"), file.Tag.Year.ToString(CultureInfo.InvariantCulture));
                    this.data.Add(this.GetString("Title"), file.Tag.Title);
                    this.data.Add(this.GetString("Album"), file.Tag.Album);
                    this.data.Add(this.GetString("Duration"), this.FormatTimeSpan(file.Properties.Duration));
                    this.data.Add(this.GetString("Performer"), file.Tag.FirstPerformer);
                    this.data.Add(this.GetString("Track"), file.Tag.Track.ToString(CultureInfo.InvariantCulture));
                    this.data.Add(this.GetString("AudioBitrate"), file.Properties.AudioBitrate.ToString(CultureInfo.InvariantCulture));
                    this.data.Add(this.GetString("AudioChannels"), file.Properties.AudioChannels.ToString(CultureInfo.InvariantCulture));
                    this.data.Add(this.GetString("AudioSampleRate"), file.Properties.AudioSampleRate.ToString(CultureInfo.InvariantCulture));
                    this.data.Add(this.GetString("Genre"), file.Tag.FirstGenre);
                    if (file.Properties.Codecs.Count() > 0)
                    {
                        this.data.Add(this.GetString("Codec"), file.Properties.Codecs.First().Description);
                    }
                    return true;
                }
                else
                {
                    KryptonMessageBox.Show(string.Format("Файл {0} не содержит музыки.", this.location), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                KryptonMessageBox.Show(string.Format("Файл {0} не содержит музыки.", this.location), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return false;
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
            this.changedAttributes.Add(this.GetString("Year"));
            this.changedAttributes.Add(this.GetString("Title"));
            this.changedAttributes.Add(this.GetString("Album"));
            this.changedAttributes.Add(this.GetString("Duration"));
            this.changedAttributes.Add(this.GetString("Performer"));
            this.changedAttributes.Add(this.GetString("Track"));
            this.changedAttributes.Add(this.GetString("AudioBitrate"));
            this.changedAttributes.Add(this.GetString("AudioChannels"));
            this.changedAttributes.Add(this.GetString("Genre"));
            this.changedAttributes.Add(this.GetString("Codec"));
        }
        
        private string FormatTimeSpan(TimeSpan time)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}:{1}:{2}", new object[] { time.Hours, time.Minutes.ToString("00"), time.Seconds.ToString("00") } );
        }
    }
}
