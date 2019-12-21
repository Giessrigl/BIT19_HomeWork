//-----------------------------------------------------------------------
// <copyright file="NewCommand.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the NewCommand class.
// It ensures that a new turtle can be added.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.EditorCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class NewCommand : IEditorCommand
    {
        public static IEditorCommand Parse(string commandLine)
        {
            string[] possibleCommands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            if (possibleCommands.Length > 1)
            {
                return null;
            }
            else
            {
                return new NewCommand();
            }
        }

        public void Visit(InputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException();
            }

            if (handler.EditorReadOut.Count >= 1)
            {
                handler.EditorReadOut.Clear();
                handler.text = string.Empty;
                handler.PageNumber = 1;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Visit(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            
            user.Turtleargs.Add(new TurtleAttributes());
        }

        public void Visit(ErrorMessage errormessage)
        {
            errormessage.Message = "A new turtle could not be added. Please give this turtle at least one command.";
        }
    }
}
