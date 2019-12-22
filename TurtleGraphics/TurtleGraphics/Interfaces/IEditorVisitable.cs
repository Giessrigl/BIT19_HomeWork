//-----------------------------------------------------------------------
// <copyright file="IEditorVisitable.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the IEditorVisitable interface.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.Interfaces
{
    /// <summary>
    /// This interface exists to ensure that the classes of the editor stuff that can be visited have an accept method.
    /// </summary>
    public interface IEditorVisitable
    {
        /// <summary>
        /// Invites the visiting object in.
        /// </summary>
        /// <param name="visitor">The visiting object.</param>
        void Accept(IEditorVisitor visitor);
    }
}
