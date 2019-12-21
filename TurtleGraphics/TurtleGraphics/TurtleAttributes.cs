namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class TurtleAttributes : IExecutionVisitor, IExecutionVisitable
    {
        public TurtleAttributes()
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

        private int turtleDirection;
        public int TurtleDirection
        {
            get
            {
                return this.turtleDirection;
            }
            set
            {
                switch(value)
                {
                    case 0:
                        this.turtleDirection = value;
                        break;
                    case 90:
                        this.turtleDirection = value;
                        break;
                    case 180:
                        this.turtleDirection = value;
                        break;
                    case 270:
                        this.turtleDirection = value;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
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
            Position position = this.Position;

            if (this.Position.Top < 0)
            {
                position = new Position(this.Position.Left, 0);
                if (int.TryParse(this.Turtle.Commands[0].GetValue(), out int value))
                {
                    if (value > 1)
                    {
                        this.Turtle.Commands.RemoveAt(0);
                    }
                }
            }
            else if (this.Position.Top > board.Height)
            {
                position = new Position(this.Position.Left, board.Height);
                if (int.TryParse(this.Turtle.Commands[0].GetValue(), out int value))
                {
                    if (value > 1)
                    {
                        this.Turtle.Commands.RemoveAt(0);
                    }
                }
            }
            else if (this.Position.Left < 0)
            {
                position = new Position(0, this.Position.Top);
                if (int.TryParse(this.Turtle.Commands[0].GetValue(), out int value))
                {
                    if (value > 1)
                    {
                        this.Turtle.Commands.RemoveAt(0);
                    }
                }
            }
            else if (this.Position.Left > board.Width)
            {
                position = new Position(board.Width, this.Position.Top);
                if (int.TryParse(this.Turtle.Commands[0].GetValue(), out int value))
                {
                    if (value > 1)
                    {
                        this.Turtle.Commands.RemoveAt(0);
                    }
                }
            }
            this.Position = position;

            // Stamp the current track
            if (this.Draw == true) 
            {
                board.SetTrackChar(this.Position, this.TrackSymbol);
                board.SetTrackColor(this.Position, this.TrackColor);
            }

            if (!(board.Turtles.Contains(this)))
            {
                board.Turtles.Add(this);
            }
        }

        public void Visit(TurtleAttributes user)
        {

        }
    }
}
