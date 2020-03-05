using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facade.Concrete;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            TextEditor textEditor = new TextEditor();
            Compiller compiller = new Compiller();
            CLR clr = new CLR();

            VisualStudioFacade ide = new VisualStudioFacade(textEditor, compiller, clr);

            Programmer programmer = new Programmer();
            programmer.CreateApplication(ide);

            Console.Read();
        }
    }
}


//class SubsystemA
//{
//    public void A1()
//    { }
//}
//class SubsystemB
//{
//    public void B1()
//    { }
//}
//class SubsystemC
//{
//    public void C1()
//    { }
//}

//public class Facade
//{
//    SubsystemA subsystemA;
//    SubsystemB subsystemB;
//    SubsystemC subsystemC;

//    public Facade(SubsystemA sa, SubsystemB sb, SubsystemC sc)
//    {
//        subsystemA = sa;
//        subsystemB = sb;
//        subsystemC = sc;
//    }
//    public void Operation1()
//    {
//        subsystemA.A1();
//        subsystemB.B1();
//        subsystemC.C1();
//    }
//    public void Operation2()
//    {
//        subsystemB.B1();
//        subsystemC.C1();
//    }
//}

//class Client
//{
//    public void Main()
//    {
//        Facade facade = new Facade(new SubsystemA(), new SubsystemB(), new SubsystemC());
//        facade.Operation1();
//        facade.Operation2();
//    }
//}
