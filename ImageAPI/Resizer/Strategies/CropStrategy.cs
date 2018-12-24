using ImageAPI.Interfaces;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageAPI.Resizer.Strategies
{
    public class CropStrategy : IResizeStrategy
    {
        public void Process(string sourceFile, string destinationFile, int width, int height, int startX, int startY)
        {
            Bitmap srcImg = Image.FromFile(sourceFile) as Bitmap;
            ImageFormat imgFormat = srcImg.RawFormat;

            Rectangle destRect = new Rectangle(startX, startY, width, height);

            Bitmap bmp = new Bitmap(destRect.Width, destRect.Height, PixelFormat.Format24bppRgb);
            Rectangle srcRect = new Rectangle(0, 0, destRect.Width, destRect.Height);

            //int srcWidth, srcHeight;
            float srcRatio = width / height;
            if (startX < 0 || (startX + width) > srcImg.Width || startY < 0 || (startY + height) > srcImg.Height)
            {
                //throw new CropOutOfRange("Selected area is out of destination image range.");
            }
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            gfx.DrawImage(srcImg, srcRect, destRect, GraphicsUnit.Pixel);

            // Image destImage = bmp.Clone(destRect, bmp.PixelFormat);
            bmp.Save(destinationFile, System.Drawing.Imaging.ImageFormat.Jpeg);
            srcImg.Dispose();
            bmp.Dispose();
            gfx.Dispose();
        }
    }
}
