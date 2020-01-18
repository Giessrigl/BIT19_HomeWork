using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mine_Sweeper.Commands;
using Mine_Sweeper.Interfaces;
using Mine_Sweeper.ConsoleWatcher;
using Mine_Sweeper.Game_board_elements;
using Mine_Sweeper.KeyboardWatcher;

namespace Mine_Sweeper
{
    public class Application
    {
        /// <summary>
        /// The key board watcher used in this application.
        /// </summary>
        private KeyBoardWatcher keyBoardWatcher;

        private ConsoleSizeWatcher consoleSizeWatcher;

        private GameFinisher gameFinisher;

        private InputHandler inputhandler;

        private GameboardHandler gamehandler;

        private Thread inputFinisherThread;

        private Thread gameFinisherThread;
        /// <summary>
        /// The console renderer for this application.
        /// </summary>
        private IRenderer renderer;

        private bool GameFinished;

        private bool QuitGame;

        public bool QuitApp
        {
            get;
            private set;
        }

        public Application()
        {
            this.renderer = new ConsoleRenderer();
            this.consoleSizeWatcher = new ConsoleSizeWatcher();
            this.keyBoardWatcher = new KeyBoardWatcher();
            this.QuitApp = false;
        }

        public void Start()
        {
            this.inputhandler = new InputHandler();
            this.gamehandler = new GameboardHandler();

            this.consoleSizeWatcher.Start();
            this.consoleSizeWatcher.OnSizeChanged += this.RenewInput;

            this.keyBoardWatcher.Start();
            this.keyBoardWatcher.OnKeyPressed += this.UseKeyForInput;

            inputhandler.Accept(renderer);

            this.inputFinisherThread = new Thread(this.RunGame);
            this.inputFinisherThread.Start();

            while (true)
            {
                if (this.QuitGame)
                {
                    break;
                }
            }
        }

        private void UseKeyForInput(object sender, OnKeyPressedEventArgs eventArgs)
        {
            if (eventArgs == null)
            {
                throw new ArgumentNullException();
            }

            ConsoleKeyInfo cki = eventArgs.KeyInfo;
            inputhandler.AcceptKey(cki);
            inputhandler.Accept(renderer);
        }

        private void UseKeyForGame(object sender, OnKeyPressedEventArgs eventArgs)
        {
            if (eventArgs == null)
            {
                throw new ArgumentNullException();
            }

            Field cursorField = new Field(gamehandler.Cursor.Position.Left, gamehandler.Cursor.Position.Top);
            cursorField.Accept(renderer);
            ConsoleKeyInfo cki = eventArgs.KeyInfo;
            Position currentpos = cursorField.Position;
            ICommand gamecommand = null;

            switch (cki.Key)
            {
                case ConsoleKey.UpArrow:
                    currentpos.Top--;
                    gamecommand = new MoveCommand(currentpos.Left, currentpos.Top);
                    break;

                case ConsoleKey.DownArrow:
                    currentpos.Top++;
                    gamecommand = new MoveCommand(currentpos.Left, currentpos.Top);
                    break;

                case ConsoleKey.LeftArrow:
                    currentpos.Left--;
                    gamecommand = new MoveCommand(currentpos.Left, currentpos.Top);
                    break;

                case ConsoleKey.RightArrow:
                    currentpos.Left++;
                    gamecommand = new MoveCommand(currentpos.Left, currentpos.Top);
                    break;

                case ConsoleKey.Enter:
                    gamecommand = new DiscoverFieldCommand(currentpos.Left, currentpos.Top);
                    break;

                case ConsoleKey.X:
                    gamecommand = new SetFlagCommand(currentpos.Left, currentpos.Top);
                    break;

                case ConsoleKey.F12:
                    gamecommand = new CheatModeCommand();
                    break;
            }

            if (gamecommand != null)
            {
                gamehandler.Accept(gamecommand);
                this.gamehandler.Accept(this.renderer);
                this.gamehandler.Cursor.Accept(this.renderer);

                this.IsGameFinished();
            }
        }

