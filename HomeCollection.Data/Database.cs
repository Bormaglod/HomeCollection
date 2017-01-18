//-----------------------------------------------------------------------
// <copyright file="Database.cs" company="Sergey Teplyashin">
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
// <date>24.02.2011</date>
// <time>13:09</time>
// <summary>Defines the Database class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using ComponentLib.Data;
    using Db4objects.Db4o;
    using Db4objects.Db4o.Config;
    using Db4objects.Db4o.Linq;
    
    #endregion
    
    /// <summary>
    /// Description of Database.
    /// </summary>
    public class Database : BaseDatabase
    {
        //private bool opened;
        //private IObjectContainer data;
        //private List<object> tables;
        //private string fileName;
        private ObjectClassCollection classes;
        private FolderCollection folders;
        private ObjectDataCollection objects;
        private FilterCollection filters;
        private ImageCollection images;
        
        public Database()
        {
            /*this.tables = new List<object>();
            this.fileName = string.Empty;*/
            AddCollections(new IExtCollection[] {
                                     this.classes = new ObjectClassCollection(this),
                                     this.folders = new FolderCollection(this),
                                     this.filters = new FilterCollection(this),
                                     this.images = new ImageCollection(this),
                                     this.objects = new ObjectDataCollection(this)
                                 });
        }
        
        /*public event EventHandler<EventArgs> DatabaseClosing;
        
        public event EventHandler<EventArgs> DatabaseClosed;
        
        public event EventHandler<EventArgs> DatabaseOpened;
        
        public event EventHandler<DatabaseOpeningEventArgs> DatabaseOpening;*/
        
        /// <summary>
        /// Gets or sets the object contains database information.
        /// </summary>
        /// <value>The database information (title, author, license, etc.)</value>
        public Information Information
        {
            get
            {
                return (from Information i in Data select i).FirstOrDefault();
                /*IEnumerable<Information> info = from Information i in this.data
                                                select i;
                return info.Count() == 0 ? null : info.First();*/
            }
            
            set
            {
                if (this.Information != null)
                {
                    Data.Delete(this.Information);
                }
                
                Data.Store(value);
            }
        }
        
        public ObjectClassCollection Classes
        {
            get { return this.classes; }
        }
        
        public FolderCollection Folders
        {
            get { return this.folders; }
        }
        
        public ObjectDataCollection Objects
        {
            get { return this.objects; }
        }
        
        public FilterCollection Filters
        {
            get { return this.filters; }
        }
        
        public ImageCollection Images
        {
            get { return this.images; }
        }
        
        /*#region IDatabase interface implemented
        
        public bool Opened
        {
            get { return this.opened; }
        }
        
        public IObjectContainer Data
        {
            get { return this.data; }
        }
        
        public IEnumerable<IExtCollection> Collections
        {
            get { return this.tables.OfType<IExtCollection>(); }
        }
        
        #endregion*/
        
        /*#region ITransaction interface implemented
        
        public void StartTransaction()
        {
            foreach (ITransaction t in this.tables)
            {
                t.StartTransaction();
            }
        }
        
        public void Commit()
        {
            foreach (ITransaction t in this.tables)
            {
                t.Commit();
            }
        }
        
        public void Rollback()
        {
            foreach (ITransaction t in this.tables)
            {
                t.Rollback();
            }
        }
        
        #endregion*/
        
        /*/// <summary>
        /// Открывает существующую базу данных.
        /// </summary>
        /// <param name="name">Имя файла базы данных.</param>
        public void Open(string name)
        {
            if (this.data != null)
            {
                this.data.Close();
            }
            
            this.fileName = name;
            this.PrepareAndOpenDatabase();
            this.OnDatabaseOpened();
        }*/
        
        /// <summary>
        /// Процедура создает новую базу данных. Если файл БД уже существут,
        /// то он будет удален.
        /// </summary>
        /// <param name="name">Имя файла базы данных.</param>
        /// <param name="info">Информация о БД (заголовок, автор, лицензия и т.д.).</param>
        public void Create(string name, Information info)
        {
            AddDatabaseParameter("Info", info);
            Create(name);
            /*if (this.data != null)
            {
                this.data.Close();
            }
            
            if (File.Exists(name))
            {
                File.Delete(name);
            }
            
            this.fileName = name;
            this.PrepareAndOpenDatabase();
            this.Information = info;
            this.CreateDefaultRecords();
            this.OnDatabaseOpened();*/
        }
        
        public void Recreate(bool defaults = false)
        {
            Information info = this.Information;
            if (Data != null)
            {
                Data.Close();
            }
            
            System.IO.File.Delete(FileName);
            
            this.PrepareAndOpenDatabase();
            this.Information = info;
            
            if (defaults)
            {
                this.CreateDefaultRecords();
            }
        }
        
        /*/// <summary>
        /// Закрывает открытую базу данных.
        /// </summary>
        public void Close()
        {
            if (this.data != null)
            {
                this.OnDatabaseClosing();
                this.data.Close();
                this.data = null;
                this.fileName = string.Empty;
                this.opened = false;
                this.OnDatabaseClosed();
            }
        }*/
        
        /*public void Backup()
        {
            if (this.data != null)
            {
                this.data.Ext().Backup(this.fileName + ".backup");
            }
        }*/
        
        protected override void CreateDefaultRecords()
        {
            Information info = (Information)GetDatabaseParameter("Info");
            this.Information = info;
            base.CreateDefaultRecords();
        }
            
        /*protected virtual void PrepareAndOpenDatabase()
        {
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();
            config.Common.ActivationDepth = 7;
            if (this.DatabaseOpening != null)
            {
                this.DatabaseOpening(this, new DatabaseOpeningEventArgs(config));
            }
            
            this.data = Db4oEmbedded.OpenFile(config, this.fileName);
            this.opened = true;
        }*/
        
        /*protected virtual void CreateDefaultRecords()
        {
            
        }*/
        
        /*private void OnDatabaseClosing()
        {
            if (this.DatabaseClosing != null)
            {
                this.DatabaseClosing(this, new EventArgs());
            }
        }
        
        private void OnDatabaseClosed()
        {
            if (this.DatabaseClosed != null)
            {
                this.DatabaseClosed(this, new EventArgs());
            }
        }
        
        private void OnDatabaseOpened()
        {
            if (this.DatabaseOpened != null)
            {
                this.DatabaseOpened(this, new EventArgs());
            }
        }*/
    }
}
