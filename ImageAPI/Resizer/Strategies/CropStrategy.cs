using ImageAPI.Interfaces;

namespace ImageAPI.Resizer.Strategies
{
    public class CropStrategy : IResizeStrategy
    {
        public void Process(string sourceFile, string destinationFile, int width, int height, int startX, int startY)
        {
            throw new System.NotImplementedException();
        }
    }
}
