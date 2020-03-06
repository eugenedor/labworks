using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediator.Abstract;

namespace Mediator.Concrete
{
    /// <summary>
    /// класс программиста
    /// </summary>
    class ProgrammerColleague : Colleague
    {
        public ProgrammerColleague(Abstract.Mediator mediator)
        : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение программисту: " + message);
        }
    }
}
