namespace TurtleGraphics
{
    using System.Collections.Generic;
    using TurtleGraphics.Interfaces;

    public class User : IEditorVisitable
    {
        public List<TurtleAttributes> Turtleargs
        {
            get;
            set;
        }

        public User()
        {
            this.Turtleargs = new List<TurtleAttributes>();
            TurtleAttributes baseTurtle = new TurtleAttributes();
            this.Turtleargs.Add(baseTurtle);
        }

        public void Accept(IEditorVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
