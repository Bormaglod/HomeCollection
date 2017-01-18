//-----------------------------------------------------------------------
// <copyright file="ColumnCollectionEditor.cs" company="Sergey Teplyashin">
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
// <date>09.02.2011</date>
// <time>14:40</time>
// <summary>Defines the ColumnCollectionEditor class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Properties
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    using HomeCollection.Data;
    
    #endregion
    
    /// <summary>
    /// Description of ColumnCollectionEditor.
    /// </summary>
    public class ColumnCollectionEditor : UITypeEditor
    {
        private IWindowsFormsEditorService service = null;
            
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context != null && context.Instance != null && provider != null)
            {
                FieldTable fdt = (FieldTable)context.Instance;
                this.service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (this.service != null)
                {
                    using (FormColumnCollection form = new FormColumnCollection(fdt.Proxy.Database, (List<ColumnProperty>)value))
                    {
                        if (this.service.ShowDialog(form) == DialogResult.OK)
                        {
                            value = form.Collection;
                        }
                    }
                }
            }
            
            return value;
        }
    }
}
