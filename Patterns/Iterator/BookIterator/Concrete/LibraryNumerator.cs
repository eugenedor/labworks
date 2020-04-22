﻿using BookIterator.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookIterator.Concrete
{
    class LibraryNumerator : IBookIterator
    {
        IBookNumerable aggregate;
        int index = 0;

        public LibraryNumerator(IBookNumerable a)
        {
            aggregate = a;
        }

        public bool HasNext()
        {
            return index < aggregate.Count;
        }

        public Book Next()
        {
            return aggregate[index++];
        }
    }
}
