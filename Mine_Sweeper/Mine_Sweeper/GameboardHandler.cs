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
    public class GameboardHandler : IInputVisitor, IGameVisitable
    {
        private Random rndm;

        public bool IsCheatModeOn
        {
            get;
            set;
        }

        public Gameboard Gameboard { get; private set; }

        public Cursor Cursor
        {
            get;
            private set;
        }

        public GameboardHandler()
        {
            this.rndm = new Random();
            this.Cursor = new Cursor();
        }

        public void Accept(IGameVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Visit(InputHandler handler)
        {
            this.Gameboard = new Gameboard(handler.Width, handler.Height, handler.Mines);
            this.PlaceBombs(this.Gameboard);
            this.CalculateMineNumbers(this.Gameboard);
        }

        private void PlaceBombs(Gameboard board)
        {
            int mines = board.MineCount;
            int counter = 0;
            do
            {
                int bomb = rndm.Next(0, board.Gamefields.Count);

                if (board.Gamefields.ElementAt(bomb).HasMine == false)
                {
                    board.Gamefields.ElementAt(bomb).HasMine = true;
                    counter++;
                }
            }
            while (counter < mines);
        }

        private void CalculateMineNumbers(Gameboard board)
        {
            int height = 0;
            int width = 0;
            while (true)
            {
                if (height >= board.Height && width >= board.Width)
                {
                    break;
                }

                foreach (Field field in board.Gamefields)
                {
                    int minecount = 0;

                    Position originPosition = new Position(field.Position.Left - 1, field.Position.Top - 1);

                    for (int y = 0; y < 3; y++)
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            Field examinedField = board.GetFieldAtPosition(new Position(originPosition.Left + x, originPosition.Top + y));

                            if (examinedField == field)
                            {
                                continue;
                            }

                            if (examinedField != null)
                            {
                                if (examinedField.HasMine)
                                {
                                    minecount++;
                                }
                            }
                        }
                    }

                    field.Minenumber = minecount;
                }

                if (width < board.Width)
                {
                    width++;
                }
                else
                {
                    height++;
                    width = 0;
                }
            }
        }
    }
}
