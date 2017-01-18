//-----------------------------------------------------------------------
// <copyright file="Enums.cs" company="Sergey Teplyashin">
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
// <date>21.03.2012</date>
// <time>9:29</time>
// <summary>Defines enums.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Data.Core
{
    #region Using directives
    
    using System;
    using System.ComponentModel;
    
    #endregion
    
    public enum FieldType
    {
        /// <summary>
        /// Определяет значение атрибута "Текст".
        /// </summary>
        [LocalizedDescription("Text")]
        Text,
        
        /// <summary>
        /// Определяет значение атрибута "Большой текст".
        /// </summary>
        [LocalizedDescription("Memo")]
        Memo,
        
        /// <summary>
        /// Определяет значение атрибута "Выбор".
        /// </summary>
        [LocalizedDescription("Select")]
        Select,
        
        /// <summary>
        /// Определяет значение атрибута "Число".
        /// </summary>
        [LocalizedDescription("Number")]
        Number,
        
        /// <summary>
        /// Определяет значение атрибута "Список".
        /// </summary>
        [LocalizedDescription("List")]
        List,
        
        /// <summary>
        /// Определяет значение атрибута "Да/Нет".
        /// </summary>
        [LocalizedDescription("Boolean")]
        Boolean,
        
        /// <summary>
        /// Определяет значение атрибута "Url".
        /// </summary>
        [LocalizedDescription("Url")]
        Url,
        
        /// <summary>
        /// Определяет значение атрибута "Дата".
        /// </summary>
        [LocalizedDescription("Date")]
        Date,
        
        /// <summary>
        /// Определяет значение атрибута "Таблица".
        /// </summary>
        [LocalizedDescription("Table")]
        Table,
        
        /// <summary>
        /// Определяет значение атрибута "Изображение".
        /// </summary>
        [LocalizedDescription("Image")]
        Image,
        
        /// <summary>
        /// Определяет значение атрибута "Рейтинг".
        /// </summary>
        [LocalizedDescription("Rating")]
        Rating,
        
        /// <summary>
        /// Определяет значение атрибута "ССылка".
        /// </summary>
        [LocalizedDescription("ReferenceType")]
        Reference
    }
    
    public enum SystemProperty
    {
        Name,
        
        Custom
    }
    
    public enum MoveDirection
    {
        Up,
        
        Down
    }
    
    public enum UrlType
    {
        [LocalizedDescription("SelectUrl")]
        Select,
        
        [LocalizedDescription("File")]
        File,
        
        [LocalizedDescription("Folder")]
        Folder,
        
        [LocalizedDescription("WebPage")]
        Url
    }
    
    public enum Logical
    {
        And,
        
        Or
    }
    
    public enum FilterOperation
    {
        Contains,
        
        NotContains,
        
        Equal,
        
        NotEqual
    }
}