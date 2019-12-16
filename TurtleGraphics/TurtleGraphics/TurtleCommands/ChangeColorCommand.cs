namespace TurtleGraphics.TurtleCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class ChangeColorCommand : ITurtleCommand
    {
        private static ConsoleColor TurtleValue;

        public void Execute()
        {
            throw new ArgumentNullException();   
        }

        public ChangeColorCommand(ConsoleColor color)
        {
            TurtleValue = color;
        }

        public static ITurtleCommand Check(string commandLine)
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
                // check possibleCommands[2] on color!
                ConsoleColor turtleValue = ConsoleColor.Red;
                return new ChangeColorCommand(turtleValue);
            }
            else if (possibleCommands[2].ToLower() == "changecolor")
            {
                // check possibleCommands[3] on color!
                ConsoleColor turtleValue = ConsoleColor.Red;
                return new ChangeColorCommand(turtleValue);
            }

            return null;
        }

        public string GetValue()
        {
            return TurtleValue.ToString();
        }
    }
}
