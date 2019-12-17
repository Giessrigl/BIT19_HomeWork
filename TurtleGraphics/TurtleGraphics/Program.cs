namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;

    class Program
    {
        static void Main()
        {
            Editor overseer = new Editor();
            overseer.Start();

            // DrawBoard board = new DrawBoard(Console.WindowWidth, Console.WindowHeight);
        }
    }
}
