//-----------------------------------------------------------------------
// <copyright file="OnKeyPressedEventArgs.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the OnKeyPressedEventArgs class.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    using System;

    /// <summary>
    /// Represents the <see cref="OnKeyPressedEventArgs"/> class.
    /// </summary>
    public class OnKeyPressedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnKeyPressedEventArgs"/> class.
        /// </summary>
        /// <param name="cki">The key that has been pressed.</param>
        public OnKeyPressedEventArgs(ConsoleKeyInfo cki)
        {
            this.KeyInfo = cki;
        }

        /// <summary>
        /// Gets the key that has been pressed.
        /// </summary>
        /// <value>
        /// The key that has been pressed.
        /// </value>
        public ConsoleKeyInfo KeyInfo
        {
            get;
            private set;
        }
    }
}