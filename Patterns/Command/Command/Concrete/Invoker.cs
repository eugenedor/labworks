using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command.Abstract;

namespace Command.Concrete
{
    /// <summary>
    /// инициатор команды
    /// </summary>
    class Invoker
    {
        Command.Abstract.Command command;
        public void SetCommand(Command.Abstract.Command c)
        {
            command = c;
        }
        public void Run()
        {
            command.Execute();
        }
        public void Cancel()
        {
            command.Undo();
        }
    }
}
