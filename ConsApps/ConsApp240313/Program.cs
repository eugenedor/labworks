using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsApp240313
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char comma = ',';
            char semicolon = ';';
            char d, g;
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
                
                //";",
                //"303000",
                //"303000;",
                //"303000;404000",
                //"303000;404000;",
                //"303000;404000;505000",
                //"303000;404000;505000;"
            };

            int i = 1;
            foreach (string item in items)
            {
                PrintItems(item, i);

                if (!string.IsNullOrWhiteSpace(item))
                {
                    d = item.Contains(semicolon) ? semicolon : comma;
                    g = item.IndexOf(semicolon, 0) != -1 ? semicolon : comma;
                    Console.WriteLine($"|d = {d} |g = {g}|");

                    if (!DigitsOnlyInString(item.Trim()) && item.IndexOf(comma, 0) != -1)
                    {
                        Console.WriteLine($"PARSE");
                        MethodSplitV1(item, d);
                        MethodSplitV2(item, d);
                        SplitRowV1(item, d);
                        SplitRowV2(item, d);
                    }
                    else
                    {
                        Console.WriteLine(item);
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
                ++i;
            }

            //Console.WriteLine($"text = |{"abcde".Substring(5, 0)}|");

            Console.WriteLine(System.Environment.NewLine + "Press and key to exit");
            Console.ReadKey();
        }

        static void PrintItems(string strng, int num)
        {
            Console.WriteLine($"--{num}-------------------------");
            Console.WriteLine($"Item{num} = \"{strng}\"");

            Console.WriteLine();
        }

        /// <summary>
        /// Только цифры в строке
        /// </summary>
        static bool DigitsOnlyInString(string s)
        {
            foreach (char ch in s)
            {
                if (!char.IsDigit(ch))
                    return false;
            }
            return true;
        }

        static void MethodSplitV1(string s, char d)
        {
            try
            {
                Console.Write("MethodSplitV1: ");

                string[] strArray = s.Split(d).ToArray();
                Console.Write($"length={strArray.Length}   ");
                foreach (string item in strArray)
                    Console.Write("[" + item + "]");

                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static void MethodSplitV2(string s, char d)
        {
            try
            {
                Console.Write("MethodSplitV2: ");

                string[] strArray = s.Split(d).Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();
                Console.Write($"length={strArray.Length}   ");
                foreach (string item in strArray)
                    Console.Write("[" + item + "]");

                Console.WriteLine();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static void SplitRowV1(string row, char separator)
        {
            try
            {
                Console.Write("SplitRowV1:    ");

                string[] strArray;
                if (string.IsNullOrEmpty(row))
                {
                    strArray = new[] { string.Empty };
                    Console.Write($"length={strArray.Length}   ");
                    foreach (string item in strArray)
                        Console.Write("[" + item + "]");

                    Console.WriteLine("");
                    return;
                }
                if (string.IsNullOrEmpty(separator.ToString()) || row.IndexOf(separator, 0) == -1)
                {
                    strArray = new[] { row };
                    Console.Write($"length={strArray.Length}   ");
                    foreach (string item in strArray)
                        Console.Write("[" + item + "]");

                    Console.WriteLine("");
                    return;
                }

                var lst = new List<string>();
                int i = 0, j = 0, len = row.Length;
                while (j <= len)
                {
                    if (j < len)
                        j = row.IndexOf(separator, j) != -1 ? row.IndexOf(separator, j) : len;

                    var subRow = row.Substring(i, j - i);
                    lst.Add(subRow);
                    j += 1;
                    i = j;
                }

                strArray = lst?.ToArray();
                Console.Write($"length={strArray.Length}   ");
                foreach (string item in strArray)
                    Console.Write("[" + item + "]");

                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static void SplitRowV2(string row, char separator)
        {
            try
            {
                Console.Write("SplitRowV2:    ");

                string[] strArray;
                if (string.IsNullOrEmpty(row))
                {
                    strArray = new[] { string.Empty };
                    Console.Write($"length={strArray.Length}   ");
                    foreach (string item in strArray)
                        Console.Write("[" + item + "]");

                    Console.WriteLine("");
                    return;
                }
                if (string.IsNullOrEmpty(separator.ToString()) || row.IndexOf(separator, 0) == -1)
                {
                    strArray = new[] { row };
                    Console.Write($"length={strArray.Length}   ");
                    foreach (string item in strArray)
                        Console.Write("[" + item + "]");

                    Console.WriteLine("");
                    return;
                }

                var lst = new List<string>();
                int i = 0, j = 0, len = row.Length;
                while (j < len)
                {
                    j = row.IndexOf(separator, j) != -1 ? row.IndexOf(separator, j) : len;

                    var subRow = row.Substring(i, j - i);
                    lst.Add(subRow);
                    j += 1;
                    i = j;
                }

                strArray = lst?.ToArray();
                Console.Write($"length={strArray.Length}   ");
                foreach (string item in strArray)
                    Console.Write("[" + item + "]");

                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
