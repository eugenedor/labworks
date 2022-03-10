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
                "2147483647",
                "-2147483647",
                "2147483648",
                "-2147483648",
                "9223372036854775807",
                "007",
                "00008",
                "0.00",
                "0,00",
                "123.49",
                "567,89",
                "4.345E+11",
                "4,345E+11",
                "4.34531E+11",
                "4,34531E+11",
                "4.345E+2",
                "4,345E+2",
                "Какой-то текст 14.03.2012 123.45 987,65!",
                "a000009",
                "FALse",
                "TRue",
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

                string CommaReplace (string s) 
                { 
                    return s.Contains(",") ? s.Replace(",", ".") : s;
                }

                if (Regex.IsMatch(value, @"^[-]?\d+((\.|\,)\d+)?(?:[eE][-+]?\d+)?$"))
                {
                    string res = CommaReplace(value);
                    if (decimal.TryParse(res, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal decResult) ||
                        decimal.TryParse(res, NumberStyles.Float, CultureInfo.InvariantCulture, out decResult))
                    {
                        return CommaReplace(decResult.ToString());
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
