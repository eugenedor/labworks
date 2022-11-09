//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;

namespace StrTransVal //MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private enum TransMethod
        {
            toDefault = 0,
            toCustom = 1,
            toLower = 2,
            toUpper = 3
        }

        static void Main(string[] args)
        {
            var arrs = new[]
            {
                new { Val = "не завершена", ExclSubstrs = new List<string>()},
                new { Val = "продажа", ExclSubstrs = new List<string>()},
                new { Val = "КС", ExclSubstrs = new List<string>() { "КС" }},
                new { Val = "Не КС", ExclSubstrs = new List<string>() { "КС" }},
                new { Val = "ЦБ долг", ExclSubstrs = new List<string>() { "ЦБ" }},
                new { Val = "Страна РФ - правопреемница СССР", ExclSubstrs = new List<string>() { "РФ", "СССР" }},
                new { Val = "Россия (РФ) - великая страна", ExclSubstrs = new List<string>() { "РФ" }},
            };

            int i = 0;
            foreach (var arr in arrs)
            {
                Console.WriteLine($"{i}) {arr.Val}");

                Console.WriteLine($"Custom:  {Transform_ToString(arr.Val, TransMethod.toCustom, arr.ExclSubstrs)}");
                Console.WriteLine($"Lower:   {Transform_ToString(arr.Val, TransMethod.toLower, arr.ExclSubstrs)}");
                Console.WriteLine($"Upper:   {Transform_ToString(arr.Val, TransMethod.toUpper, arr.ExclSubstrs)}");

                Console.WriteLine($"Default: {Transform_ToString(arr.Val, TransMethod.toDefault, arr.ExclSubstrs)}");

                ++i;
                Console.WriteLine();
            }

            Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
            Console.ReadKey();
        }

        static string Transform_ToString(string value, TransMethod transMethod, List<string> excludeSubstrs)
        {
            try
            {
                value = (value ?? string.Empty).Trim();

                if (string.IsNullOrEmpty(value))
                {
                    return value;
                }

                value = transMethod switch
                {
                    TransMethod.toCustom => value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower(),
                    TransMethod.toLower => value.ToLower(),
                    TransMethod.toUpper => value.ToUpper(),
                    TransMethod.toDefault => value,
                    _ => value,
                };

                var cnt = excludeSubstrs?.Count ?? 0;
                if (cnt > 0)
                {
                    foreach (var exSubstr in excludeSubstrs)
                    {

                    }
                }

                return value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}