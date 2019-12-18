namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class ExecutionRenderer : IExecutionVisitor
    {
        public ExecutionRenderer()
        {
            Console.Clear();
        }

        public void Visit(DrawBoard board)
        {
            foreach (Position position in board.TrackPositions)
            {
                Console.SetCursorPosition(position.Left, position.Top);
                Console.ForegroundColor = board.GetColor(position);
                Console.Write($"{board.GetTrackChar(position)}");
            }
        }

        public void Visit(TurtleArguments args)
        {
            if (args.Position.Left >= 0 && args.Position.Top >=0)
            {
                if (args.Position.Left < Console.WindowWidth && args.Position.Top < Console.WindowHeight)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            try
                            {
                                Console.SetCursorPosition(args.Position.Left - 1 + i, args.Position.Top - 1 + j);
                                Console.Write(" ");
                            }
                            catch
                            {

                            }
                        }
                    }
                    Console.SetCursorPosition(args.Position.Left, args.Position.Top);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{args.TurtleSymbol}");
                }
            }
        }
    }
}