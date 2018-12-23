using ImageAPI.Enums;
using ImageAPI.Interfaces;

namespace ImageAPI.Resizer.Strategies
{
    public class ImageResizeStrategyCreator : IResizeStrategyCreator
    {
        public IResizeStrategy GetStrategy(ResizeType resizeType)
        {
            switch (resizeType)
            {
                case ResizeType.Skew:
                    return new SkewStrategy();
                case ResizeType.KeepAspect:
                    return new KeepAspectStrategy();
                case ResizeType.Crop:
                    return new CropStrategy();
            }

            //TODO
            throw new System.Exception();
        }
    }
}
