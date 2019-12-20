namespace TurtleGraphics
{
    using System;
    using System.Collections.Generic;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class DrawBoard : IExecutionVisitable
    {
        public DrawBoard(int width, int height)
        {
            this.boardTracks = new char[width, height];
            this.boardTrackColors = new ConsoleColor[width, height];
            this.TrackPositions = new List<Position>();

            this.BoardTurtles = new List<TurtleArguments>();
        }

        public int Width
        {
            get
            {
                return this.boardTracks.GetLength(0);
            }
        }

        public int Height
        {
            get
            {
                return this.boardTracks.GetLength(1);
            }
        }

        public List<Position> TrackPositions;

        public List<TurtleArguments> BoardTurtles;

        private char[,] boardTracks;

        private ConsoleColor[,] boardTrackColors;

        public char GetTrackChar(Position position)
        {
            return this.boardTracks[position.Left, position.Top];
        }

        public void SetTrackChar(Position position, char character)
        {
            if (character == '\0')
            {
                throw new ArgumentNullException();
            }

            this.boardTracks[position.Left, position.Top] = character;

            if (!(TrackPositions.Contains(position)))
            {
                TrackPositions.Add(position);
            }
        }

        public ConsoleColor GetTrackColor(Position position)
        {
            return this.boardTrackColors[position.Left, position.Top];
        }

        public void SetTrackColor(Position position, ConsoleColor color)
        {
            this.boardTrackColors[position.Left, position.Top] = color;
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
