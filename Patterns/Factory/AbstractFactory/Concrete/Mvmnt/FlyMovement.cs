using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Abstract;

namespace AbstractFactory.Concrete.Mvmnt
{
    /// <summary>
    /// движение полета
    /// </summary>
    class FlyMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Летим");
        }
    }
}
