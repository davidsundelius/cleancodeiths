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
        public void PrintTollFeeTest()
        {
            using(var stringWriter= new StringWriter())
            {
                Console.SetOut(stringWriter);                
                CalculateTollFee.PrintTollFee(
                    Environment.CurrentDirectory +
                    "../../../../../TollFeeCalculator/testData.txt"
                );
                var expected  = "The total fee for the inputfile is 55";
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void GetTotalTollFeeCostTest()
        {
            var dates = CalculateTollFeeTests.dates;
            var actual = CalculateTollFee.GetTotalTollFeeCost(dates);
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
        public void GetTollFeeByDateTest(string dateString, int fee)
        {
            var date = DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            var expected = fee;
            var actual = CalculateTollFee.GetTollFeeByDate(date);

            Assert.AreEqual(expected, actual);
        }

        internal static IEnumerable<object[]> GetDatesAndPrices()
        {
            yield return new object[] { "2020-06-30 00:50", 0 };
            yield return new object[] { "2020-06-30 06:34", 13 };
            yield return new object[] { "2020-06-30 08:52", 8 };
            yield return new object[] { "2020-06-30 10:13", 8 };
            yield return new object[] { "2020-06-30 10:25", 8 };
            yield return new object[] { "2020-06-30 11:04", 8 };
            yield return new object[] { "2020-06-30 16:50", 18 };
            yield return new object[] { "2020-06-30 18:00", 8 };
            yield return new object[] { "2020-06-30 21:30", 0 };
            yield return new object[] { "2020-07-01 00:00", 0 };
        }

        [TestMethod]
        [DynamicData(nameof(GetTollFreeDates), DynamicDataSourceType.Method)]
        public void IsTollFreeDateTest(string dateString, bool isFreeDate)
        {
            var date = DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            var expected = isFreeDate;
            var actual = CalculateTollFee.IsTollFreeDate(date);
            Assert.AreEqual(expected, actual);
        }

        internal static IEnumerable<object[]> GetTollFreeDates()
        {
            yield return new object[] { "2020-07-06 16:10", true };
            yield return new object[] { "2020-12-02 10:13", false };
            yield return new object[] { "2020-12-18 08:34", false };
            yield return new object[] { "2020-12-20 08:34", true };
        }
    }
}
