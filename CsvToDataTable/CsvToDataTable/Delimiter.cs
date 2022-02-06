using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CsvToDataTable
{
    public class Delimiter
    {
        public static void TestIsDelimiter()
        {
            string[] rows = new string[]
            {
                null,
                string.Empty,
                "",
                "abc",
                ";;",
                @"ghj;abc;ijew;abc;wiuhewiu",
                @"""123;456;789"";234;345;""456;789"";567",   //4 (7)
                @"1965;Мышка;""А правильней; использовать """"Ёлочки;"""""";;""4900,00""", //4 (6)
                @"Тест;""Просто тест;""", //1 (2)
                @"Креатив""Сила;""" //0 (1)
            };
        }
    }
}
