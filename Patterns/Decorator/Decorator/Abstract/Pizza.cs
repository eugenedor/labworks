using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Abstract
{
    abstract class Pizza
    {
        public string Name { get; protected set; }

        public Pizza(string n)
        {
            this.Name = n;
        }

        public abstract int GetCost();
    }
}
