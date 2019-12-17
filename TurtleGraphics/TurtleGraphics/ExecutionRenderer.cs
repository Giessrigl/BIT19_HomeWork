namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class ExecutionRenderer : IExecutionVisitor
    {
        public void Visit(DrawBoard board)
        {
            Console.Clear();
            Position position;

            for (int i = 0; i < Console.WindowWidth - 1; i++)
            {
                for (int j = 0; j < Console.WindowHeight - 1; j++)
                {
                    if (board.boardcontent[i,j] == '\0')
                    {
                        continue;
                    }
                    else
                    {
                        position = new Position(i, j);
                        Console.ForegroundColor = board.GetColor(position);
                        Console.SetCursorPosition(i, j);
                        Console.Write($"{board.GetChar(position)}");
                    }
                }
            }
        }

        public void Visit(TurtleArguments args)
        {
            Console.SetCursorPosition(args.Position.Left, args.Position.Top);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{args.TurtleSymbol}");
        }
    }
}