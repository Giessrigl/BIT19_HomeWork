using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TurtleGraphics
{
    public class Executioner
    {
        private List<Thread> TurtleThreads;

        private User User;
        private ExecutionRenderer Renderer;
        private WindowSettings Options;
        private DrawBoard Board;

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
                Thread thread = new Thread(ExecuteCommands(args));
                TurtleThreads.Add(thread);
                thread.Start();
            }

            int counter;
            do
            {
                counter = 0;
                foreach (Thread thread in TurtleThreads)
                {
                    if (thread == null)
                    {
                        counter++;
                    }
                }
            }
            while (counter < TurtleThreads.Count());

            Console.ReadKey(true);
            Environment.Exit(0);
        }

        private ThreadStart ExecuteCommands(TurtleArguments args)
        {
            while (0 < args.Turtle.Commands.Count)
            {
                Board.Accept(args);
                args.Accept(args.Turtle.Commands[0]);
                args.Turtle.Commands.RemoveAt(0);

                Board.Accept(this.Renderer);
                args.Accept(this.Renderer);
            }

            return null;
        }
    }
}
