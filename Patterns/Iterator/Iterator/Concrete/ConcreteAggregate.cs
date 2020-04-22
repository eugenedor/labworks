using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iterator.Abstract;
using System.Collections;

namespace Iterator.Concrete
{
    class ConcreteAggregate : Aggregate
    {
        private readonly ArrayList _items = new ArrayList();

        public override Iterator.Abstract.Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public override int Count
        {
            get { return _items.Count; }
            protected set { }
        }

        public override object this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }
    }
}
