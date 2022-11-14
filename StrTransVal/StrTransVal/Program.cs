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
            toLower = 1,
            toUpper = 2,
            toCustom = 3
        }

        static void Main(string[] args)
        {
            var arrs = new[]
            {
                new { Value = "не завершена", SpecialWords = new List<string>()},
                new { Value = "продажа", SpecialWords = new List<string>()},
                new { Value = "КС", SpecialWords = new List<string>() { "КС" }},
                new { Value = "Не КС", SpecialWords = new List<string>() { "КС" }},
                new { Value = "ЦБ долг", SpecialWords = new List<string>() { "ЦБ" }},
                new { Value = "Страна РФ - правопреемница СССР", SpecialWords = new List<string>() { "РФ", "СССР" }},
                new { Value = "Великая Россия (РФ) - могущественная страна РФ", SpecialWords = new List<string>() { "Россия", "РФ" }},
                new { Value = "МСК - столица России (РФ) и точка!", SpecialWords = new List<string>() { "МСК", "России", "РФ" }},
            };

            var strValue = "МСК - столица России";
            Console.WriteLine($"-1) {strValue}");
            Console.WriteLine($"Default: {Transform_ToString(strValue)}");
            Console.WriteLine($"lower:   {Transform_ToString(strValue, TransformString.toLower)}");
            Console.WriteLine($"UPPER:   {Transform_ToString(strValue, TransformString.toUpper)}");
            Console.WriteLine($"Custom:  {Transform_ToString(strValue, TransformString.toCustom)}");
            Console.WriteLine();

            int i = 0;
            foreach (var arr in arrs)
            {
                Console.WriteLine($"{i}) {arr.Value}");

                Console.WriteLine($"Default: {Transform_ToString(arr.Value, TransformString.toDefault, arr.SpecialWords)}");
                Console.WriteLine($"lower:   {Transform_ToString(arr.Value, TransformString.toLower, arr.SpecialWords)}");
                Console.WriteLine($"UPPER:   {Transform_ToString(arr.Value, TransformString.toUpper, arr.SpecialWords)}");
                Console.WriteLine($"Custom:  {Transform_ToString(arr.Value, TransformString.toCustom, arr.SpecialWords)}");


                ++i;
                Console.WriteLine();
            }

            //--------------------------------------------------
            Console.WriteLine(System.Environment.NewLine + "Press any key");
            Console.ReadKey();
            Console.Clear();

            var text1 = "Великая Россия (РФ) - могущественная страна РФ";
            Dictionary<int, int> dic1 = new Dictionary<int, int>()
            {
                { 8, 6 },
                { 16, 2 },
                { 44, 2 },
            };

            Console.WriteLine(text1);
            int j = 0;
            foreach (var d1 in dic1)
            {
                Console.Write($"'{text1.Substring(j, d1.Key - j)}' | ");
                Console.WriteLine($"'{text1.Substring(d1.Key, d1.Value)}'");
                j = d1.Key + d1.Value;
            }
            if (j < text1.Length)
                Console.WriteLine($"'{text1.Substring(j, text1.Length - j)}'");

            Console.WriteLine();

            var text2 = "МСК - столица России (РФ) и точка!";
            Dictionary<int, int> dic2 = new Dictionary<int, int>()
            {
                { 0, 3 },
                { 14, 6 },
                { 22, 2 },
            };

            Console.WriteLine(text2);
            j = 0;
            foreach (var d2 in dic2)
            {
                Console.Write($"'{text2.Substring(j, d2.Key - j)}' | ");
                Console.WriteLine($"'{text2.Substring(d2.Key, d2.Value)}'");
                j = d2.Key + d2.Value;
            }
            if (j < text2.Length)
                Console.WriteLine($"'{text2.Substring(j, text2.Length - j)}'");

            Console.WriteLine();

            var text3 = "aaabbbbccddddd";
            Dictionary<int, int> dic3 = new Dictionary<int, int>()
            {
                { 0, 3 },
                { 3, 4 },
                { 7, 2 },
                { 9, 5 }
            };

            Console.WriteLine(text3);
            j = 0;
            foreach (var d3 in dic3)
            {
                Console.WriteLine($"(1)'{text3.Substring(j, d3.Key - j)}'");
                Console.WriteLine($"(2)'{text3.Substring(d3.Key, d3.Value)}'");
                Console.WriteLine($"(3)'{text3.Substring(d3.Key + d3.Value, text3.Length - (d3.Key + d3.Value))}'");
            }

            Console.WriteLine();
            //--------------------------------------------------	

            Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
            Console.ReadKey();
        }

        static string Transform_ToString(string value, TransformString transformString = TransformString.toDefault, IEnumerable<string> specialWords = null)
        {
            value = (value ?? string.Empty).Trim();

            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            value = transformString switch
            {                    
                TransformString.toLower => value.ToLower(),
                TransformString.toUpper => value.ToUpper(),
                TransformString.toCustom => value[..1].ToUpper() + value[1..].ToLower(),  //value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower()
                TransformString.toDefault => value,
                _ => value,
            };

            var ignoreTransformStringsSpecialWords = new[] 
            { 
                TransformString.toDefault, 
                TransformString.toUpper 
            };

            if (!ignoreTransformStringsSpecialWords.Contains(transformString) &&
                (specialWords?.Any() ?? false))
            {
                foreach (var specialWord in specialWords)
                {
                    var patternSpecialWord = $@"\b{specialWord}\b";
                    //value = Regex.Replace(value, patternSpecialWord, specialWord, RegexOptions.IgnoreCase);

                    MatchCollection matches = Regex.Matches(value, patternSpecialWord, RegexOptions.IgnoreCase);
                    if (matches != null && matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            if (match.Success)
                            {
                                Console.WriteLine($"indx: {match.Index}| len: {match.Value.Length}| val: {match.Value}");
                            }
                        }
                    }
                }
            }

            return value;
        }
    }
}