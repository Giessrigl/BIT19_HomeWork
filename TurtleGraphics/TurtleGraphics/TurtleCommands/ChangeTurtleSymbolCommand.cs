//-----------------------------------------------------------------------
// <copyright file="ChangeTurtleSymbolCommand.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the ChangeTurtleSymbolCommand class.
// It ensures that the symbol of the turtle will be changed.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.TurtleCommands
{
    using System;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// Represents the <see cref="ChangeTurtleSymbolCommand"/> class.
    /// </summary>
    public class ChangeTurtleSymbolCommand : ITurtleCommand
    {
        /// <summary>
        /// The symbol that the turtle symbol should be changed into.
        /// </summary>
        private char turtleValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeTurtleSymbolCommand"/> class.
        /// </summary>
        /// <param name="turtleValue">The symbol the turtle symbol should be changed into.</param>
        public ChangeTurtleSymbolCommand(char turtleValue)
        {
            this.turtleValue = turtleValue;
        }

        /// <summary>
        /// This method checks if the command line has a valid change turtle symbol command at the valid position.
        /// </summary>
        /// <param name="commandLine">The command line the user has written.</param>
        /// <returns>An instanced change turtle symbol command if the command is valid or null if the command is not valid.</returns>
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
                return new ChangeTurtleSymbolCommand(turtleValue);
            }
            else if (possibleCommands.Length == 4 && possibleCommands[3].Length == 1)
            {
                char turtleValue = char.Parse(possibleCommands[3]);
                return new ChangeTurtleSymbolCommand(turtleValue);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// This method gets the symbol of the change turtle symbol command as a string.
        /// </summary>
        /// <returns>The symbol of the change turtle symbol command as a string.</returns>
        public string GetValue()
        {
            return this.turtleValue.ToString();
        }

        /// <summary>
        /// Changes the turtles symbol to the specified symbol.
        /// </summary>
        /// <param name="attributes">The attributes of the specific turtle.</param>
        public void Visit(TurtleAttributes attributes)
        {
            attributes.TurtleSymbol = this.turtleValue;
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
