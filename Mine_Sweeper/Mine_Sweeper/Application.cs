using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private InputHandler inputhandler;

        private GameboardHandler gamehandler;

        /// <summary>
        /// The console renderer for this application.
        /// </summary>
        private IRenderer renderer;

        private ConsoleSettings defaultSettings;

        private ConsoleSettings newSettings;

        private bool QuitGame;

        private string GameQuitMessage;

        public Application()
        {
            this.defaultSettings = ConsoleSettings.Fetch();
            this.renderer = new ConsoleRenderer();
            this.gamehandler = new GameboardHandler();
            this.inputhandler = new InputHandler();
            this.GameQuitMessage = string.Empty;
        }

        public void Start()
        {
            ConsoleSettings.SetConsoleSizeToMax();
            newSettings = ConsoleSettings.Fetch();

            this.consoleSizeWatcher = new ConsoleSizeWatcher();
            this.consoleSizeWatcher.Start();
            this.consoleSizeWatcher.OnConsoleSizeChanged += this.RenewInput; // Zum neu erstellen der Anzeige

            this.keyBoardWatcher = new KeyBoardWatcher();
            this.keyBoardWatcher.Start();
            this.keyBoardWatcher.OnKeyPressed += this.UseKeyForInput; // Zum eingeben der Zahlen

            inputhandler.Accept(renderer);

            do
            {

            }
            while (!inputhandler.IsFinished);

            this.consoleSizeWatcher.OnConsoleSizeChanged -= this.RenewInput; // wenn eingabe fertig
            this.consoleSizeWatcher.OnConsoleSizeChanged += this.RenewGameBoard; // zum neu erstellen des gameboards

            this.keyBoardWatcher.OnKeyPressed -= this.UseKeyForInput; // wenn eingabe fertig
            this.keyBoardWatcher.OnKeyPressed += this.UseKeyForGame; // Für bewegen auf spielfeld

            this.inputhandler.Accept(this.gamehandler);

            this.gamehandler.Gameboard.Accept(this.renderer);
            this.gamehandler.Accept(this.renderer);
            this.gamehandler.Cursor.Accept(this.renderer);

            do
            {

            }
            while (!QuitGame);

            // Game Quitting Klasse
            // accept (renderer) -> wenn Mine getroffen (Zeige alle minen)
            // immer danach wenn key gedrückt -> (Console.Clear)

            this.keyBoardWatcher.OnKeyPressed -= this.UseKeyForGame; // wenn spiel beendet
            this.consoleSizeWatcher.OnConsoleSizeChanged -= this.RenewGameBoard; // zum neu erstellen des gameboards



            this.keyBoardWatcher.Stop();
            this.consoleSizeWatcher.Stop();
            ConsoleSettings.ChangeTo(this.defaultSettings);
        }

        public bool Stop()
        {
            // Abfragen ob neues Spiel
            // wenn ja neues Spiel

            // wenn nicht:

            // wenn applikation beendet wird
            return true;
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
            }

            this.IsGameFinished();
        }

        private bool IsGameFinished()
        {
            int flaggedMinescount = 0;
            int discoveredFieldcount = 0;

            foreach (Field field in gamehandler.Gameboard.Gamefields)
            {
                if (field.HasMine && field.ShowNumber)
                {
                    QuitGame = true;
                    GameQuitMessage = "KABUMM! You tapped on a mine. Do you want to try a new game?";
                    break;
                }

                if (field.HasMine && field.HasFlag)
                {
                    flaggedMinescount++;
                    if (flaggedMinescount >= gamehandler.Gameboard.MineCount)
                    {
                        QuitGame = true;
                        GameQuitMessage = "Congratulations! You win. Do you want to try a new game?";
                        break;
                    }
                }

                if (!field.HasMine && field.ShowNumber)
                {
                    discoveredFieldcount++;
                    if (discoveredFieldcount >= gamehandler.Gameboard.Gamefields.Count - gamehandler.Gameboard.MineCount)
                    {
                        QuitGame = true;
                        GameQuitMessage = "Congratulations! You win. Do you want to try a new game?";
                        break;
                    }
                }
            }
            
            return false;
        }

        private void RenewInput(object sender, OnConsoleSizeChangedEventArgs eventArgs)
        {
            if (eventArgs == null)
            {
                throw new ArgumentNullException();
            }

            ConsoleSettings.ChangeTo(newSettings);

        }

        private void RenewGameBoard(object sender, OnConsoleSizeChangedEventArgs eventArgs)
        {
            if (eventArgs == null)
            {
                throw new ArgumentNullException();
            }

            ConsoleSettings.ChangeTo(newSettings);
        }
    }
}

