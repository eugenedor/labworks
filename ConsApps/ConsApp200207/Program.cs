using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsApp200207
{
    class Program
    {
        static void Main(string[] args)
        {
            A aa = new A();
            A ab = new B();
            B bb = new B();

            aa.Print();
            ab.Print();
            bb.Print();
            Console.ReadKey();
        }
    }

    public interface I
    {
        void Print();
    }

    public class A : I
    {
        public void Print()
        {
            Method();
        }

        public virtual void Method()
        {
            Console.WriteLine("Method_A");
        }
    }

    public class B : A
    {
        public override void Method()
        {
            Console.WriteLine("Method_B");
        }
    }
}
