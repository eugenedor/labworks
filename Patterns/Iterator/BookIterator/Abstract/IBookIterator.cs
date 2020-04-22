using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookIterator.Concrete;

namespace BookIterator.Abstract
{
    interface IBookIterator
    {
        bool HasNext();
        Book Next();
    }
}
