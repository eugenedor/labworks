using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapter.Abstract;
using Adapter.Concrete;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // путешественник
            Driver driver = new Driver();
            // машина
            Auto auto = new Auto();
            // отправляемся в путешествие
            driver.Travel(auto);                                     //ITransport.Drive();
            // встретились пески, надо использовать верблюда
            Camel camel = new Camel();
            // используем адаптер
            ITransport camelTransport = new CamelToTransportAdapter(camel);
            // продолжаем путь по пескам пустыни
            driver.Travel(camelTransport);                           //ITransport.Drive();

            Console.Read();
        }
    }
}


//class Client
//{
//    public void Request(Target target)
//    {
//        target.Request();
//    }
//}
//// класс, к которому надо адаптировать другой класс   
//class Target
//{
//    public virtual void Request()
//    { }
//}

//// Адаптер
//class Adapter : Target
//{
//    private Adaptee adaptee = new Adaptee();

//    public override void Request()
//    {
//        adaptee.SpecificRequest();
//    }
//}

//// Адаптируемый класс
//class Adaptee
//{
//    public void SpecificRequest()
//    { }
//}
