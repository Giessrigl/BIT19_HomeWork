

namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class WindowSettings
    {
        public void SetWindow(int width, int height)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
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
