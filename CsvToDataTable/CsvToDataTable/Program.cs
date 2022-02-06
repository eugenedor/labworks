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
                delimiter = GetDelimiter();

                if (rows == null || rows.Count() == 0)
                {
                    return;
                }

                Console.WriteLine("rows:");
                foreach (var r in rows)
                {
                    Console.WriteLine(r);
                }
                Console.WriteLine();

                result = GetDataTable(rows, delimiter);
                PrintTable(result);
                PrintTable2(result);

                Console.WriteLine(System.Environment.NewLine + "Press any key");
                Console.ReadKey();
                Console.Clear();

                FieldsInRow.TestCountOfFieldsInRow();

                Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
                Console.ReadKey();
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message); 
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
        /// Получить разделитель из данных
        /// </summary>
        static string GetDelimiter() => ";";

        /// <summary>
        /// Определить количество полей в строке
        /// </summary>
        static int GetCountOfFieldsInRow(string row, string delimiter)
        {
            try
            {
                if (string.IsNullOrEmpty(row))
                    return 0;

                var delimiters = Regex.Matches(row, delimiter);
                var delimiterCount = delimiters.Count;

                var patternOfQuotes = "(?:\\\"[^\\\"]*\\\")";
                if (Regex.IsMatch(row, patternOfQuotes))
                {
                    var rowQuotes = Regex.Matches(row, patternOfQuotes);
                    var excludeDelimiterCount = 0;
                    foreach (var rowQuot in rowQuotes)
                    {
                        var excludeDelimiters = Regex.Matches(rowQuot.ToString(), delimiter);
                        excludeDelimiterCount += excludeDelimiters.Count;
                    }
                    delimiterCount -= excludeDelimiterCount;
                }
                var fieldCount = delimiterCount + 1;
                return fieldCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Определить размер таблицы
        /// </summary>
        static void GetSizeOfTable(string[] rows, string delimiter, out int rowCount, out int colCount)
        {
            rowCount = colCount = 0;
            try
            {
                rowCount = rows.Count();
                if (rows == null || rowCount == 0)
                {
                    throw new ArgumentNullException("Невозможно определить размер для DataTable"); ;
                }
                var rowFirst = rows[0];
                colCount = GetCountOfFieldsInRow(rowFirst, delimiter);

                Console.WriteLine($"rowCount = {rowCount}; colCount = {colCount};");
                Console.WriteLine();
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
                char separator = default;
                if (hasDelimiter)
                    separator = delimiter.ToCharArray()[0];
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
                    var fields = hasDelimiter ? rows[i].Split(separator) : new[] { rows[i] };
                    var fieldsCount = fields.Count();

                    var dr = dt.NewRow();
                    for (int j = 0; j < ColCnt; j++)
                    {
                        if (fieldsCount == ColCnt || j < fieldsCount)
                            dr[j] = fields[j];
                        else
                            dr[j] = string.Empty;
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
