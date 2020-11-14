using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight.Abstract;
using TrafficLight.Concrete;
using System.Threading;

namespace TrafficLight
{
    class Program
    {
        static void Main(string[] args)
        {
            var tl = new TrafficLight.Concrete.TrafficLight(new Red());

            Console.WriteLine("BEGIN");
            Thread.Sleep(1000);

            //1
            tl.ToSwitch();
            tl.ToSwitch();
            tl.ToSwitch();
            tl.ToSwitch();
            tl.ToSwitch();
            //2
            tl.ToSwitch();
            tl.ToSwitch();
            tl.ToSwitch();
            tl.ToSwitch();
            tl.ToSwitch();
            //3
            tl.ToSwitch();

            Console.Clear();
            Console.WriteLine("END");
            Thread.Sleep(1000);
            Console.Clear();

            Console.ReadLine();
        }
    }
}
