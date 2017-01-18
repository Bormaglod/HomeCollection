//-----------------------------------------------------------------------
// <copyright file="FormConfigure.cs" company="Sergey Teplyashin">
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
// <time>13:59</time>
// <summary>Defines the FormConfigure class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    
    #endregion
    
    /// <summary>
    /// Description of FormConfigure.
    /// </summary>
    public partial class FormConfigure : KryptonForm
    {
        private bool changed;
        private string lang;
        
        public FormConfigure()
        {
            InitializeComponent();
            
            foreach (string local in MainForm.Config.App.View.Locales.Values)
            {
                this.comboLang.Items.Add(local);
            }
        }
        
        public Font TableFont
        {
            get { return this.labelNameFont.StateCommon.ShortText.Font; }
        }
        
        public Font AttrNameFont
        {
            get { return this.labelAttrFont.StateCommon.ShortText.Font; }
        }
        
        public Font AttrValueFont
        {
            get { return this.labelValueFont.StateCommon.ShortText.Font; }
        }
        
        public Font CategoryFont
        {
            get { return this.labelCatFont.StateCommon.ShortText.Font; }
        }
        
        private bool Changed
        {
            set
            {
                this.changed = value; 
                this.UpdateButtons();
            }
        }
        
        public bool ShowConfigure()
        {
            this.LoadParameters();
            lang = MainForm.Config.App.View.LocalName;
            if (ShowDialog() == DialogResult.OK)
            {
                this.SaveParameters();
                if ((lang != MainForm.Config.App.View.LocalName) && MainForm.Config.App.View.WarningChangeLanguage)
                {
                    KryptonTaskDialog d = new KryptonTaskDialog();
                    d.WindowTitle = Strings.LangChangedTitle;
                    d.Content = Strings.LangChangedContent;
                    d.CheckboxText = Strings.LangChangedCheck;
                    d.CheckboxState = false;
                    d.ShowDialog();
                    MainForm.Config.App.View.WarningChangeLanguage = !d.CheckboxState;
                }
                
                return true;
            }
            
            return false;
        }
        
        private void UpdateButtons()
        {
            this.buttonAccept.Enabled = this.changed;
        }
        
        private void UpdateFont(KryptonLabel label, Font font)
        {
            label.StateCommon.ShortText.Font = font;
            label.Text = font.Name;
        }
        
        private void LoadParameters()
        {
            this.comboLang.SelectedItem = MainForm.Config.App.View.LocalName;

            this.UpdateFont(this.labelNameFont, MainForm.Config.App.View.TableFont.CreateFont());
            this.UpdateFont(this.labelAttrFont, MainForm.Config.App.View.AttrNameFont.CreateFont());
            this.UpdateFont(this.labelValueFont, MainForm.Config.App.View.AttrValueFont.CreateFont());
            this.UpdateFont(this.labelCatFont, MainForm.Config.App.View.CategoryFont.CreateFont());
            
            this.checkBeginLastFile.Checked = MainForm.Config.App.General.LoadLastOpened;
            this.checkSaveBackup.Checked = MainForm.Config.App.General.Backup;
            this.numericIntervalBackup.Value = MainForm.Config.App.General.BackupMinutes;
            this.numericIntervalBackup.Enabled = this.checkSaveBackup.Checked;
            
            this.Changed = false;
        }
        
        private void SaveParameters()
        {
            MainForm.Config.App.View.LocalCode = MainForm.Config.App.View.LocalizableByName((string)this.comboLang.SelectedItem);
            MainForm.Config.App.View.TableFont.Update(this.labelNameFont.StateCommon.ShortText.Font);
            MainForm.Config.App.View.AttrNameFont.Update(this.labelAttrFont.StateCommon.ShortText.Font);
            MainForm.Config.App.View.AttrValueFont.Update(this.labelValueFont.StateCommon.ShortText.Font);
            MainForm.Config.App.View.CategoryFont.Update(this.labelCatFont.StateCommon.ShortText.Font);
            
            MainForm.Config.App.General.LoadLastOpened = this.checkBeginLastFile.Checked;
            MainForm.Config.App.General.Backup = this.checkSaveBackup.Checked;
            MainForm.Config.App.General.BackupMinutes = Convert.ToInt32(this.numericIntervalBackup.Value);
            
            this.Changed = false;
        }
        
        private void ButtonChooseFontClick(object sender, EventArgs e)
        {
            this.fontDialog1.Font = this.labelNameFont.StateCommon.ShortText.Font;
            if (this.fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.UpdateFont(this.labelNameFont, this.fontDialog1.Font);
                this.Changed = true;
            }
        }
        
        private void ButtonAcceptClick(object sender, EventArgs e)
        {
            this.SaveParameters();
        }
        
        private void ChangeData(object sender, EventArgs e)
        {
            this.Changed = true;
        }
        
        private void CheckSaveBackupCheckedChanged(object sender, EventArgs e)
        {
            this.Changed = true;
            this.numericIntervalBackup.Enabled = this.checkSaveBackup.Checked;
        }
        
        private void ButtonChooseFontAttrClick(object sender, EventArgs e)
        {
            this.fontDialog1.Font = this.labelAttrFont.StateCommon.ShortText.Font;
            if (this.fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.UpdateFont(this.labelAttrFont, this.fontDialog1.Font);
                this.Changed = true;
            }
        }
        
        private void ButtonChooseFontValueClick(object sender, EventArgs e)
        {
            this.fontDialog1.Font = this.labelValueFont.StateCommon.ShortText.Font;
            if (this.fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.UpdateFont(this.labelValueFont, this.fontDialog1.Font);
                this.Changed = true;
            }
        }
        
        private void ButtonChooseFontCatClick(object sender, EventArgs e)
        {
            this.fontDialog1.Font = this.labelCatFont.StateCommon.ShortText.Font;
            if (this.fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.UpdateFont(this.labelCatFont, this.fontDialog1.Font);
                this.Changed = true;
            }
        }
    }
}
