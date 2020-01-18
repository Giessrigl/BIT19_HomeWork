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
    public class GameFinisher : IInputVisitable
    {
        public bool IsAnswerCorrect
        {
            get;
            private set;
        }

        public bool IsGameFinishAccepted
        {
            get;
            private set;
        }

        public string QuitMessage
        {
            get;
            private set;
        }

        public string ErrorMessage
        {
            get;
            private set;
        }

        public GameFinisher(string quitMessage)
        {
            this.QuitMessage = quitMessage;
        }

        public void Accept(IInputVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void AcceptKey(ConsoleKeyInfo cki)
        {
            if (this.IsGameFinishAccepted)
            {
                if (cki.Key == ConsoleKey.J)
                {
                    IsAnswerCorrect = true;
                }
                else if (cki.Key == ConsoleKey.N)
                {
                    IsAnswerCorrect = true;
                }
                else if (char.IsControl(cki.KeyChar))
                {

                }
                else
                {
                    ErrorMessage = "Please press J if you want to play again and N if you do not want to play again!";
                }
            }
            else
            {
                if (cki.Key == ConsoleKey.Enter)
                {
                    IsGameFinishAccepted = true;
                }
            }
        }
    }
}
