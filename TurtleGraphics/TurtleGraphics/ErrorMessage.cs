namespace TurtleGraphics
{
    using System;
    using TurtleGraphics.Interfaces;

    public class ErrorMessage: IEditorVisitable
    {
        public string Message;

        public ErrorMessage(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException();
            }

            this.Message = message;
        }

        public void Accept(IEditorVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
