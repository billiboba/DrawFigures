using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Practic
{
    public class Object
    {
        public int x;
        public int y;
        public Color color;
    }

    public class Point : Object
    {
        public int X;
        public int Y;
        public Point(int x,int y)
        {
            X=x; Y=y;   
        }
    }
    

    //public class Rect : Point 
    //{

    //}

    //public class HLine : Point
    //{

    //}

    //public class VLine : Point
    //{

    //}
}
