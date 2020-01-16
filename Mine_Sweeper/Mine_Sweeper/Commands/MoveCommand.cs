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
    public class MoveCommand : ICommand
    {
        private Position moveToPos;

        public MoveCommand(int left, int top)
        {
            this.moveToPos = new Position(left, top);
        }

        public void Visit(GameboardHandler handler)
        {
            if (this.moveToPos.Left >= 0 && this.moveToPos.Top >= 0)
            {
                if (this.moveToPos.Left < handler.Gameboard.Width && this.moveToPos.Top < handler.Gameboard.Height)
                {
                    handler.Cursor.Position = this.moveToPos;
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
