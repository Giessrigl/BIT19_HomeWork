namespace TurtleGraphics.EditorCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class NewCommand : IEditorCommand
    {
        public static IEditorCommand Parse(string commandLine)
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

            if (handler.EditorReadOut.Count >= 1)
            {
                handler.EditorReadOut.Clear();
                handler.text = "";
                handler.PageNumber = 1;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
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
            errormessage.Message = "This turtle must have at least one command before adding a new one.";
        }
    }
}
