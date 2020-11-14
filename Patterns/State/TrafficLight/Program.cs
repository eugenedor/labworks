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
            Context cntxt = new Context(new Red());

            Console.WriteLine("Begin");
            Thread.Sleep(1000);

            //1
            cntxt.ToSwitch();
            cntxt.ToSwitch();
            cntxt.ToSwitch();
            cntxt.ToSwitch();
            cntxt.ToSwitch();
            //2
            cntxt.ToSwitch();
            cntxt.ToSwitch();
            cntxt.ToSwitch();
            cntxt.ToSwitch();
            cntxt.ToSwitch();

            Console.Clear();
            Console.WriteLine("End");
            Thread.Sleep(1000);
            Console.Clear();
            Console.ReadLine();
        }
    }
}
