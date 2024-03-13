using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsApp220130
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var str = "ghj;abc;ijew;abc;wiuhewiu;abc;wkkabc;";
            var delimiter = ";";
            string[] strs = new string[]
            {
                @"ghj;abc;ijew;abc;wiuhewiu", //4
                @"""123;456;789"";234;345;""456;789"";567",   //4 (7)
                @"1965;Пиксель;E240 – формальдегид (опасный консервант)!;""красный, зелёный, битый"";""3000,00""", //4
                @"1965;Мышка;""А правильней использовать """"Ёлочки"""""";;""4900,00""", //4
                @"""Н/д"";Кнопка;Сочетания клавиш;""MUST USE! Ctrl, Alt, Shift"";""4799,00""" //4
            };

            var c = 0;
            foreach (string str in strs)
            {
                c++;
                Console.WriteLine($"Position = {c}; string = {str}");
            }
            Console.WriteLine($"countRow = {c}");

            Console.WriteLine();
            Console.WriteLine($"delimiter = {delimiter}");

            c = 0;
            foreach (string str in strs)
            {
                c++;
                Console.WriteLine($"Position = {c}; string = {str}");

                MethodIndexOf(str, delimiter);
                MethodRegexMatches(str, delimiter);
                MethodSplit(str, delimiter);
                MethodLINQ(str, delimiter);
                MethodToCharArray(str, delimiter);
                Console.WriteLine();
            }
            Console.WriteLine($"countRow = {c}");
            Console.WriteLine();

            Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
            Console.ReadKey();
        }

        static void MethodIndexOf(string str, string delimiter)
        {
            string pttrn = @"(?:\""[^\""]*\"")";
            MatchCollection matches = Regex.Matches(str, pttrn);
            var x = matches.Count;

            int cntExcpt = 0;
            foreach (Match match in matches)
            {
                int j = 0;
                while ((j = match.ToString().IndexOf(delimiter, j)) != -1)
                {
                    cntExcpt++;
                    j += delimiter.Length;
                }
            }

            int i = 0, count = 0;
            while ((i = str.IndexOf(delimiter, i)) != -1)
            {
                count++;
                i += delimiter.Length;
            }

            Console.WriteLine($"MethodIndexOf. CountCol = {count - cntExcpt}");
        }

        static void MethodRegexMatches(string str, string delimiter)
        {
            MatchCollection matches = Regex.Matches(str, delimiter);
            int count = matches.Count;

            Console.WriteLine($"MethodRegexMatches. CountCol = {count}");
        }

        static void MethodSplit(string str, string delimiter)
        {
            string[] strArray = str.Split(delimiter.ToCharArray()[0]);
            int count = strArray.Length - 1;

            Console.WriteLine($"MethodSplit. CountCol = {count}");
        }

        static void MethodLINQ(string str, string delimiter)
        {
            int count =
                (from ch in str
                 where ch.ToString() == delimiter
                 //where delimiter.Equals(ch.ToString())
                 select ch).Count();

            Console.WriteLine($"MethodLINQ. CountCol = {count}");
        }

        static void MethodToCharArray(string str, string delimiter)
        {
            int count = str.ToCharArray().Where(i => i.ToString() == delimiter).Count();

            Console.WriteLine($"MethodToCharArray. CountCol = {count}");
        }
    }
}
