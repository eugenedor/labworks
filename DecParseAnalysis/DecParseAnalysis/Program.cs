using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DecParseAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var str1 = "123.456";
            var str2 = "987,654";

            Console.WriteLine($"str1 = {str1}");
            Console.WriteLine($"str2 = {str2}");

            Console.WriteLine();
            MetOne(str1);
            MetOne(str2);

            Console.WriteLine();
            MetMod(str1);
            MetMod(str2);

            Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
            Console.ReadKey();
        }

        private static void MetOne(string str)
        {
            string SymReplace(string s, string oldVal, string newVal)
            {
                return s.Contains(oldVal) ? s.Replace(oldVal, newVal) : s;
            }

            Console.WriteLine($"{nameof(str)} = {str}");
            var comma = ",";
            var dot = ".";

            if (decimal.TryParse(str, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal dec))
            {
                Console.WriteLine("<->");
                Console.WriteLine($"{nameof(str)} = {str}");
                Console.WriteLine("dec1 - true");
                Console.WriteLine($"dec1 = {dec}");
                Console.WriteLine($"RESULT =====> {SymReplace(dec.ToString(), comma, dot)}");
            }
            else
            {
                Console.WriteLine("comma -> dot");
                str = SymReplace(str, comma, dot);
                Console.WriteLine($"{nameof(str)} = {str}");
                if (decimal.TryParse(str, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out dec))
                {
                    Console.WriteLine("dec2 - true");
                    Console.WriteLine($"dec2 = {dec}");
                    Console.WriteLine($"RESULT =====> {SymReplace(dec.ToString(), comma, dot)}");
                }
                else
                {
                    Console.WriteLine("dec3 - false");
                }
            }
            Console.WriteLine();
        }

        private static void MetMod(string str)
        {
            string CommaReplace(string s)
            {
                return s.Contains(",") ? s.Replace(",", ".") : s;
            }

            string res = CommaReplace(str);
            if (decimal.TryParse(res, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal decResult))
            {
                Console.WriteLine($"{nameof(str)} = {str}");
                Console.WriteLine($"{nameof(res)} = {res}");
                Console.WriteLine($"decResult = {decResult}");
                Console.WriteLine($"RESULT =====> {CommaReplace(decResult.ToString())}");
                Console.WriteLine();
            }

        }
    }
}
