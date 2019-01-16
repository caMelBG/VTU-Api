using ImageAPI.Enums;

namespace ImageAPI.Interfaces
{
    public interface IResizeStrategyCreator
    {
        IResizeStrategy GetStrategy(ResizeType resizeType);
    }
}
