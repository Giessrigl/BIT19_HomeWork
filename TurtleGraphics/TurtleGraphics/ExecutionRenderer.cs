namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;

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

            for (int i = 0; i < board.Turtles.Count; i++)
            {
                Console.SetCursorPosition(board.Turtles[i].Position.Left, board.Turtles[i].Position.Top);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{board.Turtles[i].TurtleSymbol}");
            }
        }

        public void Visit(TurtleAttributes args)
        {
            // do nothing.
        }
    }
}