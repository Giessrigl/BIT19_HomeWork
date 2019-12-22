//-----------------------------------------------------------------------
// <copyright file="ChangeColorCommand.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the ChangeColorCommand class.
// It ensures that the color of the turtles tracks will be changed.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.TurtleCommands
{
    using System;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// Represents the <see cref="ChangeColorCommand"/> class.
    /// </summary>
    public class ChangeColorCommand : ITurtleCommand
    {
        /// <summary>
        /// The color that the tracks should be changed into.
        /// </summary>
        private static ConsoleColor turtleValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeColorCommand"/> class.
        /// </summary>
        /// <param name="color">The color the tracks should be changed into.</param>
        public ChangeColorCommand(ConsoleColor color)
        {
            turtleValue = color;
        }

        /// <summary>
        /// This method checks if the command line has a valid change color command at the valid position.
        /// </summary>
        /// <param name="commandLine">The command line the user has written.</param>
        /// <returns>
        /// An instanced change color command if the command is valid or null if the command is not valid.
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

            if (possibleCommands[1].ToLower() == "changecolor")
            {
                string value = string.Empty;
                if (possibleCommands[2].ToLower().Contains("dark"))
                {
                    value += "Dark";
                    value += possibleCommands[2].Substring(4, 1).ToUpper();
                    value += possibleCommands[2].Substring(5, possibleCommands[2].Length - 5).ToLower();
                }
                else
                {
                    value += possibleCommands[2][0].ToString().ToUpper();
                    value += possibleCommands[2].ToString().Substring(1).ToLower();
                }

                ConsoleColor color;
                if (Enum.TryParse<ConsoleColor>(value, out color))
                {
                    return new ChangeColorCommand(color);
                }
                else
                {
                    return null;
                }
            }
            else if (possibleCommands[2].ToLower() == "changecolor")
            {
                string value = possibleCommands[2][0].ToString().ToUpper();
                value += possibleCommands[2].ToString().Substring(1).ToLower();
                ConsoleColor color;
                if (Enum.TryParse<ConsoleColor>(value, out color))
                {
                    return new ChangeColorCommand(color);
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        /// <summary>
        /// This method gets the color of the change color command as a string.
        /// </summary>
        /// <returns>The color of the change color command as a string.</returns>
        public string GetValue()
        {
            return turtleValue.ToString();
        }

        /// <summary>
        /// Changes the turtles track color to the specified color.
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

            attributes.TrackColor = turtleValue;
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
