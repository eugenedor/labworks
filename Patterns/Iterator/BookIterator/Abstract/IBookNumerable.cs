using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookIterator.Concrete;

namespace BookIterator.Abstract
{
    interface IBookNumerable
    {
        IBookIterator CreateNumerator();

        int Count { get; }

        Book this[int index] { get; }
    }
}
