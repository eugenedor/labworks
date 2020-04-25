using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pult.Abstract;
using Pult.Concrete;

namespace Pult
{
    class Program
    {
        static void Main(string[] args)
        {
            Pult.Concrete.Pult pult = new Pult.Concrete.Pult();
            TV tv = new TV();
            pult.SetCommand(new TVOnCommand(tv));
            pult.PressButton();
            pult.PressUndo();

            Console.Read();
        }
    }
}
