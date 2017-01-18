//-----------------------------------------------------------------------
// <copyright file="${FILENAME}" company="Sergey Teplyashin">
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
// <time>13:47</time>
// <summary>Defines the ? class.</summary>
//-----------------------------------------------------------------------
using System;
using System.AddIn;
using System.Collections.Generic;
using HomeCollection.AddIns;

namespace FileTest
{
    [AddIn("FileTest", Publisher="Sergey Teplyashin", Version="1.0.0.0", Description="Testing gathering file information plugin.")]
    public class MyClass : DataPlugin
    {
        private const string pluginName = "Test Plugin Information";
        private Guid guid;
        private List<Guid> ids;
        private List<string> neededAttributes;
        private List<string> changedAttributes;
        
        public MyClass()
        {
            this.ids = new List<Guid>();
            this.ids.Add(new Guid("962BB12E-6ED7-40CB-B389-1696A88895C0")); // ru
            this.ids.Add(new Guid("DBC90FE7-71A0-4F9D-8AFD-49C1033E6DC5")); // en
            
            guid = this.ids[0];
            
            this.neededAttributes = new List<string>();
            this.changedAttributes = new List<string>();
            this.UpdateAttributes();
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
        }
        
        public override string GetData(string fieldName)
        {
            return string.Empty;
        }
        
        public override bool Execute()
        {
            return true;
        }
        
        private void UpdateAttributes()
        {
            
        }
    }
}