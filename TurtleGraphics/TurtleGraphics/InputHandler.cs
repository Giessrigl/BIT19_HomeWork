namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;
    using System.Collections.Generic;

    public class InputHandler : IEditorVisitable
    {
        public InputHandler()
        {
            this.EditorReadOut = new List<EditorLine>();
            this.text = "";
        }

        public List<EditorLine> EditorReadOut
        {
            get;
            set;
        }

        public string text
        {
            get;
            set;
        }

        public void Start(ConsoleKeyInfo cki)
        {
            if (cki.Key == ConsoleKey.Spacebar)
            {
                text += " ";

            }
            else if (cki.Key == ConsoleKey.Backspace && text.Length > 0)
            {
                string newText = "";
                for (int i = 0; i < text.Length - 1; i++)
                {
                    newText += text[i];
                }
                text = newText;
            }

            else if (text.Length < Console.WindowWidth)
            {
                text += cki.KeyChar;
            }
        }

        public void Accept(IEditorVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
