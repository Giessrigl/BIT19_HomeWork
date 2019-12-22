//-----------------------------------------------------------------------
// <copyright file="AddCommand.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the AddCommand class.
// It ensures that new turtle commands can be added to the currently available turtle.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics.EditorCommands
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.TurtleCommands;

    /// <summary>
    /// This class is responsible for adding a new turtle command to the list.
    /// </summary>
    public class AddCommand : IEditorCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddCommand"/> class.
        /// </summary>
        /// <param name="turtleCommand">The turtle command that should be added to the last added turtle.</param>
        public AddCommand(ITurtleCommand turtleCommand)
        {
            this.TurtleValue = turtleCommand.GetValue();
            this.TurtleCommand = turtleCommand;
        }

        /// <summary>
        /// Gets the value of the valid turtle command.
        /// </summary>
        /// <value>
        /// The value of the valid turtle command.
        /// </value>
        public string TurtleValue
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the valid turtle command.
        /// </summary>
        /// <value>
        /// The valid turtle command.
        /// </value>
        public ITurtleCommand TurtleCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// This method checks if the command line has a valid add command at the valid position.
        /// </summary>
        /// <param name="commandLine">The command line the user has written.</param>
        /// <returns>An instanced add command if the command is valid or null if the command is not valid.</returns>
        public static IEditorCommand Parse(string commandLine)
        {
            if (commandLine == null)
            {
                throw new ArgumentNullException();
            }

            string[] possibleCommands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (possibleCommands.Length <= 1 || possibleCommands.Length >= 4)
            {
                return null;
            }

            string command = possibleCommands[1].ToLower();
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

            if (turtleCommand != null)
            {
                return new AddCommand(turtleCommand);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Adds the current turtle command to the command list.
        /// </summary>
        /// <param name="user">The object where all turtle commands are stored.</param>
        public void Visit(User user)
        {
            user.Turtleargs[user.Turtleargs.Count - 1].Turtle.Commands.Add(this.TurtleCommand);
        }

        /// <summary>
        /// This method adds a new command line to the list of valid command lines.
        /// </summary>
        /// <param name="handler">The input handler object where the command line should be stored.</param>
        public void Visit(InputHandler handler)
        {
            EditorLine line = new EditorLine(this.TurtleCommand.ToString(), this.TurtleValue);
            handler.EditorReadOut.Add(line);
        }

        /// <summary>
        /// This method changes the error message objects message to a specific error message.
        /// </summary>
        /// <param name="errormessage">The error message object where the message should be changed.</param>
        public void Visit(ErrorMessage errormessage)
        {
            errormessage.Message = "We could not add this entry.";
        }
    }
}
