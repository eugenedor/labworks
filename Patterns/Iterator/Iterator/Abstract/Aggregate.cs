using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Abstract
{
    abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
        public abstract int Count { get; protected set; }
        public abstract object this[int index] { get; set; }
    }
}
