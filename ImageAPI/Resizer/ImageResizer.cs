﻿using ImageAPI.Enums;
using ImageAPI.Interfaces;

namespace ImageAPI.Resizer
{
    public class ImageResizer : IResizer
    {
        private IResizeStrategyCreator _resizeStretegyCreator;

        public ImageResizer(IResizeStrategyCreator resizeStrategyCreator)
        {
            _resizeStretegyCreator = resizeStrategyCreator;
        }

        public void Resize(string sourceFile, string destinationFile, ResizeType type, int width, int height, int startX, int startY)
        {
            var resizer = _resizeStretegyCreator.GetStrategy(type);

            resizer.Process(sourceFile, destinationFile, width, height, startX, startY);

            throw new System.NotImplementedException();
        }
    }
}
