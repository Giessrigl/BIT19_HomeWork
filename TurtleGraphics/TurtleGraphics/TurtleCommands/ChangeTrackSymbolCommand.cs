//-----------------------------------------------------------------------
// <copyright file="ChangeTrackSymbolCommand.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the ChangeTrackSymbolCommand class.
// It ensures that the symbol of the turtles tracks will be changed.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.TurtleCommands
{
    using System;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// Represents the <see cref="ChangeTrackSymbolCommand"/> class.
    /// </summary>
    public class ChangeTrackSymbolCommand : ITurtleCommand
    {
        /// <summary>
        /// The symbol that the tracks should be changed into.
        /// </summary>
        private char turtleValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeTrackSymbolCommand"/> class.
        /// </summary>
        /// <param name="turtleValue">The symbol that the tracks should be changed into.</param>
        public ChangeTrackSymbolCommand(char turtleValue)
        {
            this.turtleValue = turtleValue;
        }

        /// <summary>
        /// This method checks if the command line has a valid change track symbol command at the valid position.
        /// </summary>
        /// <param name="commandLine">The command line the user has written.</param>
        /// <returns>
        /// An instanced change track symbol command if the command is valid or null if the command is not valid.
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

            if (possibleCommands.Length <= 2)
            {
                return null;
            }

            if (possibleCommands.Length == 3 && possibleCommands[2].Length == 1)
            {
                char turtleValue = char.Parse(possibleCommands[2]);
                return new ChangeTrackSymbolCommand(turtleValue);
            }
            else if (possibleCommands.Length == 4 && possibleCommands[3].Length == 1)
            {
                char turtleValue = char.Parse(possibleCommands[3]);
                return new ChangeTrackSymbolCommand(turtleValue);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// This method gets the symbol of the change track symbol command as a string.
        /// </summary>
        /// <returns>The symbol of the change track symbol command as a string.</returns>
        public string GetValue()
        {
            return this.turtleValue.ToString();
        }

        /// <summary>
        /// Changes the turtles track symbol to the specified symbol.
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

            attributes.TrackSymbol = this.turtleValue;
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
