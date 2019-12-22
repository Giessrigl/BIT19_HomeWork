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
            user.FinishEditing();
        }

        /// <summary>
        /// This method clears the valid command list of the editor.
        /// </summary>
        /// <param name="handler">The input handler object where the command line should be stored.</param>
        /// <exception cref="ArgumentNullException">
        /// If the handler is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If Editor.ReadOut.Count is less than one.
        /// </exception>
        public void Visit(InputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException();
            }

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
        /// <exception cref="ArgumentNullException">
        /// If error message is null.
        /// </exception>
        public void Visit(ErrorMessage errormessage)
        {
            if (errormessage == null)
            {
                throw new ArgumentNullException();
            }

            errormessage.Message = "Every turtle must have at least one command to start drawing.";
        }
    }
}
