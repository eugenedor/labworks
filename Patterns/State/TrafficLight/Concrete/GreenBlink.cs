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
        public void ToSwitch(TrafficLight tl)
        {
            Console.Clear();
            Console.WriteLine("ЗЕЛЕНЫЙ-МИГАЮЩИЙ");
            Thread.Sleep(1000);
            tl.State = new Yellow();
        }
    }
}
