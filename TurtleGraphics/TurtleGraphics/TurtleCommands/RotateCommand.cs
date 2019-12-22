//-----------------------------------------------------------------------
// <copyright file="RotateCommand.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the RotateCommand class.
// It ensures that the turtle changes its direction.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.TurtleCommands
{
    using System;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// Represents the <see cref="RotateCommand"/> class.
    /// </summary>
    public class RotateCommand : ITurtleCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RotateCommand"/> class.
        /// </summary>
        /// <param name="turtleValue">The value in which direction the turtle should change.</param>
        public RotateCommand(int turtleValue)
        {
            this.TurtleValue = turtleValue;
        }

        /// <summary>
        /// Gets the value in which direction the turtle should change.
        /// </summary>
        /// <value>
        /// The value in which direction the turtle should change.
        /// </value>
        public int TurtleValue
        {
            get;
            private set;
        }

        /// <summary>
        /// This method checks if the command line has a valid rotate command at the valid position.
        /// </summary>
        /// <param name="commandLine">The command line the user has written.</param>
        /// <returns>An instanced rotate command if the command is valid or null if the command is not valid.</returns>
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

            if (possibleCommands[1].ToLower() == "rotate")
            {
                string turtleValue = possibleCommands[2].ToLower();
                try
                {
                    int value = int.Parse(turtleValue);
                    if (CheckRotationValid(value))
                    {
                        return new RotateCommand(value);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            }
            else if (possibleCommands[2].ToLower() == "rotate")
            {
                string turtleValue = possibleCommands[3].ToLower();

                try
                {
                    int value = int.Parse(turtleValue);
                    if (CheckRotationValid(value))
                    {
                        return new RotateCommand(value);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }

        /// <summary>
        /// This method gets the direction value in which the turtle should change its direction.
        /// </summary>
        /// <returns>The direction value in which the turtle should change its direction.</returns>
        public string GetValue()
        {
            return this.TurtleValue.ToString();
        }

        /// <summary>
        /// Changes the turtles direction based on the specified value.
        /// </summary>
        /// <param name="attributes">The attributes of the specific turtle.</param>
        public void Visit(TurtleAttributes attributes)
        {
            if (attributes.TurtleDirection + this.TurtleValue < 0)
            {
                attributes.TurtleDirection = ((attributes.TurtleDirection + this.TurtleValue) % 360) * (-1);
            }
            else
            {
                attributes.TurtleDirection = (attributes.TurtleDirection + this.TurtleValue) % 360;
            }
        }

        /// <summary>
        /// Is not necessary.
        /// </summary>
        /// <param name="board">The object where the tracks and turtle positions are stored.</param>
        public void Visit(DrawBoard board)
        {
            // do nothing.
        }

        /// <summary>
        /// Checks if the specific value is a valid value.
        /// </summary>
        /// <param name="value">The value the user wants the direction of the turtle to change.</param>
        /// <returns>True if the value is valid, false if not.</returns>
        private static bool CheckRotationValid(int value)
        {
            switch (value)
            {
                case 0:
                    return true;

                case 90:
                    return true;

                case 180:
                    return true;

                case 270:
                    return true;

                case -90:
                    return true;

                case -180:
                    return true;

                case -270:
                    return true;

                default:
                    return false;
            }
        }
    }
}
