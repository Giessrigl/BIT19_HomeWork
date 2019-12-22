//-----------------------------------------------------------------------
// <copyright file="NewCommand.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the NewCommand class.
// It ensures that a new turtle can be added.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.EditorCommands
{
    using System;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// This class is responsible for adding a new turtle to the list of turtles.
    /// </summary>
    public class NewCommand : IEditorCommand
    {
        /// <summary>
        /// This method checks if the command line has a valid new command at the valid position.
        /// </summary>
        /// <param name="commandLine">The command line the user has written.</param>
        /// <returns>An instanced new command if the command is valid or null if the command is not valid.</returns>
        public static IEditorCommand Parse(string commandLine)
        {
            string[] possibleCommands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            if (possibleCommands.Length > 1)
            {
                return null;
            }
            else
            {
                return new NewCommand();
            }
        }

        /// <summary>
        /// This method clears the current list of valid command lines.
        /// </summary>
        /// <param name="handler">The input handler object where the command line should be stored.</param>
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
                handler.PageNumber = 1;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Adds a new turtle to the list of turtles.
        /// </summary>
        /// <param name="user">The object where all turtle commands are stored.</param>
        public void Visit(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            
            user.TurtleAttributes.Add(new TurtleAttributes());
        }

        /// <summary>
        /// This method changes the error message objects message to a specific error message.
        /// </summary>
        /// <param name="errormessage">The error message object where the message should be changed.</param>
        public void Visit(ErrorMessage errormessage)
        {
            errormessage.Message = "A new turtle could not be added. Please give this turtle at least one command.";
        }
    }
}
