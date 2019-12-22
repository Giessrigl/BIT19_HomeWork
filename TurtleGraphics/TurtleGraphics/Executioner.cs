//-----------------------------------------------------------------------
// <copyright file="Executioner.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the Executioner class.
// It should work off the turtle commands of a single turtle correctly.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    using System;
    using System.Threading;

    /// <summary>
    /// This class is responsible for the administration of the single steps a turtle command takes to be executed.
    /// </summary>
    public class Executioner
    {
        /// <summary>
        /// The first object to lock the rendering part of the thread.
        /// </summary>
        private static object locker1 = new object();

        /// <summary>
        /// The second object to lock the rendering part of the thread.
        /// </summary>
        private static object locker2 = new object();

        /// <summary>
        /// The current thread of this class.
        /// </summary>
        private Thread thread;

        /// <summary>
        /// The console renderer for the turtle command executions.
        /// </summary>
        private ExecutionRenderer renderer;

        /// <summary>
        /// The attributes of the turtle this class got.
        /// </summary>
        private TurtleAttributes currentAttributes;

        /// <summary>
        /// The draw board in which the turtle and its tracks will be stored.
        /// </summary>
        private DrawBoard board;

        /// <summary>
        /// Initializes a new instance of the <see cref="Executioner"/> class.
        /// </summary>
        /// <param name="attributes">The attributes of the turtle this class should work off.</param>
        /// <param name="board">The draw board where the turtle and its tracks will be stored.</param>
        public Executioner(TurtleAttributes attributes, DrawBoard board)
        {
            this.currentAttributes = attributes;
            this.renderer = new ExecutionRenderer();
            this.board = board;
        }

        /// <summary>
        /// Gets a value indicating whether the execution is finished or not.
        /// </summary>
        /// <value>
        /// True if this executor is finished working, false if it still executes.
        /// </value>
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

        /// <summary>
        /// Initializing a new thread which works off the steps of every turtle command of the specified turtle.
        /// </summary>
        public void Execute()
        {
            ThreadStart threadDelegate = new ThreadStart(this.ExecuteCommands);
            this.thread = new Thread(threadDelegate);
            this.thread.Start();
        }

        /// <summary>
        /// Works off the steps to execute the commands of a single turtle.
        /// </summary>
        private void ExecuteCommands()
        {
            do
            {
                lock (locker1)
                {
                    this.board.Accept(this.currentAttributes); // Tracks and Turtles are stamped on the drawboard
                    this.board.Accept(this.renderer); // draws the tracks
                }

                if (this.currentAttributes.Turtle.Commands.Count > 0)
                {
                    this.currentAttributes.Accept(this.currentAttributes.Turtle.Commands[0]); // command execution
                    this.currentAttributes.Turtle.Commands.RemoveAt(0); // remove executed command
                }
            }
            while (this.currentAttributes.Turtle.Commands.Count > 0);

            lock (locker2)
            {
                this.board.Accept(this.currentAttributes); // Tracks and Turtles are stamped on the drawboard
                this.board.Accept(this.renderer); // draws the tracks
            }
        }
    }
}
