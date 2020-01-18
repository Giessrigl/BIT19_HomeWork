using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine_Sweeper.Interfaces
{
    public interface IInputVisitor
    {
        void Visit(InputHandler handler);

        void Visit(GameFinisher finisher);
    }
}
