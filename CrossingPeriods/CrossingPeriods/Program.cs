using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingPeriods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var start = new DateTime(2023, 6, 6);
            var end = new DateTime(2023, 7, 7);

            var filterPeriod = new DateTimePeriod(start, end);
            Console.Write($"Period: {filterPeriod.Start?.Date:yyyy.MM.dd} - {filterPeriod.End?.Date:yyyy.MM.dd} ");
            Console.WriteLine();
            Console.WriteLine();

            var periods = new Dictionary<int, DateTimePeriod>
            {
                [1] = new DateTimePeriod(new DateTime(2023, 1, 1), new DateTime(2023, 3, 31)),
                [2] = new DateTimePeriod(new DateTime(2023, 4, 1), new DateTime(2023, 6, 30)),
                [3] = new DateTimePeriod(new DateTime(2023, 7, 1), new DateTime(2023, 9, 30)),
                [4] = new DateTimePeriod(new DateTime(2023, 10, 1), new DateTime(2023, 12, 31))
            };

            periods[14] = new DateTimePeriod(new DateTime(2023, 4, 1), new DateTime(2023, 4, 30));
            periods[15] = new DateTimePeriod(new DateTime(2023, 5, 1), new DateTime(2023, 5, 31));
            periods[16] = new DateTimePeriod(new DateTime(2023, 6, 1), new DateTime(2023, 6, 30));
            periods[17] = new DateTimePeriod(new DateTime(2023, 7, 1), new DateTime(2023, 7, 31));
            periods[18] = new DateTimePeriod(new DateTime(2023, 8, 1), new DateTime(2023, 8, 31));
            periods[19] = new DateTimePeriod(new DateTime(2023, 9, 1), new DateTime(2023, 9, 30));

            foreach (var period in periods)
            {
                Console.Write($"Period_{period.Key} ({period.Value.Start?.Date:yyyy.MM.dd} - {period.Value.End?.Date:yyyy.MM.dd}) is intersected: ");
                Console.Write(period.Value.IsIntersected(filterPeriod));
                Console.WriteLine($"  {Convert.ToInt32(period.Value.IsIntersected(filterPeriod))}");
            }

            Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
            Console.ReadKey();
        }
    }
}
