using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator.Abstract;

namespace Decorator.Concrete
{
    class PlusTomatoPizza : PizzaDecorator
    {
        public PlusTomatoPizza(Pizza p) : base(p.Name + ", с томатами", p)
        { }

        public override int GetCost()
        {
            return pizza.GetCost() + 100;
        }
    }
}
