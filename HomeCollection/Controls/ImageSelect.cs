//-----------------------------------------------------------------------
// <copyright file="ImageSelect.cs" company="Sergey Teplyashin">
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
// <date>21.02.2011</date>
// <time>10:13</time>
// <summary>Defines the ImageSelect class.</summary>
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
    /// Description of ImageSelect.
    /// </summary>
    public partial class ImageSelect : ImageSelectBase
    {
        private const int minWidth = 100;
        private const int minHeight = 100;
        
        private bool smallMode;
        
        public ImageSelect() : base()
        {
            InitializeComponent();
        }
        
        public ImageSelect(Database database, ImageData imageData, string imagesPath, Field field) : base(database, imageData, imagesPath, field)
        {
            InitializeComponent();
        
            if (this.Current != null)
            {
                this.pictureBox1.Image = new Bitmap(this.Current.Image);
            }
            
            this.gridImages.RowTemplate.Height = this.panelImages.Height;
            this.UpdateViewImageList();
            this.groupImage.ValuesPrimary.Image = null;
            this.groupImage.ValuesPrimary.Heading = field.Name;
            this.UpdateButtons();
        }
        
        public ImageSelect(Database database, ImageData imageData, Field field) : this(database, imageData, string.Empty, field)
        {
        }
        
        public ImageSelect(Database database, ImageData imageData) : this(database, imageData, string.Empty, null)
        {
        }
        
        public ImageSelect(Database database, ImageData imageData, string imagesPath) : this(database, imageData, imagesPath, null)
        {
        }
        
        private void UpdateMode()
        {
            this.gridImages.Visible = !this.smallMode;
            this.panelButtons.Visible = !this.smallMode;
            this.groupImage.HeaderVisiblePrimary = this.smallMode;
        }
        
        private void UpdateButtons()
        {
            this.buttonSelectImage.Enabled = this.Count > 0 && this.Current != null;
            this.buttonClearImage.Enabled = this.Count > 0 && this.Current != null;
        }
        
        private DataGridViewCell GetCell(ImageReference r)
        {
            foreach (DataGridViewCell cell in this.gridImages.Rows[0].Cells)
            {
                if ((ImageReference)cell.Tag == r)
                {
                    return cell;
                }
            }
            
            return null;
        }
        
        private void UpdateViewImageList()
        {
            this.gridImages.Columns.Clear();
            if (this.Count > 1)
            {
                for (int i = 0; i < this.Count; i ++)
                {
                    this.gridImages.Columns.Add(new DataGridViewImageColumn());
                }
                
                int row = this.gridImages.Rows.Add();
                int col = 0;
                foreach (ImageReference r in this.Images)
                {
                    this.gridImages[col, 0].Value = new Bitmap(r.Thumbnail);                                                                                                                                                                                                                                                            
                    this.gridImages[col, 0].Tag = r;
                    col++;
                }
                
                if (this.Current != null)
                {
                    DataGridViewCell cell = this.GetCell(this.Current);
                    if (cell != null)
                    {
                        cell.Selected = true;
                    }
                }
                
                this.panelImages.Visible = true;
            }
            else
            {
                this.panelImages.Visible = false;
            }
        }
        
        private ImageReference AddImage(string fileName)
        {
            ImageReference r = this.Database.Images[fileName];
            if (r == null)
            {
                r = ImageReference.CreateImageReference(fileName, this.ImagesPath);
                if (r == null)
                {
                    return null;
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
            
            this.Images.Add(r);
            Image b = new Bitmap(r.Image);
            this.pictureBox1.Image = b;
            
            return r;
        }
        
        private void ButtonSelectImageClick(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImageReference r = this.AddImage(this.openFileDialog1.FileName);
                if (r != null)
                {
                    this.Images.Remove(this.Current);
                    this.Current = r;
                    this.UpdateViewImageList();
                }
            }
        }
        
        private void ButtonClearImageClick(object sender, EventArgs e)
        {
            this.Images.Remove(this.Current);
            if (this.Count == 0)
            {
                this.pictureBox1.Image = Resources.photo;
                this.Current = null;
            }
            else
            {
                this.Current = this.Images.First();
            }
            
            this.UpdateViewImageList();
            this.UpdateButtons();
        }
        
        private void ButtonAddClick(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (this.AddImage(this.openFileDialog1.FileName) != null)
                {
                    if (this.Current == null)
                    {
                        this.Current = this.Images.First();
                    }
                    
                    this.UpdateViewImageList();
                    this.UpdateButtons();
                }
            }
        }
        
        void GridImagesSelectionChanged(object sender, EventArgs e)
        {
            if (this.gridImages.SelectedCells.Count > 0)
            {
                DataGridViewCell cell = this.gridImages.SelectedCells[0];
                if (cell.Tag != null)
                {
                    ImageReference r = (ImageReference)cell.Tag;
                    this.Current = r;
                    this.pictureBox1.Image = new Bitmap(r.Image);
                }
            }
        }
        
        void ImageSelectSizeChanged(object sender, EventArgs e)
        {
            this.smallMode = Size.Width <= minWidth || Size.Height <= minHeight;
            this.UpdateMode();
        }
        
        void ButtonAddFromInternetClick(object sender, EventArgs e)
        {
            string addr = KryptonInputBox.Show("Введите адрес изображения", "Network location", string.Empty);
            if (!string.IsNullOrEmpty(addr))
            {
                if (this.AddImage(addr) != null)
                {
                    this.UpdateViewImageList();
                    this.UpdateButtons();
                }
            }
        }
    }
}
