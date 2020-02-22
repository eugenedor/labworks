using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryMethod.Abstract;

namespace FactoryMethod.Concrete.Hs
{
    /// <summary>
    /// Деревянный дом (ConcreteProductB)
    /// </summary>
    class WoodHouse : House
    {
        public WoodHouse()
        {
            Console.WriteLine("Деревянный дом построен");
        }
    }
}
