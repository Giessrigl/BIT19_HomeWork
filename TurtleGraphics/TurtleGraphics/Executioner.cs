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
        private Thread thread;

        private ExecutionRenderer Renderer;
        
        private TurtleArguments currentargs;

        private static object locker1 = new object();

        private static object locker2 = new object();

        private static object locker3 = new object();

        private DrawBoard Board;

        public bool IsFinished 
        { 
            get
            {
                if (thread != null)
                {
                    throw new NullReferenceException();
                }

                return !thread.IsAlive;
            }
        }

        public Executioner(TurtleArguments args, DrawBoard board)
        {
            this.currentargs = args;
            this.Renderer = new ExecutionRenderer();
            this.Board = board;
        }

        public void Execute()
        {
            ThreadStart threadDelegate = new ThreadStart(ExecuteCommands);
            this.thread = new Thread(threadDelegate);
            thread.Start();
        }

        private void ExecuteCommands()
        {
            do
            {
                lock(locker1)
                {
                    Board.Accept(currentargs); // Tracks and Turtles are stamped on the drawboard
                    Board.Accept(this.Renderer); // draws the tracks
                }

                currentargs.Accept(currentargs.Turtle.Commands[0]); // command execution
                currentargs.Turtle.Commands.RemoveAt(0); // remove executed command
            }
            while (0 < currentargs.Turtle.Commands.Count);

            Board.Accept(currentargs); // Tracks and Turtles are stamped on the drawboard
        }
    }
}
