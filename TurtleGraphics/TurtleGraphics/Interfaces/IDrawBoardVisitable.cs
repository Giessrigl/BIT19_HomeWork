namespace TurtleGraphics.Interfaces
{
    public interface IDrawBoardVisitable
    {
        void Accept(IDrawBoardVisitor visitor);
    }
}
