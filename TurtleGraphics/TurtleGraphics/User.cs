namespace TurtleGraphics
{
    using System.Collections.Generic;
    using TurtleGraphics.Interfaces;

    public class User : IEditorVisitable
    {
        public List<TurtleArguments> Turtleargs
        {
            get;
            set;
        }

        public User()
        {
            this.Turtleargs = new List<TurtleArguments>();
            TurtleArguments baseTurtle = new TurtleArguments();
            this.Turtleargs.Add(baseTurtle);
        }

        public void Accept(IEditorVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
