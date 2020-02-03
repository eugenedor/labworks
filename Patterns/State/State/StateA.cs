using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class StateA : State
    {
        public override void Handle(Context context)
        {
            Console.WriteLine("StateA: Переход в состояние StateB");
            context.State = new StateB();
        }
    }
}
