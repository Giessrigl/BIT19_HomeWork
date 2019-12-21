namespace TurtleGraphics.TurtleCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class ChangeTurtleSymbolCommand : ITurtleCommand
    {
        private char TurtleValue;

        public ChangeTurtleSymbolCommand(char turtleValue)
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

            if (possibleCommands.Length == 3 && possibleCommands[2].Length == 1)
            {
                char turtleValue = char.Parse(possibleCommands[2]);
                return new ChangeTurtleSymbolCommand(turtleValue);
            }
            else if (possibleCommands.Length == 4 && possibleCommands[3].Length == 1)
            {
                char turtleValue = char.Parse(possibleCommands[3]);
                return new ChangeTurtleSymbolCommand(turtleValue);
            }
            else
            {
                return null;
            }

        }

        public string GetValue()
        {
            return this.TurtleValue.ToString();
        }

        public void Visit(TurtleAttributes args)
        {
            args.TurtleSymbol = TurtleValue;
        }

        public void Visit(DrawBoard board)
        {
            // do nothing.
        }
    }
}
