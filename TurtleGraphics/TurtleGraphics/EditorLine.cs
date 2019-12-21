namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class EditorLine
    {
        public EditorLine(string turtleCommand, string turtleValue)
        {
            if (turtleCommand == null)
            {
                throw new ArgumentNullException();
            }

            if (turtleValue == null)
            {
                throw new ArgumentNullException();
            }

            if (turtleCommand.ToString().Contains("MoveCommand"))
            {
                this.TurtleCommand = "Move";
            }
            else if (turtleCommand.ToString().Contains("RotateCommand"))
            {
                this.TurtleCommand = "Rotate";
            }
            else if (turtleCommand.ToString().Contains("SleepCommand"))
            {
                this.TurtleCommand = "Sleep";
            }
            else if (turtleCommand.ToString().Contains("PenUpCommand"))
            {
                this.TurtleCommand = "PenUp";
            }
            else if (turtleCommand.ToString().Contains("PenDownCommand"))
            {
                this.TurtleCommand = "PenDown";
            }
            else if (turtleCommand.ToString().Contains("ChangeColorCommand"))
            {
                this.TurtleCommand = "ChangeColor";
            }
            else if (turtleCommand.ToString().Contains("ChangeTrackSymbolCommand"))
            {
                this.TurtleCommand = "ChangeTrackSymbol";
            }
            else if (turtleCommand.ToString().Contains("ChangeTurtleSymbolCommand"))
            {
                this.TurtleCommand = "ChangeTurtleSymbol";
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            this.TurtleValue = turtleValue;
        }

        public string TurtleCommand
        {
            get;
            private set;
        }

        public string TurtleValue
        {
            get;
            private set;
        }
    }
}
