//-----------------------------------------------------------------------
// <copyright file="FieldNotFoundException.cs" company="Sergey Teplyashin">
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
// <date>25.03.2011</date>
// <time>9:24</time>
// <summary>Defines the FieldNotFoundException class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    using System.Runtime.Serialization;
    
    #endregion
    
    /// <summary>
    /// Description of ExceptionFieldNotFound.
    /// </summary>
    [Serializable()]
    public class FieldNotFoundException : Exception
    {
        public FieldNotFoundException() : base()
        {
        }
        
        public FieldNotFoundException(string message) : base(message)
        {
        }
        
        public FieldNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
        
        protected FieldNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
