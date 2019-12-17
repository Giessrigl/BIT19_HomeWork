namespace TurtleGraphics.TurtleCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class RotateCommand : ITurtleCommand
    {
        public int TurtleValue
        {
            get;
            private set;
        }

        public RotateCommand(int turtleValue)
        {
            this.TurtleValue = turtleValue;
        }

        public static ITurtleCommand Parse(string commandLine)
        {
            if (commandLine == null)
            {
                throw new ArgumentNullException();
            }

            string[] possibleCommands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (2 >= possibleCommands.Length)
            {
                return null;
            }

            if (possibleCommands[1].ToLower() == "rotate")
            {
                string turtleValue = possibleCommands[2].ToLower();
                try
                {
                    int value = int.Parse(turtleValue);
                    if (CheckRotationValid(value))
                    {
                        return new RotateCommand(value);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            }
            else if (possibleCommands[2].ToLower() == "rotate")
            {
                string turtleValue = possibleCommands[3].ToLower();

                try
                {
                    int value = int.Parse(turtleValue);
                    if (CheckRotationValid(value))
                    {
                        return new RotateCommand(value);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }

        public string GetValue()
        {
            return this.TurtleValue.ToString();
        }

        private static bool CheckRotationValid(int value)
        {
            switch(value)
            {
                case 0:
                    return true;

                case 90:
                    return true;

                case 180:
                    return true;

                case 270:
                    return true;

                case -90:
                    return true;

                case -180:
                    return true;

                case -270:
                    return true;

                default:
                    return false;
            }
        }

        public void Visit(TurtleArguments args)
        {
            args.TurtleDirection = (args.TurtleDirection + TurtleValue) % 360;
        }

        public void Visit(DrawBoard board)
        {
            // do nothing.
        }
    }
}
