//-----------------------------------------------------------------------
// <copyright file="FormUserData.cs" company="Sergey Teplyashin">
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
// <date>03.05.2011</date>
// <time>14:46</time>
// <summary>Defines the FormUserData class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml;
    using ComponentFactory.Krypton.Toolkit;
    using HomeCollection.Core;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    
    #endregion

    /// <summary>
    /// Description of FormUserData.
    /// </summary>
    public partial class FormUserData : FormDataAbstract
    {
        private XmlDocument doc;
        
        public FormUserData(IDataCollection collection, Database data, XmlDocument xmlData/*, IEnumerable<IImportPlugin> plugins*/) : base(collection, data/*, plugins*/)
        {
            InitializeComponent();
            
            this.doc = xmlData;
        }
        
        protected override void CreateControls()
        {
            foreach (XmlNode node in this.doc.ChildNodes)
            {
                if (node.Name == "form")
                {
                    XmlAttribute attr = node.Attributes["width"];
                    int w = attr != null ? int.Parse(attr.Value) : Width;
                    attr = node.Attributes["height"];
                    int h = attr != null ? int.Parse(attr.Value) : Height;
                    attr = node.Attributes["min_width"];
                    int min_w = attr != null ? int.Parse(attr.Value) : 0;
                    attr = node.Attributes["min_height"];
                    int min_h = attr != null ? int.Parse(attr.Value) : 0;
                    attr = node.Attributes["max_width"];
                    int max_w = attr != null ? int.Parse(attr.Value) : 0;
                    attr = node.Attributes["max_height"];
                    int max_h = attr != null ? int.Parse(attr.Value) : 0;
                    
                    Size = new Size(w, h);
                    MinimumSize = new Size(min_w, min_h);
                    MaximumSize = new Size(max_w, max_h);
                    
                    foreach (XmlNode cNode in node.ChildNodes)
                    {
                        if (cNode.Name == "controls")
                        {
                            foreach (XmlNode controlNode in cNode.ChildNodes)
                            {
                                AddNode(controlNode, Controls);
                            }
                            
                            break;
                        }
                    }
                    
                    break;
                }
            }
            
            this.SelectFirstControl(Controls);
        }
        
        private TabControl GetTabControl(System.Windows.Forms.Control.ControlCollection ctrls)
        {
            foreach (Control c in ctrls)
            {
                TabControl tc = c as TabControl;
                if (tc != null)
                {
                    return tc;
                }
            }
            
            return null;
        }
        
        private TabPage GetPage(TabControl tabControl, string name)
        {
            foreach (TabPage tp in tabControl.TabPages)
            {
                if (tp.Text == name)
                {
                    return tp;
                }
            }
            
            TabPage t = new TabPage(name);
            t.UseVisualStyleBackColor = true;
            tabControl.TabPages.Add(t);
            return t;
        }
        
        private void AddNode(XmlNode node, System.Windows.Forms.Control.ControlCollection ctrls)
        {
            XmlAttribute attr = node.Attributes["X"];
            int x = attr != null ? int.Parse(attr.Value) : 0;
            
            attr = node.Attributes["Y"];
            int y = attr != null ? int.Parse(attr.Value) : 0;
            
            if (node.Name == "page")
            {
                TabControl tc = this.GetTabControl(ctrls);
                if (tc == null)
                {
                    tc = new TabControl();
                    tc.Location = new Point(x, y);
                    attr = node.Attributes["anchor"];
                    if (attr != null)
                    {
                        tc.Anchor = this.GetAnchor(attr.Value);
                    }
                    
                    attr = node.Attributes["width"];
                    int w = attr == null ? 0 : int.Parse(attr.Value);
                    
                    attr = node.Attributes["height"];
                    int h = attr == null ? 0 : int.Parse(attr.Value);
                    
                    if (w > 0 || h > 0)
                    {
                        tc.Size = new Size(w == 0 ? tc.Width : w, h == 0 ? tc.Height : h);
                    }
                    
                    ctrls.Add(tc);
                }
                
                attr = node.Attributes["name"];
                string pageName = attr == null ? Strings.CategoryDefault : attr.Value;
                TabPage tp = this.GetPage(tc, pageName);
                
                foreach (XmlNode controlNode in node.ChildNodes)
                {
                    AddNode(controlNode, tp.Controls);
                }
            }
            if (node.Name == "label")
            {
                attr = node.Attributes["text"];
                if (attr != null)
                {
                    KryptonLabel label = new KryptonLabel();
                    label.Text = attr.Value;
                    label.Location = new Point(x, y);
                    ctrls.Add(label);
                }
            }
            else if (node.Name == "line")
            {
                KryptonBorderEdge line = new KryptonBorderEdge();
                line.Location = new Point(x, y);
                line.AutoSize = false;
                attr = node.Attributes["width"];
                if (attr != null)
                {
                    line.Size = new Size(int.Parse(attr.Value), 1);
                }
                else
                {
                    line.Size = new Size(50, 1);
                }
                
                attr = node.Attributes["anchor"];
                if (attr != null)
                {
                    line.Anchor = this.GetAnchor(attr.Value);
                }
                
                ctrls.Add(line);
            }
            else if (node.Name == "control")
            {
                attr = node.Attributes["field"];
                if (attr != null)
                {
                    Field field = Obj.ObjectClass.FindField(attr.Value, true);
                    if (field != null)
                    {
                        Control control = AddFieldControl(field);
                        attr = node.Attributes["anchor"];
                        if (attr != null)
                        {
                            control.Anchor = this.GetAnchor(attr.Value);
                        }
                        
                        attr = node.Attributes["width"];
                        int w = attr == null ? 0 : int.Parse(attr.Value);
                        
                        attr = node.Attributes["height"];
                        int h = attr == null ? 0 : int.Parse(attr.Value);
                        
                        if (w > 0 || h > 0)
                        {
                            control.Size = new Size(w == 0 ? control.Width : w, h == 0 ? control.Height : h);
                        }
                        
                        control.Location = new Point(x, y);
                        
                        if (field.FieldType == FieldType.Boolean)
                        {
                            attr = node.Attributes["text"];
                            if (attr != null)
                            {
                                bool view_text = bool.Parse(attr.Value);
                                control.Text = field.Name;
                            }
                        }
                        else if (field.FieldType == FieldType.List)
                        {
                            attr = node.Attributes["small_buttons"];
                            if (attr != null)
                            {
                                bool sb = bool.Parse(attr.Value);
                                ((ListBoxControl)control).SmallButtons = sb;
                            }
                        }
                        
                        ctrls.Add(control);
                    }
                }
            }
        }
        
        private AnchorStyles GetAnchor(string anchorText)
        {
            AnchorStyles style = AnchorStyles.None;
            if (!string.IsNullOrEmpty(anchorText))
            {
                string[] anchors = anchorText.Split(new char[] { ',' });
                foreach (string a in anchors)
                {
                    if (a == "left")
                    {
                        style |= AnchorStyles.Left;
                    }
                    else if (a == "right")
                    {
                        style |= AnchorStyles.Right;
                    }
                    else if (a == "top")
                    {
                        style |= AnchorStyles.Top;
                    }
                    else if (a == "bottom")
                    {
                        style |= AnchorStyles.Bottom;
                    }
                }
            }
            
            return style;
        }
    }
}
