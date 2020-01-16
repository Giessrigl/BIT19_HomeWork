using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine_Sweeper.Interfaces
{
    public interface IGameVisitable
    {
        void Accept(IGameVisitor visitor);
    }
}
