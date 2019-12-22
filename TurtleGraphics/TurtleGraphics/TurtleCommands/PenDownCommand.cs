//-----------------------------------------------------------------------
// <copyright file="PenDownCommand.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the PenDownCommand class.
// It ensures that the turtle stamps its tracks on the drawboard.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.TurtleCommands
{
    using System;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// Represents the <see cref="PenDownCommand"/> class.
    /// </summary>
    public class PenDownCommand : ITurtleCommand
    {
        /// <summary>
        /// This method checks if the command line has a valid pen down command at the valid position.
        /// </summary>
        /// <param name="commandLine">The command line the user has written.</param>
        /// <returns>
        /// An instanced pen down command if the command is valid or null if the command is not valid.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If commandLine is null.
        /// </exception>
        public static ITurtleCommand Parse(string commandLine)
        {
            if (commandLine == null)
            {
                throw new ArgumentNullException();
            }

            string[] possibleCommands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (possibleCommands.Length == 2)
            {
                if (possibleCommands[1].ToLower() == "pendown")
                {
                    return new PenDownCommand();
                }
                else
                {
                    return null;
                }
            }
            else if (possibleCommands.Length == 3)
            {
                if (possibleCommands[2].ToLower() == "pendown")
                {
                    return new PenDownCommand();
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        /// <summary>
        /// This method gets the value of the pen down command as a string.
        /// </summary>
        /// <returns>The value of the pen down command as a string.</returns>
        public string GetValue()
        {
            return string.Empty;
        }

        /// <summary>
        /// Changes the turtle into the drawing state.
        /// </summary>
        /// <param name="attributes">The attributes of the specific turtle.</param>
        /// <exception cref="ArgumentNullException">
        /// If attributes is null.
        /// </exception>
        public void Visit(TurtleAttributes attributes)
        {
            if (attributes == null)
            {
                throw new ArgumentNullException();
            }

            attributes.Draw = true;
        }

        /// <summary>
        /// Is not necessary.
        /// </summary>
        /// <param name="board">The object where the tracks and turtle positions are stored.</param>
        /// <exception cref="ArgumentNullException">
        /// If board is null.
        /// </exception>
        public void Visit(DrawBoard board)
        {
            if (board == null)
            {
                throw new ArgumentNullException();
            }

            // do nothing.
        }
    }
}
