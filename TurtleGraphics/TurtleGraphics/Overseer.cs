namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class Overseer
    {
        private User User;
        private ConsoleRenderer Renderer;
        private InputHandler Handler;
        private EditorlineChecker Checker;
        private ConsoleRelatedOptions Options;
        private ErrorMessage ErrorMessage;

        public Overseer()
        {

            this.Options = new ConsoleRelatedOptions();
            this.User = new User();
            this.Renderer = new ConsoleRenderer();
            this.Handler = new InputHandler();
            this.Checker = new EditorlineChecker();
            this.ErrorMessage = new ErrorMessage("");
        }

        public void Start()
        {
            Options.SetConsoleWindow(Console.LargestWindowWidth, Console.LargestWindowHeight);

            KeyBoardWatcher keyBoardWatcher = new KeyBoardWatcher();
            keyBoardWatcher.OnKeyPressed += UseKey;
        }

        private void UseKey(object sender, OnKeyPressedEventArgs eventArgs)
        {
            ConsoleKeyInfo cki = eventArgs.KeyInfo;

            switch(cki.Key)
            {
                case ConsoleKey.Enter:
                    if (!string.IsNullOrWhiteSpace(this.Handler.text))
                    {
                        IEditorCommand command = Checker.Check(Handler.text);
                        ErrorMessage.Message = "";

                        if (command != null)
                        {
                            try
                            {
                                Handler.text = "";
                                Handler.Accept(command);
                                User.Accept(command);
                                Handler.Accept(Renderer);
                            }
                            catch
                            {
                                ErrorMessage.Accept(command);
                            }
                        }
                        else
                        {
                            Handler.text = "";
                            ErrorMessage.Message = "This is not a valid command.";
                        }
                    }
                    break;

                default:
                    ErrorMessage.Message = "";
                    Handler.Start(cki);
                    break;
            }
            Handler.Accept(Renderer);
            ErrorMessage.Accept(Renderer);
        }
    }
}
