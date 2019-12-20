namespace TurtleGraphics.TurtleCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;
    using System.Threading;

    public class MoveCommand : ITurtleCommand
    {
        private int turtleValue;

        public MoveCommand(int turtleValue)
        {
            this.turtleValue = turtleValue;
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

            if (possibleCommands.Length == 3 && possibleCommands[1].ToLower() == "move")
            {
                string turtleValue = possibleCommands[2];
                if (int.TryParse(turtleValue, out int result))
                {
                    if (result > 0)
                    {
                        return new MoveCommand(result);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else if (possibleCommands.Length == 4 && possibleCommands[2].ToLower() == "move")
            {
                string turtleValue = possibleCommands[3];
                if (int.TryParse(turtleValue, out int result))
                {
                    if (result > 0)
                    {
                        return new MoveCommand(result);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        public string GetValue()
        {
            return this.turtleValue.ToString();
        }

        public void Visit(TurtleArguments args)
        {
            Position position = args.Position;
            switch(args.TurtleDirection)
            {
                case 0:
                    position.Left++;
                    break;
                case 90:
                    position.Top++;
                    break;
                case 180:
                    position.Left--;
                    break;
                case 270:
                    position.Top--;
                    break;

            }
            args.Position = position;

            if ((turtleValue) != 0)
            {
                args.Turtle.Commands.Insert(1, new MoveCommand(turtleValue - 1));
            }
            Thread.Sleep(1000);
        }

        public void Visit(DrawBoard board)
        {
            // do nothing.
        }
    }
}
