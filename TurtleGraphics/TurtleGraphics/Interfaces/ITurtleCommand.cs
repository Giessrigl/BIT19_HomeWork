namespace TurtleGraphics.Interfaces
{
    public interface ITurtleCommand : IExecutionVisitor
    {
        string GetValue();
    }
}
