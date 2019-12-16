namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class ConsoleRenderer : IRenderer
    {
        public void Visit(InputHandler handler)
        {
            // TODO Achtung: nur den betreffenden Bereich clearen!
            Console.Clear();

            for (int i = 0; i < handler.EditorReadOut.Count; i++)
            {
                Console.SetCursorPosition(0, i + 2);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{handler.EditorReadOut[i].TurtleCommand}");

                string check = handler.EditorReadOut[i].TurtleCommand;

                if (check == "Move" || check == "Rotate" || check == "Sleep")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (check == "ChangeColor" || check == "ChangeTurtleSymbol" || check == "ChangeTrackSymbol")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                Console.Write($" {handler.EditorReadOut[i].TurtleValue}");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, handler.EditorReadOut.Count + 2);
            Console.Write($"{handler.text}");
        }

        public void Visit(User user)
        {
            throw new NotImplementedException();
        }

        public void Visit(ErrorMessage errormessage)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{errormessage.Message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
