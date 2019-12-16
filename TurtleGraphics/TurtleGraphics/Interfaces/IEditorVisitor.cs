using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleGraphics.Interfaces
{
    public interface IEditorVisitor
    {
        void Visit(User user);

        void Visit(InputHandler handler);

        void Visit(ErrorMessage errormessage);
    }
}
