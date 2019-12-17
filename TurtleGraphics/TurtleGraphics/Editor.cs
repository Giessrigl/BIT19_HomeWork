namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class Editor
    {
        private User User;
        private EditorRenderer EditorRenderer;
        private InputHandler Handler;
        private EditorlineParser Checker;
        private WindowSettings Options;
        private ErrorMessage ErrorMessage;

        public Editor()
        {

            this.Options = new WindowSettings();
            this.User = new User();
            this.EditorRenderer = new EditorRenderer();
            this.Handler = new InputHandler();
            this.Checker = new EditorlineParser();
            this.ErrorMessage = new ErrorMessage("");
        }

        public void Start()
        {
            Options.SetWindow(Console.LargestWindowWidth, Console.LargestWindowHeight);

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
                        IEditorCommand command = Checker.Parse(Handler.text);
                        ErrorMessage.Message = "";

                        if (command == null)
                        {
                            Handler.text = "";
                            ErrorMessage.Message = "This is not a valid command.";
                        }
                        else
                        {
                            try
                            {

                                Handler.text = "";
                                Handler.Accept(command);
                                User.Accept(command);
                            }
                            catch
                            {
                                ErrorMessage.Accept(command);
                            }
                        }
                    }
                    break;

                default:
                    ErrorMessage.Message = "";
                    Handler.Start(cki);
                    break;
            }
            Handler.Accept(EditorRenderer);
            ErrorMessage.Accept(EditorRenderer);
        }
    }
}
