using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine_Sweeper.ConsoleWatcher
{
    public class ConsoleSizeWatcherThreadArguments
    {
        public ConsoleSizeWatcherThreadArguments()
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
