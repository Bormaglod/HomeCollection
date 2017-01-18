//-----------------------------------------------------------------------
// <copyright file="UserFormConverter.cs" company="Sergey Teplyashin">
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
// <date>20.06.2011</date>
// <time>13:34</time>
// <summary>Defines the UserFormConverter class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Properties
{
    #region Using directives
    
    using System;
    using System.ComponentModel;
    
    #endregion
    
    /// <summary>
    /// Description of UserFormConverter.
    /// </summary>
    public class UserFormConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            
            return base.CanConvertTo(context, destinationType);
        }
        
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return Strings.FormEdit;
            }
            
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
