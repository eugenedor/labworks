using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.Abstract;
using Builder.Concrete;


namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Builder.Abstract.Builder builder = new ConcreteBuilder();
            Director director = new Director(builder);
            director.Construct();
            Product product = builder.GetResult();

            foreach (var part in product.parts)
                Console.WriteLine(part);

            Console.ReadKey();
        }
    }
}
