namespace TurtleGraphics.EditorCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;
    public class InsertCommand : IEditorCommand
    {
        private static string TurtleValue;

        private int EditorValue;

        public InsertCommand(int editorValue, ITurtleCommand turtleCommand)
        {
            if (editorValue < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.EditorValue = editorValue;
            this.turtleCommand = turtleCommand;
        }

        public ITurtleCommand turtleCommand
        {
            get;
            private set;
        }

        public static IEditorCommand Parse(string commandLine)
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

            string value = possibleCommands[1];
            int editorValue;

            try
            {
                editorValue = int.Parse(value);
            }
            catch
            {
                return null;
            }

            string[] newpossibleCommands = new string[possibleCommands.Length - 1];
            newpossibleCommands[0] = possibleCommands[0];

            if (newpossibleCommands.Length == 2)
            {
                newpossibleCommands[1] = possibleCommands[2];
            }
            else if (newpossibleCommands.Length == 3)
            {
                newpossibleCommands[1] = possibleCommands[2];
                newpossibleCommands[2] = possibleCommands[3];
            }

            commandLine = string.Join(" ", newpossibleCommands);
            string command = newpossibleCommands[1].ToLower();
            ITurtleCommand turtleCommand = null;

            switch (command)
            {
                case "move":
                    turtleCommand = MoveCommand.Parse(commandLine);
                    break;

                case "rotate":
                    turtleCommand = RotateCommand.Parse(commandLine);
                    break;

                case "sleep":
                    turtleCommand = SleepCommand.Parse(commandLine);
                    break;

                case "penup":
                    turtleCommand = PenUpCommand.Parse(commandLine);
                    break;

                case "pendown":
                    turtleCommand = PenDownCommand.Parse(commandLine);
                    break;

                case "changecolor":
                    turtleCommand = ChangeColorCommand.Parse(commandLine);
                    break;

                case "changetracksymbol":
                    turtleCommand = ChangeTrackSymbolCommand.Parse(commandLine);
                    break;

                case "changeturtlesymbol":
                    turtleCommand = ChangeTurtleSymbolCommand.Parse(commandLine);
                    break;
            }

            if (turtleCommand != null && editorValue > 0)
            {
                TurtleValue = turtleCommand.GetValue();
                return new InsertCommand(editorValue, turtleCommand);
            }
            else
            {
                return null;
            }
        }

        public void Visit(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            user.Turtleargs[user.Turtleargs.Count - 1].Turtle.Commands.Insert(EditorValue - 1, turtleCommand);
        }

        public void Visit(InputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException();
            }

            EditorLine line = new EditorLine(turtleCommand.ToString(), TurtleValue);
            handler.EditorReadOut.Insert(EditorValue - 1, line);
        }

        public void Visit(ErrorMessage errormessage)
        {
            errormessage.Message = "We could not insert your command.";
        }
    }
}
