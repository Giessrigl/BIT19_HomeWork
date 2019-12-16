namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;

    class Program
    {
        static void Main()
        {
            Overseer overseer = new Overseer();
            overseer.Start();

            // DrawBoard board = new DrawBoard(Console.WindowWidth, Console.WindowHeight);
        }
    }
}
