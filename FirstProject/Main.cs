using System;
using System.Collections.Generic;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace Practic
{
    public class Scene
    {
        public void CreateBmpImage()
        {
            Bitmap bitmap = new Bitmap(200, 200);

            // Получаем объект Graphics, который позволяет рисовать на изображении
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.FillRectangle(new SolidBrush(Color.Red), 10, 10, 1, 1);
            }
            bitmap.Save("D:\\VisualProects\\Practic\\output.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        }
        public string ReadFromFile(string path)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = Path.Combine(basePath, path);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("файл не найден", path);
            }
            string fileContent = File.ReadAllText(fullPath);

            return fileContent;
        }
    }

    

    public class MainClass
    {
        public static void Main()
        {
            Scene scene = new Scene();
            string text = scene.ReadFromFile("\\FirstProject\\TextFile1.txt");
            Console.WriteLine(text);
            scene.CreateBmpImage();
        }
    }
}
