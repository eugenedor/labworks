using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsApp191008
{
    class Program
    {
        static void Main(string[] args)
        {
            A ab = new B();
            A ac = new C();
            B bc = new C();
            A ad = new D();
            A ae = new E();
            Console.WriteLine(ab.Print());
            Console.WriteLine(ac.Print());
            Console.WriteLine(bc.Print());
            Console.WriteLine(ad.Print());
            Console.WriteLine(ae.Print());

            Console.WriteLine();

            X xy = new Y();
            X xz = new Z();
            Y yz = new Z();
            Console.WriteLine(xy.Print());
            Console.WriteLine(xz.Print());
            Console.WriteLine(yz.Print());

            Console.ReadKey();
        }
    }

    public abstract class A
    {
        public virtual string Print() => "A";
    }

    public class B : A
    {
        public override string Print() => "B";
        //public new string Print() => "B";
    }

    public class C : B
    {
        public new string Print() => "C";
    }

    public class D : A
    {
        public new string Print() => "D";
    }

    public class E : A
    {
        public string Print() => "E";  //Warning "E.Print()" скрывает наследуемый член "A.Print()". Чтобы текущий член переопределял эту реализацию, добавьте ключевое слово override. В противном случае добавьте ключевое слово new.
    }


    //X-Y-Z revert A-B-C
    public abstract class X
    {
        public virtual string Print() => "X";
    }

    public class Y : X
    {
        public new string Print() => "Y";
    }

    public class Z : Y
    {
        public new string Print() => "Z";
        //public override string Print() => "Z";  //Error "Z.Print()": невозможно переопределить наследуемый член "Y.Print()", так как он не помечен как virtual, abstract или override.
    }

}
