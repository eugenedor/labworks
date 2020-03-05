using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsApp191205
{
    class Program
    {
        static void Main(string[] args)
        {
            A ab = new B();
            A ac = new C();
            A ad = new D();
            A ae = new E();
            A af = new F();
            A ag = new G();
            A ak = new K();
            B bb = new B();
            B bc = new C();
            B bk = new K();
            C cc = new C();
            G gg = new G();
            K kk = new K();
            Console.WriteLine($"ab.Print(): {ab.Print()}");
            Console.WriteLine($"ac.Print(): {ac.Print()}");
            Console.WriteLine($"ad.Print(): {ad.Print()}");
            Console.WriteLine($"ae.Print(): {ae.Print()}");
            Console.WriteLine($"af.Print(): {af.Print()}");
            Console.WriteLine($"ag.Print(): {ag.Print()}");
            Console.WriteLine($"ak.Print(): {ak.Print()}");
            Console.WriteLine($"bb.Print(): {bb.Print()}");
            Console.WriteLine($"bc.Print(): {bc.Print()}");
            Console.WriteLine($"bk.Print(): {bk.Print()}");
            Console.WriteLine($"cc.Print(): {cc.Print()}");
            Console.WriteLine($"gg.Print(): {gg.Print()}");
            Console.WriteLine($"kk.Print(): {kk.Print()}");
            Console.ReadKey();
        }
    }

    public interface I
    {
        string Print();
    }

    public class A : I
    {
        public virtual string Print() => "A";
    }

    public class B : A { }

    public class C : B
    {
        public override string Print() => "C";
    }

    public class D : A
    {
        public override string Print() => "D";
    }

    public class E : A
    {
        public new string Print() => "E";
    }

    public class F : A
    {
        public string Print() => "F";
    }

    public class G : B { }

    public class K : B
    {
        public new string Print() => "K";
    }
}
