using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight.Abstract;

namespace TrafficLight.Concrete
{
    class TrafficLight
    {
        public IColourState State { get; set; }

        public TrafficLight(IColourState cs)
        {
            State = cs;
        }

        public void ToSwitch()
        {
            State.ToSwitch(this);
        }
    }
}
