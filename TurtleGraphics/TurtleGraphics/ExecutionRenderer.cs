namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class ExecutionRenderer : IRenderer, IExecutionVisitor
    {
        public ExecutionRenderer()
        {
            Console.Clear();
        }

        public void Visit(User user)
        {
            // jede turtle position
            // jede turtle symbol

            //zeichne turtle!

            // LEER!
        }

        public void Visit(DrawBoard board)
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                for (int j = 0; j < Console.WindowHeight; j++)
                {
                    if (board.boardcontent[i,j] == '\0')
                    {
                        continue;
                    }
                    else
                    {
                        Position position = new Position(i, j);
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
            Console.Write($"{args.TurtleSymbol}");
        }
    }
}