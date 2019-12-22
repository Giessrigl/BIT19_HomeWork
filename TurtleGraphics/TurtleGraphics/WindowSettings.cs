//-----------------------------------------------------------------------
// <copyright file="WindowSettings.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the WindowSettings class.
// It ensures that the console window is at max size.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    using System;

    /// <summary>
    /// Represents the <see cref="WindowSettings"/> class.
    /// </summary>
    public class WindowSettings
    {
        /// <summary>
        /// This method sets the console window size to the maximum size and makes the cursor invisible.
        /// </summary>
        public void SetWindowToMax()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        }

        /// <summary>
        /// This method gets the current height of the console window.
        /// </summary>
        /// <returns>The current height of the console window.</returns>
        public int GetWindowHeight()
        {
            return Console.WindowHeight;
        }

        /// <summary>
        /// This method gets the current width of the console window.
        /// </summary>
        /// <returns>The current width of the console window.</returns>
        public int GetWindowWidth()
        {
            return Console.WindowWidth;
        }
    }
}
