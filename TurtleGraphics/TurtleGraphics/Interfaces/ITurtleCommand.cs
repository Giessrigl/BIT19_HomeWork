//-----------------------------------------------------------------------
// <copyright file="ITurtleCommand.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the ITurtleCommand interface.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.Interfaces
{
    /// <summary>
    /// This interface exists to give the turtle commands the things they need.
    /// </summary>
    public interface ITurtleCommand : IExecutionVisitor
    {
        /// <summary>
        /// Gets the value of the turtle command.
        /// </summary>
        /// <returns>The value of the turtle command.</returns>
        string GetValue();
    }
}
