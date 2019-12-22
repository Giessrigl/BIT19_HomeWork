//-----------------------------------------------------------------------
// <copyright file="User.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the User class.
// It is a container for all turtle attributes of all instanced turtles.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    using System.Collections.Generic;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// Represents the <see cref="User"/> class.
    /// </summary>
    public class User : IEditorVisitable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            this.TurtleAttributes = new List<TurtleAttributes>();
            TurtleAttributes baseTurtle = new TurtleAttributes();
            this.TurtleAttributes.Add(baseTurtle);
        }

        /// <summary>
        /// Gets or sets the list of all turtle attributes of all instanced turtles.
        /// </summary>
        /// <value>
        /// The list of all turtle attributes of all instanced turtles.
        /// </value>
        public List<TurtleAttributes> TurtleAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Invites the visiting object in.
        /// </summary>
        /// <param name="visitor">The visiting object.</param>
        public void Accept(IEditorVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
