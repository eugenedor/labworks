using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterAntiPa
{
    class Program
    {
        static void Main(string[] args)
        {
            WaterAntiPa water = new WaterAntiPa(WaterState.LIQUID);
            water.Heat();
            water.Frost();
            water.Frost();

            Console.ReadLine();
        }
    }
}
