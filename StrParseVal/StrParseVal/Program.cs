using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace StrParseVal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strs = new string[]
            {
                "2012-03-14 22:35:31.027",
                "14/03/2012",
                "14 марта 2012 г.",
                "14/03/12",
                "14 мар 19",
                "14-мар-2012",
                "2012-03-14",
                "14-Mar-2012",
                "03/14/2012",
                "03/14/12",
                "2012.03.14",
                "12.03.14",
                "14.03.12",
                "14.03.2012",
                "12/0009",
                "13/0009",
                "0009/12",
                "0009/13",
                "12/2009",
                "13/2009",
                "2009/12",
                "2009/13",
                "09062022",
                "20220609",
                "2147483647",
                "-2147483647",
                "2147483648",
                "-2147483648",
                "9223372036854775807",
                "007",
                "00008",
                "0.01",
                "0,02",
                ".03",
                ",04",
                "-0.05",
                "-0,06",
                "-.07",
                "-,08",
                "123.49",
                "567,89",
                "4.345E+11",
                "4,345E+11",
                "4.34531E+11",
                "4,34531E+11",
                "4.345E+2",
                "4,345E+2",
                ".345E+11",
                ",345E+11",
                "Какой-то текст 14.03.2012 123.45 987,65!",
                "a000009",
                "FALse",
                "TRue",
                "\"ООО \"\"ХУДОЖЕСТВЕННЫЕ МАТЕРИАЛЫ\"\"\"",
                "\"ООО \"\"ТАНТАЛ\"\"\"",
                "\"\"\"ТЕКСТ1\"\"\"",
                "\"\"ТЕКСТ2\"\"",
                "\"ТЕКСТ3\"",
                "\"\"",
                "\"",
                ""
            };

            int i = 0;
            foreach (string str in strs)
            {
                Console.WriteLine($"{i}) {str}");
                var result = GetParseValue(str);
                Console.WriteLine($"{result}");
                ++i;
                Console.WriteLine();
            }

            Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
            Console.ReadKey();

            //GetCultures();
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

                var zero = "0";
                if (Regex.IsMatch(value, @"^[-]?\d+$"))
                {
                    if (value.StartsWith(zero) && DigitsOnlyInString(value))
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
                    var ixDigitDelimiter = valueMod.IndexOf(digitDelimiter);
                    if (ixDigitDelimiter == 0)
                    {
                        valueMod = zero + valueMod;
                    }
                    var minus = "-";
                    if (valueMod.StartsWith(minus) && ixDigitDelimiter == 1)
                    {
                        valueMod = minus + zero + valueMod.Substring(1);
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

                var dateFormats = new string[] { "dd.MM.yyyy", "dd.MM.yy", "dd/MM/yyyy", "dd/MM/yy" };
                if (DateTime.TryParseExact(value, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateResult))
                {
                    var dateStart = new DateTime(1900, 1, 1);
                    var dateEnd = new DateTime(9999, 12, 31);
                    if (dateStart <= dateResult.Date && dateResult.Date <= dateEnd)
                    {
                        return dateResult.ToString("dd.MM.yyyy");
                    }
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
        static bool DigitsOnlyInString(string s)
        {
            foreach (char ch in s)
            {
                if (!char.IsDigit(ch))
                    return false;
            }
            return true;
        }

        public static void GetCultures()
        {
            Console.WriteLine("{0,-53}{1}", "CULTURE", "SPECIFIC CULTURE");

            // Get each neutral culture in the .NET Framework.
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures);

            // Determine the specific culture associated with each neutral culture.
            foreach (var culture in cultures)
            {
                Console.Write("{0,-12} {1,-40}", culture.Name, culture.EnglishName);
                try
                {
                    Console.WriteLine("{0}", CultureInfo.CreateSpecificCulture(culture.Name).Name);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("(no associated specific culture)");
                }
            }

            Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
            Console.ReadKey();
        }
    }
}
