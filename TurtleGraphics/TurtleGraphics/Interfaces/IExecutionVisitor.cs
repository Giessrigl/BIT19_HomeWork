namespace TurtleGraphics.Interfaces
{
    public interface IExecutionVisitor
    {
        void Visit(DrawBoard board);

        void Visit(TurtleAttributes user);
    }
}