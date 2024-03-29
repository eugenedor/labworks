﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToDataTable
{
    public class TestSplit
    {
        public static void TestSplt()
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
                @"ABC;DE;F",                                    //Pos__6: 7
                @"ABC;DE;F;",                                   //Pos__7: 4
                @"ABC;""DE;F""",                                //Pos__8: 4
                @"ABC;""DE;F;""",                               //Pos__9: 4
                @"""123;456;789"";234;345;""456;789"";567"      //Pos__10: 5 (8)
            };

            var c = 0;
            Console.WriteLine("--SpltRowBackup--");
            foreach (string row in rows)
            {
                Console.WriteLine($"Pos = {c}, string = {row}");
                var fields = SpltRowBackup(row, separator);
                Console.WriteLine("-SeparVar-");
                for (int i = 0; i < fields.Length; i++)
                {
                    Console.WriteLine($"{i} fieldValue=|{fields[i]}|");
                }
                Console.WriteLine();
                c++;
            }

            Console.WriteLine(System.Environment.NewLine + "Press any key");
            Console.ReadKey();
            Console.Clear();

            c = 0;
            Console.WriteLine("--SplitRow--");
            foreach (string row in rows)
            {                
                Console.WriteLine($"Pos = {c}, string = {row}");
                var fields = SplitRow(row, separator);
                Console.WriteLine("-SeparVar-");
                for (int i = 0; i < fields.Length; i++)
                {
                    Console.WriteLine($"{i} fieldValue=|{fields[i]}|");
                }
                Console.WriteLine();
                c++;
            }
        }

        static string[] SpltRowBackup(string row, string separator)
        {
            try
            {
                if (string.IsNullOrEmpty(row))
                    return new[] { string.Empty };
                if (string.IsNullOrEmpty(separator) || row.IndexOf(separator, 0) == -1)
                    return new[] { row };


                var lst = new List<string>();
                int i = 0, j = 0;
                while ((j = row.IndexOf(separator, j)) != -1)
                {
                    var sbstr = row.Substring(i, j - i);
                    var quot = @"""";
                    if (sbstr.Contains(quot))
                    {
                        int quotInSbstrCount = 0, k = 0;
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
                    lst.Add(sbstr);
                    j += separator.Length;
                    i = j;
                }
                j = row.Length;
                var sbstrLast = row.Substring(i, j - i);
                lst.Add(sbstrLast);

                return lst?.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static string[] SplitRow(string row, string separator)
        {
            try
            {
                if (string.IsNullOrEmpty(row))
                    return new[] { string.Empty };
                if (string.IsNullOrEmpty(separator) || row.IndexOf(separator, 0) == -1)
                    return new[] { row };

                var lst = new List<string>();
                int i = 0, j = 0, len = row.Length;
                while (j <= len)
                {
                    j = row.IndexOf(separator, j) != -1 ? row.IndexOf(separator, j) : len;
                    var sbstr = row.Substring(i, j - i);
                    var quot = @"""";
                    if (sbstr.Contains(quot))
                    {
                        int quotInSbstrCount = 0, k = 0;
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
                    lst.Add(sbstr);
                    j += separator.Length;
                    i = j;
                }

                return lst?.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
