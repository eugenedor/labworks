using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class StateB : State
    {
        public override void Handle(Context context)
        {
            Console.WriteLine("StateB: Переход в состояние StateA");
            context.State = new StateA();
        }
    }
}
