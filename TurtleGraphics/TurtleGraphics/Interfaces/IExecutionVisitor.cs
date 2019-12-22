//-----------------------------------------------------------------------
// <copyright file="IExecutionVisitor.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the IExecutionVisitor interface.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.Interfaces
{
    /// <summary>
    /// This interface exists to ensure that the visitors of the execution stuff have their visit methods.
    /// </summary>
    public interface IExecutionVisitor
    {
        /// <summary>
        /// To visit the draw board objects.
        /// </summary>
        /// <param name="board">The object that should be visited.</param>
        void Visit(DrawBoard board);

        /// <summary>
        /// To visit the turtle attributes objects.
        /// </summary>
        /// <param name="attributes">The object that should be visited.</param>
        void Visit(TurtleAttributes attributes);
    }
}