using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CsvToDataTable
{
    public class TestSeparator
    {
        public static void TestGetSeparator()
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

                var separator = GetSeparator(row);
                Console.WriteLine($"Separator {separator}");

                Console.WriteLine();
                c++;
            }

            Console.WriteLine();
        }

        static string GetSeparator(string row)
        {
            try
            {
                var semicolon = ";";
                var isSeparatorSemicolon = IsSeparator(row, semicolon);
                Console.WriteLine($"isSeparatorSemicolon = {isSeparatorSemicolon}");
                var comma = ",";
                var isSeparatorComma = IsSeparator(row, comma);
                Console.WriteLine($"isSeparatorComma = {isSeparatorComma}");

                if (isSeparatorSemicolon && isSeparatorComma)
                {
                    throw new ArgumentNullException("Невозможно определить разделитель");
                }

                if (isSeparatorSemicolon)
                    return semicolon;
                if (isSeparatorComma)
                    return comma;

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static int GetCountOfSeparatorsInRow(string row, string separator)
        {
            try
            {
                if (row == null)
                {
                    throw new ArgumentNullException("Невозможно определить строку для чтения");
                }
                if (string.IsNullOrEmpty(separator))
                {
                    throw new ArgumentNullException("Не указан разделитель для проверки");
                }

                //var separatorCount = 0;
                //var i = 0;
                //while ((i = row.IndexOf(separator, i)) != -1)
                //{
                //    ++separatorCount;
                //    i += separator.Length;
                //}

                //var patternOfQuotes = "(?:\\\"[^\\\"]*\\\")";
                //if (separatorCount > 0 && Regex.IsMatch(row, patternOfQuotes))
                //{
                //    var rowQuotes = Regex.Matches(row, patternOfQuotes);
                //    var excludeSeparatorCount = 0;
                //    foreach (var rowQuot in rowQuotes)
                //    {
                //        var j = 0;
                //        while ((j = rowQuot.ToString().IndexOf(separator, j)) != -1)
                //        {
                //            ++excludeSeparatorCount;
                //            j += separator.Length;
                //        }
                //    }
                //    separatorCount -= excludeSeparatorCount;
                //}

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
                return separatorCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static bool IsSeparator(string row, string separator)
        {
            try
            {
                var separatorCount = GetCountOfSeparatorsInRow(row, separator);
                return (separatorCount > 0); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

