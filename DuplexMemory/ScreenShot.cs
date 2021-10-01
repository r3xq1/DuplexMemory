namespace DuplexMemory
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Forms;

    public static class ScreenShot
    {
        /// <summary>
        /// Метод для получения скриншота всего экрана в памяти
        /// </summary>
        /// <returns></returns>
        public static byte[] GetData()
        {
            try
            {
                int width = Screen.PrimaryScreen.Bounds.Width, height = Screen.PrimaryScreen.Bounds.Height;
                using var bitmap = new Bitmap(width, height);
                using var graph = Graphics.FromImage(bitmap);
                graph.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                using var memoryStream = new MemoryStream { Position = 0 };
                graph.InterpolationMode = InterpolationMode.Bicubic;
                graph.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                graph.SmoothingMode = SmoothingMode.HighSpeed;
                bitmap.Save(memoryStream, ImageFormat.Png);
                return memoryStream?.ToArray() ?? memoryStream.GetBuffer() ?? null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
