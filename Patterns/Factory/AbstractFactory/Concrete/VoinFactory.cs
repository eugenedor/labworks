using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Abstract;
using AbstractFactory.Concrete.Mvmnt;
using AbstractFactory.Concrete.Wpn;

namespace AbstractFactory.Concrete
{
    /// <summary>
    /// Фабрика создания бегущего героя с мечом
    /// </summary>
    class VoinFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }

        public override void Print()
        {
            Console.WriteLine("Боец: \"Лютый воин\"");
        }
    }
}
