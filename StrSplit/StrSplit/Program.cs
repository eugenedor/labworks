using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StrSplit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string separator = ";";
            string[] strs;

            strs = new string[]
            {
                "1;Текст1\"Текст2\"Текст3\";123;456;",
                "2;Текст1\"Текст2\"Текст3\";\"АБВ\";123;",
                "3;Текст1\"Текст2\"Текст3\";\"Текст\";123;",
                "4;Текст1\"Текст2\"Текст3\";\"\"Текст\"\";123;",
                "5;Текст1\"Текст2\"Текст3\";\"\"\"Текст\"\"\";123;",
                "6;Текст1\"Текст2\"Текст3\";Текст1\"Текст2\"Текст3\";123;",
                "7;Текст1\"Текст2;\"123;456;",
                "8;Текст1\"Текст2;\"123;456;789;",
                "9;\"Текст1;Текст2;\";123;456;789;",
                "10;\"Текст1\"Текст2\";\";123;456;789;",
                "11;\"Текст1;Текст2\";123;456;789;",
                "12;",
                "13;13",
                "14;;",
                "15;\"Текст1;Текст2\"",
                "16;\"Текст1;Текст2\";123",
                "17;Текст0\"Текст1;Текст2\";123",
                "18;'Текст1;Текст2\";123",
                "19;Текст1\"Текст2\"Текст3\";123;",
                "20;\"Текст1;\"\"Текст2\"\"Текст3\"\"\";123;",
                "21;\"Текст1\"\"Текст2\"\";Текст3\"\"\";123;",
                "22;\"Текст1\"\"Текст2\"\";\"\"Текст3\"\"\";123;",
                "23;\"Текст1\"\"Текст2\"\"\";123;456;",
                "24;\"Текст1Текст2\";123;456;789;",
                "25;   \"Текст1;Текст2\";123",
                "26;'Текст1;Текст2';123",
                "27;\"Текст1 \"\"",
                "28;\"Те\"\"кс\"\"т1\"Текст2\";\"123;456;789;",
                "29;\"Те\"\"кс\"\"т1\"Текст2\";123;456;789;",
                "30;\" \" \";123;456;789;",
                "31; \" \" \";123;456;789;"
            };

            int i = 1;
            foreach (string str in strs)
            {
                Console.WriteLine($"{i}) {str}");
                //var separCount = GetCountOfSeparatorsInRow(str, separator);
                var result = SplitRow(str, separator);
                PrintItems(result, -1);
                ++i;
                Console.WriteLine();
            }

            Console.WriteLine(System.Environment.NewLine + "Press and key to exit");
            Console.ReadKey();
        }

        /// <summary>
        /// Разделение строки на массив подстрок
        /// </summary>
        static string[] SplitRow(string row, string separator)
        {
            try
            {
                if (string.IsNullOrEmpty(row))
                {
                    return new[] { string.Empty };
                }
                if (string.IsNullOrEmpty(separator) || row.IndexOf(separator, 0) == -1 || row.IndexOf(separator, 0) == row.Length - 1)
                {
                    return new[] { row };
                }

                var lst = new List<string>();
                var quot = @"""";
                int i = 0, j = 0, len = row.Length;
                int k = 1;  //пропуск первой кавычки
                while (j <= len)
                {
                    if (j < len)
                    {
                        j = row.IndexOf(separator, j) != -1 ? row.IndexOf(separator, j) : len;
                    }

                    var subRow = row.Substring(i, j - i);

                    if (subRow.StartsWith(quot))
                    {
                        int quotCount = 0;
                        while ((k = subRow.IndexOf(quot, k)) != -1)
                        {
                            var symCur = subRow.Substring(k, quot.Length);
                            k += quot.Length;
                            if (k < subRow.Length)
                            {
                                var symNext = subRow.Substring(k, quot.Length);
                                if (symCur == symNext)  //пропуск двойной кавычки
                                {
                                    k += quot.Length;
                                    continue;
                                }
                            }
                            ++quotCount;
                        }
                        if (j < len && quotCount == 0)  //пропуск разделителя
                        {
                            j += separator.Length;
                            k = j - i;
                            continue;
                        }
                    }

                    lst.Add(subRow);
                    j += separator.Length;
                    i = j;
                    k = 1;
                }

                return lst?.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Прочитать строки из файла
        /// </summary>
        static List<string> ReadRowsFromFile(string fileName)
        {
            try
            {
                var rows = new List<string>();
                using (var reader = new StreamReader(fileName, Encoding.GetEncoding(1251)))
                {
                    string row;
                    while ((row = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(row.Trim()))
                            rows.Add(row);
                    }
                }
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static void PrintItems(string[] items, int cnt)
        {
            //Console.WriteLine();
            Console.WriteLine("--------------------------------------");

            for (int i = 0; i < items.Length; ++i)
            {
                Console.Write("|" + items[i].ToString() + "|\t");
            }
            Console.WriteLine();
            Console.WriteLine($"itemsLength    = {items.Length}");
            Console.WriteLine($"countDelimiter = {cnt}");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine();
        }
    }
}
