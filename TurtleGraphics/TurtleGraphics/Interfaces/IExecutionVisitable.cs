namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;
    using TurtleGraphics.EditorCommands;
    using TurtleGraphics.TurtleCommands;

    public interface IExecutionVisitable
    {
        void Accept(IExecutionVisitor visitor);
    }
}