using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsApp240314
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var items = new string[]
{
                "",
                ",",
                "000000",
                "000000,",
                "000000,101000",
                "000000,101000,",
                "000000,101000,202000",
                "000000,101000,202000,",
            };


            int i = 0;
            foreach (var item in items)
            {
                var codes = new List<string>() { "000000", "101000", "202000", "303000", "404000", "505000" };

                Console.WriteLine($"--{i}--------------------------------------------------");
                
                Console.Write($"codes{i}: ");
                foreach (string code in codes)
                    Console.Write("[" + code + "]");
                Console.WriteLine();

                Console.WriteLine($"item{i} = \"{item}\"");
                Console.WriteLine();

                if (!string.IsNullOrWhiteSpace(item))
                {
                    var comma = ',';
                    if (!DigitsOnlyInString(item.Trim()) && item.IndexOf(comma) != -1)
                    {
                        Console.WriteLine($"***Parse***");
                        //string[] itemArray = item.Split(comma).ToArray();
                        var itemArray = item.Split(comma).Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();
                        Console.Write($"length={itemArray.Length}   ");
                        foreach (var it in itemArray)
                            Console.Write("[" + it + "]");
                        Console.WriteLine("");
                        Console.WriteLine($"***********");

                        codes = codes.Where(p => itemArray.Contains(p)).ToList();
                    }
                    else
                    {
                        Console.WriteLine($"***Equal***");
                        Console.WriteLine(item);
                        Console.WriteLine($"***********");

                        codes = codes.Where(p => p == item).ToList();
                    }

                    Console.WriteLine();
                    Console.Write("codesResult: ");
                    foreach (var code in codes)
                        Console.Write("[" + code + "]");

                    Console.WriteLine();
                }

                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine();
                ++i;
            }

            Console.WriteLine(System.Environment.NewLine + "Press and key to exit");
            Console.ReadKey();
        }

        /// <summary>
        /// Только цифры в строке
        /// </summary>
        private static bool DigitsOnlyInString(string s)
        {
            foreach (char ch in s)
                if (!char.IsDigit(ch))
                    return false;

            return true;
        }
    }
}
