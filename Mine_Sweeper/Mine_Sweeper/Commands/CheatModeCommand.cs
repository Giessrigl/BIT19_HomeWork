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
    public class CheatModeCommand : ICommand
    {
        public void Visit(GameboardHandler handler)
        {
            if (handler.IsCheatModeOn)
            {
                handler.IsCheatModeOn = false;
            }
            else if (!handler.IsCheatModeOn)
            {
                handler.IsCheatModeOn = true;
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
