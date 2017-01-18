//-----------------------------------------------------------------------
// <copyright file="NumberProperty.cs" company="Sergey Teplyashin">
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
// <time>9:04</time>
// <summary>Defines the NumberProperty class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    
    #endregion
    
    /// <summary>
    /// Description of NumberProperty.
    /// </summary>
    public class NumberProperty
    {
        private int decimalPlaces;
        private decimal maximum;
        private decimal minimum;
        private decimal increment;
        private bool thousands;
        private string suffix;
        private string prefix;
        private bool bounds;
        
        public NumberProperty()
        {
            this.maximum = 100;
            this.increment = 1;
            this.suffix = string.Empty;
            this.prefix = string.Empty;
        }
        
        public int DecimalPlaces
        {
            get { return this.decimalPlaces; }
            set { this.decimalPlaces = value; }
        }
        
        public decimal Maximum
        {
            get { return this.maximum; }
            set { this.maximum = value; }
        }
        
        public decimal Minimum
        {
            get { return this.minimum; }
            set { this.minimum = value; }
        }
        
        public decimal Increment
        {
            get { return this.increment; }
            set { this.increment = value; }
        }
        
        public bool Thousands
        {
            get { return this.thousands; }
            set { this.thousands = value; }
        }
        
        public string Suffix
        {
            get { return this.suffix; }
            set { this.suffix = value; }
        }
        
        public string Prefix
        {
            get { return this.prefix; }
            set { this.prefix = value; }
        }
        
        public bool Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }
        
        public string Format
        {
            get
            {
                string res = this.thousands ? "#,##0" : "#0";
                if (this.decimalPlaces > 0)
                {
                    res += ".";
                    for (int i = 0; i < this.decimalPlaces; i++)
                    {
                        res += "0";
                    }
                }
                
                res = string.Format("{0} {1} {2}", prefix, res, suffix);
                return res;
            }
        }
    }
}
