//-----------------------------------------------------------------------
// <copyright file="PenUpCommand.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the PenUpCommand class.
// It ensures that the turtle does not stamp its tracks on the drawboard.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.TurtleCommands
{
    using System;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// Represents the <see cref="PenUpCommand"/> class.
    /// </summary>
    public class PenUpCommand : ITurtleCommand
    {
        /// <summary>
        /// This method checks if the command line has a valid pen up command at the valid position.
        /// </summary>
        /// <param name="commandLine">The command line the user has written.</param>
        /// <returns>An instanced pen up command if the command is valid or null if the command is not valid.</returns>
        public static ITurtleCommand Parse(string commandLine)
        {
            if (commandLine == null)
            {
                throw new ArgumentNullException();
            }

            string[] possibleCommands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            if (possibleCommands.Length == 2)
            {
                if (possibleCommands[1].ToLower() == "penup")
                {
                    return new PenUpCommand();
                }
                else
                {
                    return null;
                }
            }
            else if (possibleCommands.Length == 3)
            {
                if (possibleCommands[2].ToLower() == "penup")
                {
                    return new PenUpCommand();
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        /// <summary>
        /// This method gets the value of the pen up command as a string.
        /// </summary>
        /// <returns>The value of the pen up command as a string.</returns>
        public string GetValue()
        {
            return string.Empty;
        }

        /// <summary>
        /// Changes the turtle into the not drawing state.
        /// </summary>
        /// <param name="attributes">The attributes of the specific turtle.</param>
        public void Visit(TurtleAttributes attributes)
        {
            attributes.Draw = false;
        }

        /// <summary>
        /// Is not necessary.
        /// </summary>
        /// <param name="board">The object where the tracks and turtle positions are stored.</param>
        public void Visit(DrawBoard board)
        {
            // do nothing.
        }
    }
}
