//-----------------------------------------------------------------------
// <copyright file="KeyBoardWatcher.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the KeyBoardWatcher class.
// It ensures that after the user presses a key an event will be fired.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    using System;
    using System.Threading;

    /// <summary>
    /// This class is firing an event after the user pressed a key.
    /// </summary>
    public class KeyBoardWatcher
    {
        /// <summary>
        /// The thread that monitors for pressed keys.
        /// </summary>
        private Thread thread;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyBoardWatcher"/> class.
        /// </summary>
        public KeyBoardWatcher()
        {
            this.Thread = new Thread(this.Worker);
            this.Thread.Start();
        }

        /// <summary>
        /// Is fired when a key is pressed.
        /// </summary>
        public event EventHandler<OnKeyPressedEventArgs> OnKeyPressed;

        /// <summary>
        /// Gets or sets the thread that monitors for pressed keys.
        /// </summary>
        private Thread Thread
        {
            get
            {
                return this.thread;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.thread = value;
            }
        }

        /// <summary>
        /// Fires the <see cref="OnKeyPressed"/> event.
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected virtual void FireOnKeyPressed(OnKeyPressedEventArgs e)
        {
            if (this.OnKeyPressed != null)
            {
                this.OnKeyPressed(this, e);
            }
        }

        /// <summary>
        /// Represents the worker thread that monitors pressed keys.
        /// </summary>
        private void Worker()
        {
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                this.FireOnKeyPressed(new OnKeyPressedEventArgs(cki));
            }
        }
    }
}
