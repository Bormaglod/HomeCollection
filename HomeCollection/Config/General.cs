//-----------------------------------------------------------------------
// <copyright file="General.cs" company="Sergey Teplyashin">
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
// <date>25.03.2011</date>
// <time>14:12</time>
// <summary>Defines the General class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Config
{
    #region Using directives
    
    using System;
    using System.Xml.Serialization;
    
    #endregion
    
    /// <summary>
    /// Description of General.
    /// </summary>
    public class General
    {
        private bool loadLastOpened;
        private bool backup;
        private int backupMinutes;
        
        public General()
        {
        }
        
        [XmlAttribute]
        public bool LoadLastOpened
        {
            get { return this.loadLastOpened; }
            set { this.loadLastOpened = value; }
        }
        
        [XmlAttribute]
        public bool Backup
        {
            get { return this.backup; }
            set { this.backup = value; }
        }
        
        [XmlAttribute]
        public int BackupMinutes
        {
            get { return this.backupMinutes; }
            set { this.backupMinutes = value; }
        }
        
        public void Defaults()
        {
            this.loadLastOpened = false;
            this.backup = false;
            this.backupMinutes = 15;
        }
    }
}
