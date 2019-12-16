namespace TurtleGraphics
{
    using System;

    public class TurtleArguments
    {
        public TurtleArguments()
        {
            this.Turtle = new Turtle();
            this.Position = new Position(0, 0);
            this.TurtleSymbol = 'X';
            this.TrackSymbol = '+';
            this.TrackColor = ConsoleColor.White;
            this.Draw = false;
            this.SleepTime = 1000;
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

        public int SleepTime
        {
            get;
            set;
        }
    }
}
