using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsApp220131
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var delimiter = ";";
            string[] strs = new string[]
            {
                null,
                string.Empty,
                "",
                "abc",
                ";;",
                @"ghj;abc;ijew;abc;wiuhewiu", //4
                @"""123;456;789"";234;345;""456;789"";567",   //4 (7)
                @"1965;Пиксель;E240 – формальдегид (опасный консервант)!;""красный, зелёный, битый"";""3000,00""", //4
                @"1965;Мышка;""А правильней использовать """"Ёлочки"""""";;""4900,00""", //4
                @"""Н/д"";Кнопка;Сочетания клавиш;""MUST USE! Ctrl, Alt, Shift"";""4799,00""" //4
            };

            StrsDescr(strs, delimiter);
            GetDimension(strs, delimiter);

            Console.WriteLine();
            Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
            Console.ReadKey();
        }

        static void StrsDescr(string[] strs, string delimiter)
        {
            Console.WriteLine($"delimiter = {delimiter}");
            var c = 0;
            foreach (string str in strs)
            {
                c++;
                Console.WriteLine($"Position = {c}; string = {str}");
            }
            Console.WriteLine($"countRow = {c}");
            Console.WriteLine();
        }

        static void GetDimension(string[] strs, string delimiter)
        {
            var c = 0;
            foreach (string str in strs)
            {
                c++;
                Console.WriteLine($"Position = {c}; string = {str}");

                MethodIndexOf(str, delimiter, true);
                MethodRegexMatches(str, delimiter, true);
                MethodSplit(str, delimiter);
                MethodLINQ(str, delimiter);
                MethodToCharArray(str, delimiter);
                Console.WriteLine();
            }
            Console.WriteLine($"countRow = {c}");
            Console.WriteLine();
        }

        static void MethodIndexOf(string str, string delimiter, bool useQuot = false)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                {
                    Console.WriteLine($"MethodIndexOf. CountCol = 0");
                    return;
                }

                int i = 0, countCol = 0;
                while ((i = str.IndexOf(delimiter, i)) != -1)
                {
                    countCol++;
                    i += delimiter.Length;
                }

                if (useQuot)
                {
                    var pttrnQuot = "(?:\\\"[^\\\"]*\\\")";
                    if (Regex.IsMatch(str, pttrnQuot))
                    {
                        var strQuots = Regex.Matches(str, pttrnQuot);
                        int countEx = 0;
                        foreach (var strQuot in strQuots)
                        {
                            int j = 0;
                            while ((j = strQuot.ToString().IndexOf(delimiter, j)) != -1)
                            {
                                countEx++;
                                j += delimiter.Length;
                            }
                        }
                        countCol -= countEx;
                    }
                }
                Console.WriteLine($"MethodIndexOf. CountCol = {countCol}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MethodIndexOf Exception = {ex.Message}");
            }
        }

        static void MethodRegexMatches(string str, string delimiter, bool useQuot = false)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                {
                    Console.WriteLine($"MethodRegexMatches. CountCol = 0");
                    return;
                }

                var delimits = Regex.Matches(str, delimiter);
                int countCol = delimits.Count;

                if (useQuot)
                {
                    var pttrnQuot = "(?:\\\"[^\\\"]*\\\")";
                    if (Regex.IsMatch(str, pttrnQuot))
                    {
                        var strQuots = Regex.Matches(str, pttrnQuot);

                        int countEx = 0;
                        foreach (var strQuot in strQuots)
                        {
                            var delimitExs = Regex.Matches(strQuot.ToString(), delimiter);
                            countEx += delimitExs.Count;
                        }
                        countCol -= countEx;
                    }
                }

                Console.WriteLine($"MethodRegexMatches. CountCol = {countCol}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MethodRegexMatches Exception = {ex.Message}");
            }
        }

        static void MethodSplit(string str, string delimiter)
        {
            try
            {
                string[] strArray = str.Split(delimiter.ToCharArray()[0]);
                int countCol = strArray.Length - 1;

                Console.WriteLine($"MethodSplit. CountCol = {countCol}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MethodSplit Exception = {ex.Message}");
            }
        }

        static void MethodLINQ(string str, string delimiter)
        {
            try
            {
                int countCol =
                    (from ch in str
                     where ch.ToString() == delimiter
                     //where delimiter.Equals(ch.ToString())
                     select ch).Count();

                Console.WriteLine($"MethodLINQ. CountCol = {countCol}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MethodLINQ Exception = {ex.Message}");
            }
        }

        static void MethodToCharArray(string str, string delimiter)
        {
            try
            {
                int countCol = str.ToCharArray().Where(i => i.ToString() == delimiter).Count();

                Console.WriteLine($"MethodToCharArray. CountCol = {countCol}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MethodToCharArray Exception = {ex.Message}");
            }
        }
    }
}
