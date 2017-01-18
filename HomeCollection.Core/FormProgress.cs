//-----------------------------------------------------------------------
// <copyright file="FormProgress.cs" company="Sergey Teplyashin">
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
// <date>20.05.2011</date>
// <time>10:45</time>
// <summary>Defines the FormProgress class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Core
{
    #region Using directives
    
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    
    #endregion

    /// <summary>
    /// Description of FormProgress.
    /// </summary>
    public partial class FormProgress : KryptonForm
    {
        public FormProgress()
        {
            this.InitializeComponent();
            this.progressBar.Value = 0;
            
            // TODO: надо сделать окно модальным, иначе в процессе использвания пользователь щелкает мышкой вне окно, и "прогресс" исчезает
        }
        
        public string Message
        {
            get
            {
                return this.labelText.Text;
            }
            
            set
            {
                this.labelText.Text = value;
                Application.DoEvents();
            }
        }
        
        public int Count
        {
            get { return this.progressBar.Maximum; }
            set { this.progressBar.Maximum = value; }
        }
        
        public void DoNextMessage(string message)
        {
            this.labelText.Text = message;
            this.progressBar.Value++;
            Application.DoEvents();
        }
    }
}
