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
            int overwrite = 0;
            if (handler.text.Length > Console.WindowWidth)
            {
                overwrite = handler.text.Length - Console.WindowWidth;
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

                string turtleCommand = handler.EditorReadOut[pagenumber * 10 - 10 + i].TurtleCommand;
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
            for (int i = 0; i < handler.text.Length; i++)
            {
                if (i < Console.WindowWidth)
                {
                    Console.Write($"{handler.text[i + overwrite]}");
                }
                else
                {
                    break;
                }
            }
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
