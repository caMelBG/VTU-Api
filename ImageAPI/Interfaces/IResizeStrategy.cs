namespace ImageAPI.Interfaces
{
    public interface IResizeStrategy
    {
        void Process(string sourceFile, string destinationFile, int width, int height, int startX, int startY);
    }
}
