using ImageAPI.Enums;
using ImageAPI.Exceptions;
using ImageAPI.Interfaces;

namespace ImageAPI.Resizer.Strategies
{
    public class ResizeStrategyCreator : IResizeStrategyCreator
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

            throw new ResizeTypeNotSupportedException($"Resize type {resizeType} is not supported.");
        }
    }
}
