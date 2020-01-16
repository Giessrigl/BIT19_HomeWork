using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mine_Sweeper.Game_board_elements;

namespace Mine_Sweeper.Interfaces
{
    public interface IGameVisitor
    {
        void Visit(GameboardHandler handler);

        void Visit(Gameboard board);

        void Visit(Cursor cursor);

        void Visit(Field field);
    }
}
