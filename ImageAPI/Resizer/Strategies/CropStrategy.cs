using ImageAPI.Interfaces;
using System.Drawing;

namespace ImageAPI.Resizer.Strategies
{
    public class CropStrategy : IResizeStrategy
    {
        public void Process(string sourceFile, string destinationFile, int width, int height, int startX, int startY)
        {
            var point = new Point(startX, startY);
            var size = new Size(width, height);
            var srcRect = new Rectangle(point, size);
            var sourceImage = Image.FromFile(sourceFile) as Bitmap;
            var destinationImage = new Bitmap(srcRect.Width, srcRect.Height);

            using (var graphics = Graphics.FromImage(destinationImage))
            {
                var destRect = new Rectangle(0, 0, destinationImage.Width, destinationImage.Height);
                graphics.DrawImage(sourceImage, destRect, srcRect, GraphicsUnit.Pixel);
            }
        }
    }
}
