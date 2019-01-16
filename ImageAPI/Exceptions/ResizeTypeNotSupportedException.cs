using System;

namespace ImageAPI.Exceptions
{
    public class ResizeTypeNotSupportedException : ArgumentException
    {
        public ResizeTypeNotSupportedException()
        {
        }

        public ResizeTypeNotSupportedException(string message) : base(message)
        {
        }
    }
}
