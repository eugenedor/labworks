using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    /// <summary>
    /// Cтроит панельные дома (ConcreteCreatorA)
    /// </summary>
    class PanelDeveloper : Developer
    {
        public PanelDeveloper(string name) : base(name)
        { }

        public override House Create() //override Product FactoryMethod()
        {
            return new PanelHouse();
        }
    }
}
