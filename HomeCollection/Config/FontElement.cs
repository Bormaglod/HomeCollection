//-----------------------------------------------------------------------
// <copyright file="FontElement.cs" company="Sergey Teplyashin">
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
// <date>05.01.2011</date>
// <time>19:10</time>
// <summary>Defines the FontElement class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Config
{
    #region Using directives
    
    using System;
    using System.Drawing;
    
    #endregion
    
    /// <summary>
    /// Description of FontElement.
    /// </summary>
    public class FontElement
    {
        private string name;
        private bool bold;
        private bool italic;
        private bool strikeout;
        private bool underline;
        private float size;
        private byte charSet;
        
        public FontElement()
        {
        }
        
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        
        public bool Bold
        {
            get { return this.bold; }
            set { this.bold = value; }
        }
        
        public bool Italic
        {
            get { return this.italic; }
            set { this.italic = value; }
        }
        
        public bool Strikeout
        {
            get { return this.strikeout; }
            set { this.strikeout = value; }
        }
        
        public bool Underline
        {
            get { return this.underline; }
            set { this.underline = value; }
        }
        
        public float Size
        {
            get { return this.size; }
            set { this.size = value; }
        }
        
        public byte CharSet
        {
            get { return this.charSet; }
            set { this.charSet = value; }
        }
        
        public Font CreateFont()
        {
            FontStyle style = FontStyle.Regular;
            if (this.Italic)
            {
                style |= FontStyle.Italic;
            }
                
            if (this.Bold)
            {
                style |= FontStyle.Bold;
            }
                
            if (this.Strikeout)
            {
                style |= FontStyle.Strikeout;
            }
                
            if (this.Underline)
            {
                style |= FontStyle.Underline;
            }
                
            return new Font(this.Name, this.Size, style, GraphicsUnit.Point, this.CharSet);
        }
        
        public void Update(Font font)
        {
            this.Name = font.Name;
            this.Bold = font.Bold;
            this.Italic = font.Italic;
            this.Strikeout = font.Strikeout;
            this.Underline = font.Underline;
            this.Size = font.Size;
            this.CharSet = font.GdiCharSet;
        }
        
        public void Defaults()
        {
            this.name = "Microsoft Sans Serif";
            this.size = 8;
            this.bold = false;
            this.italic = false;
            this.strikeout = false;
            this.underline = false;
            this.charSet = 0;
        }
    }
}
