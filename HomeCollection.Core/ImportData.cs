//-----------------------------------------------------------------------
// <copyright file="ImportData.cs" company="Sergey Teplyashin">
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
// <date>16.05.2011</date>
// <time>15:21</time>
// <summary>Defines the ImportData class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Core
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of ImportData.
    /// </summary>
    public class ImportData : TransformData
    {
        private const string name = "Import from XML";
        private const string filterName = "XML File (*.xml)";
        private const string ext = "*.xml";
        
        public ImportData(Database database) : base(database)
        {
        }
        
        public override void CreateXmlDocument()
        {
            throw new NotImplementedException();
        }
        
        protected override string GetFilterName()
        {
            return filterName;
        }
        
        protected override string GetExtension()
        {
            return ext;
        }
        
        protected override string GetName()
        {
            return name;
        }
        
        protected override bool Execute()
        {
            Load(FileName);
            try
            {
                this.ExecuteImport("/records/record");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public void ExecuteImport(string xmlPath)
        {
            ImportExecutorData ide = new ImportExecutorData(Database, Document, xmlPath);
            ide.ExecuteImport();
        }
    }
}
