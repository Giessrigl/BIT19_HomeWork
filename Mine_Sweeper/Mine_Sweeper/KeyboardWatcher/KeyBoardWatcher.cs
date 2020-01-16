

namespace Mine_Sweeper.KeyboardWatcher
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
        /// Arguments for the thread that monitors for pressed keys.
        /// </summary>
        private KeyboardWatcherThreadArguments threadArguments;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyBoardWatcher"/> class.
        /// </summary>
        public KeyBoardWatcher()
        {
            this.threadArguments = new KeyboardWatcherThreadArguments();
        }

        /// <summary>
        /// Is fired when a key is pressed.
        /// </summary>
        public event EventHandler<OnKeyPressedEventArgs> OnKeyPressed;

        /// <summary>
        /// Starts the watcher.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Is thrown if the watcher is already started.
        /// </exception>
        public void Start()
        {
            if (this.thread != null && this.thread.IsAlive)
            {
                throw new InvalidOperationException("The KeyboardWatcher is already running.");
            }

            this.threadArguments.Exit = false;
            this.thread = new Thread(this.Worker);
            this.thread.Start(this.threadArguments);
        }

        /// <summary>
        /// Stops the watcher.
        /// </summary>
        /// <exception cref="InvalidOperationException">Is thrown if the watcher is already stopped.</exception>
        public void Stop()
        {
            if (this.thread == null || !this.thread.IsAlive)
            {
                throw new InvalidOperationException("The KeyboardWatcher is already stopped.");
            }

            this.threadArguments.Exit = true;
        }

        /// <summary>
        /// Represents the worker thread that monitors pressed keys.
        /// </summary>
        /// <param name="data">The thread arguments.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Is thrown if the specified instance for data is not of type <see cref="KeyboardWatcherThreadArguments"/>.
        /// </exception>
        private void Worker(object data)
        {
            if (!(data is KeyboardWatcherThreadArguments))
            {
                throw new ArgumentOutOfRangeException(nameof(data), $"The specified data must be an instance of the {nameof(KeyboardWatcherThreadArguments)} class");
            }

            KeyboardWatcherThreadArguments args = (KeyboardWatcherThreadArguments)data;

            while (!args.Exit)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                this.FireOnKeyPressed(new OnKeyPressedEventArgs(cki));
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
    }
}
