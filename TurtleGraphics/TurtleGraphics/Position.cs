//-----------------------------------------------------------------------
// <copyright file="Position.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the Position struct.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    /// <summary>
    /// Represents the <see cref="Position"/> struct.
    /// </summary>
    public struct Position
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> struct.
        /// </summary>
        /// <param name="left">The horizontal position of an object.</param>
        /// <param name="top">The vertical position of an object.</param>
        public Position(int left, int top)
        {
            this.Left = left;
            this.Top = top;
        }

        /// <summary>
        /// Gets or sets the horizontal position of an element.
        /// </summary>
        /// <value>
        /// The horizontal position of an element.
        /// </value>
        public int Left
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the vertical position of an element.
        /// </summary>
        /// <value>
        /// The vertical position of an element.
        /// </value>
        public int Top
        {
            get;
            set;
        }
    }
}
