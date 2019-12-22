//-----------------------------------------------------------------------
// <copyright file="ExecutionRenderer.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the ExecutionRenderer class.
// It ensures that the turtles and tracks will be displayed correctly in the console.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// This class is responsible for the console display of the turtle command execution part of the application.
    /// </summary>
    public class ExecutionRenderer : IExecutionVisitor
    {
        /// <summary>
        /// Displays the turtles and tracks of the specific draw board in the console.
        /// </summary>
        /// <param name="board">The draw board where the turtles and tracks are stored.</param>
        /// <exception cref="ArgumentNullException">
        /// If board is null.
        /// </exception>
        public void Visit(DrawBoard board)
        {
            if (board == null)
            {
                throw new ArgumentNullException();
            }

            Console.Clear();

            for (int i = 0; i < board.TrackPositions.Count; i++)
            {
                Console.SetCursorPosition(board.TrackPositions[i].Left, board.TrackPositions[i].Top);
                Console.ForegroundColor = board.GetTrackColor(board.TrackPositions[i]);
                Console.Write($"{board.GetTrackChar(board.TrackPositions[i])}");
            }

            for (int i = 0; i < board.Turtles.Count; i++)
            {
                Console.SetCursorPosition(board.Turtles[i].Position.Left, board.Turtles[i].Position.Top);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{board.Turtles[i].TurtleSymbol}");
            }
        }

        /// <summary>
        /// Is not necessary.
        /// </summary>
        /// <param name="attributes">The attributes of a turtle.</param>
        /// <exception cref="ArgumentNullException">
        /// If attributes is null.
        /// </exception>
        public void Visit(TurtleAttributes attributes)
        {
            if (attributes == null)
            {
                throw new ArgumentNullException();
            }

            // do nothing.
        }
    }
}