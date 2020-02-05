using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    /// <summary>
    /// Строит деревянные дома (ConcreteCreatorB)
    /// </summary>
    class WoodDeveloper : Developer
    {
        public WoodDeveloper(string name) : base(name)
        { }

        public override House Create() //override Product FactoryMethod()
        {
            return new WoodHouse();
        }
    }
}
