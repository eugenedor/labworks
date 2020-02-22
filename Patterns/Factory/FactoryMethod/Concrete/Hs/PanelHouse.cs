using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryMethod.Abstract;

namespace FactoryMethod.Concrete.Hs
{
    /// <summary>
    /// Панельный дом (ConcreteProductA)
    /// </summary>
    class PanelHouse : House
    {
        public PanelHouse()
        {
            Console.WriteLine("Панельный дом построен");
        }
    }
}
