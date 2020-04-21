using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Concrete
{
    class Product
    {
        public List<object> parts = new List<object>();

        public void Add(string part)
        {
            parts.Add(part);
        }
    }
}
