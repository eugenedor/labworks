using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsApp200121
{
    class Program
    {
        static void Main(string[] args)
        {
            Parent p = new Parent();
            p.Method1();
            Console.WriteLine();

            Child c = new Child();
            c.Method1();
            Console.WriteLine();

            Parent pc = new Child(); //Parent pc = new Child() Вызываем метод Method1 виртуальный, а так как мы передаем экземпляр Child (с переопределением метода), то  мы проваливаемся в Method1 класса Child и уже потом дергаем базовый Parent.
            pc.Method1();
            Console.WriteLine();

            ChildEx ce = new ChildEx();
            ce.Method1();
            Console.WriteLine();

            Parent pce = new ChildEx(); //Parent pc = new ChildEx() Вызываем метод Method1 виртуальный, а так как мы передаем экземпляр ChildEx (с сокрытием метода), то мы сразу в Method1 класса Parent (это только здесь сразу проваливаемся).
            pce.Method1();
            Console.WriteLine();
            Console.ReadLine();
        }

        public class Parent
        {
            public virtual void Method1()
            {
                Console.WriteLine("Method_1_1");
                Method2();
                Console.WriteLine("Method_1_3");
            }

            public virtual void Method2() { Console.WriteLine("Method_1_2"); }
        }

        public class Child : Parent
        {
            public override void Method1()
            {
                base.Method1();
            }

            public override void Method2() { Console.WriteLine("Method_2_2"); }
        }

        public class ChildEx : Parent
        {
            public new void Method1()
            {
                base.Method1();
            }

            public override void Method2() { Console.WriteLine("Method_2_2ex"); }
        }
    }
}
