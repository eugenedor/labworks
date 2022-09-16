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

            //Console.WriteLine(12.34m.ToString("F8", new CultureInfo("ru-RU")));
            //Console.WriteLine(12.34m.ToString("F15", new CultureInfo("ru-RU")));
            //Console.WriteLine();

            Console.WriteLine($"str1 = {str1}");
            Console.WriteLine($"str2 = {str2}");

            Console.WriteLine();
            Console.WriteLine("MetOne");
            MetOne(str1);
            MetOne(str2);

            Console.WriteLine();
            Console.WriteLine("MetMod");
            MetMod(str1);
            MetMod(str2);

            Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
            Console.ReadKey();
        }

        private static void MetOne(string str)
        {
            //string SymReplace(string s, string oldVal, string newVal)
            //{
            //    return s.Contains(oldVal) ? s.Replace(oldVal, newVal) : s;
            //}

            Console.WriteLine($"{nameof(str)} = {str}");
            //var comma = ",";
            //var dot = ".";

            if (decimal.TryParse(str, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal dec))
            {
                Console.WriteLine("<->");
                Console.WriteLine($"{nameof(str)} = {str}");
                Console.WriteLine($"1 dec = {dec}");
                Console.WriteLine($"RESULT: {dec.ToString()}");
            }
            else
            {
                Console.WriteLine("comma -> dot");
                if (str.Contains(","))
                    str = str.Replace(",", ".");

                //Console.WriteLine("dot -> comma");
                //if (str.Contains("."))
                //    str = str.Replace(".", ",");

                //str = SymReplace(str, comma, dot)
                //Console.WriteLine("dot -> comma");
                //str = SymReplace(str, dot, comma);
                Console.WriteLine($"{nameof(str)} = {str}");
                if (decimal.TryParse(str, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out dec))
                {
                    Console.WriteLine($"2 dec = {dec}");
                    Console.WriteLine($"RESULT: {dec.ToString()}");
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
            if (decimal.TryParse(str, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal dec))
            {
                Console.WriteLine($"RESULT: {dec.ToString()}");
            }
            else
            {
                if (str.Contains(","))
                    str = str.Replace(",", ".");

                //if (str.Contains("."))
                //    str = str.Replace(".", ",");

                if (decimal.TryParse(str, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out dec))
                {
                    Console.WriteLine($"RESULT: {dec.ToString()}");
                }
                else
                {
                    Console.WriteLine($"RESULT DEFAULT: {str}");
                }
            }
        }
    }
}
