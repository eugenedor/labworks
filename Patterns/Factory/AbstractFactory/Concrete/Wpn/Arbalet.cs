using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Abstract;

namespace AbstractFactory.Concrete.Wpn
{
    /// <summary>
    /// класс арбалет
    /// </summary>
    class Arbalet : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Стреляем из арбалета");
        }
    }
}
