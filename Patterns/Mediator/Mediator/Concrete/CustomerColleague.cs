using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediator.Abstract;

namespace Mediator.Concrete
{
    /// <summary>
    /// класс заказчика
    /// </summary>
    class CustomerColleague : Colleague
    {
        public CustomerColleague(Abstract.Mediator mediator)
        : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение заказчику: " + message);
        }
    }
}
