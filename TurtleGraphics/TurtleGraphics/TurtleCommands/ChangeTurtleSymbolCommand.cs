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

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public static ITurtleCommand Check(string commandLine)
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
                return new ChangeTrackSymbolCommand(turtleValue);
            }
            else if (possibleCommands.Length == 4 && possibleCommands[3].Length == 1)
            {
                char turtleValue = char.Parse(possibleCommands[3]);
                return new ChangeTrackSymbolCommand(turtleValue);
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
    }
}
