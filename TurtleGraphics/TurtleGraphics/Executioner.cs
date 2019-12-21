


namespace TurtleGraphics
{
    using System;
    using System.Threading;

    public class Executioner
    {
        private Thread thread;

        private ExecutionRenderer Renderer;
        
        private TurtleAttributes currentargs;

        private static object locker1 = new object();

        private static object locker2 = new object();

        private DrawBoard Board;

        public bool IsFinished 
        { 
            get
            {
                if (this.thread != null)
                {
                    throw new NullReferenceException();
                }

                return !this.thread.IsAlive;
            }
        }

        public Executioner(TurtleAttributes args, DrawBoard board)
        {
            this.currentargs = args;
            this.Renderer = new ExecutionRenderer();
            this.Board = board;
        }

        public void Execute()
        {
            ThreadStart threadDelegate = new ThreadStart(ExecuteCommands);
            this.thread = new Thread(threadDelegate);
            this.thread.Start();
        }

        private void ExecuteCommands()
        {
            do
            {
                lock(locker1)
                {
                    this.Board.Accept(this.currentargs); // Tracks and Turtles are stamped on the drawboard
                    this.Board.Accept(this.Renderer); // draws the tracks
                }

                if (this.currentargs.Turtle.Commands.Count > 0)
                {
                    this.currentargs.Accept(this.currentargs.Turtle.Commands[0]); // command execution
                    this.currentargs.Turtle.Commands.RemoveAt(0); // remove executed command
                }
            }
            while (0 < this.currentargs.Turtle.Commands.Count);

            lock (locker2)
            {
                this.Board.Accept(this.currentargs); // Tracks and Turtles are stamped on the drawboard
                this.Board.Accept(this.Renderer); // draws the tracks
            }
        }
    }
}
