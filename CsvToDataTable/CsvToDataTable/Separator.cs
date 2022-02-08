using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToDataTable
{
    public class Separator
    {
        public static void TestSepar()
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
                @"ABC;DE;F",                                    //Pos__6: 7
                @"ABC;DE;F;",                                   //Pos__7: 4
                @"""123;456;789"";234;345;""456;789"";567"      //Pos__8: 5 (8)
            };

            var c = 0;
            foreach (string row in rows)
            {                
                Console.WriteLine($"Pos = {c}, string = {row}");
                var fields = Split(row, delimiter);
                Console.WriteLine("-SeparVarOne-");
                for (int i = 0; i < fields.Length; i++)
                {
                    Console.WriteLine($"{i} fieldValue=|{fields[i]}|");
                }
                Console.WriteLine();
                c++;
            }
        }

        static string[] Split(string row, string delimiter) 
        {
            if (string.IsNullOrEmpty(row))
                return new [] { string.Empty };

            var lst = new List<string>();
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

                lst.Add(sbstr);
                j += delimiter.Length;
                i = j;
            }

            j = row.Length;
            var sbstrLast = row.Substring(i, j - i);
            lst.Add(sbstrLast);

            return lst?.ToArray();
        }
    }
}
