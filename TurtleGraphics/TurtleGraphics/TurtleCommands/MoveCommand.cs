//-----------------------------------------------------------------------
// <copyright file="MoveCommand.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the MoveCommand class.
// It ensures that the turtle moves a specific amount of steps on the draw board based on its direction.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.TurtleCommands
{
    using System;
    using System.Threading;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// Represents the <see cref="MoveCommand"/> class.
    /// </summary>
    public class MoveCommand : ITurtleCommand
    {
        /// <summary>
        /// The steps that the turtle should move on the draw board.
        /// </summary>
        private int turtleValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveCommand"/> class.
        /// </summary>
        /// <param name="turtleValue">The amounts of steps the turtle should move on the draw board.</param>
        public MoveCommand(int turtleValue)
        {
            this.turtleValue = turtleValue;
        }

        /// <summary>
        /// This method checks if the command line has a valid move command at the valid position.
        /// </summary>
        /// <param name="commandLine">The command line the user has written.</param>
        /// <returns>An instanced move command if the command is valid or null if the command is not valid.</returns>
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

            if (possibleCommands.Length == 3 && possibleCommands[1].ToLower() == "move")
            {
                string turtleValue = possibleCommands[2];
                if (int.TryParse(turtleValue, out int result))
                {
                    if (result > 0)
                    {
                        return new MoveCommand(result);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else if (possibleCommands.Length == 4 && possibleCommands[2].ToLower() == "move")
            {
                string turtleValue = possibleCommands[3];
                if (int.TryParse(turtleValue, out int result))
                {
                    if (result > 0)
                    {
                        return new MoveCommand(result);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        /// <summary>
        /// This method gets the amounts of steps the turtle should make as a string.
        /// </summary>
        /// <returns>The amounts of steps the turtle should make as a string.</returns>
        public string GetValue()
        {
            return this.turtleValue.ToString();
        }

        /// <summary>
        /// Changes the position of the turtle by one and instancing a new move command with the value reduced by one.
        /// </summary>
        /// <param name="attributes">The attributes of the specific turtle.</param>
        public void Visit(TurtleAttributes attributes)
        {
            Position position = attributes.Position;
            switch (attributes.TurtleDirection)
            {
                case 0:
                    position.Left++;
                    break;
                case 90:
                    position.Top++;
                    break;
                case 180:
                    position.Left--;
                    break;
                case 270:
                    position.Top--;
                    break;
            }

            attributes.Position = position;

            if (this.turtleValue > 1)
            {
                attributes.Turtle.Commands.Insert(1, new MoveCommand(this.turtleValue - 1));
            }

            Thread.Sleep(1000);
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
