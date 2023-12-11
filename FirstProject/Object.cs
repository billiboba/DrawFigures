using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Practic
{
    public abstract class Object
    {
        public int x { get; set; }
        public int y { get; set; }
        public abstract void DrawFigures(Bitmap bitmap);

    }

    public class Point : Object
    {
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override void DrawFigures(Bitmap bitmap)
        {
            if ((x >= 0 && x <= bitmap.Width) && (y >= 0 && y <= bitmap.Height))
            {
                bitmap.SetPixel(x, y, Color.Aqua);
            }
        }
    }

    public class Rect : Point
    {
        private int x1 { get; set; }
        private int y1 { get; set; }
        public Rect(int x, int y, int x1, int y1) : base(x, y)
        {
            this.x1 = x1;
            this.y1 = y1;
        }
        public override void DrawFigures(Bitmap bitmap)
        {
            Graphics g = Graphics.FromImage(bitmap);
            if (((x >= 0 && x <= bitmap.Width) && (x1 >= 0 && x1 <= bitmap.Width)) && ((y >= 0 && y <= bitmap.Height) && (y1 >= 0 && y1 <= bitmap.Height)))
            {
                g.DrawRectangle(Pens.Aqua, x, y, x1, y1);
            }
        }
    }

    public class HLine : Point
    {
        private int length { get; set; }
        public HLine(int x, int y, int length) : base(x, y)
        {
            this.length = length;
        }
        public override void DrawFigures(Bitmap bitmap)
        {
            Graphics g = Graphics.FromImage(bitmap);
            if ((x >= 0 && x <= bitmap.Width) && (y >= 0 && y <= bitmap.Height) && (length >= 0 && length <= bitmap.Width))
            {
                g.DrawLine(Pens.Aqua, x, y, length, y);
            }
        }
    }

    public class VLine : Point
    {
        private int length { get; set; }
        public VLine(int x, int y, int length) : base(x, y)
        {
            this.length = length;
        }
        public override void DrawFigures(Bitmap bitmap)
        {
            Graphics g = Graphics.FromImage(bitmap);
            if ((x >= 0 && x <= bitmap.Width) && (y >= 0 && y <= bitmap.Height) && (length >= 0 && length <= bitmap.Height))
            {
                g.DrawLine(Pens.Aqua, x, y, x, length);
            }
        }
    }
 
}
