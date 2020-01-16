
namespace Mine_Sweeper.ConsoleWatcher
{
    using System;
    using System.Threading;

    public class ConsoleSizeWatcher
    {
        public ConsoleSizeWatcher()
        {
            this.threadArgs = new ConsoleSizeWatcherThreadArgs();
        }

        private Thread thread;

        private ConsoleSizeWatcherThreadArgs threadArgs;

        public event EventHandler<OnConsoleSizeChangedEventArgs> OnConsoleSizeChanged;

        private bool IsUsed
        {
            get;
            set;
        }

        public void Start()
        {
            if (thread != null && thread.IsAlive)
            {
                throw new InvalidOperationException("The Window Size Watcher is already running.");
            }

            thread = new Thread(Worker);
            thread.Start();
        }

        public void Stop()
        {
            if (thread == null || !thread.IsAlive)
            {
                throw new InvalidOperationException("The Window Size Watcher is already stopped.");
            }

            threadArgs.Exit = true;

        }

        public void Worker()
        {
            ConsoleSettings oldSettings = ConsoleSettings.Fetch();
            OnConsoleSizeChangedEventArgs eventArgs = new OnConsoleSizeChangedEventArgs(oldSettings);

            while (!threadArgs.Exit)
            {
                ConsoleSettings newSettings = ConsoleSettings.Fetch();
                if (!oldSettings.CheckIfEqual(newSettings))
                {
                    FireOnSizeChanged(eventArgs);
                }

                Thread.Sleep(1000);
            }
        }

        protected virtual void FireOnSizeChanged(OnConsoleSizeChangedEventArgs e)
        {
            if (IsUsed == false)
            {
                IsUsed = true;

                if (OnConsoleSizeChanged != null)
                {
                    OnConsoleSizeChanged(this, e);
                }

                IsUsed = false;
            }
        }
    }
}