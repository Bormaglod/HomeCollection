//-----------------------------------------------------------------------
// <copyright file="ImportConfiguration.cs" company="Sergey Teplyashin">
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
// <time>14:12</time>
// <summary>Defines the ImportConfiguration class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Core
{
    #region Using directives
    
    using System;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Schema;
    using ComponentFactory.Krypton.Toolkit;
    using HomeCollection.Data;
    
    #endregion
    /// <summary>
    /// Description of ImportConfiguration.
    /// </summary>
    public class ImportConfiguration : TransformConfiguration
    {
        private const string name = "Import configuration";
        
        public ImportConfiguration(Database database) : base(database)
        {
        }
        
        protected override string GetName()
        {
            return name;
        }
        
        protected override bool Execute()
        {
            try
            {
                Load(FileName);
                bool continueImport = true;
                if (!this.CorrectLanguage())
                {
                    continueImport = KryptonMessageBox.Show("Язык, использванный для создания шаблона, не соответствует языку интерфейса, что может привести к некорректной работе дополнения. Продолжить установку шаблона?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
                }
                
                if (continueImport)
                {
                    FormImport form = new FormImport(this.Database, Document);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        return true;
                    }
                }
            }
            catch (XmlSchemaValidationException e)
            {
                string v = string.Empty;
                XmlAttribute attr = e.SourceObject as XmlAttribute;
                if (attr != null)
                {
                    v = attr.OwnerElement.Name + ": ";
                }
                
                KryptonMessageBox.Show(v + e.Message, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return false;
        }
        
        private bool CorrectLanguage()
        {
            if (!string.IsNullOrEmpty(Language))
            {
                XmlNode node = Document.SelectSingleNode("/config");
                XmlAttribute attr = node.Attributes["language"];
                return attr.Value == Language.Substring(0, 2);
            }
            else
            {
                return true;
            }
        }
    }
}
