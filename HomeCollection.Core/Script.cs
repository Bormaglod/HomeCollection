//-----------------------------------------------------------------------
// <copyright file="Script.cs" company="Sergey Teplyashin">
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
// <date>27.05.2011</date>
// <time>10:05</time>
// <summary>Defines the Script class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection.Core
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    
    #endregion
    
    /// <summary>
    /// Description of Script.
    /// </summary>
    public class Parser
    {
        private FieldValue fieldValue;
        
        public delegate string FieldValue(string fieldName);
        
        public Parser(FieldValue fieldValue)
        {
            this.fieldValue = fieldValue;
        }
        
        public string Execute(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                return string.Empty;
            }
            
            return this.CalculateFunction(expression);
        }
        
        private string CalculateFunction(string exp)
        {
            int begin = exp.IndexOf('(');
            int end = exp.LastIndexOf(')');
            if (begin == -1 || end == -1)
            {
                return string.Empty;
            }
            
            string name = exp.Substring(0, begin);
            string param = exp.Substring(begin + 1, end - begin - 1);
            if (name == "substr")
            {
                return this.CalcSubstring(param);
            }
            else if (name == "concat")
            {
                return this.CalcConcat(param, true);
            }
            else if (name == "concat1")
            {
                return this.CalcConcat(param, false);
            }
            else if (name == "first")
            {
                return this.CalcFirst(param);
            }
            else if (name == "suffix")
            {
                return this.CalcSuffix(param);
            }
            else if (name == "prefix")
            {
                return this.CalcPrefix(param);
            }
            else
            {
                return string.Empty;
            }
        }
        
        private string CalcSuffix(string param)
        {
            string res = string.Empty;
            IEnumerator<string> list = this.AnalyseParameters(param).GetEnumerator();
            if (list.MoveNext())
            {
                if (!string.IsNullOrEmpty(list.Current))
                {
                    res = list.Current;
                    if (list.MoveNext())
                    {
                        res += list.Current;
                    }
                }
            }
            
            return res;
        }
        
        private string CalcPrefix(string param)
        {
            string res = string.Empty;
            IEnumerator<string> list = this.AnalyseParameters(param).GetEnumerator();
            if (list.MoveNext())
            {
                /*string text = list.Current;
                if (list.MoveNext())
                {
                    res = prefix + list.Current;
                }*/
                if (!string.IsNullOrEmpty(list.Current))
                {
                    res = list.Current;
                    if (list.MoveNext())
                    {
                        res = list.Current + res;
                    }
                }
            }
            
            return res;
        }
        
        private string CalcFirst(string param)
        {
            string res = string.Empty;
            IEnumerator<string> list = this.AnalyseParameters(param).GetEnumerator();
            if (list.MoveNext())
            {
                if (list.Current.Length > 0)
                {
                    res = list.Current.Substring(0, 1);
                }
                
                if (list.MoveNext() && !string.IsNullOrEmpty(res))
                {
                    res += list.Current;
                }
            }
            
            return res;
        }
        
        private string CalcConcat(string param, bool empty)
        {
            string res = string.Empty;
            IEnumerator<string> list = this.AnalyseParameters(param).GetEnumerator();
            if (list.MoveNext())
            {
                string delim = list.Current;
                bool first = true;
                while (list.MoveNext())
                {
                    if (!empty && string.IsNullOrEmpty(list.Current))
                    {
                        break;
                    }
                    
                    if (!string.IsNullOrEmpty(list.Current))
                    {
                        if (!first)
                        {
                            res += delim;
                        }
                        
                        first = false;
                        res += list.Current;
                    }
                }
            }
            
            return res;
        }
        
        private string CalcSubstring(string param)
        {
            string res = string.Empty;
            IEnumerator<string> list = this.AnalyseParameters(param).GetEnumerator();
            if (list.MoveNext())
            {
                string text = list.Current;
                int index = 0;
                int len = text.Length;
                if (list.MoveNext())
                {
                    index = int.Parse(list.Current);
                    if (list.MoveNext())
                    {
                        len = int.Parse(list.Current);
                    }
                    else
                    {
                        len = text.Length - index + 1;
                    }
                }
                
                res = text.Substring(index, len);
            }
            
            return res;
        }
        
        private IEnumerable<string> AnalyseParameters(string param)
        {
            List<string> list = new List<string>();
             // текущая позиция в строке
            int idx = 0;
            
            // Выпоним цикл по всем символам строки
            while (idx < param.Length)
            {
                // Пропустим пробелы и запятые
                if (param[idx] == ' ' || param[idx] == ',')
                {
                    idx++;
                    continue;
                }
                
                if (param[idx] == '"')
                {
                    int idx_text = param.IndexOf('"', idx + 1);
                    string text = string.Empty;
                    if (idx_text == -1)
                    {
                        text = param.Substring(idx + 1);
                        idx = param.Length;
                    }
                    else
                    {
                        text = param.Substring(idx + 1, idx_text - idx - 1);
                        idx = idx_text + 1;
                    }
                    
                    list.Add(text);
                    continue;
                }
                
                int idx_end = idx;
                while (idx_end < param.Length && param[idx_end] != ' ' && param[idx_end] != '(' && param[idx_end] != ',')
                {
                    idx_end++;
                }
                
                if (idx_end < param.Length && param[idx_end] == '(')
                {
                    int close_b = param.IndexOf(')', idx_end);
                    if (close_b == -1)
                    {
                        idx = param.Length;
                        continue;
                    }
                    
                    string resFunc = this.CalculateFunction(param.Substring(idx, close_b - idx + 1));
                    list.Add(resFunc);
                    idx = close_b + 1;
                }
                else
                {
                    string token = param.Substring(idx, idx_end - idx);
                    if (token.Length > 0)
                    {
                        if (char.IsDigit(token[0]))
                        {
                            list.Add(token);
                        }
                        else
                        {
                            string resField = this.fieldValue(token);
                            list.Add(resField);
                        }
                    }
                    
                    idx = idx_end + 1;
                }
            }
            
            return list;
        }
    }
}
