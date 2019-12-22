//-----------------------------------------------------------------------
// <copyright file="TurtleAttributes.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the TurtleAttributes class.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// Represents the <see cref="TurtleAttributes"/> class.
    /// </summary>
    public class TurtleAttributes : IExecutionVisitor, IExecutionVisitable
    {
        /// <summary>
        /// The direction of this turtle.
        /// </summary>
        private int turtleDirection;

        /// <summary>
        /// Initializes a new instance of the <see cref="TurtleAttributes"/> class.
        /// </summary>
        public TurtleAttributes()
        {
            this.Turtle = new Turtle();
            this.Position = new Position(0, 0);
            this.TurtleSymbol = 'X';
            this.TrackSymbol = '+';
            this.TrackColor = ConsoleColor.White;
            this.Draw = false;
        }

        /// <summary>
        /// Gets the turtle of this attributes.
        /// </summary>
        /// <value>
        /// The turtle of this attributes.
        /// </value>
        public Turtle Turtle
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the position of this turtle.
        /// </summary>
        /// <value>
        /// The position of this turtle.
        /// </value>
        public Position Position
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the direction of this turtle.
        /// </summary>
        /// <value>
        /// The direction of this turtle.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If value is not valid.
        /// </exception>
        public int TurtleDirection
        {
            get
            {
                return this.turtleDirection;
            }

            set
            {
                switch (value)
                {
                    case 0:
                        this.turtleDirection = value;
                        break;
                    case 90:
                        this.turtleDirection = value;
                        break;
                    case 180:
                        this.turtleDirection = value;
                        break;
                    case 270:
                        this.turtleDirection = value;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        /// <summary>
        /// Gets or sets the character of this turtle.
        /// </summary>
        /// <value>
        /// The character with which this turtle will be displayed.
        /// </value>
        public char TurtleSymbol
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the character for the tracks the turtle traces.
        /// </summary>
        /// <value>
        /// The character that will be displayed for the tracks of this turtle.
        /// </value>
        public char TrackSymbol
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the color of the tracks of this turtle.
        /// </summary>
        /// <value>
        /// The color of the tracks of this turtle.
        /// </value>
        public ConsoleColor TrackColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the turtle draws its tracks or not.
        /// </summary>
        /// <value>
        /// True if the turtle draws, false if not.
        /// </value>
        public bool Draw
        {
            get;
            set;
        }

        /// <summary>
        /// Invites the visiting object in.
        /// </summary>
        /// <param name="visitor">The visiting object.</param>
        /// <exception cref="ArgumentNullException">
        /// If visitor is null.
        /// </exception>
        public void Accept(IExecutionVisitor visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException();
            }

            visitor.Visit(this);
        }

        /// <summary>
        /// This method ensures that the turtle is inside the draw board and stores the tracks and the turtle in the draw board.
        /// </summary>
        /// <param name="board">The object that should be visited.</param>
        /// <exception cref="ArgumentNullException">
        /// If board is null.
        /// </exception>
        public void Visit(DrawBoard board)
        {
            if (board == null)
            {
                throw new ArgumentNullException();
            }

            Position position = this.Position;

            if (this.Position.Top < 0)
            {
                position = new Position(this.Position.Left, 0);
                if (int.TryParse(this.Turtle.Commands[0].GetValue(), out int value))
                {
                    if (value > 1)
                    {
                        this.Turtle.Commands.RemoveAt(0);
                    }
                }
            }
            else if (this.Position.Top > board.Height)
            {
                position = new Position(this.Position.Left, board.Height);
                if (int.TryParse(this.Turtle.Commands[0].GetValue(), out int value))
                {
                    if (value > 1)
                    {
                        this.Turtle.Commands.RemoveAt(0);
                    }
                }
            }
            else if (this.Position.Left < 0)
            {
                position = new Position(0, this.Position.Top);
                if (int.TryParse(this.Turtle.Commands[0].GetValue(), out int value))
                {
                    if (value > 1)
                    {
                        this.Turtle.Commands.RemoveAt(0);
                    }
                }
            }
            else if (this.Position.Left > board.Width)
            {
                position = new Position(board.Width, this.Position.Top);
                if (int.TryParse(this.Turtle.Commands[0].GetValue(), out int value))
                {
                    if (value > 1)
                    {
                        this.Turtle.Commands.RemoveAt(0);
                    }
                }
            }

            this.Position = position;

            if (this.Draw == true) 
            {
                board.SetTrackChar(this.Position, this.TrackSymbol);
                board.SetTrackColor(this.Position, this.TrackColor);
            }

            if (!board.Turtles.Contains(this))
            {
                board.Turtles.Add(this);
            }
        }

        /// <summary>
        /// Is not necessary.
        /// </summary>
        /// <param name="user">The object that should be visited.</param>
        /// <exception cref="ArgumentNullException">
        /// If user is null.
        /// </exception>
        public void Visit(TurtleAttributes user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
