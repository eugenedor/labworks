using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Developer developer = new PanelDeveloper("ООО КирпичСтрой");
            developer.PrintDev();
            House housePanel = developer.Create();            
            Console.WriteLine();

            developer = new WoodDeveloper("Частный застройщик");
            developer.PrintDev();
            House houseWood = developer.Create();
            Console.ReadLine();
        }
    }
}
