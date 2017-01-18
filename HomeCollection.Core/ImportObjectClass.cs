//-----------------------------------------------------------------------
// <copyright file="ImportObjectClass.cs" company="Sergey Teplyashin">
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
// <date>18.04.2011</date>
// <time>9:51</time>
// <summary>Defines the ImportObjectClass class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Core
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Xml;
    
    #endregion
    
    /// <summary>
    /// Description of ImportedClass.
    /// </summary>
    public class ImportObjectClass
    {
        private string originalName;
        private string name;
        private Guid guid;
        private string baseName;
        private Guid baseGuid;
        private StringCollection dependences;
        private List<Guid> dependencesGuid;
        private ErrorClasses error;
        private string category;
        private bool groupName;
        private bool creating;
        
        public ImportObjectClass(XmlNode node)
        {
            this.error = ErrorClasses.None;
            
            XmlAttribute attr = node.Attributes["name"];
            this.originalName = attr == null ? string.Empty : attr.Value;
            
            attr = node.Attributes["guid"];
            this.guid = attr == null ? Guid.NewGuid() : new Guid(attr.Value);
            
            attr = node.Attributes["base"];
            this.baseName = attr == null ? string.Empty : attr.Value;
            
            attr = node.Attributes["base_guid"];
            this.baseGuid = attr == null ? Guid.Empty : new Guid(attr.Value);
            
            // наименование категории
            attr = node.ParentNode.Attributes["name"];
            this.category = attr == null ? string.Empty : attr.Value;
            
            this.name = string.Empty;
            
            attr = node.Attributes["groupname"];
            this.groupName = attr == null ? false : bool.Parse(attr.Value);
            
            attr = node.Attributes["creating"];
            this.creating = attr == null ? true : bool.Parse(attr.Value);
            
            this.dependences = new StringCollection();
            this.dependencesGuid = new List<Guid>();
            foreach (XmlNode field in node.ChildNodes)
            {
                if (field.Name == "field")
                {
                    XmlAttribute attrRef = field.Attributes["reference"];
                    if (attrRef != null)
                    {
                        this.dependences.Add(attrRef.Value);
                    }
                    
                    XmlAttribute attrRefGuid = field.Attributes["ref_guid"];
                    if (attrRefGuid != null)
                    {
                        this.dependencesGuid.Add(new Guid(attrRefGuid.Value));
                    }
                }
            }
        }
        
        public bool Creating
        {
            get { return this.creating; }
        }
        
        public bool GroupName
        {
            get { return this.groupName; }
        }
        
        public string Category
        {
            get { return this.category; }
        }
        
        public string OriginalName
        {
            get { return this.originalName; }
        }
        
        public string Name
        {
            get
            {
                return string.IsNullOrEmpty(this.name) ? this.originalName : this.name;
            }
            
            set
            {
                if (value == this.originalName)
                {
                    this.name = string.Empty;
                }
                else
                {
                    this.name = value;
                }
                
                this.error = ErrorClasses.None;
            }
        }
        
        public Guid Identifier
        {
            get { return this.guid; }
        }
        
        public bool CorrectName
        {
            get { return !string.IsNullOrEmpty(this.originalName); }
        }
        
        public ErrorClasses Error
        {
            get { return this.error; }
            set { this.error = value; }
        }
        
        public StringCollection Dependences
        {
            get { return this.dependences; }
        }
        
        public List<Guid> DependenceGuid
        {
            get { return this.dependencesGuid; }
        }
        
        public string BaseName
        {
            get { return this.baseName; }
        }
        
        public Guid BaseGuid
        {
            get { return this.baseGuid; }
        }
        
        public bool HasBaseClass()
        {
            return !string.IsNullOrEmpty(this.baseName) || this.baseGuid != Guid.Empty;
        }
        
        public bool HasBaseClass(ImportObjectClass ic)
        {
            return ic.Identifier == this.baseGuid || ic.Name == this.baseName;
        }
        
        public override string ToString()
        {
            return this.Name;
        }
    }
}
