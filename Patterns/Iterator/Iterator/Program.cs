using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iterator.Abstract;
using Iterator.Concrete;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Aggregate a = new ConcreteAggregate();

            Iterator.Abstract.Iterator i = a.CreateIterator();

            object item = i.First();
            while (!i.IsDone())
            {
                item = i.Next();
            }
        }
    }
}
