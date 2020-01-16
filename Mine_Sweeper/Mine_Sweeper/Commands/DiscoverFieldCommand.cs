using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mine_Sweeper.Commands;
using Mine_Sweeper.ConsoleWatcher;
using Mine_Sweeper.Interfaces;
using Mine_Sweeper.Game_board_elements;
using Mine_Sweeper.KeyboardWatcher;

namespace Mine_Sweeper.Commands
{
    public class DiscoverFieldCommand : ICommand
    {
        private Position showAtPos;

        public DiscoverFieldCommand(int left, int top)
        {
            this.showAtPos = new Position(left, top);
        }

        public void Visit(GameboardHandler handler)
        {
            Field examinedField = handler.Gameboard.GetFieldAtPosition(showAtPos);
            if (examinedField != null)
            {
                if (examinedField.HasMine)
                {
                    examinedField.ShowNumber = true;
                    return;
                }
                else if (examinedField.HasFlag || examinedField.ShowNumber)
                {
                    return;
                }
                else if (examinedField.Minenumber > 0)
                {
                    examinedField.ShowNumber = true;
                }
                else
                {
                    examinedField.ShowNumber = true;

                    Position originPosition = new Position(examinedField.Position.Left - 1, examinedField.Position.Top - 1);
                    for (int y = 0; y < 3; y++)
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            DiscoverFieldCommand gamecommand = new DiscoverFieldCommand(originPosition.Left + x, originPosition.Top + y);
                            gamecommand.Visit(handler);
                        }
                    }
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
