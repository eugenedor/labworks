using BookIterator.Abstract;
using BookIterator.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            Console.WriteLine("===Part1 with reader===");
            Reader reader = new Reader();
            reader.SeeBooks(library);

            Console.WriteLine();

            Console.WriteLine("===Part2 without reader==="); 
            IBookIterator iterator = library.CreateNumerator();
            while (iterator.HasNext())
            {
                Book book = iterator.Next();
                Console.WriteLine(book.Name);
            }

            Console.Read();
        }
    }
}

//У нас есть класс читателя, который хочет получить информацию о книгах, которые находятся в библиотеке. 
//И для этого надо осуществить перебор объектов с помощью итератора
//Интерфейс IBookIterator представляет итератор наподобие интерфейса IEnumerator. Роль интерфейса составного агрегата представляет тип IBookNumerable. 
//Клиентом здесь является класс Reader, который использует итератор для обхода объекта библиотеки.

//public interface IEnumerator
//{
//    bool MoveNext(); // перемещение на одну позицию вперед в контейнере элементов
//    object Current { get; }  // текущий элемент в контейнере
//    void Reset(); // перемещение в начало контейнера
//}

//public interface IEnumerable
//{
//    IEnumerator GetEnumerator();
//}