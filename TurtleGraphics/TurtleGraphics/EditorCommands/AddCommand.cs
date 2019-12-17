namespace TurtleGraphics.EditorCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class AddCommand : IEditorCommand
    {
        public string TurtleValue
        {
            get;
            private set;
        }

        public ITurtleCommand turtleCommand
        {
            get;
            private set;
        }

        public AddCommand(ITurtleCommand turtleCommand)
        {
            this.TurtleValue = turtleCommand.GetValue();
            this.turtleCommand = turtleCommand;
        }

        public void Visit(User user)
        {
            user.Turtleargs[user.Turtleargs.Count - 1].Turtle.Commands.Add(turtleCommand);
        }

        public void Visit(InputHandler handler)
        {
            EditorLine line = new EditorLine(turtleCommand.ToString(), this.TurtleValue);
            handler.EditorReadOut.Add(line);
        }

        public void Visit(ErrorMessage errormessage)
        {
            errormessage.Message = "We could not add this entry.";
        }

        public static IEditorCommand Parse(string commandLine)
        {
            if (commandLine == null)
            {
                throw new ArgumentNullException();
            }

            string[] possibleCommands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            if (1 >= possibleCommands.Length || possibleCommands.Length >= 4)
            {
                return null;
            }

            string command = possibleCommands[1].ToLower();
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

            if (turtleCommand != null)
            {
                return new AddCommand(turtleCommand);
            }
            else
            {
                return null;
            }
        }
    }
}
