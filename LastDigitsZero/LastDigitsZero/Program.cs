using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastDigitsZero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strs = new string[]
            {
                "12345678901234",
                "123456789012345",
                "1234567890123456",
                "-1234567890123456",
                "12345678901234567",
                "123456789012345678",
                "1234567890123456789",                
                "-1234567890123456789",
                "12345678901234,",
                "123456789012345,",
                "1234567890123456,",
                "-1234567890123456,",
                "12345678901234567,",
                "123456789012345678,",
                "1234567890123456789,",                
                "-1234567890123456789,",
                "123456789012,34",
                "1234567890123,45",
                "12345678901234,56",
                "-12345678901234,56",
                "123456789012345,67",
                "1234567890123456,78",
                "12345678901234567,89",                
                "-12345678901234567,89",
                "1234567890,1234",
                "12345678901,2345",
                "123456789012,3456",
                "-123456789012,3456",
                "1234567890123,4567",
                "12345678901234,5678",
                "123456789012345,6789",                
                "-123456789012345,6789",
                "1234567890123.4567",
                "123456.7890123,4567",
                "123456,7890123,4567",
                "ABCDEFG7890123,4567",
                "12345678901234.",
                "'1234567890123456",
                "'-1234567890123456",
                "1234567890123.45",
                "12345678901234.56",
                "12345678901234567.89",
                "12345678901.2345",
                "123456789012.3456",
                "123456789012345.6789",
            };

            int c = 0;
            foreach (string str in strs)
            {
                ++c;
                Console.WriteLine($"Num{c}\t = {str}");
                string result = ChangeLastDigitsOfLongNumToZero(str);
                Console.WriteLine($"Result\t = {result}");
                Console.WriteLine();
            }

            //Console.WriteLine($"1 {RepeatDelimiter("", ',')}");
            //Console.WriteLine($"2 {RepeatDelimiter("a", ',')}");
            //Console.WriteLine($"3 {RepeatDelimiter("a,", ',')}");
            //Console.WriteLine($"4 {RepeatDelimiter("a,b", ',')}");
            //Console.WriteLine($"5 {RepeatDelimiter("a,b,", ',')}");
            //Console.WriteLine($"6 {RepeatDelimiter("a,b,c", ',')}");
            //Console.WriteLine($"7 {RepeatDelimiter("a,b,c,", ',')}");
            //Console.WriteLine($"8 {RepeatDelimiter("a,b,c,d", ',')}");

            Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
            Console.ReadKey();
        }

        /// <summary>
        /// НЕ ИСПОЛЬЗУЕТСЯ!
        /// Изменить последние цифры длинного числа (больше 15) на ноль
        /// Excel сохраняет только 15 значащих цифр числа и изменяет цифры после пятнадцатого разряда на ноль
        /// </summary>
        /// <param name="str">строка</param>
        /// <param name="digitDelimiter">разделитель цифр</param>
        /// <returns>строка</returns>
        static string ChangeLastDigitsOfLongNumToZero(string str)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                {
                    return str;
                }
                str = str.Trim();

                char comma = ',';
                char dot = '.';
                var isDelimiterComma = str.Contains(comma);
                var isDelimiterDot = str.Contains(dot);

                if (isDelimiterComma && isDelimiterDot)
                {
                    return str;
                }

                char digitDelimiter = default;
                if (isDelimiterComma)
                {
                    digitDelimiter = comma;
                }
                if (isDelimiterDot)
                {
                    digitDelimiter = dot;
                }                

                if (isDelimiterComma || isDelimiterDot)
                {
                    str = str.TrimEnd(new[] { digitDelimiter });
                    if (RepeatDelimiter(str, digitDelimiter))
                    {
                        return str;
                    }
                }

                if (str.StartsWith("\'"))
                {
                    return str;
                }

                int digitCount = 15;

                int len = str.Length;
                if (len <= digitCount)
                {
                    return str;
                }

                int digitCountInString = GetDigitCountInString(str);
                if (digitCountInString <= digitCount)
                {
                    return str;
                }

                char minus = '-';
                char zero = '0';

                bool isNegative = str.StartsWith(minus.ToString());             
                if (isNegative && DigitsOnlyInString(str.Substring(1)) || DigitsOnlyInString(str))
                {
                    if (isNegative)
                    {
                        ++digitCount;
                    }                        
                    return str.Substring(0, digitCount).PadRight(len, zero);
                }

                if (str.Contains(digitDelimiter))
                {
                    int i = 0;
                    var result = new StringBuilder();
                    foreach (char ch in str)
                    {
                        if (!char.IsDigit(ch))
                        {
                            if (ch != digitDelimiter && ch != minus)
                            {
                                return str;
                            }
                            result.Append(ch);
                            continue;
                        }
                        if (i < digitCount)
                        {
                            result.Append(ch);
                        }
                        else
                        {
                            result.Append(zero);
                        }
                        ++i;
                    }
                    return result.ToString();
                }
                return str;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Получить количество цифр в строке
        /// </summary>
        static int GetDigitCountInString(string s)
        {
            int count = 0;
            foreach (char ch in s)
            {
                if (char.IsDigit(ch))
                    ++count;
            }
            return count;
        }

        /// <summary>
        /// Только цифры в строке
        /// </summary>
        static bool DigitsOnlyInString(string s)
        {
            foreach (char ch in s)
            {
                if (!char.IsDigit(ch))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Повтор разделителя
        /// </summary>
        static bool RepeatDelimiter(string s, char delimiter)
        {
            int count = 0, j = 0;
            while ((j = s.IndexOf(delimiter, j)) != -1)
            {
                ++count;
                if (count > 1)
                {
                    return true;
                }
                ++j;
            }
            return false;
        }
    }
}
