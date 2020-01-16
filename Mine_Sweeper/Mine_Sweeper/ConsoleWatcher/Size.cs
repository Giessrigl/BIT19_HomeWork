using System;

namespace Mine_Sweeper.ConsoleWatcher
{
    public class Size
    {
        public Size(int width, int height)
        {
            if (width < 10)
            {
                throw new ArgumentOutOfRangeException($"The console width cannot be less than 10");
            }
            if (height < 10)
            {
                throw new ArgumentOutOfRangeException($"The console height cannot be less than 10");
            }

            Width = width;
            Height = height;
        }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}