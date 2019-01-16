using ImageAPI.Interfaces;
using System.Drawing;

namespace ImageAPI.Resizer.Strategies
{
    internal class SkewStrategy : IResizeStrategy
    {
        public void Process(string sourceFile, string destinationFile, int width, int height, int startX, int startY)
        {
            using (var sourceImage = Image.FromFile(sourceFile) as Bitmap)
            {
                using (var targetImage = new Bitmap(width, width))
                {
                    using (var graphics = Graphics.FromImage(targetImage))
                    {
                        var destRectangle = new Rectangle(0, 0, targetImage.Width, targetImage.Height);
                        var srcRectangle = new Rectangle(0, 0, sourceImage.Width, sourceImage.Height);
                        graphics.DrawImage(sourceImage, destRectangle, srcRectangle, GraphicsUnit.Pixel);
                        targetImage.Save(destinationFile);
                    }
                }
            }
        }
    }
}
