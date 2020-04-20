using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strategy.Concrete;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Car auto = new Car(4, "Volvo", new PetrolMove());
            auto.Print();
            auto.Move();
            auto.Movable = new ElectricMove();
            auto.Move();

            Console.ReadLine();
        }
    }
}
