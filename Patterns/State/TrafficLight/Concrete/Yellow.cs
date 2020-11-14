using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TrafficLight.Abstract;

namespace TrafficLight.Concrete
{
    class Yellow : IColourState
    {
        public void ToSwitch(TrafficLight tl)
        {
            Console.Clear();
            Console.WriteLine("ЖЕЛТЫЙ");
            Thread.Sleep(2000);
            tl.State = new Red();
        }
    }
}
