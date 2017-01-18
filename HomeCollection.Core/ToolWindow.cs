//-----------------------------------------------------------------------
// <copyright file="ToolWindow.cs" company="Sergey Teplyashin">
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
// <date>26.01.2011</date>
// <time>9:15</time>
// <summary>Defines the ToolWindow class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Core
{
    #region Using directives
    
    using System;
    using HomeCollection.Data;
    using WeifenLuo.WinFormsUI.Docking;
    
    #endregion
    
    /// <summary>
    /// Description of ToolWindow.
    /// </summary>
    public class ToolWindow : DockContent
    {
        private Database database;
        private IApplication application;
        
        public ToolWindow()
        {
            this.application = null;
        }
        
        public ToolWindow(IApplication app)
        {
            this.application = app;
        }
        
        public ToolWindow(IApplication app, Database data) : this(app)
        {
            this.database = data;
        }
        
        public IApplication App
        {
            get { return this.application; }
        }
        
        public Database Database
        {
            get { return this.database; }
        }
        
        public virtual void DatabaseOpened() { }
        
        public virtual void RefreshWindow() { }
        
        public void DoDatabaseOpened()
        {
            DatabaseOpened();
            RefreshWindow();
        }
        
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.application != null)
            {
                this.application.CloseChildWindow(this);
            }
        }
    }
}
