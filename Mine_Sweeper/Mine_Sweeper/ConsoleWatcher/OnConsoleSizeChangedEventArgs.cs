using System;

namespace Mine_Sweeper.ConsoleWatcher
{
    public class OnConsoleSizeChangedEventArgs : EventArgs
    {
        public OnConsoleSizeChangedEventArgs(ConsoleSettings defaultSettings)
        {
            DefaultSettings = defaultSettings;
        }

        public ConsoleSettings DefaultSettings { get; private set; }
    }
}