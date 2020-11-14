using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TrafficLight.Abstract;

namespace TrafficLight.Concrete
{
    class Green : IColourState
    {
        public void ToSwitch(Context context)
        {
            Console.Clear();
            Console.WriteLine("ЗЕЛЕНЫЙ");
            Thread.Sleep(5000);
            context.State = new GreenBlink();
        }
    }
}
