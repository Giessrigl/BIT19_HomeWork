namespace TurtleGraphics.EditorCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using System.Collections.Generic;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;
    using System.Threading;

    public class RunCommand : IEditorCommand
    {
        private List<Executioner> Executioners;
        private WindowSettings Options;
        private DrawBoard Board;

        public RunCommand()
        {
            this.Executioners = new List<Executioner>();
            this.Options = new WindowSettings();
            this.Board = new DrawBoard(Options.GetWindowWidth(), Options.GetWindowHeight());
        }

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
            Executioner executor;

            foreach (TurtleAttributes args in user.Turtleargs)
            {
                executor = new Executioner(args, this.Board);
                executor.Execute();
            }

            while (true)
            {
                KeyBoardWatcher keyBoardWatcher = new KeyBoardWatcher();
                keyBoardWatcher.OnKeyPressed += CheckIfThreadsFinished;
            }
        }

        private void CheckIfThreadsFinished(object sender, OnKeyPressedEventArgs eventArgs)
        {
            bool result = true;
            foreach (Executioner executioner in Executioners)
            {
                if (result)
                {
                    result = executioner.IsFinished;
                }
                else
                {
                    TerminateApplication();
                }
            }
        }

        public void Visit(InputHandler handler)
        {
            if (handler.EditorReadOut.Count >= 1)
            {
                handler.EditorReadOut.Clear();
                handler.text = string.Empty;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
            
        }

        private void TerminateApplication()
        {
            Environment.Exit(0);
        }

        public void Visit(ErrorMessage errormessage)
        {
            errormessage.Message = "Every turtle must have at least one command to start drawing.";
        }
    }
}
