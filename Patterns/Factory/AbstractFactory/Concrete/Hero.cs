using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Abstract;

namespace AbstractFactory
{
    /// <summary>
    /// клиент - сам супергерой
    /// </summary>
    class Hero
    {
        private HeroFactory heroFactory;
        private Weapon weapon;
        private Movement movement;

        public Hero(HeroFactory factory)
        {
            heroFactory = factory;
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
        }

        public void Run()
        {
            movement.Move();
        }
        public void Hit()
        {
            weapon.Hit();
        }

        public void Print()
        {
            heroFactory.Print();
        }
    }
}
