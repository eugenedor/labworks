using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator.Abstract;

namespace Decorator.Concrete
{
    class PlusCheesePizza : PizzaDecorator
    {
        public PlusCheesePizza(Pizza p) : base(p.Name + ", с сыром", p)
        { }

        public override int GetCost()
        {
            return pizza.GetCost() + 150;
        }
    }
}
