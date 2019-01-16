using ImageAPI.Interfaces;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImageAPI.Resizer.Strategies
{
    internal class CropStrategy : IResizeStrategy
    {
        public void Process(string sourceFile, string destinationFile, int width, int height, int startX, int startY)
        {
            using (var sourceImage = Image.FromFile(sourceFile) as Bitmap)
            {
                var imageFormat = sourceImage.RawFormat;
                var destRectangle = new Rectangle(startX, startY, width, height);
                using (var bitmap = new Bitmap(destRectangle.Width, destRectangle.Height, PixelFormat.Format24bppRgb))
                {
                    var srcRectangle = new Rectangle(0, 0, destRectangle.Width, destRectangle.Height);
                    using (var graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        graphics.DrawImage(sourceImage, srcRectangle, destRectangle, GraphicsUnit.Pixel);

                        bitmap.Save(destinationFile);
                    }
                }
            }
        }
    }
}
