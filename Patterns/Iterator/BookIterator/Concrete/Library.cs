using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookIterator.Abstract;

namespace BookIterator.Concrete
{
    class Library : IBookNumerable
    {
        private Book[] books;

        public Library()
        {
            books = new Book[]
            {
                new Book {Name="Война и мир"},
                new Book {Name="Отцы и дети"},
                new Book {Name="Вишневый сад"}
            };
        }

        public int Count
        {
            get { return books.Length; }
        }

        public Book this[int index]
        {
            get { return books[index]; }
        }
        public IBookIterator CreateNumerator()
        {
            return new LibraryNumerator(this);
        }
    }
}
