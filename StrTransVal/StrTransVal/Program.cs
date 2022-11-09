using System;
using System.Text.RegularExpressions;

//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

namespace StrTransVal //MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private enum TransformString
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
                new { Value = "не завершена", Abbreviations = new List<string>()},
                new { Value = "продажа", Abbreviations = new List<string>()},
                new { Value = "КС", Abbreviations = new List<string>() { "КС" }},
                new { Value = "Не КС", Abbreviations = new List<string>() { "КС" }},
                new { Value = "ЦБ долг", Abbreviations = new List<string>() { "ЦБ" }},
                new { Value = "Страна РФ - правопреемница СССР", Abbreviations = new List<string>() { "РФ", "СССР" }},
                new { Value = "Великая Россия (РФ) - могущественная страна (РФ)", Abbreviations = new List<string>() { "Россия", "РФ" }},
                new { Value = "МОСКВА - столица России (РФ) и точка", Abbreviations = new List<string>() { "МОСКВА", "России", "РФ" }},
            };

            int i = 0;
            foreach (var arr in arrs)
            {
                Console.WriteLine($"{i}) {arr.Value}");

                Console.WriteLine($"Custom:  {Transform_ToString(arr.Value, TransformString.toCustom, arr.Abbreviations)}");
                Console.WriteLine($"Lower:   {Transform_ToString(arr.Value, TransformString.toLower, arr.Abbreviations)}");
                Console.WriteLine($"Upper:   {Transform_ToString(arr.Value, TransformString.toUpper, arr.Abbreviations)}");

                Console.WriteLine($"Default: {Transform_ToString(arr.Value, TransformString.toDefault, arr.Abbreviations)}");

                ++i;
                Console.WriteLine();
            }

            Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
            Console.ReadKey();
        }

        static string Transform_ToString(string value, TransformString transformString, List<string> abbreviations)
        {
            try
            {
                value = (value ?? string.Empty).Trim();

                if (string.IsNullOrEmpty(value))
                {
                    return value;
                }

                value = transformString switch
                {
                    TransformString.toCustom => value[..1].ToUpper() + value[1..].ToLower(),  //value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower()
                    TransformString.toLower => value.ToLower(),
                    TransformString.toUpper => value.ToUpper(),
                    TransformString.toDefault => value,
                    _ => value,
                };

                var ignoreTransformString = new[] { TransformString.toDefault, TransformString.toUpper };

                if (abbreviations != null && abbreviations.Count > 0
                    && !ignoreTransformString.Contains(transformString)

                    && transformString != TransformString.toUpper
                    && transformString != TransformString.toDefault)
                {
                    foreach (var abbreviation in abbreviations)
                    {
                        var pattern = $@"\b{abbreviation}\b";
                        value = Regex.Replace(value, pattern, abbreviation, RegexOptions.IgnoreCase);
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