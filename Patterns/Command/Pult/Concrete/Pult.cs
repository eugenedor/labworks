using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pult.Abstract;

namespace Pult.Concrete
{
    /// <summary>
    /// Invoker - инициатор
    /// </summary>
    class Pult
    {
        ICommand command;

        public Pult()
        {
            command = new NoCommand();
        }

        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public void PressButton()
        {
            //if (command != null)
            command.Execute();
        }
        public void PressUndo()
        {
            //if (command != null)
            command.Undo();
        }
    }
}
