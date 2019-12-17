namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public struct Position
    {
        public int Left
        {
            get;
            set;
        }

        public int Top
        {
            get;
            set;
        }

        public Position(int left, int top)
        {
            this.Left = left;
            this.Top = top;
        }
    }
}
