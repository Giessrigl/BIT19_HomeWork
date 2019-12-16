namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public struct Position
    {
        public readonly int Left;

        public readonly int Top;

        public Position(int left, int top)
        {
            this.Left = left;
            this.Top = top;
        }
    }
}
