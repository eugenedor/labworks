using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateMethod.Concrete;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var school = new School();
            var university = new University();

            Console.WriteLine("***Школа***");
            school.Learn();
            Console.WriteLine();

            Console.WriteLine(@"***Университет***");
            university.Learn();

            Console.ReadLine();
        }
    }
}

//abstract class AbstractClass
//{
//    public void TemplateMethod()
//    {
//        Operation1();
//        Operation2();
//    }
//    public abstract void Operation1();
//    public abstract void Operation2();
//}

//class ConcreteClass : AbstractClass
//{
//    public override void Operation1()
//    {
//    }

//    public override void Operation2()
//    {
//    }
//}