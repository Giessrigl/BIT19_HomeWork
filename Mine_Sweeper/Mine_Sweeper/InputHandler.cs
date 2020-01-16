using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mine_Sweeper.Commands;
using Mine_Sweeper.ConsoleWatcher;
using Mine_Sweeper.Interfaces;
using Mine_Sweeper.Game_board_elements;
using Mine_Sweeper.KeyboardWatcher;

namespace Mine_Sweeper
{
    public class InputHandler : IInputVisitable
    {
        private string text = "";

        public bool Error
        {
            get;
            set;
        }

        public string Text
        {
            get
            {
                return this.text;
            }
            private set
            {
                this.text = value;
            }
        }

        public int Height
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public int Mines
        {
            get;
            set;
        }

        public bool IsFinished
        {
            get;
            set;
        }

        public InputHandler()
        {
            this.Error = false;
        }

        public void AcceptKey(ConsoleKeyInfo cki)
        {
            this.Error = false;
            if (!char.IsControl(cki.KeyChar))
            {
                if (text.Length < 5)
                {
                    text += cki.KeyChar;
                }
            }
            else
            {
                switch (cki.Key)
                {
                    case ConsoleKey.Enter:
                        try
                        {
                            int number = int.Parse(text);
                            if (number > 0)
                            {
                                if (this.Height <= 0)
                                {
                                    this.Height = number;
                                }
                                else if (this.Width <= 0)
                                {
                                    this.Width = number;
                                }
                                else if (this.Mines <= 0)
                                {
                                    this.Mines = number;
                                }
                                this.text = "";
                            }
                        }
                        catch
                        {
                            this.Error = true;
                        }
                        break;

                    case ConsoleKey.Backspace:
                        if (text.Length > 0)
                        {
                            text = text.Remove(text.Length - 1);
                        }
                        break;
                }
            }
        }

        public void Accept(IInputVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
