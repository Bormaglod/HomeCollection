//-----------------------------------------------------------------------
// <copyright file="SimpleImageSelect.cs" company="Sergey Teplyashin">
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
// <date>17.06.2011</date>
// <time>11:22</time>
// <summary>Defines the SimpleImageSelect class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using HomeCollection.Data;
    
    #endregion

    /// <summary>
    /// Description of SimpleImageSelect.
    /// </summary>
    public partial class SimpleImageSelect : ImageSelectBase
    {
        private bool showButton;
        private Image currentImage;
        
        public SimpleImageSelect() : base()
        {
            InitializeComponent();
        }
        
        public SimpleImageSelect(Database database, ImageData imageData, string imagesPath, Field field) : base(database, imageData, imagesPath, field)
        {
        }
        
        public SimpleImageSelect(Database database, ImageData imageData, Field field) : this(database, imageData, string.Empty, field)
        {
        }
        
        public SimpleImageSelect(Database database, ImageData imageData) : this(database, imageData, string.Empty, null)
        {
        }
        
        public SimpleImageSelect(Database database, ImageData imageData, string imagesPath) : base(database, imageData, imagesPath)
        {
            InitializeComponent();
            this.currentImage = Resources.photo;
            this.showButton = true;
            if (this.Current != null)
            {
                this.currentImage = new Bitmap(this.Current.Image);
            }
        }
        
        private void UpdateButtons()
        {
            this.buttonAdd.Visible = this.showButton;
            this.buttonAddFromWeb.Visible = this.showButton;
            this.buttonDelete.Visible = this.showButton;
            this.buttonEdit.Visible = this.showButton;
            this.buttonLeft.Visible = this.showButton;
            this.buttonRight.Visible = this.showButton;
        }
        
        private void AddImage(string fileName)
        {
            ImageReference r = this.Database.Images[fileName];
            if (r == null)
            {
                r = ImageReference.CreateImageReference(fileName, this.ImagesPath);
                if (r == null)
                {
                    return;
                }
                else
                {
                    this.Database.Images.Add(r);
                }
            }
            else
            {
                if (r.CheckImages(this.ImagesPath))
                {
                    this.Database.Images.Update(r);
                }
            }
            
            this.Current = r;
            this.Images.Add(this.Current);
            this.currentImage = new Bitmap(this.Current.Image);
            Invalidate();
        }
        
        private void SimpleImageSelectPaint(object sender, PaintEventArgs e)
        {
            int h = Height;
            int w = Width;
            if (Width > Height)
            {
                double k = (double)this.currentImage.Width / (double)this.currentImage.Height;
                w = (int)(k * Height);
            }
            else
            {
                double k = (double)this.currentImage.Height / (double)this.currentImage.Width;
                h = (int)(k * Width);
            }
            
            int x = (Width - w) / 2;
            int y = (Height - h) / 2;
            
            e.Graphics.DrawImage(this.currentImage, x, y, w, h);
        }
        
        private void ButtonLeftClick(object sender, EventArgs e)
        {
            int idx = this.Images.IndexOf(this.Current);
            if (idx > 0)
            {
                idx--;
                this.Current = this.Images[idx];
                this.currentImage = new Bitmap(this.Current.Image);
                Invalidate();
            }
        }
        
        private void ButtonRightClick(object sender, EventArgs e)
        {
            int idx = this.Images.IndexOf(this.Current);
            if (idx < this.Images.Count - 1)
            {
                idx++;
                this.Current = this.Images[idx];
                this.currentImage = new Bitmap(this.Current.Image);
                Invalidate();
            }
        }
        
        private void SimpleImageSelectResize(object sender, EventArgs e)
        {
            int leftY = Height - this.buttonLeft.Height - 3;
            int rightY = Height - this.buttonRight.Height - 3;
            int x1 = (Width - (this.buttonLeft.Width + this.buttonRight.Width + 6)) / 2;
            int x2 = x1 + this.buttonLeft.Width + 6;
            this.buttonLeft.Location  = new Point(x1, leftY);
            this.buttonRight.Location = new Point(x2, rightY);
        }
        
        private void ButtonAddClick(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.AddImage(this.openFileDialog1.FileName);
            }
        }
        
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            this.Images.Remove(this.Current);
            if (this.Images.Count == 0)
            {
                this.Current = null;
                this.currentImage = Resources.photo;
            }
            else
            {
                this.Current = this.Images.First();
                this.currentImage = new Bitmap(this.Current.Image);
            }
            
            Invalidate();
        }
        
        private void ButtonAddFromWebClick(object sender, EventArgs e)
        {
            string addr = KryptonInputBox.Show("Введите адрес изображения", "Network location", string.Empty);
            if (!string.IsNullOrEmpty(addr))
            {
                this.AddImage(addr);
            }
        }
        
        private void ButtonEditClick(object sender, EventArgs e)
        {
            if (this.Current != null)
            {
                FormImageViewer viewer = new FormImageViewer(this.Current.Image);
                viewer.Show();
            }
        }
        
        private void SimpleImageSelectClick(object sender, EventArgs e)
        {
            this.showButton = !this.showButton;
            this.UpdateButtons();
        }
    }
}
