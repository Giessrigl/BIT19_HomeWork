//-----------------------------------------------------------------------
// <copyright file="Editor.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the Editor class.
// The editor administrates all classes that have to do with the command entries of the user.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// This class is responsible for the correct work off of the user's entries.
    /// </summary>
    public class Editor
    {
        /// <summary>
        /// Contains all turtle attributes of all turtles.
        /// </summary>
        private User user;

        /// <summary>
        /// The console renderer for the command inputs.
        /// </summary>
        private EditorRenderer editorRenderer;

        /// <summary>
        /// Is responsible for the right work off of a character the user types in.
        /// </summary>
        private InputHandler handler;

        /// <summary>
        /// Proofs if a whole command line is a valid command.
        /// </summary>
        private EditorlineParser parser;

        /// <summary>
        /// The settings of the console.
        /// </summary>
        private WindowSettings options;

        /// <summary>
        /// The given error message if the user does something wrong.
        /// </summary>
        private ErrorMessage errorMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="Editor"/> class.
        /// </summary>
        public Editor()
        {
            this.options = new WindowSettings();
            this.user = new User();
            this.editorRenderer = new EditorRenderer();
            this.handler = new InputHandler();
            this.parser = new EditorlineParser();
            this.errorMessage = new ErrorMessage(string.Empty);
        }

        /// <summary>
        /// Adjusts the window size and initializes the keyboard watcher.
        /// </summary>
        public void Start()
        {
            this.options.SetWindowToMax();

            KeyBoardWatcher keyBoardWatcher = new KeyBoardWatcher();
            keyBoardWatcher.OnKeyPressed += this.UseKey;
        }

        /// <summary>
        /// Is responsible for the correct work off of the key the user pressed.
        /// </summary>
        /// <param name="sender">The sending object.</param>
        /// <param name="eventArgs">The key the user pressed.</param>
        private void UseKey(object sender, OnKeyPressedEventArgs eventArgs)
        {
            ConsoleKeyInfo cki = eventArgs.KeyInfo;

            switch (cki.Key)
            {
                case ConsoleKey.Enter:
                    if (!string.IsNullOrWhiteSpace(this.handler.Text))
                    {
                        IEditorCommand command = this.parser.Parse(this.handler.Text);
                        this.errorMessage.Message = string.Empty;

                        if (command == null)
                        {
                            this.errorMessage.Message = "This is not a valid command.";
                        }
                        else
                        {
                            try
                            {
                                this.handler.Text = string.Empty;
                                this.handler.Accept(command);
                                this.user.Accept(command);
                            }
                            catch
                            {
                                this.errorMessage.Accept(command);
                            }
                        }
                    }

                    break;

                default:
                    this.errorMessage.Message = string.Empty;
                    this.handler.Start(cki);
                    break;
            }

            this.handler.Accept(this.editorRenderer);
            this.errorMessage.Accept(this.editorRenderer);
        }
    }
}
