namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class DrawBoard
    {
        public DrawBoard(int width, int height)
        {
            this.boardcontent = new char[width, height];
            this.contentcolors = new ConsoleColor[width, height];
        }

        public int Width
        {
            get
            {
                return this.boardcontent.GetLength(0);
            }
        }

        public int Height
        {
            get
            {
                return this.boardcontent.GetLength(1);
            }
        }

        public char[,] boardcontent;
        public ConsoleColor[,] contentcolors;

        public char GetChar(Position position)
        {
            return this.boardcontent[position.Left, position.Top];
        }

        public void SetChar(Position position, char character)
        {
            this.boardcontent[position.Left, position.Top] = character;
        }
    }
}
