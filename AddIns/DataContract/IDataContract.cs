//-----------------------------------------------------------------------
// <copyright file="IDataContract.cs" company="Sergey Teplyashin">
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
// <time>7:58</time>
// <summary>Defines the IDataContract interface.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.AddIns
{
    #region Using directives
    
    using System;
    using System.AddIn.Contract;
    using System.AddIn.Pipeline;
    
    #endregion
    
    /// <summary>
    /// Description of IDataContract.
    /// </summary>
    [AddInContract]
    public interface IDataContract : IContract
    {
        string GetName();
        IListContract<Guid> GetObjectClassId();
        string GetLocaleObjectClass(Guid guid);
        bool SetCurrentGuid(Guid guid);
        IListContract<string> GetNeededAttributes();
        IListContract<string> GetChangedAttributes();
        void SetData(string fieldName, string value);
        string GetData(string fieldName);
        bool Execute();
    }
}
