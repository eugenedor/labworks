using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicDeleg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();

            var v1 = 9m;
            var v2 = 3m;

            Console.WriteLine("*****SimpleOperation*****");
            Console.WriteLine("variables1:");
            Console.WriteLine($"v1 = {v1}; v2 = {v2}");
            Console.WriteLine();

            Console.WriteLine($"result1(+) = {calc.SimpleOperation("+", v1, v2)}");
            Console.WriteLine($"result1(-) = {calc.SimpleOperation("-", v1, v2)}");
            Console.WriteLine($"result1(*) = {calc.SimpleOperation("*", v1, v2)}");
            Console.WriteLine($"result1(/) = {calc.SimpleOperation("/", v1, v2)}");
            Console.WriteLine();

            v1 = 14m;
            v2 = 2m;

            Console.WriteLine("*****PerformOperation*****");
            Console.WriteLine("variables2:");
            Console.WriteLine($"v1 = {v1}; v2 = {v2}");
            Console.WriteLine();

            Console.WriteLine($"result2(+) = {calc.PerformOperation("+", v1, v2)}");
            Console.WriteLine($"result2(-) = {calc.PerformOperation("-", v1, v2)}");
            Console.WriteLine($"result2(*) = {calc.PerformOperation("*", v1, v2)}");
            Console.WriteLine($"result2(/) = {calc.PerformOperation("/", v1, v2)}");

            Console.WriteLine("defineoperation: mod %");
            calc.DefineOperation("mod", (x, y) => x % y);
            Console.WriteLine($"result2(mod) = {calc.PerformOperation("mod", v1, v2)}");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("*****StringHelper*****");            
            Console.WriteLine("Apple is capitalized:     " + "Apple".IsCapitalized());
            Console.WriteLine("pineapple is capitalized: " + StringHelper.IsCapitalized("pineapple"));

            Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
            Console.ReadKey();
        }
    }
}
