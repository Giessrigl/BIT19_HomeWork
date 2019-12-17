namespace TurtleGraphics.TurtleCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class ChangeColorCommand : ITurtleCommand
    {
        private static ConsoleColor TurtleValue;

        public ChangeColorCommand(ConsoleColor color)
        {
            TurtleValue = color;
        }

        public static ITurtleCommand Parse(string commandLine)
        {
            if (commandLine == null)
            {
                throw new ArgumentNullException();
            }

            string[] possibleCommands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if(2 >= possibleCommands.Length)
            {
                return null;
            }

            if (possibleCommands[1].ToLower() == "changecolor")
            {
                string value = possibleCommands[2][0].ToString().ToUpper();
                value += possibleCommands[2].ToString().Substring(1).ToLower();
                ConsoleColor color;
                if (Enum.TryParse<ConsoleColor>(value, out color))
                {
                    return new ChangeColorCommand(color);
                }
                else
                {
                    return null;
                }
            }
            else if (possibleCommands[2].ToLower() == "changecolor")
            {
                string value = possibleCommands[2][0].ToString().ToUpper();
                value += possibleCommands[2].ToString().Substring(1).ToLower();
                ConsoleColor color;
                if (Enum.TryParse<ConsoleColor>(value, out color))
                {
                    return new ChangeColorCommand(color);
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
            return TurtleValue.ToString();
        }

        public void Visit(TurtleArguments args)
        {
            args.TrackColor = TurtleValue;
        }

        public void Visit(DrawBoard board)
        {
            // do nothing.
        }
    }
}
