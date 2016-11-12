using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Design;
using System.IO;

namespace MemoryControl
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer();

            /* using (timer.StartTimer())
             {
                 // do things
             }

             Console.WriteLine(timer.ElapsedMilliseconds);*/

            var bitmap = (Bitmap)Bitmap.FromFile("C:\\image.bmp");
            using (timer.StartTimer())
            {
                for (var x = 0; x < bitmap.Width; x++)
                    for (var y = 0; y < bitmap.Height; y++)
                        bitmap.SetPixel(x, y, Color.Red);
            }
            Console.WriteLine(timer.ElapsedMilliseconds);
            using (timer.StartTimer())
            {
                using (var bitmapEditor = new BitmapEditor(bitmap))
                {
                    for (var x = 0; x < bitmap.Width;x++)
                        for (var y = 0; y < bitmap.Height; y++)
                            bitmapEditor.SetPixel(x, y, 255, 255, 255);
                }
            }
            Console.WriteLine(timer.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
