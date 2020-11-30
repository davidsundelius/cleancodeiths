using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculatorTests
{
    public static class PassingDatesAndPricesRepository
    {
        internal static readonly DateTime[] dates = new[]
        {
            new DateTime(2020,6,30,00,50,0),
            new DateTime(2020,6,30,06,34,00),
            new DateTime(2020,6,30,08,52,00),
            new DateTime(2020,6,30,10,13,00),
            new DateTime(2020,6,30,10,25,00),
            new DateTime(2020,6,30,11,4,00),
            new DateTime(2020,6,30,16,50,00),
            new DateTime(2020,6,30,18,0,00),
            new DateTime(2020,6,30,21,30,00),
            new DateTime(2020,7,01,00,0,00)
        };

        internal static readonly Tuple<DateTime, int>[] datesAndPrices = new[]
        {
            new Tuple<DateTime,int>(dates[0], 0),
            new Tuple<DateTime,int>(dates[1], 13),
            new Tuple<DateTime,int>(dates[2], 8),
            new Tuple<DateTime,int>(dates[3], 8),
            new Tuple<DateTime,int>(dates[4], 8),
            new Tuple<DateTime,int>(dates[5], 8),
            new Tuple<DateTime,int>(dates[6], 18),
            new Tuple<DateTime,int>(dates[7], 8),
            new Tuple<DateTime,int>(dates[8], 0),
            new Tuple<DateTime,int>(dates[9], 0)
        };
    }
}
