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

namespace Mine_Sweeper.Commands
{
    public class SetFlagCommand : ICommand
    {
        private Position flagOnPos;

        public SetFlagCommand(int left, int top)
        {
            this.flagOnPos = new Position(left, top);
        }

        public void Visit(GameboardHandler handler)
        {
            Field examinedField = handler.Gameboard.GetFieldAtPosition(flagOnPos);
            if (!examinedField.ShowNumber)
            {
                if (examinedField.HasFlag)
                {
                    examinedField.HasFlag = false;
                }
                else
                {
                    examinedField.HasFlag = true;
                }
            }
        }

        public void Visit(Gameboard board)
        {
            throw new NotImplementedException();
        }

        public void Visit(Cursor cursor)
        {
            throw new NotImplementedException();
        }

        public void Visit(Field field)
        {
            throw new NotImplementedException();
        }
    }
}
