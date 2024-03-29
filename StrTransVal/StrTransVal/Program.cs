﻿using System;
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
            toSentence = 3
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
            Console.WriteLine($"Sentence:  {Transform_ToString(strValue, TransformString.toSentence)}");
            Console.WriteLine();

            int i = 0;
            foreach (var arr in arrs)
            {
                Console.WriteLine($"{i}) {arr.Value}");

                Console.WriteLine($"Default: {Transform_ToString(arr.Value, TransformString.toDefault, arr.SpecialWords)}");
                Console.WriteLine($"lower:   {Transform_ToString(arr.Value, TransformString.toLower, arr.SpecialWords)}");
                Console.WriteLine($"UPPER:   {Transform_ToString(arr.Value, TransformString.toUpper, arr.SpecialWords)}");
                Console.WriteLine($"Sentence:  {Transform_ToString(arr.Value, TransformString.toSentence, arr.SpecialWords)}");


                ++i;
                Console.WriteLine();
            }

            Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
            Console.ReadKey();
        }

        static string Transform_ToString(string value, TransformString transformString = TransformString.toDefault, IEnumerable<string> specWords = null)
        {
            value = value?.Trim();
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            value = transformString switch
            {                    
                TransformString.toLower => value.ToLower(),
                TransformString.toUpper => value.ToUpper(),
                TransformString.toSentence => value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower(), //value[..1].ToUpper() + value[1..].ToLower(),
                TransformString.toDefault => value,
                _ => value,
            };

            var existSpecWords = specWords?.Any() ?? false;
            if (existSpecWords)
            {
                var ignoreTransformStringsForSpecWords = new[] { TransformString.toDefault, TransformString.toUpper };
                var transformToStringForSpecWords = !ignoreTransformStringsForSpecWords.Contains(transformString);
                if (transformToStringForSpecWords)
                {
                    foreach (var specWord in specWords)
                    {
                        var patternSpecWord = $@"\b{specWord}\b";
                        value = Regex.Replace(value, patternSpecWord, specWord, RegexOptions.IgnoreCase);
                    }
                }
            }

            return value;
        }
    }
}