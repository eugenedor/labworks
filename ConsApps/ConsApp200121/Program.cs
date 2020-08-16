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

            Parent pc = new Child();
            pc.Method1();
            Console.WriteLine();

            ChildEx ce = new ChildEx();
            ce.Method1();
            Console.WriteLine();

            Parent pce = new ChildEx();
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
