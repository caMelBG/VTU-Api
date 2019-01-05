using System;

namespace ImageAPI.Exceptions
{
    public class ImageFormatNotSupportedException : ArgumentException
    {
        public ImageFormatNotSupportedException()
        {
        }

        public ImageFormatNotSupportedException(string message) : base(message)
        {
        }
    }
}
