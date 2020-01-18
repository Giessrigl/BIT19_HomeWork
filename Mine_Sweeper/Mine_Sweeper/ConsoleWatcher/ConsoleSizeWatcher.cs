using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mine_Sweeper.ConsoleWatcher
{
    public class ConsoleSizeWatcher
    {
        private int formerWindowHeight;

        private int formerWindowWidth;

        private int formerBufferHeight;

        private int formerBufferWidth;

        private int neededWidth;

        private int neededHeight;

        private Thread thread;

        private ConsoleSizeWatcherThreadArguments threadArgs;

        public event EventHandler<OnSizeChangedEventArgs> OnSizeChanged;

        public ConsoleSizeWatcher()
        {
            this.threadArgs = new ConsoleSizeWatcherThreadArguments();

            this.formerWindowHeight = Console.WindowHeight;
            this.formerWindowWidth = Console.WindowWidth;

            this.formerBufferHeight = Console.BufferHeight;
            this.formerBufferWidth = Console.BufferWidth;
        }

        public void Start()
        {
            if (this.thread != null && this.thread.IsAlive)
            {
                throw new InvalidOperationException("The ConsoleSizeWatcher is already running.");
            }

            this.neededWidth = Console.LargestWindowWidth - 5;
            this.neededHeight = Console.LargestWindowHeight - 5;

            this.ChangeConsoleSettings();

            this.threadArgs.Exit = false;
            this.thread = new Thread(this.Worker);
            this.thread.Start(this.threadArgs);
        }

        public void Stop()
        {
            if (this.thread == null || !this.thread.IsAlive)
            {
                throw new InvalidOperationException("The ConsoleSizeWatcher is already stopped.");
            }

            try
            {
                Console.WindowHeight = formerWindowHeight;
                Console.WindowWidth = formerWindowWidth;

                Console.BufferHeight = formerBufferHeight;
                Console.BufferWidth = formerBufferWidth;
            }
            catch
            {
                Console.BufferHeight = formerBufferHeight;
                Console.BufferWidth = formerBufferWidth;

                Console.WindowHeight = formerWindowHeight;
                Console.WindowWidth = formerWindowWidth;
            }


            this.threadArgs.Exit = true;
        }

        protected virtual void FireOnSizeChanged(OnSizeChangedEventArgs args)
        {
            if (this.OnSizeChanged != null)
            {
                this.OnSizeChanged(this, args);
            }
        }

        private void ChangeConsoleSettings()
        {
            Console.CursorVisible = false;
            try
            {
                Console.WindowHeight = neededHeight;
                Console.WindowWidth = neededWidth;

                Console.BufferHeight = neededHeight;
                Console.BufferWidth = neededWidth;
            }
            catch
            {
                Console.BufferHeight = neededHeight;
                Console.BufferWidth = neededWidth;

                Console.WindowHeight = neededHeight;
                Console.WindowWidth = neededWidth;
            }
        }

        private void Worker(object data)
        {
            if (!(data is ConsoleSizeWatcherThreadArguments))
            {
                throw new ArgumentOutOfRangeException(nameof(data), $"The specified data must be an instance of the {nameof(ConsoleSizeWatcherThreadArguments)} class");
            }

            ConsoleSizeWatcherThreadArguments args = (ConsoleSizeWatcherThreadArguments)data;
            
            while (!args.Exit)
            {
                if (Console.WindowHeight != neededHeight || Console.WindowWidth != neededWidth)
                {

                    Console.Clear();
                    try
                    {
                        if (Console.BufferWidth > neededWidth)
                        {
                            Console.WindowWidth = neededWidth;
                            Console.BufferWidth = neededWidth;
                        }
                        else
                        {
                            Console.BufferWidth = neededWidth;
                            Console.WindowWidth = neededWidth;
                        }
                        if (Console.BufferHeight > neededHeight)
                        {
                            Console.WindowHeight = neededHeight;
                            Console.BufferHeight = neededHeight;
                        }
                        else
                        {
                            Console.BufferHeight = neededHeight;
                            Console.WindowHeight = neededHeight;
                        }
                        this.FireOnSizeChanged(new OnSizeChangedEventArgs());
                    }
                    catch
                    {
                        Console.Clear();
                        Console.Write("An error occured after changing the console size. Please resize the window to continue!");
                    }
                }

                Thread.Sleep(800);
            }
        }
    }
}
