namespace TurtleGraphics.Interfaces
{
    public interface IEditorVisitable
    {
        void Accept(IEditorVisitor visitor);
    }
}
