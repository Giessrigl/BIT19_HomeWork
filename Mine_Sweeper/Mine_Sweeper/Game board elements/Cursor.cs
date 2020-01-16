using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mine_Sweeper.Commands;
using Mine_Sweeper.ConsoleWatcher;
using Mine_Sweeper.Interfaces;
using Mine_Sweeper.KeyboardWatcher;

namespace Mine_Sweeper.Game_board_elements
{
    public class Cursor : IGameVisitable
    {
        public Cursor()
        {
            this.Position = new Position(0, 0);
        }

        public Position Position
        {
            get;
            set;
        }

        public void Accept(IGameVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
