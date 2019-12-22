//-----------------------------------------------------------------------
// <copyright file="Application.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the Application class.
// It is the main entry point for the turtle graphics application.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    using System;
    using System.Collections.Generic;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// This class is responsible for the correct work off of every other class needed for this application.
    /// </summary>
    public class Application
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
        /// The key board watcher used in this application.
        /// </summary>
        private KeyBoardWatcher keyBoardWatcher;

        /// <summary>
        /// The list of the executioner objects that execute the turtles commands for each turtle.
        /// </summary>
        private List<Executioner> executioners;

        /// <summary>
        /// The draw board in which the turtles and tracks will be stored.
        /// </summary>
        private DrawBoard board;

        /// <summary>
        /// Initializes a new instance of the <see cref="Application"/> class.
        /// </summary>
        public Application()
        {
            this.options = new WindowSettings();
            this.user = new User();
            this.editorRenderer = new EditorRenderer();
            this.handler = new InputHandler();
            this.parser = new EditorlineParser();
            this.errorMessage = new ErrorMessage(string.Empty);
            this.executioners = new List<Executioner>();
            this.options = new WindowSettings();
            this.board = new DrawBoard(this.options.GetWindowWidth(), this.options.GetWindowHeight());
            this.keyBoardWatcher = new KeyBoardWatcher();
        }

        /// <summary>
        /// Adjusts the window size and initializes the keyboard watcher.
        /// </summary>
        public void Start()
        {
            this.options.SetWindowToMax();
            this.keyBoardWatcher.Start();
            this.keyBoardWatcher.OnKeyPressed += this.UseKey;
        }

        /// <summary>
        /// Is responsible for the correct work off of the key the user pressed.
        /// </summary>
        /// <param name="sender">The sending object.</param>
        /// <param name="eventArgs">The key the user pressed.</param>
        /// <exception cref="ArgumentNullException">
        /// If eventArgs is null.
        /// </exception>
        public void UseKey(object sender, OnKeyPressedEventArgs eventArgs)
        {
            if (eventArgs == null)
            {
                throw new ArgumentNullException();
            }

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

                    if (this.user.EditingIsFinished)
                    {
                        this.keyBoardWatcher.OnKeyPressed -= this.UseKey;
                        this.InitializeExecution();
                        this.keyBoardWatcher.OnKeyPressed += this.CheckIfExecutionersFinished;
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

        /// <summary>
        /// Instances an executioner for every turtle.
        /// </summary>
        private void InitializeExecution()
        {
            Executioner executor;

            foreach (TurtleAttributes args in this.user.TurtleAttributes)
            {
                executor = new Executioner(args, this.board);
                executor.Execute();
                this.executioners.Add(executor);
            }
        }

        /// <summary>
        /// Proofs if all executioners have finished working before it calls a method to stop the application.
        /// </summary>
        /// <param name="sender">The sending object.</param>
        /// <param name="eventArgs">The key the user pressed.</param>
        /// <exception cref="ArgumentNullException">
        /// If eventArgs is null.
        /// </exception>
        private void CheckIfExecutionersFinished(object sender, OnKeyPressedEventArgs eventArgs)
        {
            if (eventArgs == null)
            {
                throw new ArgumentNullException();
            }

            bool result = true;
            foreach (Executioner executioner in this.executioners)
            {
                if (result)
                {
                    result = executioner.IsFinished;
                }
                else
                {
                    break;
                }
            }

            if (result)
            {
                this.TerminateApplication();
            }
        }

        /// <summary>
        /// This method stops the application after a key is pressed and all executioners have finished working.
        /// </summary>
        private void TerminateApplication()
        {
            this.keyBoardWatcher.Stop();
            Environment.Exit(0);
        }
    }
}
