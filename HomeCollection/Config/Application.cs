//-----------------------------------------------------------------------
// <copyright file="Application.cs" company="Sergey Teplyashin">
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
// <time>9:24</time>
// <summary>Defines the Application class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Config
{
    #region Using directives
    
    using System;
    
    #endregion

    /// <summary>
    /// Description of Application.
    /// </summary>
    public class Application
    {
        private View view;
        private Main mainForm;
        private General general;
        
        public Application()
        {
            this.view = new View();
            this.mainForm = new Main();
            this.general = new General();
        }
        
        public View View
        {
            get { return this.view; }
            set { this.view = value; }
        }
        
        public Main Main
        {
            get { return this.mainForm; }
            set { this.mainForm = value; }
        }
        
        public General General
        {
            get { return this.general; }
            set { this.general = value; }
        }
        
        public void Defaults()
        {
            this.view.Defaults();
            this.mainForm.Defaults();
            this.general.Defaults();
        }
    }
}
