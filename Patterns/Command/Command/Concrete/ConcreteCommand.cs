﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command.Abstract;

namespace Command.Concrete
{
    /// <summary>
    /// конкретная команда
    /// </summary>
    class ConcreteCommand : Command.Abstract.Command
    {
        Receiver receiver;
        public ConcreteCommand(Receiver r)
        {
            receiver = r;
        }
        public override void Execute()
        {
            receiver.Operation();
        }

        public override void Undo()
        { }
    }
}
