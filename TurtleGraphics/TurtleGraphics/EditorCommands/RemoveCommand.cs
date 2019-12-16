namespace TurtleGraphics.EditorCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class RemoveCommand : IEditorCommand
    {
        private int editorValue;

        public RemoveCommand(int editorValue)
        {
            this.editorValue = editorValue;
        }

        public static IEditorCommand Check(string commandLine)
        {
            if (commandLine == null)
            {
                throw new ArgumentNullException();
            }

            string[] possibleCommands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (possibleCommands.Length > 2)
            {
                return null;
            }

            string editorValue = possibleCommands[1]; // Chcke if integer between 0 and turtlecommands.count -1 ! user this.user!

            try
            {
                int value = int.Parse(editorValue);
                if (value >= 0)
                {
                    return new RemoveCommand(value);
                }

                return null;
            }
            catch
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
           
            user.Turtleargs[user.Turtleargs.Count - 1].Turtle.Commands.RemoveAt(editorValue);
        }

        public void Visit(InputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException();
            }
            
            handler.EditorReadOut.RemoveAt(editorValue);
        }

        public void Visit(ErrorMessage errormessage)
        {
            errormessage.Message = "We could not remove this entry. It does not exist.";
        }
    }
}
