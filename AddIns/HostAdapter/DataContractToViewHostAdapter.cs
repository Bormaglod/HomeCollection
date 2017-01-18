//-----------------------------------------------------------------------
// <copyright file="DataContractToViewHostAdapter.cs" company="Sergey Teplyashin">
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
// <time>13:19</time>
// <summary>Defines the DataContractToViewHostAdapter class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.AddIns
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.AddIn.Pipeline;
    
    #endregion
    
    [HostAdapter]
    internal class DataContractToViewHostAdapter : DataPlugin
    {
        private IDataContract contract;
        private ContractHandle handle;
        
        public DataContractToViewHostAdapter(IDataContract contract)
        {
            this.contract = contract;
            handle = new ContractHandle(contract);
        }
        
        public override string GetName()
        {
            return contract.GetName();
        }
        
        public override IList<Guid> GetObjectClassId()
        {
            return CollectionAdapters.ToIList<Guid>(contract.GetObjectClassId());
        }
        
        public override string GetLocaleObjectClass(Guid guid)
        {
            return contract.GetLocaleObjectClass(guid);
        }
        
        public override bool SetCurrentGuid(Guid guid)
        {
            return contract.SetCurrentGuid(guid);
        }
        
        public override IList<string> GetNeededAttributes()
        {
            return CollectionAdapters.ToIList<string>(contract.GetNeededAttributes());
        }
        
        public override IList<string> GetChangedAttributes()
        {
            return CollectionAdapters.ToIList<string>(contract.GetChangedAttributes());
        }
        
        public override void SetData(string fieldName, string value)
        {
            contract.SetData(fieldName, value);
        }
        
        public override string GetData(string fieldName)
        {
            return contract.GetData(fieldName);
        }
        
        public override bool Execute()
        {
            return contract.Execute();
        }
    }
}
