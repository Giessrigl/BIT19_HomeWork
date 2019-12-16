namespace TurtleGraphics.EditorCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class RunCommand : IEditorCommand
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
                return new RunCommand();
            }
        }

        public void Visit(User user)
        {
            // Hier gehts weiter zur Execution der Turtle Commands mit Threads!!!!
        }

        public void Visit(InputHandler handler)
        {
            throw new NotImplementedException();
        }

        public void Visit(ErrorMessage errormessage)
        {
            errormessage.Message = "Failed at drawing.";
        }
    }
}
