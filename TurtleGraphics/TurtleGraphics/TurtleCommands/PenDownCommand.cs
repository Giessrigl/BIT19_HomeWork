namespace TurtleGraphics.TurtleCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class PenDownCommand : ITurtleCommand
    {
        public void Execute()
        {
            throw new ArgumentNullException();
        }

        public static ITurtleCommand Check(string commandLine)
        {
            if (commandLine == null)
            {
                throw new ArgumentNullException();
            }

            string[] possibleCommands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (possibleCommands.Length == 2)
            {
                if (possibleCommands[1].ToLower() == "pendown")
                {
                    return new PenDownCommand();
                }
                else
                {
                    return null;
                }
            }
            else if (possibleCommands.Length == 3)
            {
                if (possibleCommands[2].ToLower() == "pendown")
                {
                    return new PenDownCommand();
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
            return " ";
        }
    }
}
