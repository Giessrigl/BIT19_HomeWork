//-----------------------------------------------------------------------
// <copyright file="EditorLine.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the EditorLine class.
// It stores a valid turtle command for the command line as strings in the right format.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    using System;

    /// <summary>
    /// This class is responsible for storing a valid turtle command as strings in the correct format.
    /// </summary>
    public class EditorLine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditorLine"/> class.
        /// </summary>
        /// <param name="turtleCommand">The valid turtle command as a string.</param>
        /// <param name="turtleValue">The valid turtle value as a string.</param>
        public EditorLine(string turtleCommand, string turtleValue)
        {
            if (turtleCommand == null)
            {
                throw new ArgumentNullException();
            }

            if (turtleValue == null)
            {
                throw new ArgumentNullException();
            }

            if (turtleCommand.ToString().Contains("MoveCommand"))
            {
                this.TurtleCommand = "Move";
            }
            else if (turtleCommand.ToString().Contains("RotateCommand"))
            {
                this.TurtleCommand = "Rotate";
            }
            else if (turtleCommand.ToString().Contains("SleepCommand"))
            {
                this.TurtleCommand = "Sleep";
            }
            else if (turtleCommand.ToString().Contains("PenUpCommand"))
            {
                this.TurtleCommand = "PenUp";
            }
            else if (turtleCommand.ToString().Contains("PenDownCommand"))
            {
                this.TurtleCommand = "PenDown";
            }
            else if (turtleCommand.ToString().Contains("ChangeColorCommand"))
            {
                this.TurtleCommand = "ChangeColor";
            }
            else if (turtleCommand.ToString().Contains("ChangeTrackSymbolCommand"))
            {
                this.TurtleCommand = "ChangeTrackSymbol";
            }
            else if (turtleCommand.ToString().Contains("ChangeTurtleSymbolCommand"))
            {
                this.TurtleCommand = "ChangeTurtleSymbol";
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            this.TurtleValue = turtleValue;
        }

        /// <summary>
        /// Gets the valid turtle command as a string in the correct format.
        /// </summary>
        /// <value>
        /// The correct formatted turtle command as a string.
        /// </value>
        public string TurtleCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the valid turtle command value as a string.
        /// </summary>
        /// <value>
        /// The turtle command value as a string.
        /// </value>
        public string TurtleValue
        {
            get;
            private set;
        }
    }
}
