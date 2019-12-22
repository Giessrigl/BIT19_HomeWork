//-----------------------------------------------------------------------
// <copyright file="IEditorVisitor.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the IEditorVisitor interface.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.Interfaces
{
    /// <summary>
    /// This interface exists to ensure that the visitors of the editor stuff have their visit methods.
    /// </summary>
    public interface IEditorVisitor
    {
        /// <summary>
        /// To visit the user objects.
        /// </summary>
        /// <param name="user">The object that should be visited.</param>
        void Visit(User user);

        /// <summary>
        /// To visit the input handler objects.
        /// </summary>
        /// <param name="handler">The object that should be visited.</param>
        void Visit(InputHandler handler);

        /// <summary>
        /// To visit the error message objects.
        /// </summary>
        /// <param name="errormessage">The object that should be visited.</param>
        void Visit(ErrorMessage errormessage);
    }
}
