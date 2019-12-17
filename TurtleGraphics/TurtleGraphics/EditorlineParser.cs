namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class EditorlineParser
    {
        public IEditorCommand Parse(string commandLine)
        {
            if (string.IsNullOrWhiteSpace(commandLine))
            {
                throw new ArgumentNullException();
            }

            string[] possibleCommands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string editorCommand = possibleCommands[0].ToLower();

            if (possibleCommands.Length > 4)
            {
                return null;
            }
            else
            {
                switch (editorCommand)
                {
                    case "add":
                        return AddCommand.Parse(commandLine);

                    case "clear":
                        return ClearCommand.Parse(commandLine);

                    case "insert":
                        return InsertCommand.Parse(commandLine);

                    case "remove":
                        return RemoveCommand.Parse(commandLine);

                    case "new":
                        return NewCommand.Parse(commandLine);

                    case "run":
                        return RunCommand.Parse(commandLine);

                    default:
                        return null;
                }
            }
        }
    }
}
