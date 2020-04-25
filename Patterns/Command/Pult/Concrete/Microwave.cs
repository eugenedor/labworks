using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pult.Concrete
{
    class Microwave
    {
        public void StartCooking(int time)
        {
            Console.WriteLine("Подогреваем еду");
            // имитация работы с помощью асинхронного метода Task.Delay
            Task.Delay(time).GetAwaiter().GetResult();
        }

        public void StopCooking()
        {
            Console.WriteLine("Еда подогрета!");
        }
    }
}
