using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TollFeeCalculator;

namespace TollFeeCalculatorTests
{
    [TestClass]
    public class CalculateTollFeeTests
    {
        [TestMethod]
        public void RunTest()
        {
            using(var stringWriter= new StringWriter())
            {
                Console.SetOut(stringWriter);                
                CalculateTollFee.run(
                    Environment.CurrentDirectory +
                    "../../../../../TollFeeCalculator/testData.txt"
                );
                var expected  = "The total fee for the inputfile is 55";
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void TotalFeeCostTest()
        {
            var dates = CalculateTollFeeTests.dates;
            var actual = CalculateTollFee.TotalFeeCost(dates);
            var expected = 55;
            Assert.AreEqual(expected, actual);
        }

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

        [DataTestMethod]
        [DynamicData(nameof(GetDatesAndPrices), DynamicDataSourceType.Method)]
        public void TullFeePassTest(string dateString, int fee)
        {
            var date = DateTime.ParseExact(dateString, "yyyy,MM,dd,HH,mm", CultureInfo.InvariantCulture);
            var expected = fee;
            var actual = CalculateTollFee.GetTollFee(date);

            Assert.AreEqual(expected, actual);
        }

        internal static IEnumerable<object[]> GetDatesAndPrices()
        {
            yield return new object[] { "2020,06,30,00,50", 0 };
            yield return new object[] { "2020,06,30,06,34", 13 };
            yield return new object[] { "2020,06,30,08,52", 8 };
            yield return new object[] { "2020,06,30,10,13", 8 };
            yield return new object[] { "2020,06,30,10,25", 8 };
            yield return new object[] { "2020,06,30,11,04", 8 };
            yield return new object[] { "2020,06,30,16,50", 18 };
            yield return new object[] { "2020,06,30,18,00", 8 };
            yield return new object[] { "2020,06,30,21,30", 0 };
            yield return new object[] { "2020,07,01,00,00", 0 };
        }

        [TestMethod]
        [DynamicData(nameof(GetFreePassDates), DynamicDataSourceType.Method)]
        public void FreeTest(string dateString, bool isFreeDate)
        {
            var date = DateTime.ParseExact(dateString, "yyyy,MM,dd,HH,mm", CultureInfo.InvariantCulture);
            var expected = isFreeDate;
            var actual = CalculateTollFee.isFreeFeeDay(date);
            Assert.AreEqual(expected, actual);
        }

        internal static IEnumerable<object[]> GetFreePassDates()
        {
            yield return new object[] { "2020,07,06,16,10", true };
            yield return new object[] { "2020,12,02,10,13", false }; 
            yield return new object[] { "2020,12,18,08,34", false }; // Friday is fee weekday
            yield return new object[] { "2020,12,20,08,34", true }; // Sunday is fee free weekday
            yield return new object[] { "2020,12,25,13,52", true }; // Christmas day is always a Sunday
        }
    }
}
