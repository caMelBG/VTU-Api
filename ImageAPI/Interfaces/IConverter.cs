using ImageAPI.Enums;

namespace ImageAPI.Interfaces
{
    public interface IConverter
    {
        void Convert(string sourceFile, string destinationFile, ImageType type);
    }
}
