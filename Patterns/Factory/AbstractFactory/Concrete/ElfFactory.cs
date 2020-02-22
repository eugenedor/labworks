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
    /// Фабрика создания летящего героя с арбалетом
    /// </summary>
    class ElfFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }

        public override void Print()
        {
            Console.WriteLine("Боец: \"Эльф\"");
        }
    }
}
