using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryMethod.Abstract;
using FactoryMethod.Concrete.Hs;

namespace FactoryMethod.Concrete.Dev
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
