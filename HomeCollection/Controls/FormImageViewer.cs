//-----------------------------------------------------------------------
// <copyright file="FormImageViewer.cs" company="Sergey Teplyashin">
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
// <date>23.03.2011</date>
// <time>13:29</time>
// <summary>Defines the FormImageViewer class.</summary>
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
    /// Description of FormImageViewer.
    /// </summary>
    public partial class FormImageViewer : KryptonForm
    {
        public FormImageViewer(string fileName)
        {
            InitializeComponent();
            Text = fileName;
            this.pictureBox1.ImageLocation = fileName;
        }
        
        private void CenterImage()
        {
            int x = 0;
            int y = 0;
            if (pictureBox1.Width < panelImage.Width)
            {
                x = (panelImage.Width - pictureBox1.Width) / 2;
            }
            
            if (pictureBox1.Height < panelImage.Height)
            {
                y = (panelImage.Height - pictureBox1.Height) / 2;
            }
            
            pictureBox1.Location = new Point(x, y);
        }
        
        void ButtonBestFitClick(object sender, EventArgs e)
        {
        	pictureBox1.Dock = DockStyle.Fill;
        	pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            buttonBestFit.Enabled = false;
            buttonActualSize.Enabled = true;
        }
        
        void ButtonActualSizeClick(object sender, EventArgs e)
        {
        	pictureBox1.Dock = DockStyle.None;
        	pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        	buttonBestFit.Enabled = true;
        	buttonActualSize.Enabled = false;
        	this.CenterImage();
        }
        
        void PanelImageResize(object sender, EventArgs e)
        {
        	this.CenterImage();
        }
    }
}
