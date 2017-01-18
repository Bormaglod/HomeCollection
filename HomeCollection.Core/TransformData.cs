//-----------------------------------------------------------------------
// <copyright file="TransformData.cs" company="Sergey Teplyashin">
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
// <date>28.03.2012</date>
// <time>13:31</time>
// <summary>Defines the TransformData class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Core
{
    #region Using directives
    
    using System;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml;
    using HomeCollection.Data;
    using Mvp.Xml.XInclude;
    
    #endregion
    
    /// <summary>
    /// Description of TransformData.
    /// </summary>
    public abstract class TransformData
    {
        private Database database;
        private string fileName;
        private string lang;
        private XmlDocument doc;
        
        public TransformData(Database database)
        {
            this.database = database;
            this.fileName = string.Empty;
            this.lang = string.Empty;
            this.doc = new XmlDocument();
        }
        
        public XmlDocument Document
        {
            get { return this.doc; }
        }
        
        public string FileName
        {
            get { return this.fileName; }
        }
        
        public string Language
        {
            get { return this.lang; }
        }
        
        public Database Database
        {
            get { return this.database; }
        }
        
        public string Name
        {
            get { return this.GetName(); }
        }
        
        public string FilterName
        {
            get { return this.GetFilterName(); }
        }
        
        public string Extension
        {
            get { return this.GetExtension(); }
        }
        
        public string ShortExtension
        {
            get { return this.GetShortExtension(); }
        }
        
        public string FilterString
        {
            get { return string.Format("{0}|{1}", this.Name, this.Extension); }
        }
        
        public bool Execute(string fileName)
        {
            this.fileName = fileName;
            if (this.Database.Opened)
            {
                return this.Execute();
            }
            else
            {
                return false;
            }
        }
        
        public bool Execute(string fileName, string lang)
        {
            this.lang = lang;
            return Execute(fileName);
        }
        
        public virtual void CreateXmlDocument()
        {
            this.doc.RemoveAll();
        }
        
        public void Save(string fileName)
        {
            this.doc.Save(fileName);
        }
        
        public void Load(string fileName)
        {
            string schema = Path.GetDirectoryName(Application.ExecutablePath) + @"\Templates\config.xsd";
            if (System.IO.File.Exists(schema))
            {
                XmlTextReader r = new XmlTextReader(fileName);
                XIncludingReader xir = new XIncludingReader(r);
                this.doc.Schemas.Add(null, schema);
                this.doc.Load(xir);
                //this.doc.Validate(null/*this.ValidationEventHandler*/);
            }
            else
            {
                throw new System.IO.FileNotFoundException("Файл config.xsd не найден. Продолжение не возможно.", schema);
            }
        }
        
        protected abstract bool Execute();
        
        protected abstract string GetName();
        
        protected abstract string GetFilterName();
        
        protected abstract string GetExtension();
        
        protected string GetShortExtension()
        {
            return this.GetExtension().Substring(2, this.GetExtension().Length - 2);
        }
        
        /*private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
        }*/
    }
}
