﻿namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class DrawBoard : IExecutionVisitable
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

        public char[,] boardcontent
        {
            get;
            private set;
        }
        public ConsoleColor[,] contentcolors
        {
            get;
            private set;
        }

        public char GetChar(Position position)
        {
            return this.boardcontent[position.Left, position.Top];
        }

        public void SetChar(Position position, char character)
        {
            if (character == '\0')
            {
                throw new ArgumentNullException();
            }

            this.boardcontent[position.Left, position.Top] = character;
        }

        public ConsoleColor GetColor(Position position)
        {
            return this.contentcolors[position.Left, position.Top];
        }

        public void SetColor(Position position, ConsoleColor color)
        {
            this.contentcolors[position.Left, position.Top] = color;
        }

        public void Accept(IExecutionVisitor visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException();
            }

            visitor.Visit(this);
        }
    }
}