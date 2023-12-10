using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Practic
{
    public class Main
    {
        public Scene(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            graphics = Graphics.FromImage(bitmap);
        }
        public void Main()
        {
            Scene scene = new Scene(800, 600);
            scene.Save("scene.png");
        }

    }
}
