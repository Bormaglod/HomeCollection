//-----------------------------------------------------------------------
// <copyright file="FormImport.cs" company="Sergey Teplyashin">
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
// <date>16.03.2011</date>
// <time>9:07</time>
// <summary>Defines the FormImport class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Core
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Drawing;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Forms;
    using System.Xml;
    using ComponentFactory.Krypton.Toolkit;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of FormImport.
    /// </summary>
    public partial class FormImport : KryptonForm
    {
        //private ExportImportManager manager;
        private Database database;
        private XmlDocument doc;
        private ImportExecutorClass classes;
        
        public FormImport(/*ExportImportManager manager, */Database database, XmlDocument doc)
        {
            InitializeComponent();

            //this.manager = manager;
            this.database = database;
            this.doc = doc;
            this.classes = new ImportExecutorClass(this.database, this.doc, "/config");
            this.CheckXmlDocument();
        }
        
        private void UpdateControls()
        {
            buttonImport.Enabled = false;
            if (this.gridClasses.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.gridClasses.SelectedRows[0];
                ImportObjectClass ic = (ImportObjectClass)row.Tag;
                if (ic != null)
                {
                    this.panelInfo.Visible = ic.Error != ErrorClasses.None;
                    switch (ic.Error)
                    {
                        case ErrorClasses.ExistClassId:
                            labelError.Text = Strings.TemplateWarning;
                            break;
                        case ErrorClasses.ExistClassName:
                            labelError.Text = Strings.TemplateNameUnique;
                            break;
                        case ErrorClasses.NotFoundReference:
                            labelError.Text = Strings.TemplateNotExist;
                            break;
                    }
                    
                    buttonImport.Enabled = this.classes.CountErrors(ErrorClasses.ExistClassName) == 0 && this.classes.CountErrors(ErrorClasses.NotFoundReference) == 0;
                }
            }
        }
        
        private void CheckXmlDocument()
        {
            this.CheckClasses();
            this.CreateListClasses();
        }
        
        private void CheckClasses()
        {
            // Проверим список на совпадение имен
            foreach (ImportObjectClass ic in this.classes.Items)
            {
                // Проверим совпадение guid в импортируемом файле и в базе данных
                if (this.classes.CountClassesById(ic.Identifier) > 1 || this.database.Classes[ic.Identifier] != null)
                {
                    ic.Error = ErrorClasses.ExistClassId;
                }
                
                if (ic.Error == ErrorClasses.None)
                {
                    // Проверим совпадение имен в импортируемом файле и в базе данных
                    if (this.classes.CountClassesByName(ic.Name, false) > 1 || this.database.Classes[ic.Name] != null)
                    {
                        ic.Error = ErrorClasses.ExistClassName;
                    }
                }
                
                if (ic.Error == ErrorClasses.None)
                {
                    // Проверим базовый шаблон, может его нет в БД
                    if (!string.IsNullOrEmpty(ic.BaseName) && this.classes.CountClassesByName(ic.BaseName, true) == 0)
                    {
                        ic.Error = ErrorClasses.NotFoundReference;
                    }
                    
                    if (ic.Error == ErrorClasses.None)
                    {
                        // Если ошибок не было, то проверим базовый шаблон по идентификатору.
                        if (ic.BaseGuid != Guid.Empty && (this.classes.CountClassesById(ic.BaseGuid) == 0 && this.database.Classes[ic.BaseGuid] == null))
                        {
                            ic.Error = ErrorClasses.NotFoundReference;
                        }
                    }
                }
                
                if (ic.Error == ErrorClasses.None)
                {
                    // Проверим, все ли ссылка ссылаются на доступные шаблоны
                    // Проверим имена (они могут ссылаться только на шаблоны внутри импортируемого файла
                    foreach (string refName in ic.Dependences)
                    {
                        if (this.classes.CountClassesByName(refName, true) == 0)
                        {
                            ic.Error = ErrorClasses.NotFoundReference;
                            break;
                        }
                    }
                    
                    // Если ошибок не было, то проверим ссылки по идентификатору.
                    // Проверка осуществляется как по импортируемому файлу, так и по БД
                    if (ic.Error == ErrorClasses.None)
                    {
                        foreach (Guid refGuid in ic.DependenceGuid)
                        {
                            if (this.classes.CountClassesById(refGuid) == 0 && this.database.Classes[refGuid] == null)
                            {
                                ic.Error = ErrorClasses.NotFoundReference;
                            }
                        }
                    }
                }
            }
        }

        private void CreateListClasses()
        {
            foreach (ImportObjectClass ic in this.classes.Items)
            {
                int row = this.gridClasses.Rows.Add();
                this.gridClasses.Rows[row].Tag = ic;
                this.UpdateRow(this.gridClasses.Rows[row]);
            }
            
            this.UpdateControls();
        }
        
        private void UpdateRows()
        {
            foreach (DataGridViewRow row in this.gridClasses.Rows)
            {
                this.UpdateRow(row);
            }
            
            this.UpdateControls();
        }
        
        private void UpdateRow(DataGridViewRow row)
        {
            ImportObjectClass ic = (ImportObjectClass)row.Tag;
            row.Cells[0].Value = ic.Name;
            switch (ic.Error)
            {
                case ErrorClasses.None:
                    row.Cells[1].Value = "OK";
                    row.Cells[1].Style.ForeColor = SystemColors.WindowText;
                    break;
                case ErrorClasses.ExistClassId:
                    row.Cells[1].Value = Strings.TemplateExist;
                    row.Cells[1].Style.ForeColor = Color.Blue;
                    break;
                case ErrorClasses.ExistClassName:
                    row.Cells[1].Value = Strings.TemplateNameExist;
                    row.Cells[1].Style.ForeColor = Color.Red;
                    break;
                case ErrorClasses.NotFoundReference:
                    row.Cells[1].Value = Strings.TemplateNotExist;
                    row.Cells[1].Style.ForeColor = Color.Red;
                    break;
            }
        }
        
        private void GridClassesSelectionChanged(object sender, EventArgs e)
        {
            this.UpdateControls();
        }
        
        private void ButtonRenameClick(object sender, EventArgs e)
        {
            string newClass = KryptonInputBox.Show(Strings.InputTemplateName, Strings.Rename, string.Empty);
            if (!string.IsNullOrEmpty(newClass) && this.gridClasses.CurrentRow != null)
            {
                ImportObjectClass ic = (ImportObjectClass)this.gridClasses.CurrentRow.Tag;
                ic.Name = newClass;
                this.CheckClasses();
                this.UpdateRows();
            }
        }
        
        private void ButtonImportClick(object sender, EventArgs e)
        {
            this.classes.ExecuteImport();
        }
    }
}
