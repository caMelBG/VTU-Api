using ImageAPI.Interfaces;
using System.Drawing;

namespace ImageAPI.Resizer.Strategies
{
    internal class KeepAspectStrategy : IResizeStrategy
    {
        public void Process(string sourceFile, string destinationFile, int width, int height, int startX, int startY)
        {
            using (var sourceImage = Image.FromFile(sourceFile) as Bitmap)
            {
                int sourceWidth = sourceImage.Width;
                int sourceHeight = sourceImage.Height;
                float sourceAspect = sourceWidth / sourceHeight;
                float destinationAspect = width / height;
                if (sourceAspect == destinationAspect)
                {
                    using (var targetImage = new Bitmap(width, height))
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
}
