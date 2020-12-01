using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculatorTests
{
    internal static class PassingDatesAndPrices
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

        internal static IEnumerable<object[]> DatesAndPrices()
        {
            yield return new object[] { "2020,06,30,00,50", 0 };
            yield return new object[] { "2020,06,30,06,34", 13 };
            yield return new object[] { "2020,06,30,08,52", 8 };
            yield return new object[] { "2020,06,30,10,13", 8 };
            yield return new object[] { "2020,06,30,10,25", 8 };
            yield return new object[] { "2020,06,30,11,04", 8 };
            yield return new object[] { "2020,06,30,16,50", 18 };
            yield return new object[] { "2020,06,30,18,00,", 8 };
            yield return new object[] { "2020,06,30,21,30", 0 };
            yield return new object[] { "2020,07,01,00,00", 0 };
        }
    }
}
