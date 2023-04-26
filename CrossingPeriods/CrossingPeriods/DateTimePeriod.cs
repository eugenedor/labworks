using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingPeriods
{
    public struct DateTimePeriod
    {
        public DateTime? Start { get; }
        public DateTime? End { get; }

        public DateTimePeriod(DateTime? start, DateTime? end)
        {
            if (start.HasValue && start.HasValue)
                if (start.Value > end.Value)
                    throw new Exception($"Дата начала диапазона {start.Value} старше конечной даты {end.Value}");

            Start = start;
            End = end;
        }

        public bool IsIntersected(DateTimePeriod period2)
        {
            var start1 = Start ?? DateTime.MinValue;
            var end1 = End ?? DateTime.MaxValue;
            var start2 = period2.Start ?? DateTime.MinValue;
            var end2 = period2.End ?? DateTime.MaxValue;

            //var start = new DateTime(Math.Max(start1.Ticks, start2.Ticks));
            //var end = new DateTime(Math.Min(end1.Ticks, end2.Ticks));

            var start = start1 > start2 ? start1 : start2;
            var end = end1 < end2 ? end1 : end2;

            return start <= end;
        }
    }
}
