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
    using System;
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
            this.EditingIsFinished = false;
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
        /// Gets a value indicating whether true if the editing part is finished, false if not.
        /// </summary>
        /// <value>
        /// True if the editing part is finished, false if not.
        /// </value>
        public bool EditingIsFinished 
        {
            get;
            private set;
        }

        /// <summary>
        /// Invites the visiting object in.
        /// </summary>
        /// <param name="visitor">The visiting object.</param>
        /// <exception cref="ArgumentNullException">
        /// If visitor is null.
        /// </exception>
        public void Accept(IEditorVisitor visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException();
            }

            visitor.Visit(this);
        }

        /// <summary>
        /// Finishes the editor part with changing editing is finished to true.
        /// </summary>
        public void FinishEditing()
        {
            this.EditingIsFinished = true;
        }
    }
}
