using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPult.Abstract;

namespace MultiPult.Concrete
{
    class TVOnCommand : ICommand
    {
        TV tv;
        public TVOnCommand(TV tvSet)
        {
            tv = tvSet;
        }
        public void Execute()
        {
            tv.On();
        }
        public void Undo()
        {
            tv.Off();
        }
    }
}
