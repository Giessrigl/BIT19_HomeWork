namespace TurtleGraphics.EditorCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;
    using System.Threading;

    public class RunCommand : IEditorCommand
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
                return new RunCommand();
            }
        }

        public void Visit(User user)
        {
            Executioner executor = new Executioner(user);
            executor.Execute();
        }

        public void Visit(InputHandler handler)
        {
            if (handler.EditorReadOut.Count > 1)
            {
                handler.EditorReadOut.Clear();
                handler.text = "";
            }
            else
            {
                throw new ArgumentNullException();
            }
            
        }

        public void Visit(ErrorMessage errormessage)
        {
            errormessage.Message = "Failed at drawing.";
        }
    }
}
