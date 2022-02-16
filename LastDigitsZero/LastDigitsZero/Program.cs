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
                "12345678901234567",
                "123456789012345678",
                "1234567890123456789",
                "-1234567890123456",
                "-1234567890123456789",
                "12345678901234,",
                "123456789012345,",
                "1234567890123456,",
                "12345678901234567,",
                "123456789012345678,",
                "1234567890123456789,",
                "-1234567890123456,",
                "-1234567890123456789,",
                "123456789012,34",
                "1234567890123,45",
                "12345678901234,56",
                "123456789012345,67",
                "1234567890123456,78",
                "12345678901234567,89",
                "-12345678901234,56",
                "-12345678901234567,89",
                "1234567890,1234",
                "12345678901,2345",
                "123456789012,3456",
                "1234567890123,4567",
                "12345678901234,5678",
                "123456789012345,6789",
                "-123456789012,3456",
                "-123456789012345,6789",
                "1234567890123.4567",
                "123456.7890123,4567",
                "ABCDEFG7890123,4567",
                "12345678901234.",
                "'1234567890123456",
                "'-1234567890123456",
            };

            char comma = ',';
            int c = 0;
            foreach (string str in strs)
            {
                ++c;
                Console.WriteLine($"Num{c}\t = {str}");
                string result = ChangeLastDigitsOfLongNumToZero(str, comma);
                Console.WriteLine($"Result\t = {result}");
                Console.WriteLine();
            }
            Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
            Console.ReadKey();
        }

        /// <summary>
        /// Только цифры в строке
        /// </summary>
        static bool DigitsOnlyInString(string str)
        {
            foreach (char ch in str.ToCharArray())
            {
                if (!char.IsDigit(ch))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Изменить последние цифры длинного числа (больше 15) на ноль
        /// </summary>
        static string ChangeLastDigitsOfLongNumToZero(string str, char delimiter)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                {
                    return str;
                }

                str = str.Trim().TrimEnd(new[] { delimiter });

                if (str.StartsWith("'"))
                {
                    return str;
                }

                int digitCount = 15;
                int len = str.Length;
                char minus = '-';
                bool isNegative = str.StartsWith(minus.ToString());

                int count = digitCount;
                if (isNegative)
                    count++;
                if (str.Contains(delimiter))
                    count++;
                if (len <= count)
                {
                    return str;
                }

                char zero = '0';
                if (isNegative && DigitsOnlyInString(str.Substring(1)) || DigitsOnlyInString(str))
                {
                    if (isNegative)
                        digitCount++;
                    return str.Substring(0, digitCount).PadRight(len, zero);
                }

                if (str.Contains(delimiter))
                {
                    int i = 0;
                    var result = new StringBuilder();
                    foreach (char ch in str.ToCharArray())
                    {
                        if (!char.IsDigit(ch))
                        {
                            if (ch != delimiter && ch != minus)
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
    }
}
