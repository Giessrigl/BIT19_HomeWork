//-----------------------------------------------------------------------
// <copyright file="ErrorMessage.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the ErrorMessage class.
// It stores a specific string to explain the user what he/she did wrong.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// This class stores a specific string to explain the user what he/she did wrong.
    /// </summary>
    public class ErrorMessage : IEditorVisitable
    {
        /// <summary>
        /// The error message for the user.
        /// </summary>
        private string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorMessage" /> class.
        /// </summary>
        /// <param name="message">The message the user should to see.</param>
        /// <exception cref="ArgumentNullException">
        /// If message is null.
        /// </exception>
        public ErrorMessage(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException();
            }

            this.Message = message;
        }

        /// <summary>
        /// Gets or sets a message for the user.
        /// </summary>
        /// <value>
        /// The message for the user.
        /// </value>
        /// <exception cref="ArgumentNullException">
        /// If value is null.
        /// </exception>
        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.message = value;
            }
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
    }
}
