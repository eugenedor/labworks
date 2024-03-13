using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsApp220129
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MethodIndexOf();      // ++
            MethodRegexMatches(); // ++
            MethodSplit();        // --
            MethodRegMatches2();  // +-
            MethodLINQ();         // --
            MethodToCharArray();  // --
            MethodDef();          // --
            Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
            Console.ReadKey();
        }

        static void MethodIndexOf()
        {
            Console.WriteLine("*****MethodIndexOf*****");

            var s = "000120000120000012000012";
            var p = "12";

            int i = 0, count = 0;
            while ((i = s.IndexOf(p, i)) != -1)
            {
                ++count;
                i += p.Length;
            }
            Console.WriteLine(count);
        }

        static void MethodRegexMatches()
        {
            Console.WriteLine("*****MethodRegexMatches*****");

            string str0 = "ghj abc ijew abc wiuhewiu abc wkkabc wlkj";
            MatchCollection matches = Regex.Matches(str0, "\\babc\\b");
            Console.WriteLine(matches.Count);
        }

        static void MethodSplit()
        {
            Console.WriteLine("*****MethodSplit*****");
            //c For
            string str1 = "ghj abc ijew abc wiuhewiu abc wkkabc wlkj";
            string[] strArray = str1.Split(' ');
            int count = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].Equals("abc"))
                    count++;
            }
            Console.WriteLine(count);
        }

        static void MethodRegMatches2()
        {
            Console.WriteLine("*****MethodRegMatches2*****");

            string s = "5425989545655";
            int count = 0;
            foreach (Match m in Regex.Matches(s, "5"))
                count++;
            Console.Write(count);
            Console.Write("; ");
            Console.WriteLine(Regex.Matches(s, "5").Count);
        }

        static void MethodLINQ()
        {
            Console.WriteLine("*****MethodLINQ*****");

            string s = "5425989545655";

            IEnumerable<char> stringQuery =
                from ch in s
                    //where ch.ToString() == "5"
                where "5".Equals(ch.ToString())
                select ch;

            Console.WriteLine(stringQuery.Count());

            IEnumerable<char> stringQuery2 =
                from ch in s
                where ch.ToString() == "5"
                select ch;

            Console.WriteLine(stringQuery2.Count());
        }

        static void MethodToCharArray()
        {
            Console.WriteLine("*****MethodToCharArray*****");

            string s = "5425989545655";
            int count = s.ToCharArray().Where(i => i.ToString() == "5").Count();

            Console.WriteLine(count);
        }

        static void MethodDef()
        {
            Console.WriteLine("*****MethodDef*****");

            string aString = "ABCDE99F-J74-12-89A";

            // Select only those characters that are numbers  
            IEnumerable<char> stringQuery =
              from ch in aString
              where Char.IsDigit(ch)
              select ch;

            // Execute the query  
            foreach (char c in stringQuery)
                Console.Write(c + " ");

            // Call the Count method on the existing query.  
            int count = stringQuery.Count();
            Console.WriteLine("Count = {0}", count);

            // Select all characters before the first '-'  
            IEnumerable<char> stringQuery2 = aString.TakeWhile(c => c != '-');

            // Execute the second query  
            foreach (char c in stringQuery2)
                Console.Write(c);

            Console.WriteLine();
        }
    }
}