        private void IsGameFinished()
        {
            int flaggedMinescount = 0;
            int discoveredFieldcount = 0;
            string GameQuitMessage;

            foreach (Field field in gamehandler.Gameboard.Gamefields)
            {
                if (field.HasMine && field.ShowNumber)
                {
                    GameFinished = true;
                    this.gamehandler.IsGameFinished = true;
                    GameQuitMessage = "You lost because you tapped on a mine. Please press enter to continue.";
                    gameFinisher = new GameFinisher(GameQuitMessage);
                    break;
                }

                if (field.HasMine && field.HasFlag)
                {
                    flaggedMinescount++;
                    if (flaggedMinescount >= gamehandler.Gameboard.MineCount)
                    {
                        GameFinished = true;
                        this.gamehandler.IsGameFinished = true;
                        GameQuitMessage = "Congratulations! You win. Please press enter to continue.";
                        gameFinisher = new GameFinisher(GameQuitMessage);
                        break;
                    }
                }

                if (!field.HasMine && field.ShowNumber)
                {
                    discoveredFieldcount++;
                    if (discoveredFieldcount >= gamehandler.Gameboard.Gamefields.Count - gamehandler.Gameboard.MineCount)
                    {
                        GameFinished = true;
                        this.gamehandler.IsGameFinished = true;
                        GameQuitMessage = "Congratulations! You win. Please press enter to continue.";
                        gameFinisher = new GameFinisher(GameQuitMessage);
                        break;
                    }
                }
            }
        }

        private void RenewInput(object sender, OnSizeChangedEventArgs eventArgs)
        {
            if (eventArgs == null)
            {
                throw new ArgumentNullException();
            }

            inputhandler.Accept(renderer);
        }

        private void RenewGameBoard(object sender, OnSizeChangedEventArgs eventArgs)
        {
            if (eventArgs == null)
            {
                throw new ArgumentNullException();
            }

            this.gamehandler.Gameboard.Accept(this.renderer);
            this.gamehandler.Accept(this.renderer);
            this.gamehandler.Cursor.Accept(this.renderer);
        }

        private void RunGame()
        {
            do
            {
                Thread.Sleep(1000);
            }
            while (!inputhandler.IsFinished);

            this.keyBoardWatcher.OnKeyPressed -= this.UseKeyForInput;
            this.consoleSizeWatcher.OnSizeChanged -= RenewInput;

            this.inputhandler.Accept(renderer);
            this.inputhandler.Accept(this.gamehandler);

            this.gamehandler.Gameboard.Accept(this.renderer);
            this.gamehandler.Accept(this.renderer);
            this.gamehandler.Cursor.Accept(this.renderer);

            this.keyBoardWatcher.OnKeyPressed += this.UseKeyForGame;
            this.consoleSizeWatcher.OnSizeChanged += RenewGameBoard;

            this.gameFinisherThread = new Thread(this.StopGame);
            this.gameFinisherThread.Start();
        }

        private void StopGame()
        {
            do
            {
                Thread.Sleep(1000);
            }
            while (!GameFinished);

            this.keyBoardWatcher.OnKeyPressed -= this.UseKeyForGame; // wenn spiel beendet
            this.consoleSizeWatcher.OnSizeChanged -= this.RenewGameBoard;

            gamehandler.Accept(renderer);
            gameFinisher.Accept(renderer);

            this.keyBoardWatcher.OnKeyPressed += this.UseKeyForRestartAnswer;
            this.consoleSizeWatcher.OnSizeChanged += this.RenewRestartQuestion;
        }

        private void UseKeyForRestartAnswer(object sender, OnKeyPressedEventArgs eventArgs)
        {
            if (eventArgs == null)
            {
                throw new ArgumentNullException();
            }

            ConsoleKeyInfo cki = eventArgs.KeyInfo;
            gameFinisher.AcceptKey(cki);
            gameFinisher.Accept(renderer);

            if (this.gameFinisher.IsGameFinishAccepted)
            {
                this.keyBoardWatcher.OnKeyPressed += this.UseKeyForAppQuit;
            }
        }

        private void UseKeyForAppQuit(object sender, OnKeyPressedEventArgs eventArgs)
        {
            if (eventArgs == null)
            {
                throw new ArgumentNullException();
            }

            ConsoleKeyInfo cki = eventArgs.KeyInfo;

            if (cki.Key == ConsoleKey.J || cki.Key == ConsoleKey.N)
            {
                this.keyBoardWatcher.OnKeyPressed -= this.UseKeyForRestartAnswer;
                this.keyBoardWatcher.OnKeyPressed -= this.UseKeyForAppQuit;
                this.consoleSizeWatcher.OnSizeChanged -= RenewRestartQuestion;

                keyBoardWatcher.Stop();
                consoleSizeWatcher.Stop();

                if (cki.Key == ConsoleKey.J)
                {
                    QuitApp = false;
                    QuitGame = true;
                }
                else if (cki.Key == ConsoleKey.N)
                {
                    QuitApp = true;
                    QuitGame = true;
                }
            }
            
        }

        private void RenewRestartQuestion(object sender, OnSizeChangedEventArgs eventArgs)
        {
            if (eventArgs == null)
            {
                throw new ArgumentNullException();
            }

            gameFinisher.Accept(renderer);
        }
    }
}

