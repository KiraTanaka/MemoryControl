using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MemoryControl
{
    public class BitmapEditor : IDisposable
    {
        public Bitmap bitmap { get; private set; } = null;
        public BitmapData bitmapData { get; private set; } = null;
        public byte[] Pixels { get; set; }
        IntPtr Iptr = IntPtr.Zero;
        public int Depth { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public BitmapEditor(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            Width = bitmap.Width;
            Height = bitmap.Height;
            int PixelCount = Width * Height;
            
            Depth = Bitmap.GetPixelFormatSize(bitmap.PixelFormat);
            bitmapData = bitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite,
                                         bitmap.PixelFormat);
            Pixels = new byte[PixelCount * Depth / 8];
            Iptr = bitmapData.Scan0;

            // Copy data from pointer to array
            Marshal.Copy(Iptr, Pixels, 0, Pixels.Length);
        }
        public void SetPixel(int x,int y, byte r, byte g, byte b)
        {
            int i = ((y * Width) + x) * Depth / 8;
            Pixels[i] = b;
            Pixels[i + 1] = g;
            Pixels[i + 2] = r;           
        }
        public void Dispose()
        {
            Marshal.Copy(Pixels, 0, Iptr, Pixels.Length);
            bitmap.UnlockBits(bitmapData);
            GC.SuppressFinalize(this);
        }
    }
}
