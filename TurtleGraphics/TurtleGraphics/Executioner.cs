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

        private static object locker = new object();

        public Executioner(TurtleArguments args)
        {
            this.currentargs = args;
            this.Renderer = new ExecutionRenderer();
            this.Options = new WindowSettings();
            Board.Accept(Options); // to determine the width and height!
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
                Board.Accept(currentargs); // Tracks are stamped on the drawboard
                Options.Accept(currentargs); // CHECK IF MOVE IS ALLOWED TO MOVE! IF NOT DELETE THE FIRST COMMAND!
                currentargs.Accept(currentargs.Turtle.Commands[0]); // command execution

                currentargs.Turtle.Commands.RemoveAt(0);

                Board.Accept(this.Renderer); // draws the tracks
                currentargs.Accept(this.Renderer); // draws the turtles
            }
            while (0 < currentargs.Turtle.Commands.Count);
        }
    }
}
