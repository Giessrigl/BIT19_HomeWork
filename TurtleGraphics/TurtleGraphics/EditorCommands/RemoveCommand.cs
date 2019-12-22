//-----------------------------------------------------------------------
// <copyright file="RemoveCommand.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the RemoveCommand class.
// It ensures that a specific turtle command will be removed from the current list of turtle commands.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.EditorCommands
{
    using System;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// This class is responsible for removing a turtle command of the current turtle command list.
    /// </summary>
    public class RemoveCommand : IEditorCommand
    {
        /// <summary>
        /// The position at where the turtle command will be removed.
        /// </summary>
        private int editorValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveCommand"/> class.
        /// </summary>
        /// <param name="editorValue">The position at where the turtle command should be inserted.</param>
        public RemoveCommand(int editorValue)
        {
            this.editorValue = editorValue;
        }

        /// <summary>
        /// This method checks if the command line has a valid remove command at the valid position.
        /// </summary>
        /// <param name="commandLine">The command line the user has written.</param>
        /// <returns>An instanced remove command if the command is valid or null if the command is not valid.</returns>
        public static IEditorCommand Parse(string commandLine)
        {
            if (commandLine == null)
            {
                throw new ArgumentNullException();
            }

            string[] possibleCommands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (possibleCommands.Length != 2)
            {
                return null;
            }

            string editorValue = possibleCommands[1]; 

            try
            {
                int value = int.Parse(editorValue);
                if (value > 0)
                {
                    return new RemoveCommand(value);
                }

                return null;
            }
            catch
            {
                return null;
            }  
        }

        /// <summary>
        /// Removes a turtle command of the current command list at the given position.
        /// </summary>
        /// <param name="user">The object where all turtle commands are stored.</param>
        public void Visit(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
           
            user.Turtleargs[user.Turtleargs.Count - 1].Turtle.Commands.RemoveAt(this.editorValue - 1);
        }

        /// <summary>
        /// This method removes a command line of the list of valid command lines at the given position.
        /// </summary>
        /// <param name="handler">The input handler object where the command line should be stored.</param>
        public void Visit(InputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException();
            }
            
            handler.EditorReadOut.RemoveAt(this.editorValue - 1);
        }

        /// <summary>
        /// This method changes the error message objects message to a specific error message.
        /// </summary>
        /// <param name="errormessage">The error message object where the message should be changed.</param>
        public void Visit(ErrorMessage errormessage)
        {
            errormessage.Message = "We could not remove this entry. It does not exist.";
        }
    }
}
