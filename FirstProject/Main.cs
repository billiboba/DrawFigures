using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Practic
{
    public class Program
    {
        public class Scene
        {
            public Bitmap CreateBox(string filepath) //Метод для создания поля на котором мы рисуем. Он возвращает наше поле определённых размеров.
            {
                StreamReader sr = new StreamReader(filepath);
                string line;
                int height = 0; int width = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');
                    if (parts.Length > 3)
                    {
                        if (int.TryParse(parts[0], out int x1_) &&
                            int.TryParse(parts[1], out int y1_) &&
                            int.TryParse(parts[2], out int x2_) &&
                            int.TryParse(parts[3], out int y2_))
                        {
                            height = Math.Abs(y2_ - y1_);
                            width = Math.Abs(x2_ - x1_);
                        }
                    }
                }
                Bitmap bitmap = new Bitmap(width, height);
                return bitmap;
            }
            public void CreateBoxWithFigures(string filepath)
            {
                Bitmap bitmap = CreateBox(filepath);
                StreamReader sr = new StreamReader(filepath);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');

                    switch (parts[0])
                    {
                        case "point":
                            int xP = Convert.ToInt32(parts[1]);
                            int yP = Convert.ToInt32(parts[2]);

                            Point point = new Point(xP, yP);
                            point.DrawFigures(bitmap);

                            break;

                        case "rect":
                            int x1R = Convert.ToInt32(parts[1]);
                            int y1R = Convert.ToInt32(parts[2]);
                            int x2R = Convert.ToInt32(parts[3]);
                            int y2R = Convert.ToInt32(parts[4]);


                            int heightR = Math.Abs(y2R - y1R);
                            int widthR = Math.Abs(x2R - x1R);
                            Rect rect = new Rect(x1R, y1R, heightR, widthR);
                            rect.DrawFigures(bitmap);
                            break;

                        case "hline":
                            int startHx = Convert.ToInt32(parts[1]);
                            int startHy = Convert.ToInt32(parts[2]);
                            int endH = Convert.ToInt32(parts[3]);
                            HLine hLine = new HLine(startHx, startHy, endH);
                            hLine.DrawFigures(bitmap);

                            break;

                        case "vline":
                            int startVx = Convert.ToInt32(parts[1]);
                            int startVy = Convert.ToInt32(parts[2]);
                            int endV = Convert.ToInt32(parts[3]);

                            VLine vLine = new VLine(startVx, startVy, endV);
                            vLine.DrawFigures(bitmap);

                            break;
                    }
                }
                string projectDirectory = Directory.GetCurrentDirectory();
                string directoryPath = Path.Combine(projectDirectory, "Images");

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string outputPath = Path.Combine(directoryPath, "output.bmp");
                bitmap.Save(outputPath, ImageFormat.Bmp);
            }
            public static void Main()
            {
                Scene scene = new Scene();
                scene.CreateBoxWithFigures("Text\\TextFile1.txt");
            }
        }
    }
}