//-----------------------------------------------------------------------
// <copyright file="View.cs" company="Sergey Teplyashin">
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
// <date>26.01.2011</date>
// <time>9:27</time>
// <summary>Defines the View class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Config
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Xml.Serialization;
    using ComponentFactory.Krypton.Toolkit;
    
    #endregion
    
    /// <summary>
    /// Description of View.
    /// </summary>
    public class View
    {
        private static PaletteModeManager[] modes = new PaletteModeManager[] { 
                PaletteModeManager.ProfessionalSystem, PaletteModeManager.ProfessionalOffice2003, 
                PaletteModeManager.Office2007Blue, PaletteModeManager.Office2007Silver,
                PaletteModeManager.Office2007Black, PaletteModeManager.Office2010Blue, 
                PaletteModeManager.Office2010Silver, PaletteModeManager.Office2010Black, 
                PaletteModeManager.SparkleBlue, PaletteModeManager.SparkleOrange,
                PaletteModeManager.SparklePurple };
        
        private IDictionary<string, string> locales;
        private string localCode;
        private bool warningChangeLanguage;
        private FontElement tableFont;
        private FontElement attrNameFont;
        private FontElement attrValueFont;
        private FontElement categoryFont;
        private PaletteModeManager mode;
        
        public View()
        {
            this.locales = new Dictionary<string, string>();
            this.locales.Add("ru-RU", "Русский");
            this.locales.Add("en-US", "English");
            this.tableFont = new FontElement();
            this.attrNameFont = new FontElement();
            this.attrValueFont = new FontElement();
            this.categoryFont = new FontElement();
        }
        
        public IDictionary<string, string> Locales
        {
            get { return this.locales; }
        }
        
        public string LocalName
        {
            get { return this.locales[this.LocalCode]; }
        }
        
        [XmlAttribute]
        public string LocalCode
        {
            get { return this.localCode; }
            set { this.localCode = value; }
        }
        
        [XmlAttribute]
        public bool WarningChangeLanguage
        {
            get { return this.warningChangeLanguage; }
            set { this.warningChangeLanguage = value; }
        }
        
        public FontElement TableFont
        {
            get { return this.tableFont; }
            set { this.tableFont = value; }
        }
        
        public FontElement AttrNameFont
        {
            get { return this.attrNameFont; }
            set { this.attrNameFont = value; }
        }
        
        public FontElement AttrValueFont
        {
            get { return this.attrValueFont; }
            set { this.attrValueFont = value; }
        }
        
        public FontElement CategoryFont
        {
            get { return this.categoryFont; }
            set { this.categoryFont = value; }
        }
        
        [XmlAttribute]
        public PaletteModeManager Mode
        {
            get { return this.mode; }
            set { this.mode = value; }
        }
        
        public string LocalizableByName(string name)
        {
            foreach (string key in this.locales.Keys)
            {
                if (this.locales[key] == name)
                {
                    return key;
                }
            }
            
            return string.Empty;
        }
        
        public PaletteModeManager GetMode(int index)
        {
            return modes[index];
        }
        
        public int GetModeIndex(PaletteModeManager mode)
        {
            for (int i = 0; i < modes.Length; i++)
            {
                if (modes[i] == mode)
                {
                    return i;
                }
            }
            
            return -1;
        }
        
        public void Defaults()
        {
            CultureInfo c = CultureInfo.CurrentCulture;
            if (c.TwoLetterISOLanguageName == "ru")
            {
                this.localCode = "ru-RU";
            }
            else
            {
                this.localCode = "en-US";
            }
            
            this.warningChangeLanguage = true;
            this.tableFont.Defaults();
            this.attrNameFont.Defaults();
            this.attrNameFont.Bold = true;
            this.attrValueFont.Defaults();
            this.categoryFont.Defaults();
            this.categoryFont.Bold = true;
            this.categoryFont.Size = 10;
            this.mode = PaletteModeManager.Office2010Silver;
        }
    }
}
