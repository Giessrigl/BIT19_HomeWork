namespace Mine_Sweeper.ConsoleWatcher
{
    public class ConsoleSizeWatcherThreadArgs
    {
        public ConsoleSizeWatcherThreadArgs()
        {
            this.Exit = false;
        }

        public bool Exit 
        { 
            get; 
            set; 
        }
    }
}