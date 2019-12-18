namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class TurtleArguments : IExecutionVisitor, IExecutionVisitable
    {
        public TurtleArguments()
        {
            this.Turtle = new Turtle();
            this.Position = new Position(0, 0);
            this.TurtleSymbol = 'X';
            this.TrackSymbol = '+';
            this.TrackColor = ConsoleColor.White;
            this.Draw = false;
        }

        public Turtle Turtle
        {
            get;
            private set;
        }

        public Position Position
        {
            get;
            set;
        }

        public int TurtleDirection
        {
            get;
            set;
        }

        public char TurtleSymbol
        {
            get;
            set;
        }

        public char TrackSymbol
        {
            get;
            set;
        }

        public ConsoleColor TrackColor
        {
            get;
            set;
        }

        public bool Draw
        {
            get;
            set;
        }

        public void Accept(IExecutionVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Visit(DrawBoard board)
        {
            if (this.Draw == true)
            {
                board.SetTrackChar(this.Position, this.TrackSymbol);
                board.SetColor(this.Position, this.TrackColor);
            }

            Position position;
            if (Position.Top < 0)
            {
                position = new Position(this.Position.Left, 0);
            }
            else if (Position.Top > board.Height)
            {
                position = new Position(this.Position.Left, board.Height);
            }
            else if (Position.Left < 0)
            {
                position = new Position(0, this.Position.Top);
            }
            else if (Position.Left > board.Width)
            {
                position = new Position(board.Width, this.Position.Top);
            }
            else
            {
                position = this.Position;
            }

            this.Position = position;
        }

        public void Visit(TurtleArguments user)
        {

        }
    }
}
