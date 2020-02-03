using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context(new StateA());
            context.Request();  // Переход в состояние StateB
            context.Request();  // Переход в состояние StateA
            Console.ReadLine();
        }
    }
}
