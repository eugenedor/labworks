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
                string delimiter;

                rows = ReadRowsFromFile(fileName)?.ToArray();                

                if (rows == null || rows.Count() == 0)
                {
                    return;
                }

                var rowFirst = rows[0];
                delimiter = GetDelimiter(rowFirst);

                Console.WriteLine("rows:");
                foreach (var r in rows)
                {
                    Console.WriteLine(r);
                }
                Console.WriteLine();

                result = GetDataTable(rows, delimiter);
                PrintTable(result);
                PrintTable2(result);

                Console.WriteLine(System.Environment.NewLine + "Press any key1");
                Console.ReadKey();
                Console.Clear();

                FieldsInRow.TestCountOfFieldsInRow();

                Console.WriteLine(System.Environment.NewLine + "Press any key2");
                Console.ReadKey();
                Console.Clear();

                Delimiter.TestGetDelimiter();

                Console.WriteLine(System.Environment.NewLine + "Press any key3");
                Console.ReadKey();
                Console.Clear();

                Separator.TestSepar();

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
            var delimiterCnt = GetCountOfDelimitersInRow(row, delimiter);
            return (delimiterCnt > 0);
        }

        /// <summary>
        /// Получить разделитель из данных
        /// </summary>
        static string GetDelimiter(string row)
        {
            try
            {
                var semicolon = ";";
                var isDelimiterSemicolon = IsDelimiter(row, semicolon);
                var comma = ",";
                var isDelimiterComma = IsDelimiter(row, comma);

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

        /// <summary>
        /// Определить количество полей в строке
        /// </summary>
        static int GetCountOfFieldsInRow(string row, string delimiter)
        {
            if (string.IsNullOrEmpty(row))
                return 0;
            if (string.IsNullOrEmpty(delimiter))
                return 1;

            var delimiterCnt = GetCountOfDelimitersInRow(row, delimiter);
            var fieldCount = delimiterCnt + 1;

            return fieldCount;
        }

        /// <summary>
        /// Определить размер таблицы
        /// </summary>
        static void GetSizeOfTable(string[] rows, string delimiter, out int rowCount, out int colCount)
        {
            rowCount = colCount = 0;
            try
            {                 
                if (rows == null || rows.Count() == 0)
                {
                    throw new ArgumentNullException("Невозможно определить размер для DataTable"); ;
                }
                rowCount = rows.Count();

                var rowNumOne = rows[0];
                colCount = GetCountOfFieldsInRow(rowNumOne, delimiter);

                Console.WriteLine($"rowCount = {rowCount}; colCount = {colCount};");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Сплит
        /// </summary>
        static string[] Split(string row, string delimiter)
        {
            try
            {
                if (string.IsNullOrEmpty(row))
                    return new[] { string.Empty };

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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Получить таблицу данных
        /// </summary>
        static DataTable GetDataTable(string[] rows, string delimiter)
        {
            try
            {
                GetSizeOfTable(rows, delimiter, out int RowCnt, out int ColCnt);
                //Console.WriteLine($"RowCnt = {RowCnt}; ColCnt = {ColCnt};");

                var hasDelimiter = !string.IsNullOrEmpty(delimiter);
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
                    var fields = hasDelimiter ? Split(rows[i], delimiter) : new[] { rows[i] };
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
