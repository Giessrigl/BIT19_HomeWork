namespace TurtleGraphics
{
    using System.Collections.Generic;
    using TurtleGraphics.Interfaces;

    public class Turtle
    {
        public List<ITurtleCommand> Commands
        {
            get;
            set;
        }

        public Turtle()
        {
            this.Commands = new List<ITurtleCommand>();
        }

    }
}
