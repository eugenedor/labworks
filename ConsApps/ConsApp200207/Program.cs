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

            Console.WriteLine("*aaprint*");
            aa.Print();

            Console.WriteLine("*abprint*");
            ab.Print();

            Console.WriteLine("*bbprint*");
            bb.Print();

            Console.WriteLine("*aa*");
            aa.Method_One();
            aa.Method_Two();
            aa.Method_Three();

            Console.WriteLine("*ab*");
            ab.Method_One();
            ab.Method_Two();
            ab.Method_Three();

            Console.WriteLine("*bb*");
            bb.Method_One();
            bb.Method_Two();
            bb.Method_Three();

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
            Console.WriteLine("Methods:");
            Method_One();
            Method_Two();
            Method_Three();
            Console.WriteLine();
        }

        public virtual void Method_One()
        {
            Console.WriteLine("Method1_A");
        }

        public virtual void Method_Two()
        {
            Console.WriteLine("Method2_A");
        }

        public void Method_Three()
        {
            Console.WriteLine("Method3_A");
        }
    }

    public class B : A
    {
        public override void Method_One()
        {
            Console.WriteLine("Method1_B");
        }

        public new void Method_Two()
        {
            Console.WriteLine("Method2_B");
        }

        public void Method_Three()
        {
            Console.WriteLine("Method3_B");
        }
    }
}
