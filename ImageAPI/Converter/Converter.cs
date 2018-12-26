using ImageAPI.Enums;
using ImageAPI.Interfaces;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageAPI.Converter
{
    public class Converter : IConverter
    {
        public void Convert(string sourceFile, string destinationFile, ImageType type)
        {
            //TODO validate

            var imageFormat = this.ParseImageType(type);
            using (var image = Image.FromFile(sourceFile))
            {
                image.Save(destinationFile, imageFormat);
            }
        }

        private ImageFormat ParseImageType(ImageType type)
        {
            switch (type)
            {
                case ImageType.Gif:
                    return ImageFormat.Gif;
                case ImageType.Png:
                    return ImageFormat.Png;
                case ImageType.Jpg:
                    return ImageFormat.Jpeg;
            }

            //TODO
            throw new Exception();
        }
    }
}
