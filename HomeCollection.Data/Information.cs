//-----------------------------------------------------------------------
// <copyright file="Information.cs" company="Sergey Teplyashin">
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
// <date>17.11.2010</date>
// <time>10:08</time>
// <summary>Defines the Information class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives

    using System;
    using System.Reflection;

    #endregion

    public class Information
    {
        #region private property

        private string title;
        private string author;
        private string license;
        private string category;
        private DateTime date;
        private string email;
        private string comment;
        private Version version;

        #endregion

        public Information()
        {
            Assembly a = Assembly.GetExecutingAssembly();
            AssemblyName name = a.GetName();
            this.version = new Version(name.Version.Major, name.Version.Minor, name.Version.Build);
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public string Author
        {
            get { return this.author; }
            set { this.author = value; }
        }

        public string License
        {
            get { return this.license; }
            set { this.license = value; }
        }

        public string Category
        {
            get { return this.category; }
            set { this.category = value; }
        }

        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }

        public Version Version
        {
            get { return this.version; }
            set { this.version = value; }
        }
    }
}
