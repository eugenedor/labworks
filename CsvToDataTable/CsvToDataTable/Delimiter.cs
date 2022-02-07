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
                null,                                           //Pos__0: 
                string.Empty,                                   //Pos__1: 
                "",                                             //Pos__2: 
                "abc",                                          //Pos__3: 
                ";;",                                           //Pos__4: 
                @"ghj;abc;ijew;abc;wiuhewiu",                   //Pos__5: 
                @"""123;456;789"";234;345;""456;789"";567",     //Pos__6: 
                @"1965;Пиксель;E240 – формальдегид (опасный консервант)!;""красный, зелёный, битый"";""3000,00""",  //Pos__7: 
                @"1965;Мышка;""А правильней; использовать """"Ёлочки;"""""";;""4900,00""",                          //Pos__8: 
                @"""Н/д"";Кнопка;Сочетания клавиш;""MUST USE! Ctrl, Alt, Shift"";""4799,00""",                      //Pos__9: 
                @"Тест;""Просто тест;""",                       //Pos_10: 
                @"Креатив""Сила;""",                            //Pos_11: 
                @"Тест;""И это тест, это так;""",               //Pos_12: 
                @"Другой тест, ""Тоже важный, а вот так;""",    //Pos_13: 
                @"Чепуха;""И ерундистика,;"""                   //Pos_14: 
            };
        }
    }
}
