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
    internal class BitmapEditor : IDisposable
    {
        internal Bitmap bitmap { get; private set; } = null;
        internal BitmapData bitmapData { get; private set; } = null;
        private byte[] Pixels;
        private IntPtr Iptr = IntPtr.Zero;
        private int Depth;
        private int Width;
        private int Height;

        public BitmapEditor(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            Width = bitmap.Width;
            Height = bitmap.Height;

            bitmapData = bitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            Pixels = new byte[Width * Height * 3];
            Iptr = bitmapData.Scan0;
            Marshal.Copy(Iptr, Pixels, 0, Pixels.Length);
        }
        public void SetPixel(int x,int y, byte red, byte green, byte blue)
        {
            int i = ((y * Width) + x) * 3;
            Pixels[i] = blue;
            Pixels[i + 1] = green;
            Pixels[i + 2] = red;           
        }
        public void Dispose()
        {
            Marshal.Copy(Pixels, 0, Iptr, Pixels.Length);
            bitmap.UnlockBits(bitmapData);
            GC.SuppressFinalize(this);
        }
    }
}
