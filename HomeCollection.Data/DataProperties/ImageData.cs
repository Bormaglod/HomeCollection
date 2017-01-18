//-----------------------------------------------------------------------
// <copyright file="ImageData.cs" company="Sergey Teplyashin">
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
// <time>11:11</time>
// <summary>Defines the ImageData class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using ComponentLib.Data;
    
    #endregion

    /// <summary>
    /// Description of ImageData.
    /// </summary>
    [Cascade]
    public class ImageData
    {
        private string refPath;
        
        [Cascade(WithObjects = false)]
        private List<string> images;
        
        public ImageData() : this(string.Empty)
        {
        }
        
        public ImageData(string referencePath)
        {
            this.refPath = referencePath;
            this.images = new List<string>();
        }
        
        public string ReferencePath
        {
            get
            {
                return this.refPath;
            }
            
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.RemoveImage(this.refPath);
                }
                else if (!this.images.Contains(value))
                {
                    this.AddImage(value);
                }
                
                this.refPath = value;
                if (string.IsNullOrEmpty(this.refPath) && this.images.Count > 0)
                {
                    this.refPath = this.images.First();
                }
            }
        }
        
        public int CountImages
        {
            get { return this.images.Count; }
        }
        
        public IEnumerable<string> Images
        {
            get { return this.images; }
        }
        
        public IEnumerable<string> CheckImages()
        {
            List<string> im = new List<string>();
            foreach (string file in this.images)
            {
                if (System.IO.File.Exists(file))
                {
                    im.Add(file);
                }
            }
            
            return im;
        }
        
        public void AddImage(string imagePath)
        {
            this.images.Add(imagePath);
        }
        
        public void AddRangeImage(IEnumerable list)
        {
            foreach (object s in list)
            {
                this.images.Add(s.ToString());
            }
        }
        
        public void RemoveImage(string imagePath)
        {
            this.images.Remove(imagePath);
        }
    }
}
