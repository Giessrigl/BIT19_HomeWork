//-----------------------------------------------------------------------
// <copyright file="KeyboardWatcherThreadArguments.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the KeyboardWatcherThreadArguments class.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    /// <summary>
    /// Represents the <see cref="KeyboardWatcherThreadArguments"/> class.
    /// </summary>
    public class KeyboardWatcherThreadArguments
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardWatcherThreadArguments"/> class.
        /// </summary>
        public KeyboardWatcherThreadArguments()
        {
            this.Exit = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the keyboard watcher shall exit or not.
        /// </summary>
        /// <value>
        /// The value indicating whether the keyboard watcher shall exit or not.
        /// </value>
        public bool Exit
        {
            get;
            set;
        }
    }
}