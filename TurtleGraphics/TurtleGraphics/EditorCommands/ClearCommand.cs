﻿//-----------------------------------------------------------------------
// <copyright file="ClearCommand.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the ClearCommand class.
// The ClearCommand class ensures that all commands of the current turtle are deleted.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.EditorCommands
{
    using System;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// This class will delete all the commands of the current turtle after using this command.
    /// </summary>
    public class ClearCommand : IEditorCommand
    {
        /// <summary>
        /// This method checks if the command line has a valid clear command at the valid position.
        /// </summary>
        /// <param name="commandLine">The command line the user has written.</param>
        /// <exception cref="ArgumentNullException">
        /// If the commandLine is null.
        /// </exception>
        /// <returns>An instanced clear command if the command is valid or null if the command is not valid.</returns>
        public static IEditorCommand Parse(string commandLine)
        {
            if (commandLine == null)
            {
                throw new ArgumentNullException();
            }

            string[] possibleCommands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (possibleCommands.Length > 1)
            {
                return null;
            }
            else
            {
                return new ClearCommand();
            }
        }

        /// <summary>
        /// Removes all the current turtle commands of the command list.
        /// </summary>
        /// <param name="user">The object where all turtle commands are stored.</param>
        /// <exception cref="ArgumentNullException">
        /// If the user is null.
        /// </exception>
        public void Visit(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            user.TurtleAttributes[user.TurtleAttributes.Count - 1].Turtle.Commands.Clear();
        }

        /// <summary>
        /// Removes all the current command lines of the current valid command list.
        /// </summary>
        /// <param name="handler">The input handler object where the command line should be stored.</param>
        /// <exception cref="ArgumentNullException">
        /// If the handler is null.
        /// </exception>
        public void Visit(InputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException();
            }

            handler.EditorReadOut.Clear();
            handler.PageNumber = 1;
        }

        /// <summary>
        /// This method changes the error message objects message to a specific error message.
        /// </summary>
        /// <param name="errormessage">The error message object where the message should be changed.</param>
        /// <exception cref="ArgumentNullException">
        /// If the error message is null.
        /// </exception>
        public void Visit(ErrorMessage errormessage)
        {
            if (errormessage == null)
            {
                throw new ArgumentNullException();
            }

            errormessage.Message = "We could not clear the command list.";
        }
    }
}
