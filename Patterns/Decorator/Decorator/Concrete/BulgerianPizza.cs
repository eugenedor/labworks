using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator.Abstract;

namespace Decorator.Concrete
{
    class BulgerianPizza : Pizza
    {
        public BulgerianPizza() : base("Болгарская пицца")
        { }

        public override int GetCost()
        {
            return 700;
        }
    }
}
