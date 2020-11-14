using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TrafficLight.Abstract;

namespace TrafficLight.Concrete
{
    class GreenBlink : IColourState
    {
        public void ToSwitch(Context context)
        {
            Console.Clear();
            Console.WriteLine("ЗЕЛЕНЫЙ-МИГАЮЩИЙ");
            Thread.Sleep(1000);
            context.State = new Yellow();
        }
    }
}
