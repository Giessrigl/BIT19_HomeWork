using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public class Executioner
    {
        private User User;
        private ExecutionRenderer Renderer;
        private WindowSettings Options;
        private DrawBoard Board;

        private TurtleArguments currentargs;
        private List<Thread> TurtleThreads;

        private static object locker = new object();

        public Executioner(User user)
        {
            this.User = user;
            this.Renderer = new ExecutionRenderer();
            this.Options = new WindowSettings();
            this.Board = new DrawBoard(Options.GetWindowWidth(), Options.GetWindowHeight());
            this.TurtleThreads = new List<Thread>();
        }

        public void Execute()
        {
            foreach (TurtleArguments args in User.Turtleargs)
            {
                this.currentargs = args;
                Thread thread = new Thread(ExecuteCommands);
                thread.Start();
                TurtleThreads.Add(thread);
            }

            //do
            //{
            //    if (TurtleThreads.Count < 1)
            //    {
            //        KeyBoardWatcher keyBoardWatcher = new KeyBoardWatcher();
            //        keyBoardWatcher.OnKeyPressed += TerminateApplication;
            //    }
            //}
            //while (true);
        }

        private void ExecuteCommands()
        {
            TurtleArguments args = currentargs;
            do
            {
                lock (locker)
                {
                    Board.Accept(args); // Tracks are stamped on the drawboard
                    args.Accept(args.Turtle.Commands[0]); // command execution

                    //args.Turtle.Commands[0].Visit();

                    args.Turtle.Commands.RemoveAt(0);


                    Board.Accept(this.Renderer); // draws the tracks
                    args.Accept(this.Renderer); // draws the turtles
                }
            }
            while (0 < args.Turtle.Commands.Count - 1);
        }

        private void TerminateApplication(object sender, OnKeyPressedEventArgs eventArgs)
        {
            Environment.Exit(0);
        }
    }
}
