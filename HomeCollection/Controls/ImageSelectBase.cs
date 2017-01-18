//-----------------------------------------------------------------------
// <copyright file="ImageSelectBase.cs" company="Sergey Teplyashin">
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
// <date>13.04.2012</date>
// <time>8:35</time>
// <summary>Defines the ImageSelectBase class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using HomeCollection.Data;
    
    #endregion
    
    /// <summary>
    /// Description of ImageSelectBase.
    /// </summary>
    public class ImageSelectBase : UserControl
    {
        private Database database;
        private ImageData image;
        private string imagesPath;
        private Field field;
        private List<ImageReference> images;
        private ImageReference cur;
        
        public ImageSelectBase()
        {
        }
        
        public ImageSelectBase(Database database, ImageData imageData, string imagesPath, Field field)
        {
            this.database = database;
            this.image = imageData;
            this.imagesPath = imagesPath;
            this.field = field;
            IEnumerable<ImageReference> irr = this.database.Images.GetImages(this.image.Images);
            this.images = new List<ImageReference>();
            foreach (ImageReference ir in irr)
            {
            	if (this.image.Images.Contains(ir.Original))
            	{
            		this.images.Add(ir);
            	}
            }
            
            this.cur = null;
            List<ImageReference> deleting = new List<ImageReference>();
            foreach (ImageReference r in this.Images)
            {
                if (!File.Exists(r.Original) && !File.Exists(r.Copy))
                {
                    this.Database.Images.Remove(r);
                    deleting.Add(r);
                    continue;
                }
                
                if (r.Original == this.Image.ReferencePath)
                {
                    this.cur = r;
                }
                
                if (r.CheckImages(this.ImagesPath))
                {
                    this.Database.Images.Update(r);
                }
            }
            
            foreach (ImageReference r in deleting)
            {
                this.Images.Remove(r);
            }
        }
        
        public ImageSelectBase(Database database, ImageData imageData, Field field) : this(database, imageData, string.Empty, field)
        {
        }
        
        public ImageSelectBase(Database database, ImageData imageData) : this(database, imageData, string.Empty, null)
        {
        }
        
        public ImageSelectBase(Database database, ImageData imageData, string imagesPath) : this(database, imageData, imagesPath, null)
        {
        }
        
        public Database Database
        {
            get { return this.database; }
        }
        
        public ImageData Image
        {
            get { return this.image; }
        }
        
        public string ImagesPath
        {
            get { return this.imagesPath; }
        }
        
        public Field Field
        {
            get { return this.field; }
        }
        
        public List<ImageReference> Images
        {
            get { return this.images; }
        }
        
        public ImageReference Current
        {
            get { return this.cur; }
            set { this.cur = value; }
        }
        
        public string ReferencePath
        {
            get { return this.cur != null ? this.cur.Original : string.Empty; }
        }
        
        public string ThumbnailsPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImagesPath) || !Directory.Exists(this.ImagesPath))
                {
                    return string.Empty;
                }
                
                return this.ImagesPath + @"\thumbnails";
            }
        }
        
        public int Count
        {
            get { return this.Images.Count; }
        }
        
        public ImageData CreateImageData()
        {
            ImageData im = new ImageData();
            im.AddRangeImage(this.Images);
            im.ReferencePath = this.cur == null ? string.Empty : this.cur.Original;
            return im;
        }
    }
}
