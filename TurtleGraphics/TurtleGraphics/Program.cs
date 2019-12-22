//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the Program class.
// It is the entry point of the whole application.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    /// <summary>
    /// This class ensures that the application starts after executing the program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Initializes and starts the administrator of the first part of the application.
        /// </summary>
        public static void Main()
        {
            Editor overseer = new Editor();
            overseer.Start();
        }
    }
}
