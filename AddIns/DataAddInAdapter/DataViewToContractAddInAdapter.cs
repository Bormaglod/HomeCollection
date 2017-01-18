//-----------------------------------------------------------------------
// <copyright file="DataViewToContractAddInAdapter.cs" company="Sergey Teplyashin">
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
// <time>11:46</time>
// <summary>Defines the DataViewToContractAddInAdapter class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.AddIns
{
    #region Using directives
    
    using System;
    using System.AddIn.Contract;
    using System.AddIn.Pipeline;
    
    #endregion
    
    [AddInAdapter]
    internal class DataViewToContractAddInAdapter : ContractBase, IDataContract
    {
        private DataPlugin view;
        
        public DataViewToContractAddInAdapter(DataPlugin view)
        {
            this.view = view;
        }
        
        public string GetName()
        {
            return view.GetName();
        }
        
        public IListContract<Guid> GetObjectClassId()
        {
            return CollectionAdapters.ToIListContract<Guid>(view.GetObjectClassId());
        }
        
        public string GetLocaleObjectClass(Guid guid)
        {
            return view.GetLocaleObjectClass(guid);
        }
        
        public bool SetCurrentGuid(Guid guid)
        {
            return view.SetCurrentGuid(guid);
        }
        
        public IListContract<string> GetNeededAttributes()
        {
            return CollectionAdapters.ToIListContract<string>(view.GetNeededAttributes());
        }
        
        public IListContract<string> GetChangedAttributes()
        {
            return CollectionAdapters.ToIListContract<string>(view.GetChangedAttributes());
        }
        
        public void SetData(string fieldName, string value)
        {
            view.SetData(fieldName, value);
        }
        
        public string GetData(string fieldName)
        {
            return view.GetData(fieldName);
        }
        
        public bool Execute()
        {
            return view.Execute();
        }
    }
}
