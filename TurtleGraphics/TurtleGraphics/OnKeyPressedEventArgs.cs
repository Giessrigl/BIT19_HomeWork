namespace TurtleGraphics
{
    using System;

    public class OnKeyPressedEventArgs
    {
        public OnKeyPressedEventArgs(ConsoleKeyInfo cki)
        {
            this.KeyInfo = cki;
        }

        public ConsoleKeyInfo KeyInfo
        {
            get;
            set;
        }
    }
}