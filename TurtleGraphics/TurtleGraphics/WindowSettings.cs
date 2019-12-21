

namespace TurtleGraphics
{
    using System;

    public class WindowSettings
    {
        public void SetWindowToMax()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        }

        public int GetWindowHeight()
        {
            return Console.WindowHeight;
        }

        public int GetWindowWidth()
        {
            return Console.WindowWidth;
        }
    }
}
