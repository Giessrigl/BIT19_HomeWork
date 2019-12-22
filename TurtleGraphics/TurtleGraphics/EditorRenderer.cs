//-----------------------------------------------------------------------
// <copyright file="EditorRenderer.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the EditorRenderer class.
// It ensures that the users inputs will be displayed correctly in the console.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// This class is responsible for the console display of the command writing part of the application.
    /// </summary>
    public class EditorRenderer : IEditorVisitor
    {
        /// <summary>
        /// This method writes all instructions, valid commands and the users current input into the console.
        /// </summary>
        /// <param name="handler">The input handler object of where the commands will be written into the console.</param>
        public void Visit(InputHandler handler)
        {
            int overwrite = 0;
            if (handler.Text.Length > Console.WindowWidth)
            {
                overwrite = handler.Text.Length - Console.WindowWidth;
            }

            Console.Clear();
            int pagenumber = handler.PageNumber;

            if (handler.EditorReadOut.Count > 10)
            {
                Console.SetCursorPosition(0, 14);
                Console.Write("Use the arrow keys to switch between the command sites.");

                Console.SetCursorPosition(0, 15);
                Console.Write($"Page number: {pagenumber}");
            }

            for (int i = 0; i < handler.EditorReadOut.Count + 10 - (pagenumber * 10) && i < 10; i++)
            {
                Console.SetCursorPosition(0, i + 2);
                Console.ForegroundColor = ConsoleColor.Blue;

                string turtleCommand = handler.EditorReadOut[(pagenumber * 10) - 10 + i].TurtleCommand;
                Console.Write($"{turtleCommand}");

                if (turtleCommand == "Move" || turtleCommand == "Rotate" || turtleCommand == "Sleep")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (turtleCommand == "ChangeColor" || turtleCommand == "ChangeTurtleSymbol" || turtleCommand == "ChangeTrackSymbol")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }

                Console.Write($" {handler.EditorReadOut[pagenumber * 10 - 10 + i].TurtleValue}");
            }

            Console.ForegroundColor = ConsoleColor.White;
            if (handler.EditorReadOut.Count + 10 - (pagenumber * 10) < 10)
            {
                Console.SetCursorPosition(0, handler.EditorReadOut.Count + 10 - (pagenumber * 10) + 2);
            }
            else
            {
                Console.SetCursorPosition(0, 10 + 2);
            }

            for (int i = 0; i < handler.Text.Length; i++)
            {
                if (i < Console.WindowWidth)
                {
                    Console.Write($"{handler.Text[i + overwrite]}");
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Is not necessary.
        /// </summary>
        /// <param name="user">The object where all turtle commands are stored.</param>
        public void Visit(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method writes the specific error message into the console.
        /// </summary>
        /// <param name="errormessage">The error message object of where the message will be written.</param>
        public void Visit(ErrorMessage errormessage)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{errormessage.Message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
