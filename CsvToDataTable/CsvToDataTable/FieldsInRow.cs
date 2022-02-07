using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CsvToDataTable
{
    public class FieldsInRow
    {
        public static void TestCountOfFieldsInRow()
        {
            var delimiter = ";";
            string[] rows = new string[]
            {
                null,                                           //Pos__0: 0
                string.Empty,                                   //Pos__1: 0
                "",                                             //Pos__2: 0
                "abc",                                          //Pos__3: 1
                ";;",                                           //Pos__4: 3
                @"ghj;abc;ijew;abc;wiuhewiu",                   //Pos__5: 5
                @"""123;456;789"";234;345;""456;789"";567",     //Pos__6: 5 (8)
                @"1965;Пиксель;E240 – формальдегид (опасный консервант)!;""красный, зелёный, битый"";""3000,00""",  //Pos__7: 5
                @"1965;Мышка;""А правильней; использовать """"Ёлочки;"""""";;""4900,00""",                          //Pos__8: 5 (7)
                @"""Н/д"";Кнопка;Сочетания клавиш;""MUST USE! Ctrl, Alt, Shift"";""4799,00""",                      //Pos__9: 5
                @"Тест;""Просто тест;""",                       //Pos_10: 2 (3)
                @"Креатив""Сила;""",                            //Pos_11: 1 (2)
                @"Тест;""И это тест, это так;""",               //Pos_12: 2 (3)
                @"Другой тест, ""Тоже важный, а вот так;""",    //Pos_13: 1 (2)
                @"Чепуха;""И ерундистика,;""",                  //Pos_14: 2 (3)
                @"ИТ;"""""                                      //Pos_15: 2 (2)
            };

            var c = 0;
            foreach (var row in rows)
            {
                Console.WriteLine($"Pos = {c}");

                var countFieldsMatches = GetCountOfFieldsInRowMatches(row, delimiter);
                Console.WriteLine($"CountFieldsMatches = {countFieldsMatches}; string = {row}");
                
                var countFieldsIndexOf = GetCountOfFieldsInRowMtchsIndexOf(row, delimiter);
                Console.WriteLine($"CountFieldsIndexOf = {countFieldsIndexOf}; string = {row}");
                
                Console.WriteLine();
                c++;
            }

            var str = "ABCD";
            var ixA = str.IndexOf("A", 0);
            var ixB = str.IndexOf("B", 0);
            var ixD = str.IndexOf("D", 0);

            Console.WriteLine($"str={str}, ixA={ixA}, ixB={ixB}, ixD={ixD}");
        }

        static int GetCountOfFieldsInRowMatches(string row, string delimiter)
        {
            try
            {
                if (string.IsNullOrEmpty(row))
                    return 0;

                var delimiters = Regex.Matches(row, delimiter);
                var delimiterCount = delimiters.Count;

                var patternOfQuotes = "(?:\\\"[^\\\"]*\\\")";
                if (Regex.IsMatch(row, patternOfQuotes))
                {
                    var rowQuotes = Regex.Matches(row, patternOfQuotes);
                    var excludeDelimiterCount = 0;
                    foreach (var rowQuot in rowQuotes)
                    {
                        var excludeDelimiters = Regex.Matches(rowQuot.ToString(), delimiter);
                        excludeDelimiterCount += excludeDelimiters.Count;
                    }
                    delimiterCount -= excludeDelimiterCount;
                }
                var fieldCount = delimiterCount + 1;
                return fieldCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static int GetCountOfFieldsInRowMtchsIndexOf(string row, string delimiter)
        {
            try
            {
                if (string.IsNullOrEmpty(row))
                    return 0;

                var delimiterCount = 0;
                var i = 0;
                while ((i = row.IndexOf(delimiter, i)) != -1)
                {
                    delimiterCount++;
                    i += delimiter.Length;
                }

                var patternOfQuotes = "(?:\\\"[^\\\"]*\\\")";
                if (Regex.IsMatch(row, patternOfQuotes))
                {
                    var rowQuotes = Regex.Matches(row, patternOfQuotes);
                    var excludeDelimiterCount = 0;
                    foreach (var rowQuot in rowQuotes)
                    {
                        var j = 0;
                        while ((j = rowQuot.ToString().IndexOf(delimiter, j)) != -1)
                        {
                            excludeDelimiterCount++;
                            j += delimiter.Length;
                        }
                    }
                    delimiterCount -= excludeDelimiterCount;
                }
                var fieldCount = delimiterCount + 1;
                return fieldCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
