//-----------------------------------------------------------------------
// <copyright file="InsertCommand.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the InsertCommand class.
// It ensures that a new turtle command can be inserted with a specified index to the currently available turtle command list.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.EditorCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.TurtleCommands;

    /// <summary>
    /// Initializes a new instance of the <see cref="InsertCommand"/> class.
    /// </summary>
    /// <param name="turtleCommand">The turtle command that should be added to the last added turtle.</param>
    public class InsertCommand : IEditorCommand
    {
        /// <summary>
        /// Gets the value of the valid turtle command.
        /// </summary>
        /// <value>
        /// The value of the valid turtle command.
        /// </value>
        private static string turtleValue;

        /// <summary>
        /// 
        /// </summary>
        private int EditorValue;

        public InsertCommand(int editorValue, ITurtleCommand turtleCommand)
        {
            if (editorValue < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.EditorValue = editorValue;
            this.turtleCommand = turtleCommand;
        }

        public ITurtleCommand turtleCommand
        {
            get;
            private set;
        }

        public static IEditorCommand Parse(string commandLine)
        {
            if (commandLine == null)
            {
                throw new ArgumentNullException();
            }

            string[] possibleCommands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (3 > possibleCommands.Length)
            {
                return null;
            }

            string value = possibleCommands[1];
            int editorValue;

            try
            {
                editorValue = int.Parse(value);
            }
            catch
            {
                return null;
            }

            string[] newpossibleCommands = new string[possibleCommands.Length - 1];
            newpossibleCommands[0] = possibleCommands[0];

            if (newpossibleCommands.Length == 2)
            {
                newpossibleCommands[1] = possibleCommands[2];
            }
            else if (newpossibleCommands.Length == 3)
            {
                newpossibleCommands[1] = possibleCommands[2];
                newpossibleCommands[2] = possibleCommands[3];
            }

            commandLine = string.Join(" ", newpossibleCommands);
            string command = newpossibleCommands[1].ToLower();
            ITurtleCommand turtleCommand = null;

            switch (command)
            {
                case "move":
                    turtleCommand = MoveCommand.Parse(commandLine);
                    break;

                case "rotate":
                    turtleCommand = RotateCommand.Parse(commandLine);
                    break;

                case "sleep":
                    turtleCommand = SleepCommand.Parse(commandLine);
                    break;

                case "penup":
                    turtleCommand = PenUpCommand.Parse(commandLine);
                    break;

                case "pendown":
                    turtleCommand = PenDownCommand.Parse(commandLine);
                    break;

                case "changecolor":
                    turtleCommand = ChangeColorCommand.Parse(commandLine);
                    break;

                case "changetracksymbol":
                    turtleCommand = ChangeTrackSymbolCommand.Parse(commandLine);
                    break;

                case "changeturtlesymbol":
                    turtleCommand = ChangeTurtleSymbolCommand.Parse(commandLine);
                    break;
            }

            if (turtleCommand != null && editorValue > 0)
            {
                turtleValue = turtleCommand.GetValue();
                return new InsertCommand(editorValue, turtleCommand);
            }
            else
            {
                return null;
            }
        }

        public void Visit(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            user.Turtleargs[user.Turtleargs.Count - 1].Turtle.Commands.Insert(EditorValue - 1, turtleCommand);
        }

        public void Visit(InputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException();
            }

            EditorLine line = new EditorLine(turtleCommand.ToString(), turtleValue);
            handler.EditorReadOut.Insert(EditorValue - 1, line);
        }

        public void Visit(ErrorMessage errormessage)
        {
            errormessage.Message = "We could not insert your command.";
        }
    }
}
