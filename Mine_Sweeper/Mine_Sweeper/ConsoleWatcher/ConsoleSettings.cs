using System;


namespace Mine_Sweeper.ConsoleWatcher
{
    public class ConsoleSettings
    {
        public ConsoleSettings(bool CursorVisible)
        {
            if (!CursorVisible)
            {
                Console.CursorVisible = false;
            }
        }

        public Size WindowSize 
        { 
            get; 
            set; 
        }

        public Size BufferSize 
        { 
            get; 
            set; 
        }

        public static void SetConsoleSizeToMax()
        {
            Console.SetWindowSize(Console.LargestWindowWidth - 5, Console.LargestWindowHeight - 5);
            Console.SetBufferSize(Console.LargestWindowWidth - 5, Console.LargestWindowHeight - 5);
        }

        public static ConsoleSettings Fetch()
        {
            ConsoleSettings settings = new ConsoleSettings(false);

            settings.WindowSize = new Size(Console.WindowWidth, Console.WindowHeight);
            settings.BufferSize = new Size(Console.BufferWidth, Console.BufferHeight);

            return settings;
        }

        public static void ChangeTo(ConsoleSettings settings)
        {
            Console.WindowWidth = settings.WindowSize.Width;
            Console.WindowHeight = settings.WindowSize.Height;

            Console.BufferWidth = settings.BufferSize.Width;
            Console.BufferHeight = settings.BufferSize.Height;
        }

        public bool CheckIfEqual(ConsoleSettings other)
        {
            if (WindowSize.Width == other.WindowSize.Width && WindowSize.Height == other.WindowSize.Height)
            {
                if (BufferSize.Width == other.BufferSize.Width && BufferSize.Height == other.BufferSize.Height)
                {
                    return true;
                }
            }

            return false;
        }
    }
}