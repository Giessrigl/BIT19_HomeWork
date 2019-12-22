//-----------------------------------------------------------------------
// <copyright file="Turtle.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the Turtle class.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    using System;
    using System.Collections.Generic;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// Represents the <see cref="Turtle"/> class.
    /// </summary>
    public class Turtle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Turtle"/> class.
        /// </summary>
        public Turtle()
        {
            this.Commands = new List<ITurtleCommand>();
        }

        /// <summary>
        /// Gets or sets the turtle commands this turtle has.
        /// </summary>
        /// <value>
        /// The turtle commands this turtle has.
        /// </value>
        /// <exception cref="ArgumentNullException">
        /// If value is null.
        /// </exception>
        public List<ITurtleCommand> Commands
        {
            get;
            set;
        }
    }
}
