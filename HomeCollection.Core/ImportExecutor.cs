//-----------------------------------------------------------------------
// <copyright file="ImportExecutor.cs" company="Sergey Teplyashin">
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
// <date>23.05.2011</date>
// <time>12:49</time>
// <summary>Defines the ImportExecutor class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Core
{
    #region Using directives
    
    using System;
    #if DEBUG
    using System.Timers;
    #endif
    using System.Xml;
    using HomeCollection.Data;
    
    #endregion
    
    /// <summary>
    /// Description of ImportExecutor.
    /// </summary>
    public class ImportExecutor
    {
        #if DEBUG
        private const double Interval = 200; 
        #endif
        
        private string xmlPath;
        private XmlDocument doc;
        private Database database;
        private FormProgress progress;
        #if DEBUG
        private Timer timer;
        private bool startProgress;
        #endif
        
        public ImportExecutor(Database database, XmlDocument doc, string xmlPath)
        {
            this.xmlPath = xmlPath;
            this.database = database;
            this.doc = doc;
            this.progress = new FormProgress();
            #if DEBUG
            this.timer = new Timer(Interval);
            this.timer.Elapsed += new ElapsedEventHandler(this.ImportExecutor_Elapsed);
            #endif
        }
        
        public string XmlPath
        {
            get { return this.xmlPath; }
        }
        
        public XmlDocument Document
        {
            get { return this.doc; }
        }
        
        public Database Database
        {
            get { return this.database; }
        }
        
        public void ShowProgress(string caption, string message)
        {
            this.progress.Message = message;
            this.progress.Text = caption;
            this.progress.Show();
        }
        
        public void Start(int Count)
        {
            this.progress.Count = Count;
            #if DEBUG
            this.timer.Start();
            #endif
        }
        
        public void StopProgress()
        {
            this.progress.Dispose();
            #if DEBUG
            this.timer.Dispose();
            #endif
        }
        
        public void NextMessage(string message)
        {
            this.progress.DoNextMessage(message);
        }
        
        public void UpdateMessage(string message)
        {
            this.progress.Message = message;
        }
        
        public void Wait()
        {
            #if DEBUG
            while (!this.startProgress);
            this.startProgress = false;
            #endif
        }
        
        #if DEBUG
        private void ImportExecutor_Elapsed(object source, ElapsedEventArgs e)
        {
            this.startProgress = true;
        }
        #endif
    }
}
