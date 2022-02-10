using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CsvToDataTable
{
    public class TestFieldsInRow
    {
        public static void TestCountOfFieldsInRow()
        {
            var separator = ";";
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
                Console.WriteLine($"Pos = {c}, string = {row}");

                var countOfFieldsInRowMatches = GetCountOfFieldsInRowMatches(row, separator);
                Console.WriteLine($"CountOfFieldsInRowMatches      = {countOfFieldsInRowMatches}");
                
                var countOfFieldsInRowMtchsIndexOf = GetCountOfFieldsInRowMtchsIndexOf(row, separator);                
                Console.WriteLine($"CountOfFieldsInRowMtchsIndexOf = {countOfFieldsInRowMtchsIndexOf}");

                var countOfFieldsInRowIndexOf = GetCountOfFieldsInRowIndexOf(row, separator);
                Console.WriteLine($"CountOfFieldsInRowIndexOf      = {countOfFieldsInRowIndexOf}");

                Console.WriteLine();
                c++;
            }

            var str = "ABCD";
            var ixA = str.IndexOf("A", 0);
            var ixB = str.IndexOf("B", 0);
            var ixD = str.IndexOf("D", 0);
            var sbstr = str.Substring(0, str.Length);

            Console.WriteLine($"str={str}, ixA={ixA}, ixB={ixB}, ixD={ixD}, sbstr={sbstr}");
        }

        static int GetCountOfFieldsInRowMatches(string row, string separator)
        {
            try
            {
                if (string.IsNullOrEmpty(row))
                    return 0;
                if (string.IsNullOrEmpty(separator))
                    return 1;

                //TODO GetCountOfSeparatorInRow
                var separators = Regex.Matches(row, separator);
                var separatorCount = separators.Count;

                var patternOfQuotes = "(?:\\\"[^\\\"]*\\\")";
                if (separatorCount > 0 && Regex.IsMatch(row, patternOfQuotes))
                {
                    var rowQuotes = Regex.Matches(row, patternOfQuotes);
                    var excludeSeparatorCount = 0;
                    foreach (var rowQuot in rowQuotes)
                    {
                        var excludeSeparators = Regex.Matches(rowQuot.ToString(), separator);
                        excludeSeparatorCount += excludeSeparators.Count;
                    }
                    separatorCount -= excludeSeparatorCount;
                }
                var fieldCount = separatorCount + 1;
                return fieldCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static int GetCountOfFieldsInRowMtchsIndexOf(string row, string separator)
        {
            try
            {
                if (string.IsNullOrEmpty(row))
                    return 0;
                if (string.IsNullOrEmpty(separator))
                    return 1;

                //TODO GetCountOfSeparatorInRow
                var separatorCount = 0;
                var i = 0;
                while ((i = row.IndexOf(separator, i)) != -1)
                {
                    ++separatorCount;
                    i += separator.Length;
                }

                var patternOfQuotes = "(?:\\\"[^\\\"]*\\\")";
                if (separatorCount > 0 && Regex.IsMatch(row, patternOfQuotes))
                {
                    var rowQuotes = Regex.Matches(row, patternOfQuotes);
                    var excludeSeparatorCount = 0;
                    foreach (var rowQuot in rowQuotes)
                    {
                        var j = 0;
                        while ((j = rowQuot.ToString().IndexOf(separator, j)) != -1)
                        {
                            ++excludeSeparatorCount;
                            j += separator.Length;
                        }
                    }
                    separatorCount -= excludeSeparatorCount;
                }
                //
                var fieldCount = separatorCount + 1;
                return fieldCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static int GetCountOfFieldsInRowIndexOf(string row, string separator)
        {
            try
            {
                if (string.IsNullOrEmpty(row))
                    return 0;
                if (string.IsNullOrEmpty(separator))
                    return 1;

                //TODO GetCountOfSeparatorInRow New!!!
                var separatorCount = 0;
                var i = 0;
                var j = 0;
                while ((j = row.IndexOf(separator, j)) != -1)
                {
                    var sbstr = row.Substring(i, j - i);

                    var quot = @"""";
                    if (sbstr.Contains(quot))
                    {
                        var quotInSbstrCount = 0;
                        var k = 0;
                        while ((k = sbstr.IndexOf(quot, k)) != -1)
                        {
                            ++quotInSbstrCount;
                            k += quot.Length;
                        }
                        if (quotInSbstrCount % 2 == 1)
                        {
                            j += separator.Length;
                            continue;
                        }
                    }

                    ++separatorCount;
                    j += separator.Length;
                    i = j;
                }
                //
                var fieldCount = separatorCount + 1;
                return fieldCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
