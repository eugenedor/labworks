using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data;
using System.Globalization;

namespace CsvToDataTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string fileName;
                fileName = @"C:\Users\edorokhin\labworks\CsvToDataTable\AppData\username";

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

                int rowCount = rows.Count();
                Console.WriteLine($"count rows: {rowCount}");
                Console.WriteLine("content rows:");
                foreach (var r in rows)
                {
                    Console.WriteLine(r);
                }
                Console.WriteLine();

                result = ConvertRowsToDataTable(rows, separator);
                PrintDataTableReader(result);
                PrintDataTableRowCol(result);
                PrintDataRow(result.Rows[result.Rows.Count - 1]);

                //Console.WriteLine(System.Environment.NewLine + "Press any key1");
                //Console.ReadKey();
                //Console.Clear();

                //TestFieldsInRow.TestCountOfFieldsInRow();

                //Console.WriteLine(System.Environment.NewLine + "Press any key2");
                //Console.ReadKey();
                //Console.Clear();

                //TestSeparator.TestGetSeparator();

                //Console.WriteLine(System.Environment.NewLine + "Press any key3");
                //Console.ReadKey();
                //Console.Clear();

                //TestSplit.TestSplt();

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
                using (var reader = new StreamReader(fileName, Encoding.GetEncoding(1251)))
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
        static string GetSeparator(string row)
        {
            var semicolon = ";";
            var isSeparatorSemicolon = IsSeparator(row, semicolon);
            if (isSeparatorSemicolon)
            {
                return semicolon;
            }
            var comma = ",";
            var isSeparatorComma = IsSeparator(row, comma);
            if (isSeparatorComma)
            {
                return comma;
            }                    
            return string.Empty;
        }

        /// <summary>
        /// Является ли разделителем
        /// </summary>
        static bool IsSeparator(string row, string separator)
        {
            var separatorCount = GetCountOfSeparatorsInRow(row, separator);
            return (separatorCount > 0);
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

        /// <summary>
        /// Конвертация строк в таблицу данных
        /// </summary>
        static DataTable ConvertRowsToDataTable(string[] rows, string separator)
        {
            try
            {
                DataTable result = new DataTable();
                if (rows != null && rows.Count() > 0)
                {
                    GetSizeOfTable(rows, separator, out int rowCount, out int columnCount);
                    for (int j = 0; j < columnCount; ++j)
                    {
                        result.Columns.Add($"F{j+1}", typeof(string));
                    }
                    for (int i = 0; i < rowCount; ++i)
                    {
                        DataRow row = result.NewRow();

                        string[] fields = SplitRow(rows[i], separator);
                        var fieldCount = fields.Count();

                        for (int j = 0; j < columnCount; ++j)
                        {
                            if (j < fieldCount)
                            {
                                row[$"F{j+1}"] = GetParseValue(fields[j]);
                            }
                            else
                            {
                                row[$"F{j+1}"] = string.Empty;
                            }                            
                        }

                        result.Rows.Add(row);
                    }
                    result = RemoveEmptyEndRows(result);
                    result = RemoveEmptyEndColumns(result);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Определить размер таблицы
        /// </summary>
        static void GetSizeOfTable(string[] rows, string separator, out int rowCount, out int columnCount)
        {
            rowCount = 0;
            columnCount = 0;
            try
            {
                if (rows == null || rows.Count() == 0)
                {
                    throw new ArgumentNullException("Невозможно определить размер для DataTable"); ;
                }
                rowCount = rows.Count();

                for (int i = 0; i < rowCount; ++i) 
                {
                    int fieldCountInRow = GetCountOfFieldsInRow(rows[i], separator);
                    if (fieldCountInRow > columnCount)
                    {
                        columnCount = fieldCountInRow;
                    }
                }

                Console.WriteLine($"rowCount = {rowCount}; columnCount = {columnCount};");
                Console.WriteLine();
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

            var separatorCount = GetCountOfSeparatorsInRow(row, separator);
            var fieldCount = separatorCount + 1;

            return fieldCount;
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

        /// <summary>
        /// Получить проанализированное значение
        /// </summary>
        public static string GetParseValue(string value)
        {
            try
            {
                value = (value ?? string.Empty).Trim();

                if (string.IsNullOrEmpty(value))
                {
                    return value;
                }

                if (Regex.IsMatch(value, @"^[-]?\d+$"))
                {
                    if (value.StartsWith("0") && DigitOnlyInString(value))
                    {
                        return value;
                    }
                    if (long.TryParse(value, out long longResult))
                    {
                        return longResult.ToString();
                    }
                    return value;
                }

                if (Regex.IsMatch(value, @"^[-]?(\d+|(?:\d+)?(?:(\.|\,)\d+))(?:[eE][-+]?\d+)?$"))
                {
                    string comma = ",";
                    string dot = ".";
                    var digitDelimiter = dot;
                    if (value.Contains(comma))
                    {
                        digitDelimiter = comma;
                    }

                    var valueMod = value;
                    int ixDigitDelimiter = valueMod.IndexOf(digitDelimiter);
                    if (ixDigitDelimiter == 0)
                    {
                        valueMod = "0" + valueMod;
                    }
                    if (valueMod.StartsWith("-") && ixDigitDelimiter == 1)
                    {
                        valueMod = "-0" + valueMod.Substring(1);
                    }

                    if (decimal.TryParse(valueMod, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal decResult) ||
                        decimal.TryParse(valueMod, NumberStyles.Float, CultureInfo.InvariantCulture, out decResult))
                    {
                        return decResult.ToString();
                    }
                    else
                    {
                        valueMod = valueMod.Contains(comma) ? valueMod.Replace(comma, dot) : valueMod;
                        if (decimal.TryParse(valueMod, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decResult) ||
                            decimal.TryParse(valueMod, NumberStyles.Float, CultureInfo.InvariantCulture, out decResult))
                        {
                            return decResult.ToString();
                        }
                    }
                    return value;
                }

                var cultRu = CultureInfo.CreateSpecificCulture("ru-Ru");
                var cultEn = CultureInfo.CreateSpecificCulture("en-US");
                var dateStyles = DateTimeStyles.None;
                if (DateTime.TryParse(value, cultRu, dateStyles, out DateTime dateResult) ||
                    DateTime.TryParse(value, cultEn, dateStyles, out dateResult))
                {
                    return dateResult.ToString("dd.MM.yyyy");
                }

                if (bool.TryParse(value, out bool boolResult))
                {
                    return boolResult.ToString().ToUpper();
                }

                var quot = @"""";
                if (value.Contains(quot))
                {
                    if (value.StartsWith(quot) && value.EndsWith(quot))
                    {
                        value = value.Remove(0, 1);
                        if (value.Length > 0)
                        {
                            value = value.Remove(value.Length - 1);
                        }
                    }
                    if (value.Contains(quot + quot))
                    {
                        value = value.Replace(quot + quot, quot);
                    }
                }

                return value;
            }
            catch
            {
                Console.WriteLine($"!!!catch-error!!! {value}");
                return value;
            }
        }

        /// <summary>
        /// Только цифры в строке
        /// </summary>
        static bool DigitOnlyInString(string s)
        {
            foreach (char ch in s)
            {
                if (!char.IsDigit(ch))
                    return false;
            }
            return true;
        }

        static DataTable RemoveEmptyEndRows(DataTable data)
        {
            int lastIndex = data.Rows.Count - 1;
            for (int i = lastIndex; i >= 0; --i)
            {
                if (RowIsEmpty(data.Rows[i]))
                {
                    data.Rows.RemoveAt(i);
                }
                else
                {
                    break;
                }
            }
            return data;
        }

        static bool RowIsEmpty(DataRow row)
        {
            if (row.ItemArray.Length > 0)
            {
                int emptyCellCount = 0;
                for (int i = 0; i < row.ItemArray.Length; ++i)
                {
                    if (row[i] == null
                        || row[i].GetType() != typeof(string)
                        || string.IsNullOrEmpty((string)row[i]))
                    {
                        ++emptyCellCount;
                    }
                    else
                    {
                        break;
                    }
                }
                if (emptyCellCount == row.ItemArray.Length)
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
            return false;
        }

        static DataTable RemoveEmptyEndColumns(DataTable data)
        {
            int lastIndex = data.Columns.Count - 1;
            for (int i = lastIndex; i >= 0; --i)
            {
                if (ColumnIsEmpty(data.Columns[i]))
                {
                    data.Columns.RemoveAt(i);
                }
                else
                {
                    break;
                }
            }
            return data;
        }

        static bool ColumnIsEmpty(DataColumn column)
        {
            for (int i = 0; i < column.Table.Rows.Count; ++i)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(column.Table.Rows[i][column.Ordinal])))
                {
                    return false;
                }
            }
            return true;
        }

        static void PrintDataTableReader(DataTable dt)
        {
            Console.WriteLine($"*****1. PrintTableWithReader*****");

            for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
            {
                Console.Write("|" + dt.Columns[curCol].ColumnName + "|" + "\t");
            }
            Console.WriteLine();

            using (var dtr = dt.CreateDataReader())
            {
                while (dtr.Read())
                {
                    for (int i = 0; i < dtr.FieldCount; i++)
                    {
                        Console.Write($"|{dtr.GetValue(i).ToString().Trim()}|\t");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine($"countRows = {dt.Rows.Count};");
            Console.WriteLine($"countColumns = {dt.Columns.Count};");
            Console.WriteLine($"**********");
        }

        static void PrintDataTableRowCol(DataTable dt)
        {
            Console.WriteLine($"*****2. PrintTableWithRowCol*****");

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
            Console.WriteLine($"countRows = {dt.Rows.Count};");
            Console.WriteLine($"countColumns = {dt.Columns.Count};");
            Console.WriteLine($"**********");
        }

        static void PrintDataRow(DataRow row)
        {
            Console.WriteLine($"*****3. PrintDataRow*****");
            for (int i = 0; i < row.ItemArray.Length; i++)
            {
                Console.Write("|" + row[i].ToString() + "|\t");
            }
            Console.WriteLine();
            Console.WriteLine($"itemarrayLength = {row.ItemArray.Length};");
            Console.WriteLine($"**********");
        }
    }
}
