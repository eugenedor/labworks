using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CsvToDataTable
{
    public class TestDelimiter
    {
        public static void TestGetDelimiter()
        {
            string[] rows = new string[]
            {
                string.Empty,                                   //Pos__0: 
                "",                                             //Pos__1: 
                "abc",                                          //Pos__2: 
                ";;",                                           //Pos__3: 
                @"ghj;abc;ijew;abc;wiuhewiu",                   //Pos__4: 
                @"""123;456;789"";234;345;""456;789"";567",     //Pos__5: 
                @"1965;Пиксель;E240 – формальдегид (опасный консервант)!;""красный, зелёный, битый"";""3000,00""",  //Pos__6: 
                @"1965;Мышка;""А правильней; использовать """"Ёлочки;"""""";;""4900,00""",                          //Pos__7: 
                @"""Н/д"";Кнопка;Сочетания клавиш;""MUST USE! Ctrl, Alt, Shift"";""4799,00""",                      //Pos__8: 
                @"Тест;""Просто тест;""",                       //Pos_9: 
                @"Креатив""Сила;""",                            //Pos_10: 
                @"Тест;""И это тест, это так;""",               //Pos_11: 
                @"Другой тест, ""Тоже важный, а вот так;""",    //Pos_12: 
                @"Чепуха;""И ерундистика,;""",                 //Pos_13: 
                @"ИТ;"""""                                      //Pos_14: 
            };

            var c = 0;
            foreach (var row in rows)
            {
                Console.WriteLine($"Pos = {c}, string = {row}");

                var delimiter = GetDelimiter(row);
                Console.WriteLine($"Delimiter {delimiter}");

                Console.WriteLine();
                c++;
            }

            Console.WriteLine();
        }

        static string GetDelimiter(string row)
        {
            try
            {
                var semicolon = ";";
                var isDelimiterSemicolon = IsDelimiter(row, semicolon);
                Console.WriteLine($"isDelimiterSemicolon = {isDelimiterSemicolon}");
                var comma = ",";
                var isDelimiterComma = IsDelimiter(row, comma);
                Console.WriteLine($"isDelimiterComma = {isDelimiterComma}");

                if (isDelimiterSemicolon && isDelimiterComma)
                {
                    throw new ArgumentNullException("Невозможно определить разделитель");
                }

                if (isDelimiterSemicolon)
                    return semicolon;
                if (isDelimiterComma)
                    return comma;

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static int GetCountOfDelimitersInRow(string row, string delimiter)
        {
            try
            {
                if (row == null)
                {
                    throw new ArgumentNullException("Невозможно определить строку для чтения");
                }
                if (string.IsNullOrEmpty(delimiter))
                {
                    throw new ArgumentNullException("Не указан разделитель для проверки");
                }

                //var delimiterCount = 0;
                //var i = 0;
                //while ((i = row.IndexOf(delimiter, i)) != -1)
                //{
                //    delimiterCount++;
                //    i += delimiter.Length;
                //}

                //var patternOfQuotes = "(?:\\\"[^\\\"]*\\\")";
                //if (delimiterCount > 0 && Regex.IsMatch(row, patternOfQuotes))
                //{
                //    var rowQuotes = Regex.Matches(row, patternOfQuotes);
                //    var excludeDelimiterCount = 0;
                //    foreach (var rowQuot in rowQuotes)
                //    {
                //        var j = 0;
                //        while ((j = rowQuot.ToString().IndexOf(delimiter, j)) != -1)
                //        {
                //            excludeDelimiterCount++;
                //            j += delimiter.Length;
                //        }
                //    }
                //    delimiterCount -= excludeDelimiterCount;
                //}

                var delimiterCount = 0;
                var i = 0;
                var j = 0;
                while ((j = row.IndexOf(delimiter, j)) != -1)
                {
                    var sbstr = row.Substring(i, j - i);

                    var quot = @"""";
                    if (sbstr.Contains(quot))
                    {
                        var quotInSbstrCount = 0;
                        var k = 0;
                        while ((k = sbstr.IndexOf(quot, k)) != -1)
                        {
                            quotInSbstrCount++;
                            k += quot.Length;
                        }
                        if (quotInSbstrCount % 2 == 1)
                        {
                            j += delimiter.Length;
                            continue;
                        }
                    }

                    delimiterCount++;
                    j += delimiter.Length;
                    i = j;
                }
                return delimiterCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static bool IsDelimiter(string row, string delimiter)
        {
            try
            {
                var delimiterCnt = GetCountOfDelimitersInRow(row, delimiter);
                return (delimiterCnt > 0); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

