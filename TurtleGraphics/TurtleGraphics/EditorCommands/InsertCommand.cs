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
        /// The position at where the turtle command will be inserted.
        /// </summary>
        private int editorValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="InsertCommand"/> class.
        /// </summary>
        /// <param name="editorValue">The position at where the turtle command should be inserted.</param>
        /// <param name="turtleCommand">The specified turtle command that should be inserted.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If the editor value is less than zero.
        /// </exception>
        public InsertCommand(int editorValue, ITurtleCommand turtleCommand)
        {
            if (editorValue < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.editorValue = editorValue;
            this.TurtleCommand = turtleCommand;
        }

        /// <summary>
        /// Gets the turtle command that will be inserted.
        /// </summary>
        /// <value>
        /// The turtle command that will be inserted.
        /// </value>
        public ITurtleCommand TurtleCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// This method checks if the command line has a valid insert command at the valid position.
        /// </summary>
        /// <param name="commandLine">The command line the user has written.</param>
        /// <exception cref="ArgumentNullException">
        /// If the commandLine is null.
        /// </exception>
        /// <returns>An instanced insert command if the command is valid or null if the command is not valid.</returns>
        public static IEditorCommand Parse(string commandLine)
        {
            if (commandLine == null)
            {
                throw new ArgumentNullException();
            }

            string[] possibleCommands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (possibleCommands.Length < 3)
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

        /// <summary>
        /// Inserts a turtle command to the current command list at the given position.
        /// </summary>
        /// <param name="user">The object where all turtle commands are stored.</param>
        /// <exception cref="ArgumentNullException">
        /// If the user is null.
        /// </exception>
        public void Visit(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            user.TurtleAttributes[user.TurtleAttributes.Count - 1].Turtle.Commands.Insert(this.editorValue - 1, this.TurtleCommand);
        }

        /// <summary>
        /// This method inserts a new command line to the list of valid command lines at the given position.
        /// </summary>
        /// <param name="handler">The input handler object where the command line should be stored.</param>
        /// <exception cref="ArgumentNullException">
        /// If the handler is null.
        /// </exception>
        public void Visit(InputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException();
            }

            EditorLine line = new EditorLine(this.TurtleCommand.ToString(), turtleValue);
            handler.EditorReadOut.Insert(this.editorValue - 1, line);
        }

        /// <summary>
        /// This method changes the error message objects message to a specific error message.
        /// </summary>
        /// <param name="errormessage">The error message object where the message should be changed.</param>
        /// <exception cref="ArgumentNullException">
        /// If the error message is null.
        /// </exception>
        public void Visit(ErrorMessage errormessage)
        {
            if (errormessage == null)
            {
                throw new ArgumentNullException();
            }

            errormessage.Message = "We could not insert your command at this position.";
        }
    }
}