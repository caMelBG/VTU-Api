using ImageAPI.Enums;
using ImageAPI.Exceptions;
using ImageAPI.Interfaces;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageAPI.Converter
{
    public class Converter : IConverter
    {
        public void Convert(string sourceFile, string destinationFile, ImageType type)
        {
            if (string.IsNullOrEmpty(sourceFile))
            {
                throw new ArgumentNullException(nameof(sourceFile));
            }
            else if (string.IsNullOrEmpty(destinationFile))
            {
                throw new ArgumentNullException(nameof(destinationFile));
            }
            else if (Directory.Exists(Path.GetDirectoryName(sourceFile)) == false)
            {
                throw new DirectoryNotFoundException(Path.GetDirectoryName(sourceFile));
            }
            else if (Directory.Exists(Path.GetDirectoryName(destinationFile)) == false)
            {
                throw new DirectoryNotFoundException(Path.GetDirectoryName(destinationFile));
            }
            else if (File.Exists(sourceFile) == false)
            {
                throw new FileNotFoundException($"No file found with name {Path.GetFileName(sourceFile)}.");
            }

            try
            {
                var imageFormat = this.ParseImageType(type);
                using (var image = Image.FromFile(sourceFile))
                {
                    image.Save(destinationFile, imageFormat);
                }

            }
            catch (Exception ex)
            {
                throw ex;
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
            
            throw new ImageFormatNotSupportedException($"Image type {type} is not supported.");
        }
    }
}
