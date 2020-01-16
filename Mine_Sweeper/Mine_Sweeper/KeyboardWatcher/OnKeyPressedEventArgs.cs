
namespace Mine_Sweeper.KeyboardWatcher
{
    using System;

    /// <summary>
    /// Represents the <see cref="OnKeyPressedEventArgs"/> class.
    /// </summary>
    public class OnKeyPressedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnKeyPressedEventArgs"/> class.
        /// </summary>
        /// <param name="cki">The key that has been pressed.</param>
        public OnKeyPressedEventArgs(ConsoleKeyInfo cki)
        {
            this.KeyInfo = cki;
        }

        /// <summary>
        /// Gets the key that has been pressed.
        /// </summary>
        /// <value>
        /// The key that has been pressed.
        /// </value>
        public ConsoleKeyInfo KeyInfo
        {
            get;
            private set;
        }
    }
}
