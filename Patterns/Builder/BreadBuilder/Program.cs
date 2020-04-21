using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadBuilder.Concrete;
using BreadBuilder.Abstract;


namespace BreadBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            // содаем объект пекаря
            Baker baker = new Baker();

            // создаем билдер для ржаного хлеба
            BreadBuilder.Abstract.BreadBuilder builder = new RyeBreadBuilder();
            // выпекаем
            Bread ryeBread = baker.Bake(builder);
            Console.WriteLine(ryeBread.ToString());

            // создаем билдер для пшеничного хлеба
            builder = new WheatBreadBuilder();
            // выпекаем
            Bread wheatBread = baker.Bake(builder);
            Console.WriteLine(wheatBread.ToString());

            Console.Read();
        }
    }

    //В данном случае с помощью конкретных строителей RyeBreadBuilder и WheatBreadBuilder создаются объекты Bread с определенным набором. 
    //В роли распорядителя выступает класс пекаря Baker, который вызывает методы конкретных строителей для построения нового объекта.
}
