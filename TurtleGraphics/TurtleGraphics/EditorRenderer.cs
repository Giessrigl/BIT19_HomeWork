namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class EditorRenderer : IEditorVisitor
    {
        public void Visit(InputHandler handler)
        {
            Console.Clear();
            int pagenumber = handler.PageNumber;

            if (handler.EditorReadOut.Count > 10)
            {
                Console.SetCursorPosition(0, 1);
                Console.Write("Use the arrow keys to switch between the command sites.");
            }

            for (int i = 0; i < handler.EditorReadOut.Count + 10 - (pagenumber * 10) && i < 10; i++)
            {
                Console.SetCursorPosition(0, i + 2);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{handler.EditorReadOut[pagenumber * 10 - 10 + i].TurtleCommand}");

                string check = handler.EditorReadOut[i].TurtleCommand;

                if (check == "Move" || check == "Rotate" || check == "Sleep")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (check == "ChangeColor" || check == "ChangeTurtleSymbol" || check == "ChangeTrackSymbol")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                Console.Write($" {handler.EditorReadOut[pagenumber * 10 - 10 + i].TurtleValue}");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 14);
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
