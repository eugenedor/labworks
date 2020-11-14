using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight.Concrete;

namespace TrafficLight.Abstract
{
    interface IColourState
    {
        void ToSwitch(TrafficLight.Concrete.TrafficLight tl);
    }
}
