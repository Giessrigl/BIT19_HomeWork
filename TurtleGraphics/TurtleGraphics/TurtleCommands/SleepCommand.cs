namespace TurtleGraphics.TurtleCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;
    using System.Threading;

    public class SleepCommand : ITurtleCommand
    {
        private int TurtleValue;

        public SleepCommand(int turtleValue)
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

            if (3 > possibleCommands.Length)
            {
                return null;
            }

            if (possibleCommands.Length == 3 && possibleCommands[1].ToLower() == "sleep")
            {
                string turtleValue = possibleCommands[2];

                if (int.TryParse(turtleValue, out int value))
                {
                    if (!(100 > value || value > 10000))
                    {
                        return new SleepCommand(value);
                    }
                }

                return null;
            }
            else if (possibleCommands.Length == 4 && possibleCommands[2].ToLower() == "sleep")
            {
                string turtleValue = possibleCommands[3];

                if (int.TryParse(turtleValue, out int value))
                {
                    if (!(100 > value || value > 10000))
                    {
                        return new SleepCommand(value);
                    }
                }

                return null;
            }

            return null;
        }

        public string GetValue()
        {
            return this.TurtleValue.ToString();
        }

        public void Visit(TurtleAttributes args)
        {
            Thread.Sleep(this.TurtleValue);
        }

        public void Visit(DrawBoard board)
        {
            // do nothing.
        }
    }
}
