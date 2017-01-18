//-----------------------------------------------------------------------
// <copyright file="IDataCollection.cs" company="Sergey Teplyashin">
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
// <date>14.04.2011</date>
// <time>12:33</time>
// <summary>Defines the IDataCollection interface.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Core
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using HomeCollection.Data;
    //using Tes.HomePrograms.Plugins.HC;
    
    #endregion
    
    /// <summary>
    /// Description of IDataCollection.
    /// </summary>
    public interface IDataCollection
    {
        //IEnumerable<IImportPlugin> Plugins { get; }
        void StoreHistory();
        void UpdateDataList();
        void UpdateDataList(string category);
        void UpdateDataList(Folder folder);
        void UpdateDataList(Folder folder, string filterData);
        void UpdateDataList(Filter filter);
        void UpdateCurrentRow();
        void UpdateCurrentData();
        
        ObjectData Add(ObjectClass objectClass, bool selectData);
        
        void UpdateDetailInfo();
    }
}
