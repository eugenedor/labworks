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
                new { Value = "Россия (РФ) - великая страна РФ", Abbreviations = new List<string>() { "РФ" }},
                new { Value = "МОСКВА - столица РОССИИ (РФ) и точка", Abbreviations = new List<string>() { "МОСКВА", "РОССИИ", "РФ" }},
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

            //--------------------------------------------------
            //Console.WriteLine(System.Environment.NewLine + "Press any key");
            //Console.ReadKey();
            //Console.Clear();

            //var text1 = "Россия (РФ) - великая страна РФ";
            //Dictionary<int, int> dic1 = new Dictionary<int, int>()
            //{
            //    { 8, 2},
            //    { 29, 2}
            //};

            //Console.WriteLine(text1);
            //int j = 0;
            //foreach (var d1 in dic1)
            //{
            //    Console.WriteLine($"'{text1.Substring(j, d1.Key - j)}'");
            //    Console.WriteLine($"'{text1.Substring(d1.Key, d1.Value)}'");
            //    j = d1.Key + d1.Value;
            //}
            //if (j < text1.Length)
            //    Console.WriteLine($"'{text1.Substring(j, text1.Length - j)}'");

            //Console.WriteLine();

            //var text2 = "МОСКВА - столица РОССИИ (РФ) и точка";
            //Dictionary<int, int> dic2 = new Dictionary<int, int>()
            //{
            //    { 0, 6},
            //    { 17, 6},
            //    { 25, 2}
            //};

            //Console.WriteLine(text2);
            //j = 0;
            //foreach (var d2 in dic2)
            //{
            //    Console.WriteLine($"'{text2.Substring(j, d2.Key - j)}'");
            //    Console.WriteLine($"'{text2.Substring(d2.Key, d2.Value)}'");
            //    j = d2.Key + d2.Value;
            //}
            //if (j < text2.Length)
            //    Console.WriteLine($"'{text2.Substring(j, text2.Length - j)}'");
            //--------------------------------------------------

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

                if (abbreviations != null && abbreviations.Count > 0)
                {
                    foreach (var abbreviation in abbreviations)
                    {
                        var pattern = $@"\b{abbreviation}\b";
                        value = Regex.Replace(value, pattern, abbreviation, RegexOptions.IgnoreCase);

                        //var matches = Regex.Matches(value, pattern, RegexOptions.IgnoreCase);
                        //if (matches != null && matches.Count > 0)
                        //{
                        //    foreach (Match match in matches)
                        //    {
                        //        if (match.Success)
                        //        {
                        //            Console.WriteLine($"indx: {match.Index}| len: {match.Value.Length}| val: {match.Value}");
                        //        }
                        //    }
                        //}
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