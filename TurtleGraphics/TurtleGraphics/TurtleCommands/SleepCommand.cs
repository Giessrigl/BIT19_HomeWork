//-----------------------------------------------------------------------
// <copyright file="SleepCommand.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the SleepCommand class.
// It ensures that the turtles thread waits a specific time in milliseconds before moving on.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.TurtleCommands
{
    using System;
    using System.Threading;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// Represents the <see cref="SleepCommand"/> class.
    /// </summary>
    public class SleepCommand : ITurtleCommand
    {
        /// <summary>
        /// The amount of milliseconds the thread should wait.
        /// </summary>
        private int turtleValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="SleepCommand" /> class.
        /// </summary>
        /// <param name="turtleValue">The amount of milliseconds the thread should wait.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If turtleValue is less than 100 or bigger than 10000.
        /// </exception>
        public SleepCommand(int turtleValue)
        {
            if (turtleValue < 100 || turtleValue > 10000)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.turtleValue = turtleValue;
        }

        /// <summary>
        /// This method checks if the command line has a valid sleep command at the valid position.
        /// </summary>
        /// <param name="commandLine">The command line the user has written.</param>
        /// <returns>
        /// An instanced sleep command if the command is valid or null if the command is not valid.
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

            if (possibleCommands.Length < 3)
            {
                return null;
            }

            if (possibleCommands.Length == 3 && possibleCommands[1].ToLower() == "sleep")
            {
                string turtleValue = possibleCommands[2];

                if (int.TryParse(turtleValue, out int value))
                {
                    if (!(value < 100 || value > 10000))
                    {
                        return new SleepCommand(value);
                    }
                }

                return null;
            }
            else if (possibleCommands.Length == 4 && possibleCommands[2].ToLower() == "sleep")
            {
                string turtleValue = possibleCommands[3];

                if (int.TryParse(turtleValue, out int value))
                {
                    if (!(value < 100 || value > 10000))
                    {
                        return new SleepCommand(value);
                    }
                }

                return null;
            }

            return null;
        }

        /// <summary>
        /// This method gets the amount of milliseconds of the sleep command as a string.
        /// </summary>
        /// <returns>The amount of milliseconds of the sleep command as a string.</returns>
        public string GetValue()
        {
            return this.turtleValue.ToString();
        }

        /// <summary>
        /// Makes the thread of the turtle wait the specific amount of milliseconds before moving on.
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

            Thread.Sleep(this.turtleValue);
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
