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

            switch (turtleCommand.ToLower())
            {
                case "turtlegraphics.turtlecommands.movecommand":
                    this.TurtleCommand = "Move";
                    break;

                case "turtlegraphics.turtlecommands.rotatecommand":
                    this.TurtleCommand = "Rotate";
                    break;

                case "turtlegraphics.turtlecommands.sleepcommand":
                    this.TurtleCommand = "Sleep";
                    break;

                case "turtlegraphics.turtlecommands.penupcommand":
                    this.TurtleCommand = "PenUp";
                    break;

                case "turtlegraphics.turtlecommands.pendowncommand":
                    this.TurtleCommand = "PenDown";
                    break;

                case "turtlegraphics.turtlecommands.changecolorcommand":
                    this.TurtleCommand = "ChangeColor";
                    break;

                case "turtlegraphics.turtlecommands.changetracksymbolcommand":
                    this.TurtleCommand = "ChangeTrackSymbol";
                    break;

                case "turtlegraphics.turtlecommands.changeturtlesymbolcommand":
                    this.TurtleCommand = "ChangeTurtleSymbol";
                    break;

                default:
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
