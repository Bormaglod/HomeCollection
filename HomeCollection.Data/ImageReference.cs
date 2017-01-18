//-----------------------------------------------------------------------
// <copyright file="ImageReference.cs" company="Sergey Teplyashin">
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
// <date>10.06.2011</date>
// <time>11:12</time>
// <summary>Defines the ImageReference class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using ComponentLib.Data;
    
    #endregion
    
    /// <summary>
    /// Description of ImageReference.
    /// </summary>
    public class ImageReference : BaseObject
    {
        private string original;
        private string copy;
        private string thumbnail;
        
        public ImageReference(string original)
        {
            this.original = original;
            this.copy = string.Empty;
            this.thumbnail = string.Empty;
        }
        
        public string Original
        {
            get { return this.original; }
            set { this.original = value; }
        }
        
        public string Copy
        {
            get { return this.copy; }
            set { this.copy = value; }
        }
        
        public string Thumbnail
        {
            get { return this.thumbnail; }
            set { this.thumbnail = value; }
        }
        
        public string Image
        {
            get
            {
                if (string.IsNullOrEmpty(this.copy))
                {
                    return this.original;
                }
                else
                {
                    if (File.Exists(this.copy))
                    {
                        return this.copy;
                    }
                    else
                    {
                        return this.original;
                    }
                }
            }
        }
        
        public static ImageReference CreateImageReference(string fileName, string pathImages)
        {
            ImageReference r = new ImageReference(fileName);
            if (r.CreateCopy(pathImages))
            {
                r.CreateThumbnail(pathImages, 100, 100);
                return r;
            }
            else
            {
                return null;
            }
        }
        
        public bool CheckImages(string pathImages)
        {
            bool modify = false;
            bool copyExist = File.Exists(this.Copy);
            if (!copyExist)
            {
                if (!(copyExist = this.CreateCopy(pathImages)))
                {
                    this.Copy = string.Empty;
                }
                
                modify = true;
            }
             
            if (copyExist)
            {
                if (!File.Exists(this.Thumbnail))
                {
                    this.CreateThumbnail(pathImages, 100, 100);
                    modify = true;
                }
            }
            else
            {
                this.Thumbnail = string.Empty;
                modify = true;
            }
            
            return modify;
        }
        
        public override string ToString()
        {
            return this.original;
        }
        
        private bool CreateCopy(string pathImages)
        {
            if (!Directory.Exists(pathImages))
            {
                Directory.CreateDirectory(pathImages);
            }
            
            this.Copy = pathImages + @"\" + Guid.NewGuid() + Path.GetExtension(this.Original);
            if (this.Original.Substring(1, 2) == @":\")
            {
                if (File.Exists(this.Original))
                {
                    File.Copy(this.Original, this.Copy);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                WebClient client = new WebClient();
                Uri uri = new Uri(this.Original);
                try
                {
                    client.DownloadFile(uri, this.Copy);
                }
                catch (WebException)
                {
                    return false;
                }
            }
            
            return true;
        }
        
        private void CreateThumbnail(string pathImages, int width, int height)
        {
            string pathThumbnail = pathImages + @"\thumbnails";
            this.Thumbnail = pathThumbnail + @"\" + Guid.NewGuid() + ".bmp";
            Bitmap b = new Bitmap(this.Image);
            double k = (double)b.Width / (double)b.Height;
            int w = width;
            int h = height;
            if (k > 1)
            {
                h = (int)Math.Round(w / k);
            }
            else if (k < 1)
            {
                w = (int)Math.Round(h * k);
            }
            
            Image im = b.GetThumbnailImage(w, h, null, IntPtr.Zero);
            if (!Directory.Exists(pathThumbnail))
            {
                Directory.CreateDirectory(pathThumbnail);
            }
            
            im.Save(this.Thumbnail);
            
            im.Dispose();
            b.Dispose();
        }
    }
}
