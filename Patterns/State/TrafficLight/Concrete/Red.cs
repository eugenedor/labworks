using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TrafficLight.Abstract;

namespace TrafficLight.Concrete
{
    class Red : IColourState
    {
        public void ToSwitch(TrafficLight tl)
        {
            Console.Clear();
            Console.WriteLine("КРАСНЫЙ");
            Thread.Sleep(5000);
            tl.State = new RedYellow();
        }
    }
}
