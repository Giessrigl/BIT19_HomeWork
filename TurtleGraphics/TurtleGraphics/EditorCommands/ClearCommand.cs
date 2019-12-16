namespace TurtleGraphics.EditorCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class ClearCommand : IEditorCommand
    {
        public static IEditorCommand Check(string commandLine) // Finished!
        {
            if (commandLine == null)
            {
                throw new ArgumentNullException();
            }

            string[] possibleCommands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (possibleCommands.Length > 1)
            {
                return null;
            }
            else
            {
                return new ClearCommand();
            }
        }

        public void Visit(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            user.Turtleargs[user.Turtleargs.Count - 1].Turtle.Commands.Clear();
        }

        public void Visit(InputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException();
            }

            handler.EditorReadOut.Clear();
        }

        public void Visit(ErrorMessage errormessage)
        {
            errormessage.Message = "We could not clear the command list.";
        }
    }
}
