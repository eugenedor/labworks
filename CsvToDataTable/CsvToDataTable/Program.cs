using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data;

namespace CsvToDataTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string fileName;
                fileName = @"C:\Users\edorokhin\labworks\CsvToDataTable\AppData\username.csv";
                //fileName = @"C:\Users\edorokhin\labworks\CsvToDataTable\AppData\username1";

                DataTable result;
                string[] rows;
                string separator;

                rows = ReadRowsFromFile(fileName)?.ToArray();                

                if (rows == null || rows.Count() == 0)
                {
                    return;
                }

                var rowFirst = rows[0];
                separator = GetSeparator(rowFirst);

                Console.WriteLine("rows:");
                foreach (var r in rows)
                {
                    Console.WriteLine(r);
                }
                Console.WriteLine();

                result = GetDataTable(rows, separator);
                PrintTable(result);
                PrintTable2(result);

                Console.WriteLine(System.Environment.NewLine + "Press any key1");
                Console.ReadKey();
                Console.Clear();

                TestFieldsInRow.TestCountOfFieldsInRow();

                Console.WriteLine(System.Environment.NewLine + "Press any key2");
                Console.ReadKey();
                Console.Clear();

                TestSeparator.TestGetSeparator();

                Console.WriteLine(System.Environment.NewLine + "Press any key3");
                Console.ReadKey();
                Console.Clear();

                TestSplit.TestSplt();

                Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
                Console.ReadKey();
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
                Console.ReadKey();
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
                using (var reader = new StreamReader(fileName))
                {
                    string row;
                    while ((row = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(row.Trim()))
                            rows.Add(row); ;
                    }
                }
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Определить количество разделителей в строке
        /// </summary>
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

                int separatorCount = 0, i = 0, j = 0;
                while ((j = row.IndexOf(separator, j)) != -1)
                {
                    var sbstr = row.Substring(i, j - i);
                    var quot = @"""";
                    if (sbstr.Contains(quot))
                    {
                        int quotInSbstrCount = 0, k = 0;
                        while ((k = sbstr.IndexOf(quot, k)) != -1)
                        {
                            quotInSbstrCount++;
                            k += quot.Length;
                        }
                        if (quotInSbstrCount % 2 == 1)
                        {
                            j += separator.Length;
                            continue;
                        }
                    }
                    separatorCount++;
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

        /// <summary>
        /// Является ли разделителем
        /// </summary>
        static bool IsSeparator(string row, string separator)
        {
            var separatorCnt = GetCountOfSeparatorsInRow(row, separator);
            return (separatorCnt > 0);
        }

        /// <summary>
        /// Получить разделитель из данных
        /// </summary>
        static string GetSeparator(string row)
        {
            try
            {
                var semicolon = ";";
                var isSeparatorSemicolon = IsSeparator(row, semicolon);
                var comma = ",";
                var isSeparatorComma = IsSeparator(row, comma);

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

        /// <summary>
        /// Определить количество полей в строке
        /// </summary>
        static int GetCountOfFieldsInRow(string row, string separator)
        {
            if (string.IsNullOrEmpty(row))
                return 0;
            if (string.IsNullOrEmpty(separator))
                return 1;

            var separatorCnt = GetCountOfSeparatorsInRow(row, separator);
            var fieldCount = separatorCnt + 1;

            return fieldCount;
        }

        /// <summary>
        /// Определить размер таблицы
        /// </summary>
        static void GetSizeOfTable(string[] rows, string separator, out int rowCount, out int colCount)
        {
            rowCount = 0;
            colCount = 0;
            try
            {                 
                if (rows == null || rows.Count() == 0)
                {
                    throw new ArgumentNullException("Невозможно определить размер для DataTable"); ;
                }
                rowCount = rows.Count();

                var rowFirst = rows[0];
                colCount = GetCountOfFieldsInRow(rowFirst, separator);

                Console.WriteLine($"rowCount = {rowCount}; colCount = {colCount};");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Разделение строк на массив подстрок
        /// </summary>
        static string[] SplitRow(string row, string separator)
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
                            quotInSbstrCount++;
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

        /// <summary>
        /// Получить таблицу данных
        /// </summary>
        static DataTable GetDataTable(string[] rows, string separator)
        {
            try
            {
                GetSizeOfTable(rows, separator, out int RowCnt, out int ColCnt);
                //Console.WriteLine($"RowCnt = {RowCnt}; ColCnt = {ColCnt};");

                var dt = new DataTable();

                //header
                for (int j = 0; j < ColCnt; j++)
                {
                    dt.Columns.Add($"column{j}");
                }
                //string[] headers = strs[0].Split(separator); 
                //foreach (string header in headers)
                //{
                //    dt.Columns.Add(header);
                //}
                //content
                for (int i = 0; i < RowCnt; i++)
                {
                    var fields = SplitRow(rows[i], separator);
                    var fieldsCount = fields.Count();

                    if (fieldsCount != ColCnt)
                    {
                        throw new Exception("Несовпадение количества полей в строке и столбцов в DataTable");
                    }

                    var dr = dt.NewRow();
                    for (int j = 0; j < ColCnt; j++)
                    {
                        dr[j] = fields[j];
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static void PrintTable(DataTable dt)
        {
            Console.WriteLine($"Rows.Count = {dt.Rows.Count}; Columns.Count = {dt.Columns.Count};");

            for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
            {
                Console.Write("|" + dt.Columns[curCol].ColumnName + "|" + "\t");
            }
            Console.WriteLine();

            DataTableReader dtr = dt.CreateDataReader();
            while (dtr.Read())
            {
                for (int i = 0; i < dtr.FieldCount; i++)
                {
                    Console.Write("|{0}|\t", dtr.GetValue(i).ToString().Trim());
                }
                Console.WriteLine();
            }
            dtr.Close();
            Console.WriteLine();
        }

        static void PrintTable2(DataTable dt)
        {
            Console.WriteLine($"countRows = {dt.Rows.Count};");
            Console.WriteLine($"countColumns = {dt.Columns.Count};");

            for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
            {
                Console.Write("|" + dt.Columns[curCol].ColumnName + "|" + "\t");
            }
            Console.WriteLine();

            for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write("|" + dt.Rows[curRow][curCol].ToString() + "|" + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
