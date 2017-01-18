//-----------------------------------------------------------------------
// <copyright file="ImageCollection.cs" company="Sergey Teplyashin">
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
// <time>11:14</time>
// <summary>Defines the ImageCollection class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Db4objects.Db4o.Linq;
    
    #endregion
    
    /// <summary>
    /// Description of ImageCollection.
    /// </summary>
    public class ImageCollection : BaseCollection<ImageReference>
    {
        public ImageCollection(Database data) : base(data)
        {
        }
        
        public ImageReference this[string path]
        {
            get
            {
                IEnumerable<ImageReference> refs =  from ImageReference r in Database.Data
                                         where r.Original == path
                                         select r;
                return refs.Count() == 0 ? null : refs.First();
            }
        }
        
        public IEnumerable<ImageReference> GetImages(IEnumerable<string> images)
        {
        	IEnumerable<ImageReference> refs = Database.Data.Query<ImageReference>(delegate(ImageReference image)
        	                                                                 {
        	                                                                 	return images.Contains(image.Original);
        	                                                                 }).AsEnumerable();
        	
        	// Этот вариант работавший в .NET Framework 3.5, неожиданно перестал работать в .NET Framework 4.0
        	// Если images не содержит ни одной строки, то результирующая выборка, тоже не содержит данных,
        	// однако возвращалась выборка с количеством данных равным 2.
        	// Попытка перечисления приводила к ошибке о невозможности преобразования IEnumerable<string> в ImageReference
            /*IEnumerable<ImageReference> refs = from ImageReference r in Database.Data
                where images.Contains(r.Original)
                select r;*/
            return refs;
        }
    }
}
