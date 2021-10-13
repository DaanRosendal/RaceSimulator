using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Color = System.Drawing.Color;

namespace WPF
{
    public static class BitmapImages
    {
        private static Dictionary<string, Bitmap> _cache = new();

        public static Bitmap AddImageToCache(string url)
        {
            if (_cache.TryGetValue(url, out var b))
            {
                return b;
            }
            
            var bitmap = new Bitmap(url);
            _cache.Add(url, bitmap);
            return bitmap;
        }
        
        public static void ClearCache()
        {
            _cache.Clear();
        }

        public static Bitmap GetEmptyBitmap(int width, int height)
        {
            if(_cache.TryGetValue("empty", out var bitmap))
            {
                return bitmap;
            }
            
            var emptyBitmap = new Bitmap(width, height);
            var g = Graphics.FromImage(emptyBitmap);
            g.Clear(Color.White);
            _cache.Add("empty", emptyBitmap);

            var emptyBitmapClone = emptyBitmap.Clone(new Rectangle(0,0,emptyBitmap.Width,emptyBitmap.Height), emptyBitmap.PixelFormat);
            return emptyBitmapClone;
        }
        
        public static BitmapSource CreateBitmapSourceFromGdiBitmap(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException(nameof(bitmap));

            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            var bitmapData = bitmap.LockBits(
                rect,
                ImageLockMode.ReadWrite,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            try
            {
                var size = rect.Width * rect.Height * 4;

                return BitmapSource.Create(
                    bitmap.Width,
                    bitmap.Height,
                    bitmap.HorizontalResolution,
                    bitmap.VerticalResolution,
                    PixelFormats.Bgra32,
                    null,
                    bitmapData.Scan0,
                    size,
                    bitmapData.Stride);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
        }
    }
}