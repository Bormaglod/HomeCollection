//-----------------------------------------------------------------------
// <copyright file="${FILENAME}" company="Sergey Teplyashin">
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
// <date>10.04.2012</date>
// <time>13:05</time>
// <summary>Defines the ? class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.AddIns
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    
    #endregion

    /// <summary>
    /// Description of DataPlugin.
    /// </summary>
    public abstract class DataPlugin
    {
        public abstract string GetName();
        public abstract IList<Guid> GetObjectClassId();
        public abstract string GetLocaleObjectClass(Guid guid);
        public abstract bool SetCurrentGuid(Guid guid);
        public abstract IList<string> GetNeededAttributes();
        public abstract IList<string> GetChangedAttributes();
        public abstract void SetData(string fieldName, string value);
        public abstract string GetData(string fieldName);
        public abstract bool Execute();
    }
}
