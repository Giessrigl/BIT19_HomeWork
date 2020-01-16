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
    public class Field : IGameVisitable
    {
        private Position position;

        private int mineNumber;

        public int Minenumber
        {
            get
            {
                return this.mineNumber;
            }
            set
            {
                if (value >= 0 && value <= 8)
                {
                    this.mineNumber = value;
                }
            }
        }

        public Position Position
        {
            get
            {
                return this.position;
            }
            private set
            {
                this.position = value;
            }
        }

        public bool HasMine
        {
            get;
            set;
        }

        public bool ShowNumber
        {
            get;
            set;
        }

        public bool HasFlag
        {
            get;
            set;
        }

        public Field(int left, int top)
        {
            this.Position = new Position(left, top);
        }

        public void Accept(IGameVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
