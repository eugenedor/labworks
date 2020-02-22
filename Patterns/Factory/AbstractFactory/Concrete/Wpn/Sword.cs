using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Abstract;

namespace AbstractFactory.Concrete.Wpn
{
    /// <summary>
    /// класс меч
    /// </summary>
    class Sword : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Бьем мечом");
        }
    }
}
