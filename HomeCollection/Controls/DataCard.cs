//-----------------------------------------------------------------------
// <copyright file="DataCard.cs" company="Sergey Teplyashin">
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
// <date>18.03.2011</date>
// <time>15:15</time>
// <summary>Defines the DataCard class.</summary>
//-----------------------------------------------------------------------

namespace HomeCollection
{
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using HomeCollection.Data;
    using HomeCollection.Data.Core;
    
    #endregion
    
    /// <summary>
    /// Description of DataCard.
    /// </summary>
    public partial class DataCard : UserControl
    {
        private const int HeightImage = 75;
        private const int WidthImage = 75;
        private const int DividerImage = 5;
        
        private Dictionary<Field, object> values;
        private string headerText;
        private Pen borderPen;
        private SolidBrush textBrush;
        private SolidBrush selectedBrush;
        private Font fontHeader;
        private Font fontName;
        private Font fontValue;
        private int updated;
        private List<ReferenceData> refs;
        private ReferenceData selected;
        private ReferenceData pressed;
        private Database database;
        
        internal enum ReferenceType
        {
            ObjectData,
            Image,
            Url
        }
        
        public DataCard(Database database, string header)
        {
            this.InitializeComponent();
        
            this.values = new Dictionary<Field, object>();
            this.headerText = header;
            this.borderPen = new Pen(Color.FromArgb(161, 169, 179));
            this.textBrush = new SolidBrush(Color.Black);
            this.selectedBrush = new SolidBrush(Color.Blue);
            this.fontName = MainForm.Config.App.View.AttrNameFont.CreateFont();
            this.fontValue = MainForm.Config.App.View.AttrValueFont.CreateFont();
            this.fontHeader = MainForm.Config.App.View.CategoryFont.CreateFont();
            this.refs = new List<DataCard.ReferenceData>();
            this.database = database;
        }
        
        public event EventHandler<EventArgs> ObjectDataSelected;
        
        public event EventHandler<EventArgs> ImageDataSelected;
        
        public string CategoryName
        {
            get { return this.headerText; }
        }
        
        public int CountValues
        {
            get { return this.values.Count; }
        }
        
        private bool IsUpdated
        {
            get { return this.updated > 0; }
        }
        
        public void BeginUpdate()
        {
            this.updated++;
        }
        
        public void EndUpdate()
        {
            if (this.updated > 0)
            {
                this.updated--;
                if (this.updated == 0)
                {
                    this.UpdateHeight();
                }
            }
        }
        
        public void AddValue(Field field, object value)
        {
            this.values.Add(field, value);
        }
        
        public void UpdateHeight()
        {
            Graphics g = Graphics.FromHwnd(Handle);
            SizeF sizeHeader = g.MeasureString(this.headerText, this.fontHeader);
            Size = new Size(Width, this.GetHeightValues() + (int)sizeHeader.Height + 11);
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            this.refs.Clear();
            base.OnPaint(e);
            this.DrawBackground(e.Graphics, e.ClipRectangle);
            this.DrawFrame(e.Graphics);
            this.DrawHeader(e.Graphics);
            this.DrawContent(e.Graphics);
        }
        
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            
            this.selected = null;
            foreach (ReferenceData rd in this.refs)
            {
                if (rd.Rect.Contains(e.X, e.Y))
                {
                    this.selected = rd;
                    break;
                }
            }
                
            if (this.pressed == null)
            {    
                if (this.selected != null)
                {
                    if (Cursor != Cursors.Hand)
                    {
                        Cursor = Cursors.Hand;
                    }
                }
                else
                {
                    if (Cursor != Cursors.Default)
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
        }
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.selected != null)
            {
                this.pressed = this.selected;
            }
        }
        
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (this.selected != null)
            {
                switch (this.selected.RefType)
                {
                    case ReferenceType.ObjectData:
                        this.OnObjectDataSelected((ObjectData)this.selected.Obj);
                        break;
                    case ReferenceType.Image:
                        this.OnImageDataSelected((string)this.selected.Obj);
                        break;
                    case ReferenceType.Url:
                        break;
                }
            }
            
