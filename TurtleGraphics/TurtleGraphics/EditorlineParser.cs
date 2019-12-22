//-----------------------------------------------------------------------
// <copyright file="EditorlineParser.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the EditorlineParser class.
// It ensures that in the end the commands the user writes will only be valid commands.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// This class is responsible for proofing if the command the user writes is valid or not.
    /// </summary>
    public class EditorlineParser
    {
        /// <summary>
        /// This method checks if the command line has a valid length and a valid editor command in the first place.
        /// </summary>
        /// <param name="commandLine">The command line the user has written.</param>
        /// <returns>
        /// A full instanced command if the command line is valid or null if the command line is not valid.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If commandLine is null or whitespace.
        /// </exception>
        public IEditorCommand Parse(string commandLine)
        {
            if (string.IsNullOrWhiteSpace(commandLine))
            {
                throw new ArgumentNullException();
            }

            string[] possibleCommands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string editorCommand = possibleCommands[0].ToLower();

            if (possibleCommands.Length > 4)
            {
                return null;
            }
            else
            {
                switch (editorCommand)
                {
                    case "add":
                        return AddCommand.Parse(commandLine);

                    case "clear":
                        return ClearCommand.Parse(commandLine);

                    case "insert":
                        return InsertCommand.Parse(commandLine);

                    case "remove":
                        return RemoveCommand.Parse(commandLine);

                    case "new":
                        return NewCommand.Parse(commandLine);

                    case "run":
                        return RunCommand.Parse(commandLine);

                    default:
                        return null;
                }
            }
        }
    }
}
