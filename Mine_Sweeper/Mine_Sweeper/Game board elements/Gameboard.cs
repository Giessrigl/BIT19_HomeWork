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
    public class Gameboard : IGameVisitable
    {
        private int height;

        private int width;

        private int mineCount;

        public int Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                this.height = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                this.width = value;
            }
        }

        public int MineCount
        {
            get
            {
                return this.mineCount;
            }
            private set
            {
                this.mineCount = value;
            }
        }

        public List<Field> Gamefields
        {
            get;
            private set;
        }

        public Gameboard(int width, int heigth, int mines)
        {
            this.Height = heigth;
            this.Width = width;
            this.MineCount = mines;
            this.Gamefields = new List<Field>();
            this.BuildFields();
        }

        public Field GetFieldAtPosition(Position position)
        {
            foreach (Field f in this.Gamefields)
            {
                if (f.Position.Left == position.Left && f.Position.Top == position.Top)
                {
                    return f;
                }
            }

            return null;
        }

        private void BuildFields()
        {
            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    Field field = new Field(i, j);
                    this.Gamefields.Add(field);
                }
            }
        }

        public void Accept(IGameVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
