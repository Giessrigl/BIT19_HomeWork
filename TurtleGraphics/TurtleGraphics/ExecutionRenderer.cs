namespace TurtleGraphics
{
    using System;
    using System.Collections.Generic;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class ExecutionRenderer : IExecutionVisitor
    {
        public ExecutionRenderer()
        {
        }

        public void Visit(DrawBoard board)
        {
            Console.Clear();

            for (int i = 0; i < board.TrackPositions.Count; i++)
            {
                Console.SetCursorPosition(board.TrackPositions[i].Left, board.TrackPositions[i].Top);
                Console.ForegroundColor = board.GetTrackColor(board.TrackPositions[i]);
                Console.Write($"{board.GetTrackChar(board.TrackPositions[i])}");
            }

            for (int i = 0; i < board.BoardTurtles.Count; i++)
            {
                Console.SetCursorPosition(board.BoardTurtles[i].Position.Left, board.BoardTurtles[i].Position.Top);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{board.BoardTurtles[i].TurtleSymbol}");
            }
        }

        public void Visit(TurtleArguments args)
        {
            // do nothing.
        }
    }
}