using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pult.Abstract
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }
}
