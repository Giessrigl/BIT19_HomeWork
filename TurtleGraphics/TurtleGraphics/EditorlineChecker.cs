namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class EditorlineChecker : IEditorLineCheckerVisitable
    {
        public IEditorCommand Check(string commandLine)
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
                        return AddCommand.Check(commandLine);

                    case "clear":
                        return ClearCommand.Check(commandLine);

                    case "insert":
                        return InsertCommand.Check(commandLine);

                    case "remove":
                        return RemoveCommand.Check(commandLine);

                    case "new":
                        return NewCommand.Check(commandLine);

                    case "run":
                        return RunCommand.Check(commandLine);

                    default:
                        return null;
                }
            }
        }

        public void Accept(IEditorLineCheckerVisitor visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException();
            }

            visitor.Visit(this);
        }
    }
}
