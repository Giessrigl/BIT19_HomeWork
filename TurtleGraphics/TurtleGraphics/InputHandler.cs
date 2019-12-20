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
            this.PageNumber = 1;
            this.EditorReadOut = new List<EditorLine>();
            this.text = "";
        }

        public int PageNumber;

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
            switch(cki.Key)
            {
                case ConsoleKey.Backspace:
                    string newText = "";
                    for (int i = 0; i < text.Length - 1; i++)
                    {
                        newText += text[i];
                    }
                    text = newText;
                    
                    break;

                case ConsoleKey.LeftArrow:
                    if (this.PageNumber > 1)
                    {
                        this.PageNumber--;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (this.PageNumber < (this.EditorReadOut.Count + 9) / 10)
                    {
                        this.PageNumber++;
                    }
                    break;

                default:
                    if (!char.IsControl(cki.KeyChar))
                    {
                        text += cki.KeyChar;
                    }
                    break;
            }
        }

        public void Accept(IEditorVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
