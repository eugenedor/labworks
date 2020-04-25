using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPult.Abstract;

namespace MultiPult.Concrete
{
    class NoCommand : ICommand
    {
        public void Execute()
        {
        }
        public void Undo()
        {
        }
    }
}
