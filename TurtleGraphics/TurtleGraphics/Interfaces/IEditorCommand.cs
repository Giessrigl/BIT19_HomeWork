//-----------------------------------------------------------------------
// <copyright file="IEditorCommand.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the IEditorCommand interface.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.Interfaces
{
    /// <summary>
    /// This interface exists to give the editor commands the things they need.
    /// </summary>
    public interface IEditorCommand : IEditorVisitor
    {
    }
}