            this.pressed = null;
        }
        
        private void OnObjectDataSelected(ObjectData od)
        {
            if (this.ObjectDataSelected != null)
            {
                this.ObjectDataSelected(od, new EventArgs());
            }
        }
        
        private void OnImageDataSelected(string fileName)
        {
            if (this.ImageDataSelected != null)
            {
                this.ImageDataSelected(fileName, new EventArgs());
            }
        }
        
        private void DrawBackground(Graphics g, Rectangle r)
        {
            g.FillRectangle(new SolidBrush(Color.White), r);
        }
        
        private void DrawFrame(Graphics g)
        {
            Rectangle r = new Rectangle(0, 0, Width - 1, Height - 1);
            g.DrawRectangle(this.borderPen, r);
            SizeF sizeHeader = g.MeasureString(this.headerText, this.fontHeader);
            int y = (int)sizeHeader.Height + 9;
            g.DrawLine(this.borderPen, 0, y, r.Width, y);
        }
        
        private void DrawHeader(Graphics g)
        {
            SizeF sizeHeader = g.MeasureString(this.headerText, this.fontHeader);
            Rectangle r = new Rectangle(1, 1, Width - 2, (int)sizeHeader.Height + 8);
            Color beginColor = Color.FromArgb(232, 236, 241);
            Color endColor = Color.FromArgb(208, 213, 219);
            LinearGradientBrush brushHeader = new LinearGradientBrush(r, beginColor, endColor, LinearGradientMode.Vertical);
            g.FillRectangle(brushHeader, r);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            g.DrawString(this.headerText, this.fontHeader, this.textBrush, new RectangleF(r.X, r.Y, r.Width, r.Height), format);
        }
        
        private int GetWidthNames(Graphics g)
        {
            int width_names = 0;
            foreach (Field field in this.values.Keys)
            {
                if (!field.IsPageField)
                {
                    SizeF size = g.MeasureString(field.Name, this.fontName);
                    if (size.Width > width_names)
                    {
                        width_names = (int)Math.Round(size.Width);
                    }
                }
            }
            
            return width_names;
        }
        
        private int GetHeightValue(Graphics g, Field field)
        {
            SizeF sizeName = SizeF.Empty;
            SizeF sizeValue = SizeF.Empty;
            if (!field.IsPageField)
            {
                if (field.FieldType == FieldType.Rating)
                {
                    sizeValue = new SizeF(178, 16);
                }
                else
                {
                    sizeValue = g.MeasureString(this.values[field].ToString(), this.fontValue);
                }
                
                sizeName = g.MeasureString(field.Name, this.fontName);
            }
            else
            {
                switch (field.FieldType)
                {
                    case FieldType.Memo:
                        string s = this.values[field].ToString();
                        sizeValue = g.MeasureString(s, this.fontValue, Width - 6);
                        break;
                    case FieldType.List:
                        ListData sc = (ListData)this.values[field];
                        sizeValue = g.MeasureString(sc.Objects.First().ToString(), this.fontValue);
                        sizeValue.Height *= sc.Objects.Count;
                        break;
                    case FieldType.Image:
                        ImageData id = (ImageData)this.values[field];
                        int w_count = (Width - DividerImage) / (WidthImage + DividerImage);
                        int h_count = id.CountImages / w_count;
                        if (h_count * w_count < id.CountImages)
                        {
                            h_count++;
                        }
                        
                        sizeValue.Height = h_count * (HeightImage + DividerImage) + 3 - 10;
                        break;
                    case FieldType.Table:
                        TableData td = (TableData)this.values[field];
                        if (td.Columns.Count() > 0)
                        {
                            SizeF sizeHeader = g.MeasureString(field.Name, this.fontName);
                            SizeF sizeRow = g.MeasureString("A"/*td.First.Data.ToString()*/, this.fontValue);
                            sizeValue.Height = sizeHeader.Height + 5 + (sizeRow.Height + 5) * td.RowCount + 1;
                        }
                        else
                        {
                            sizeValue = SizeF.Empty;
                        }
                        
                        break;
                }
            }
            
            return sizeName.Height > sizeValue.Height ? (int)sizeName.Height : (int)sizeValue.Height;
        }
        
        private int GetHeightValues()
        {
            int h = 0;
            Graphics g = Graphics.FromHwnd(Handle);
            foreach (Field field in this.values.Keys)
            {
                h += this.GetHeightValue(g, field) + 10;
            }
            
            return h;
        }
        
        private void DrawContentText(Graphics g, string text, PointF p)
        {
            g.DrawString(text, this.fontValue, this.textBrush, p);
        }
        
        private void DrawContentRaiting(Graphics g, decimal r, PointF p)
        {
            float x = p.X;
            
            int n1 = (int)r;
            int n2 = (int)(10 - r);
            for (int j = 0; j < n1; j++)
            {
                g.DrawImage(Resources.star, new PointF(x, p.Y));
                x += 18;
            }
            
            if (n1 + n2 < 10)
            {
                float d = (float)(r - n1);
                if (d < 0.39)
                {
                    g.DrawImage(Resources.star_gray, new PointF(x, p.Y));
                }
                else if (d > 0.61)
                {
                    g.DrawImage(Resources.star, new PointF(x, p.Y));
                }
                else
                {
                    g.DrawImage(Resources.star_halfgray, new PointF(x, p.Y));
                }
                
                x += 18;
            }
            
            for (int j = 0; j < n2; j++)
            {
                g.DrawImage(Resources.star_gray, new PointF(x, p.Y));
                x += 18;
            }
        }
        
        private void DrawContent(Graphics g)
        {
            int width_names = this.GetWidthNames(g);
            SizeF sizeCategory = g.MeasureString(this.headerText, this.fontHeader);
            float y = sizeCategory.Height + 14;
            foreach (Field field in this.values.Keys)
            {
                float x_name = 3;
                float x_value = width_names + 11;
                int h_value = this.GetHeightValue(g, field);
                if (!field.IsPageField)
                {
                    StringFormat format = new StringFormat();
                    format.LineAlignment = StringAlignment.Center;
                    g.DrawString(field.Name, this.fontName, this.textBrush, new RectangleF(x_name, y, width_names + 1, h_value), format);
                    int w_value = Width - 6 - width_names;
                    switch (field.FieldType)
                    {
                        case FieldType.Boolean:
                            g.DrawImage(Resources.tick, new PointF(x_value, y + (h_value - 16) / 2));
                            break;
                        case FieldType.Date:
                            DateTime dt = (DateTime)this.values[field];
                            DateProperty dprop = field.Data as DateProperty;
                            string date_format;
                            if (dprop.ViewTime)
                            {
                                date_format = "d MMM yyy H:mm:ss";
                            }
                            else
                            {
                                date_format = "d MMM yyy";
                            }
                            
                            g.DrawString(dt.ToString(date_format), this.fontValue, this.textBrush, new RectangleF(x_value, y, w_value, h_value), format);
                            break;
                        case FieldType.Select:
                            int val = (int)this.values[field];
                            List<string> sc = (List<string>)field.Data;
                            if (val < sc.Count)
                            {
                                g.DrawString(sc[val], this.fontValue, this.textBrush, new RectangleF(x_value, y, w_value, h_value), format);
                            }
                    
                            break;
                        case FieldType.Rating:
                            this.DrawContentRaiting(g, (decimal)this.values[field], new PointF(x_value, y + (h_value - 16) / 2));
                            break;
                        case FieldType.Reference:
                            ObjectData or = (ObjectData)this.values[field];
                            PointF pr = new PointF(x_value, y);
                            SizeF sizeRef = g.MeasureString(or.ToString(), this.fontValue);
                            float dRef = (h_value - sizeRef.Height) / 2;
                            g.DrawString(or.ToString(), this.fontValue, this.selectedBrush, new RectangleF(pr, new SizeF(w_value, h_value)), format);
                            pr.Y += dRef;
                            this.refs.Add(new ReferenceData(new RectangleF(pr, sizeRef), or, ReferenceType.ObjectData));
                            break;
                        case FieldType.Url:
                            string url = this.values[field].ToString();
                            pr = new PointF(x_value, y);
                            g.DrawString(url, this.fontValue, this.selectedBrush, new RectangleF(pr, new SizeF(w_value, h_value)), format);
                            SizeF sizeUrl = g.MeasureString(url, this.fontName);
                            this.refs.Add(new ReferenceData(new RectangleF(pr, sizeUrl), url, ReferenceType.Url));
                            break;
                        case FieldType.Number:
                            decimal res = (decimal)this.values[field];
                            NumberProperty num_prop = field.Data as NumberProperty;
                            g.DrawString(res.ToString(num_prop.Format), this.fontValue, this.textBrush, new RectangleF(x_value, y, w_value, h_value), format);
                            break;
                        default:
                            g.DrawString(this.values[field].ToString(), this.fontValue, this.textBrush, new RectangleF(x_value, y, w_value, h_value), format);
                            break;
                    }
                    
                    y += h_value + 9;
                }
                else
                {
                    switch (field.FieldType)
                    {
                        case FieldType.Table:
                            TableData td = (TableData)this.values[field];
                            SizeF sizeHeader = g.MeasureString(field.Name, this.fontName);
                            SizeF sizeRow = g.MeasureString("A"/*td.First.Data.ToString()*/, this.fontValue);
                            SizeF sizeTable = new SizeF(Width - 6, sizeHeader.Height + 5 + (sizeRow.Height + 5) * td.RowCount + 1);
                            
                            float y_t = y;
                            float x_t = x_name + 2;
                            foreach (ColumnProperty cp in td.Columns)
                            {
                                y_t = y + 3;
                                
                                // заголовок
                                g.DrawString(cp.Name, this.fontName, this.textBrush, new PointF(x_t, y_t));
                                SizeF sizeCol = g.MeasureString(cp.Name, this.fontName);
                                y_t += sizeCol.Height + 5;
                                for (int r = 0; r < td.RowCount; r++)
                                {
                                    object o = td[r][cp].Data;
                                    if (o == null)
                                    {
                                        continue;
                                    }
                                    
                                    PointF pf = new PointF(x_t, y_t);
                                    SizeF sizeN;
                                    if (string.IsNullOrEmpty(o.ToString()))
                                    {
                                        sizeN = g.MeasureString("A", this.fontValue);
                                    }
                                    else
                                    {
                                        sizeN = g.MeasureString(o.ToString(), this.fontValue);
                                        if (o is ObjectData)
                                        {
                                            this.refs.Add(new ReferenceData(new RectangleF(pf, sizeN), o, ReferenceType.ObjectData));
                                            g.DrawString(o.ToString(), this.fontValue, this.selectedBrush, pf);
                                        }
                                        else
                                        {
                                            g.DrawString(o.ToString(), this.fontValue, this.textBrush, pf);
                                        }
                                    }
                                    
                                    if (sizeN.Width > sizeCol.Width)
                                    {
                                        sizeCol.Width = sizeN.Width;
                                    }
                                    
                                    y_t += sizeN.Height + 5;
                                }
                                
                                x_t += sizeCol.Width + 6;
                            }
                            
                            break;
                        case FieldType.Memo:
                            string s = (string)this.values[field];
                            SizeF size = g.MeasureString(s, this.fontValue, Width - 6);
                            g.DrawString(s, this.fontValue, this.textBrush, new RectangleF(new PointF(x_name, y), size));
                            break;
                        case FieldType.List:
                            ListData sc = (ListData)this.values[field];
                            float yc = y;
                            foreach (ObjectData sl in sc.Objects)
                            {
                                PointF pf = new PointF(x_name, yc);
                                g.DrawString(sl.ToString(), this.fontValue, this.selectedBrush, pf);
                                SizeF sizeList = g.MeasureString(sl.ToString(), this.fontValue);
                                yc += sizeList.Height;
                                this.refs.Add(new ReferenceData(new RectangleF(pf, sizeList), sl, ReferenceType.ObjectData));
                            }
                            
                            break;
                        case FieldType.Image:
                            ImageData id = (ImageData)this.values[field];
                            float xi = x_name;
                            float yi = y;
                            foreach (string key in id.Images)
                            {
                                string pathImages = MainForm.AppDir + @"\images";
                                ImageReference ir = this.database.Images[key];
                                if (ir == null)
                                {
                                    ir = ImageReference.CreateImageReference(key, pathImages);
                                    if (ir != null)
                                    {
                                        this.database.Images.Add(ir);
                                    }
                                }
                                else
                                {
                                    if (ir.CheckImages(pathImages))
                                    {
                                        this.database.Images.Update(ir);
                                    }
                                    
                                    if (string.IsNullOrEmpty(ir.Copy))
                                    {
                                        ir = null;
                                    }
                                }
                                
                                if (ir == null)
                                {
                                    continue;
                                }
                                
                                int w = WidthImage;
                                int h = HeightImage;
                                
                                Image im = null;
                                
                                if (File.Exists(ir.Thumbnail))
                                {
                                    im = new Bitmap(ir.Thumbnail);
                                    if (im.Width > im.Height)
                                    {
                                        h = h * im.Height / im.Width;
                                    }
                                    else
                                    {
                                        w = w * im.Width / im.Height;
                                    }
                                }
                                else
                                {
                                    Bitmap original = new Bitmap(ir.Image);
                                    double k = (double)original.Width / (double)original.Height;
                                    
                                    if (k > 1)
                                    {
                                        h = (int)Math.Round(WidthImage / k);
                                    }
                                    else if (k < 1)
                                    {
                                        w = (int)Math.Round(HeightImage * k);
                                    }
                                    
                                    im = original.GetThumbnailImage(w, h, null, IntPtr.Zero);
                                }
                                
                                int dx = 0;
                                int dy = 0;
                                if (w > h)
                                {
                                    dy = (HeightImage - h) / 2;
                                }
                                else
                                {
                                    dx = (WidthImage - w) / 2;
                                }
                                
                                RectangleF rf = new RectangleF(xi + dx, yi + dy, w, h);
                                g.DrawImage(im, rf);
                                this.refs.Add(new ReferenceData(new RectangleF(rf.Location, rf.Size), ir.Image, ReferenceType.Image));
                                xi += WidthImage + DividerImage;
                                if (xi + WidthImage + DividerImage > Width)
                                {
                                    xi = x_name;
                                    yi += HeightImage + DividerImage;
                                }
                            }
                            
                            break;
                    }
                }
            }
        }
        
        internal class ReferenceData
        {
            private RectangleF rect;
            private object obj;
            private ReferenceType type;
            
            public ReferenceData(RectangleF r, object o, ReferenceType type)
            {
                this.rect = r;
                this.obj = o;
                this.type = type;
            }
            
            public RectangleF Rect
            {
                get { return this.rect; }
            }
            
            public object Obj
            {
                get { return this.obj; }
            }
            
            public ReferenceType RefType
            {
                get { return this.type; }
            }
        }
    }
}
