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
            string fileName;
            fileName = @"C:\Users\edorokhin\labworks\CsvToDataTable\AppData\username.csv";

            string[] lines = GetData(fileName)?.ToArray();
            string delimiter = GetDelimiter();

            if (lines == null || lines.Count() == 0)
                return;

            Console.WriteLine("Lines:");
            foreach (var ln in lines)
            {
                Console.WriteLine(ln);
            }
            Console.WriteLine();

            DataTable table = GetDataTable(lines, delimiter);
            PrintTable(table);
            PrintTable2(table);

            Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
            Console.ReadKey();
        }

        static List<string> GetData(string fileName)
        {
            try
            {
                var data = new List<string>();
                using (var reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                            data.Add(line); ;
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static string GetDelimiter() => ";";

        static void GetSizeOfTable(string[] strs, string delimiter, out int countRow, out int countCol)
        {
            countRow = countCol = 0;

            try
            {
                if (strs == null)
                    throw new ArgumentNullException("Невозможно определить размер для DataTable"); ;

                foreach (string str in strs)
                {
                    countRow++;
                    int countFields = GetCountFieldsInStr(str, delimiter); //int countFields = GetCountFieldsInStrAnother(str, delimiter);
                    Console.WriteLine($"Pos = {countRow}; countFields = {countFields}; string = {str}");

                    if (countFields > countCol)
                        countCol = countFields;
                }
                Console.WriteLine($"countRow = {countRow}; countCol = {countCol};");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static int GetCountFieldsInStr(string str, string delimiter, bool hasDelimiterInQuot = false)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                    return 0;

                var delimiters = Regex.Matches(str, delimiter);
                int countFields = delimiters.Count;
                countFields++;

                if (hasDelimiterInQuot)
                {
                    var patternQuot = "(?:\\\"[^\\\"]*\\\")";
                    if (Regex.IsMatch(str, patternQuot))
                    {
                        var strQuots = Regex.Matches(str, patternQuot);
                        int countExclude = 0;
                        foreach (var strQuot in strQuots)
                        {
                            var delimitExs = Regex.Matches(strQuot.ToString(), delimiter);
                            countExclude += delimitExs.Count;
                        }
                        countFields -= countExclude;
                    }
                }
                return countFields;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static DataTable GetDataTable(string[] strs, string delimiter)
        {
            try
            {
                GetSizeOfTable(strs, delimiter, out int RowCnt, out int ColCnt);
                //Console.WriteLine($"RowCnt = {RowCnt}; ColCnt = {ColCnt};");

                char separator = delimiter.ToCharArray()[0];
                DataTable dt = new DataTable();

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
                    string[] rows = strs[i].Split(separator);
                    int rowsCount = rows.Count();

                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < ColCnt; j++)
                    {
                        if (rowsCount == ColCnt || j < rowsCount)
                            dr[j] = rows[j];
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
