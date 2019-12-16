namespace TurtleGraphics.Interfaces
{
    public interface IEditorLineCheckerVisitable
    {
        void Accept(IEditorLineCheckerVisitor visitor);
    }
}
