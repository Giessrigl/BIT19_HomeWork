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
        private ExecutionRenderer Renderer;
        private WindowSettings Options;
        private DrawBoard Board;
        
        private TurtleArguments currentargs;

        private static object locker1 = new object();

        private static object locker2 = new object();

        public Executioner(TurtleArguments args)
        {
            this.currentargs = args;
            this.Renderer = new ExecutionRenderer();
            this.Options = new WindowSettings();
            this.Board = new DrawBoard(Options.GetWindowWidth(), Options.GetWindowHeight());
            // Board.Accept(Options); // to determine the width and height!
        }

        public void Execute()
        {
            ThreadStart threadDelegate = new ThreadStart(ExecuteCommands);
            Thread thread = new Thread(threadDelegate);
            thread.Start();
        }

        private void ExecuteCommands()
        {
            do
            {
                currentargs.Accept(currentargs.Turtle.Commands[0]); // command execution
                currentargs.Turtle.Commands.RemoveAt(0); // remove executed command
                
                Monitor.Enter(locker1);
                currentargs.Accept(this.Renderer); // draws the turtles
                Board.Accept(this.Renderer); // draws the tracks
                Thread.Sleep(50);
                Monitor.Exit(locker1);
                Board.Accept(currentargs); // Tracks are stamped on the drawboard, turtle position is added in turtlepositions
            }
            while (0 < currentargs.Turtle.Commands.Count);
        }
    }
}
