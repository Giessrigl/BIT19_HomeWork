

namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class ConsoleRelatedOptions
    {
        public void SetConsoleWindow(int width, int height)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
        }

        public int GetBiggerSize()
        {
            int biggerSize;

            if (Console.WindowWidth > Console.WindowHeight)
            {
                biggerSize = Console.WindowWidth;
            }
            else if (Console.WindowWidth < Console.WindowHeight)
            {
                biggerSize = Console.WindowHeight;
            }
            else
            {
                biggerSize = Console.WindowHeight;
            }

            return biggerSize;
        }
    }
}
