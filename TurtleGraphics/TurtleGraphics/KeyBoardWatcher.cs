using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TurtleGraphics
{
    public class KeyBoardWatcher
    {
        public EventHandler<OnKeyPressedEventArgs> OnKeyPressed;

        private Thread thread;

        private Thread Thread
        {
            get
            {
                return this.thread;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.thread = value;
            }
        }

        public KeyBoardWatcher()
        {
            this.Thread = new Thread(this.Worker);
            this.Thread.Start();
        }

        private void Worker()
        {
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                this.FireOnKeyPressed(new OnKeyPressedEventArgs(cki));
            }
        }

        protected virtual void FireOnKeyPressed(OnKeyPressedEventArgs e)
        {
            if (this.OnKeyPressed != null)
            {
                this.OnKeyPressed(this, e);
            }
        }
    }
}
