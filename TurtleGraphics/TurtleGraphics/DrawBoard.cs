//-----------------------------------------------------------------------
// <copyright file="DrawBoard.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the DrawBoard class.
// The draw board is responsible for storing the tracks and turtles that will be on the drawboard.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    using System;
    using System.Collections.Generic;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// This class contains all drawn characters with their colors based on their position on the draw board.
    /// </summary>
    public class DrawBoard : IExecutionVisitable
    {
        /// <summary>
        /// The array of the characters of the tracks based on their position.
        /// </summary>
        private char[,] boardTracks;

        /// <summary>
        /// The array of the colors of the tracks based on their position.
        /// </summary>
        private ConsoleColor[,] boardTrackColors;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawBoard"/> class.
        /// </summary>
        /// <param name="width">The width of the draw board.</param>
        /// <param name="height">The height of the draw board.</param>
        public DrawBoard(int width, int height)
        {
            this.boardTracks = new char[width, height];
            this.boardTrackColors = new ConsoleColor[width, height];
            this.TrackPositions = new List<Position>();
            this.Turtles = new List<TurtleAttributes>();
        }

        /// <summary>
        /// Gets the width of the draw board.
        /// </summary>
        /// <value>
        /// The width of the draw board.
        /// </value>
        public int Width
        {
            get
            {
                return this.boardTracks.GetLength(0);
            }
        }

        /// <summary>
        /// Gets the height of the draw board.
        /// </summary>
        /// <value>
        /// The height of the draw board.
        /// </value>
        public int Height
        {
            get
            {
                return this.boardTracks.GetLength(1);
            }
        }

        /// <summary>
        /// Gets or sets the position of a track symbol.
        /// </summary>
        /// <value>
        /// All positions of all tracks on the draw board.
        /// </value>
        public List<Position> TrackPositions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a turtle.
        /// </summary>
        /// <value>
        /// All attributes of all turtles on the draw board.
        /// </value>
        public List<TurtleAttributes> Turtles
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the track character of the board tracks array based on the position.
        /// </summary>
        /// <param name="position">The position on the draw board.</param>
        /// <returns>The track character based on the position in the draw board.</returns>
        public char GetTrackChar(Position position)
        {
            return this.boardTracks[position.Left, position.Top];
        }

        /// <summary>
        /// Sets a character in the board tracks array and the track position list based on the position.
        /// </summary>
        /// <param name="position">The position in the draw board.</param>
        /// <param name="character">The character that should be at the specified position.</param>
        public void SetTrackChar(Position position, char character)
        {
            if (character == '\0')
            {
                throw new ArgumentNullException();
            }

            this.boardTracks[position.Left, position.Top] = character;

            if (!this.TrackPositions.Contains(position))
            {
                this.TrackPositions.Add(position);
            }
        }

        /// <summary>
        /// Gets the track color of the board track colors array based on the position.
        /// </summary>
        /// <param name="position">The position in the draw board.</param>
        /// <returns>The color of a character at a specified position in the draw board.</returns>
        public ConsoleColor GetTrackColor(Position position)
        {
            return this.boardTrackColors[position.Left, position.Top];
        }

        /// <summary>
        /// Sets a track color in the board track colors array based on the position.
        /// </summary>
        /// <param name="position">The position in the draw board.</param>
        /// <param name="color">The color the character at the specified position should have.</param>
        public void SetTrackColor(Position position, ConsoleColor color)
        {
            this.boardTrackColors[position.Left, position.Top] = color;
        }

        /// <summary>
        /// Invites the specified visitor to visit this class.
        /// </summary>
        /// <param name="visitor">The class that wants to visit this class.</param>
        public void Accept(IExecutionVisitor visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException();
            }

            visitor.Visit(this);
        }
    }
}
