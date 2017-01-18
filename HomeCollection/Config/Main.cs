//-----------------------------------------------------------------------
// <copyright file="Main.cs" company="Sergey Teplyashin">
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
// <date>05.01.2011</date>
// <time>18:33</time>
// <summary>Defines the Main class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Config
{
    #region Using directives
    
    using System;
    using System.Xml.Serialization;
    
    #endregion
    
    /// <summary>
    /// Description of MainFormElement.
    /// </summary>
    public class Main
    {
        private bool viewToolBar;
        private bool viewStatusBar;
        private bool viewInfoBar;
        private int height;
        private int width;
        
        public Main()
        {
            this.viewToolBar = true;
            this.viewStatusBar = true;
            this.viewInfoBar = true;
            this.height = 600;
            this.width = 800;
        }
        
        [XmlAttribute]
        public bool ViewToolBar
        {
            get { return this.viewToolBar; }
            set { this.viewToolBar = value; }
        }
        
        [XmlAttribute]
        public bool ViewStatusBar
        {
            get { return this.viewStatusBar; }
            set { this.viewStatusBar = value; }
        }
        
        [XmlAttribute]
        public bool ViewInfoBar
        {
            get { return this.viewInfoBar; }
            set { this.viewInfoBar = value; }
        }
        
        [XmlAttribute]
        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }
        
        [XmlAttribute]
        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }
        
        public void Defaults()
        {
            this.viewToolBar = true;
            this.viewStatusBar = true;
            this.viewInfoBar = true;
            this.height = 600;
            this.width = 800;
        }
    }
}
