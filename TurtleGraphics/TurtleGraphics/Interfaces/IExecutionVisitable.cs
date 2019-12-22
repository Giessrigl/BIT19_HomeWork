//-----------------------------------------------------------------------
// <copyright file="IExecutionVisitable.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the IExecutionVisitable interface.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// This interface exists to ensure that the classes of the execution stuff that can be visited have an accept method.
    /// </summary>
    public interface IExecutionVisitable
    {
        /// <summary>
        /// Invites the visiting object in.
        /// </summary>
        /// <param name="visitor">The visiting object.</param>
        void Accept(IExecutionVisitor visitor);
    }
}