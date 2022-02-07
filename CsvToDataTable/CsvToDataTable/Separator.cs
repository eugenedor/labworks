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
                @"""123;456;789"";234;345;""456;789"";567"      //Pos__6: 5 (8)
            };

            var c = 0;
            foreach (string row in rows)
            {                
                Console.WriteLine($"Pos = {c}, string = {row}");
                var fields = Separ(row, delimiter);
                Console.WriteLine("-SeparVarOne-");
                for (int i = 0; i < fields.Length; i++)
                {
                    Console.WriteLine($"{i} fieldValue=|{fields[i]}|");
                }
                Console.WriteLine();
                c++;
            }
        }

        static string[] Separ(string row, string delimiter) 
        {
            if (string.IsNullOrEmpty(row))
                return new [] { string.Empty };

            var lst = new List<string>();
            var i = 0;
            var j = 0;
            while ((j = row.IndexOf(delimiter, j)) != -1)
            {
                var s = row.Substring(i, j - i);

                if (s.Contains(@""""))
                {
                    var c = 0;
                    var k = 0;
                    while ((k = s.IndexOf(@"""", k)) != -1)
                    {
                        c++;
                        k += @"""".Length;
                    }
                    if (c % 2 == 1)
                    {
                        j += delimiter.Length;
                        continue;
                    }
                }

                lst.Add(s);
                j += delimiter.Length;
                i = j;
            }

            j = row.Length;
            var se = row.Substring(i, j - i);
            lst.Add(se);

            return lst?.ToArray();
        }
    }
}
