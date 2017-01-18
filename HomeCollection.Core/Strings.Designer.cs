﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HomeCollection.Core
{
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings
    {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings()
        {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("HomeCollection.Core.Strings", typeof(Strings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ошибка.
        /// </summary>
        internal static string Error
        {
            get
            {
                return ResourceManager.GetString("Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Импорт.
        /// </summary>
        internal static string Import
        {
            get
            {
                return ResourceManager.GetString("Import", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Импорт атрибутов шаблона {0}.
        /// </summary>
        internal static string ImportAttributes
        {
            get
            {
                return ResourceManager.GetString("ImportAttributes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Импорт конфигурации.
        /// </summary>
        internal static string ImportConfiguration
        {
            get
            {
                return ResourceManager.GetString("ImportConfiguration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Импорт записей.
        /// </summary>
        internal static string ImportRecord
        {
            get
            {
                return ResourceManager.GetString("ImportRecord", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Импорт шаблона {0}.
        /// </summary>
        internal static string ImportTemplate
        {
            get
            {
                return ResourceManager.GetString("ImportTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Введите новое имя шаблона.
        /// </summary>
        internal static string InputTemplateName
        {
            get
            {
                return ResourceManager.GetString("InputTemplateName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Без имени.
        /// </summary>
        internal static string NoName
        {
            get
            {
                return ResourceManager.GetString("NoName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Переименование.
        /// </summary>
        internal static string Rename
        {
            get
            {
                return ResourceManager.GetString("Rename", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Шаблон уже существует..
        /// </summary>
        internal static string TemplateExist
        {
            get
            {
                return ResourceManager.GetString("TemplateExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Шаблон с таким именем уже существует..
        /// </summary>
        internal static string TemplateNameExist
        {
            get
            {
                return ResourceManager.GetString("TemplateNameExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Имя шаблона должно быть уникально. Импорт будет осуществлен только после изменения имени шаблона..
        /// </summary>
        internal static string TemplateNameUnique
        {
            get
            {
                return ResourceManager.GetString("TemplateNameUnique", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Шаблон (атрибуты шаблона) ссылается на отсутствющий шаблон..
        /// </summary>
        internal static string TemplateNotExist
        {
            get
            {
                return ResourceManager.GetString("TemplateNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Шаблон не будет импортирован, а все ссылки на него будут заменены на ссылки уже существующего шаблона..
        /// </summary>
        internal static string TemplateWarning
        {
            get
            {
                return ResourceManager.GetString("TemplateWarning", resourceCulture);
            }
        }
    }
}
