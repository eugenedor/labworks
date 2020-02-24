using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Concrete;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var structure = new Bank();
            structure.Add(new Person { Name = "Иван Алексеев", Number = "82184931" });
            structure.Add(new Company { Name = "Microsoft", RegNumber = "ewuir32141324", Number = "3424131445" });
            Console.WriteLine("HtmlVisitor");            
            structure.Accept(new HtmlVisitor());
            Console.WriteLine();

            Console.WriteLine("XmlVisitor");
            structure.Accept(new XmlVisitor());                        

            Console.ReadLine();
        }
    }
}
