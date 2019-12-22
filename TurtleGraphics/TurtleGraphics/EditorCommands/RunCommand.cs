//-----------------------------------------------------------------------
// <copyright file="RunCommand.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the RunCommand class.
// It ensures that all the turtle commands of all turtles will be executed seperatly in threads.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.EditorCommands
{
    using System;
    using System.Collections.Generic;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// This class is responsible for initiating the threads which execute the turtle commands.
    /// </summary>
    public class RunCommand : IEditorCommand
    {
        /// <summary>
        /// The list of the executioner objects that execute the turtles commands for each turtle.
        /// </summary>
        private List<Executioner> executioners;

        /// <summary>
        /// The settings of the draw board and the console window.
        /// </summary>
        private WindowSettings options;

        /// <summary>
        /// The draw board in which the turtles and tracks will be stored.
        /// </summary>
        private DrawBoard board;

        /// <summary>
        /// Initializes a new instance of the <see cref="RunCommand"/> class.
        /// </summary>
        public RunCommand()
        {
            this.executioners = new List<Executioner>();
            this.options = new WindowSettings();
            this.board = new DrawBoard(this.options.GetWindowWidth(), this.options.GetWindowHeight());
        }

        /// <summary>
        /// This method checks if the command line has a valid run command at the valid position.
        /// </summary>
        /// <param name="commandLine">The command line the user has written.</param>
        /// <returns>An instanced run command if the command is valid or null if the command is not valid.</returns>
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

        /// <summary>
        /// Starts initializing the executor objects to start the drawing.
        /// After every executor is finished, it waits for a key to be pressed.
        /// </summary>
        /// <param name="user">The object where all turtle commands are stored.</param>
        public void Visit(User user)
        {
            Executioner executor;

            foreach (TurtleAttributes args in user.TurtleAttributes)
            {
                executor = new Executioner(args, this.board);
                executor.Execute();
                this.executioners.Add(executor);
            }

            while (true)
            {
                KeyBoardWatcher keyBoardWatcher = new KeyBoardWatcher();
                keyBoardWatcher.OnKeyPressed += this.CheckIfThreadsFinished;
            }
        }

        /// <summary>
        /// This method clears the valid command list of the editor.
        /// </summary>
        /// <param name="handler">The input handler object where the command line should be stored.</param>
        public void Visit(InputHandler handler)
        {
            if (handler.EditorReadOut.Count >= 1)
            {
                handler.EditorReadOut.Clear();
                handler.Text = string.Empty;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// This method changes the error message objects message to a specific error message.
        /// </summary>
        /// <param name="errormessage">The error message object where the message should be changed.</param>
        public void Visit(ErrorMessage errormessage)
        {
            errormessage.Message = "Every turtle must have at least one command to start drawing.";
        }

        /// <summary>
        /// Proofs if all executioners have finished working before it calls a method to stop the application.
        /// </summary>
        /// <param name="sender">The sending object.</param>
        /// <param name="eventArgs">The key the user pressed.</param>
        private void CheckIfThreadsFinished(object sender, OnKeyPressedEventArgs eventArgs)
        {
            bool result = true;
            foreach (Executioner executioner in this.executioners)
            {
                if (result)
                {
                    result = executioner.IsFinished;
                }
                else
                {
                    this.TerminateApplication();
                }
            }
        }

        /// <summary>
        /// This method stops the application after a key is pressed and all executioners have finished working.
        /// </summary>
        private void TerminateApplication()
        {
            Environment.Exit(0);
        }
    }
}
