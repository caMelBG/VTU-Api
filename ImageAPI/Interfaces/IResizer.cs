using ImageAPI.Enums;

namespace ImageAPI.Interfaces
{
    public interface IResizer
    {
        void Resize(string sourceFile, string destinationFile, ResizeType type, int width, int height, int startX, int startY);
    }
}
