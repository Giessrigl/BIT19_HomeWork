namespace TurtleGraphics.EditorCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class NewCommand : IEditorCommand
    {
        public static IEditorCommand Check(string commandLine)
        {
            string[] possibleCommands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            if (possibleCommands.Length > 1)
            {
                return null;
            }
            else
            {
                return new NewCommand();
            }
        }

        public void Visit(InputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException();
            }

            handler.EditorReadOut.Clear();
        }

        public void Visit(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            user.Turtleargs.Add(new TurtleArguments());
        }

        public void Visit(ErrorMessage errormessage)
        {
            errormessage.Message = "We could not add a new turtle.";
        }
    }
}
