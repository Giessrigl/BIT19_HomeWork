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
    public class ConsoleRenderer : IRenderer
    {
        private int gameboardheight;

        private int gameboardwidth;

        public void Visit(InputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException();
            }
            int maxheight = ((Console.WindowHeight - 1 - 5 ) / 2);
            int maxwidth = ((Console.WindowWidth - 1 - 5) / 4) ;

            Console.Clear();
            if (handler.Error == true)
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Please enter only positive whole numbers!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (handler.Height > maxheight)
            {
                handler.Height = 0;
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Please type in a number between 1 and {maxheight}!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (handler.Width > maxwidth)
            {
                handler.Width = 0;
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Please type in a number between 1 and {maxwidth}!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (handler.Mines > (handler.Height * handler.Width))
            {
                handler.Mines = 0;
                int maxMines = handler.Height * handler.Width;
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Please type in a number between 1 and {maxMines}!");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.SetCursorPosition(0, 1);
            Console.Write("Please type in the height of the game board: ");
            if (handler.Height > 0)
            {
                Console.WriteLine(handler.Height);
                Console.Write("Please type in the width of the game board: ");
                if (handler.Width > 0)
                {
                    Console.WriteLine(handler.Width);
                    Console.Write("Please type in the amount of mines: ");
                    if (handler.Mines > 0)
                    {
                        Console.Clear();
                        handler.IsFinished = true;
                        if (handler.Height * handler.Width >= 300)
                        {
                            Console.SetCursorPosition(0, 1);
                            Console.Write("Please be patient. Calculating the mines may take some time.");
                        }
                    }
                    else
                    {
                        Console.Write(handler.Text);
                    }
                }
                else
                {
                    Console.Write(handler.Text);
                }
            }
            else
            {
                Console.Write(handler.Text);
            }

        }

        public void Visit(GameboardHandler handler)
        {
            if (handler.IsGameFinished)
            {
                for (int i = 0; i < gameboardheight; i++)
                {
                    for (int j = 0; j < gameboardwidth; j++)
                    {
                        Console.SetCursorPosition(j * 4 + 6, i * 2 + 1);
                        Field examinedField = handler.Gameboard.GetFieldAtPosition(new Position(j, i));
                        if (examinedField.HasMine)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" X ");
                        }
                    }
                }
            }
            else
            {
                if (handler.IsCheatModeOn)
                {
                    for (int i = 0; i < gameboardheight; i++)
                    {
                        for (int j = 0; j < gameboardwidth; j++)
                        {
                            Console.SetCursorPosition(j * 4 + 6, i * 2 + 1);
                            Field examinedField = handler.Gameboard.GetFieldAtPosition(new Position(j, i));
                            if (examinedField.HasMine)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(" X ");
                            }
                            else
                            {
                                if (examinedField.Minenumber > 0)
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write(" " + examinedField.Minenumber + " ");

                                }
                                else
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write("   ");
                                }
                            }
                        }
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    for (int i = 0; i < gameboardheight; i++)
                    {
                        for (int j = 0; j < gameboardwidth; j++)
                        {
                            Field examinedField = handler.Gameboard.GetFieldAtPosition(new Position(j, i));
                            Console.SetCursorPosition(j * 4 + 6, i * 2 + 1);
                            if (examinedField.HasFlag)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" X ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (examinedField.ShowNumber)
                            {
                                if (examinedField.HasMine)
                                {
                                    return;
                                }
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition(j * 4 + 6, i * 2 + 1);
                                if (examinedField.Minenumber > 0)
                                {
                                    Console.Write(" " + examinedField.Minenumber + " ");
                                }
                                else
                                {
                                    Console.Write("   ");
                                }
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.Write("   ");
                            }
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    this.DrawField(handler.Cursor.Position.Left, handler.Cursor.Position.Top);
                }
            }
        }

        public void Visit(Gameboard board)
        {
            Console.Clear();

            this.gameboardheight = board.Height;
            this.gameboardwidth = board.Width;

            for (int i = 0; i < this.gameboardheight; i++)
            {
                for (int j = 0; j < this.gameboardwidth; j++)
                {
                    this.DrawField(j, i);
                }
            }
        }

        private void DrawField(int left, int top)
        {
            Console.SetCursorPosition(left * 4 + 5, top * 2);
            Console.Write("+---+");
            Console.SetCursorPosition(left * 4 + 5, top * 2 + 1);
            Console.Write("|");
            Console.SetCursorPosition(left * 4 + 9, top * 2 + 1);
            Console.Write("|");
            Console.SetCursorPosition(left * 4 + 5, top * 2 + 2);
            Console.Write("+---+");

        }

        public void Visit(Cursor cursor)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            this.DrawField(cursor.Position.Left, cursor.Position.Top);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Visit(Field field)
        {
            this.DrawField(field.Position.Left, field.Position.Top);
        }

        public void Visit(GameFinisher finisher)
        {
            if (finisher.IsGameFinishAccepted)
            {
                if (finisher.IsAnswerCorrect)
                {
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Do you want to play a new game?");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(0, 2);
                    Console.Write(finisher.ErrorMessage);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.SetCursorPosition(5, 0);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(finisher.QuitMessage);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
