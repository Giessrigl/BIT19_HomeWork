namespace TurtleGraphics.TurtleCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class PenUpCommand : ITurtleCommand
    {
        public static ITurtleCommand Parse(string commandLine)
        {
            if (commandLine == null)
            {
                throw new ArgumentNullException();
            }

            string[] possibleCommands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            if (possibleCommands.Length == 2)
            {
                if (possibleCommands[1].ToLower() == "penup")
                {
                    return new PenUpCommand();
                }
                else
                {
                    return null;
                }
            }
            else if (possibleCommands.Length == 3)
            {
                if (possibleCommands[2].ToLower() == "penup")
                {
                    return new PenUpCommand();
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
            return string.Empty;
        }

        public void Visit(TurtleAttributes args)
        {
            args.Draw = false;
        }

        public void Visit(DrawBoard board)
        {
            // do nothing.
        }
    }
}
