

namespace Mine_Sweeper.KeyboardWatcher
{
    /// <summary>
    /// Represents the <see cref="KeyboardWatcherThreadArguments"/> class.
    /// </summary>
    public class KeyboardWatcherThreadArguments
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardWatcherThreadArguments"/> class.
        /// </summary>
        public KeyboardWatcherThreadArguments()
        {
            this.Exit = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the keyboard watcher shall exit or not.
        /// </summary>
        /// <value>
        /// The value indicating whether the keyboard watcher shall exit or not.
        /// </value>
        public bool Exit
        {
            get;
            set;
        }
    }
}
