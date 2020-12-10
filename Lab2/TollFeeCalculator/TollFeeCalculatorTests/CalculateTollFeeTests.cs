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
        public void PrintTotalTollFeeFromFileTest()
        {
            using StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            CalculateTollFee.PrintTotalTollFeeFromFile(
                Environment.CurrentDirectory +
                "../../../../testData.txt"
            );
            string expected = "The total Fee for the input file is 55";
            string actual = stringWriter.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrintTotalTollFeeFromFileBadContentTest()
        {
            using StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            CalculateTollFee.PrintTotalTollFeeFromFile(
                Environment.CurrentDirectory +
                "../../../../badTestData.txt"
            );
            string expected = "The toll Fee could not be calculated";
            string actual = stringWriter.ToString();
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetDatesArrays), DynamicDataSourceType.Method)]
        public void GetTotalTollFeeTest(DateTime[] dateTimes)
        {
            int expected = 0;
            int actual = CalculateTollFee.GetTotalTollFee(dateTimes);
            if (dateTimes.Length != 0) expected = 55;
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetDatesAndPrices), DynamicDataSourceType.Method)]
        public void GetTollFeeByDateTest(string dateString, int fee)
        {
            DateTime passageDate = DateTime.ParseExact(dateString,
                "yyyy-MM-dd HH:mm",
                CultureInfo.InvariantCulture);
            int expected = fee;
            int actual = CalculateTollFee.GetTollFeeByDate(passageDate);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTimesAndPrices), DynamicDataSourceType.Method)]
        public void GetTollFeeByTimeTest(string dateString, int fee)
        {
            DateTime passageDate = DateTime.ParseExact(dateString,
                "yyyy-MM-dd HH:mm",
                CultureInfo.InvariantCulture);
            int expected = fee;
            int actual = CalculateTollFee.GetTollFeeByTime(passageDate);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DynamicData(nameof(GetTollFreeDates), DynamicDataSourceType.Method)]
        public void IsDateTollFreeTest(string dateString, bool isFreeDate)
        {
            DateTime passageDate = DateTime.ParseExact(dateString,
                "yyyy-MM-dd HH:mm",
                CultureInfo.InvariantCulture);
            bool expected = isFreeDate;
            bool actual = CalculateTollFee.IsDateTollFree(passageDate);
            Assert.AreEqual(expected, actual);
        }

        #region Test Data Repository

        internal static IEnumerable<object[]> GetTollFreeDates()
        {
            yield return new object[] { "2020-07-06 16:10", true };
            yield return new object[] { "2020-12-02 10:13", false };
            yield return new object[] { "2020-12-18 08:34", false };
            yield return new object[] { "2020-12-20 08:34", true };
        }

        internal static IEnumerable<object[]> GetTimesAndPrices()
        {
            yield return new object[] { "2020-06-22 00:00", 0 };
            yield return new object[] { "2020-06-22 06:00", 8 };
            yield return new object[] { "2020-06-22 06:59", 13 };
            yield return new object[] { "2020-06-22 07:30", 18 };
            yield return new object[] { "2020-06-22 08:29", 13 };
            yield return new object[] { "2020-06-22 08:30", 8 };
            yield return new object[] { "2020-06-22 15:15", 13 };
            yield return new object[] { "2020-06-22 16:59", 18 };
            yield return new object[] { "2020-06-22 17:00", 13 };
            yield return new object[] { "2020-06-22 18:29", 8 };
            yield return new object[] { "2020-06-22 23:59", 0 };
        }

        internal static IEnumerable<object[]> GetDatesAndPrices()
        {
            yield return new object[] { "2020-07-10 16:10", 0 };
            yield return new object[] { "2020-12-02 10:13", 8 };
        }

        internal static IEnumerable<object[]> GetDatesArrays()
        {
            yield return new object[]
            {
                new []
                {
                    new DateTime(2020,6,30,00,5,0),
                    new DateTime(2020,6,30,06,34,00),
                    new DateTime(2020,6,30,08,52,00),
                    new DateTime(2020,6,30,10,13,00),
                    new DateTime(2020,6,30,10,25,00),
                    new DateTime(2020,6,30,11,4,00),
                    new DateTime(2020,6,30,16,50,00),
                    new DateTime(2020,6,30,18,0,00),
                    new DateTime(2020,6,30,21,30,00),
                    new DateTime(2020,7,01,00,0,00)
                }
            };
            yield return new object[]
            {
                new DateTime[]{ }
            };
        }

        #endregion Test Data Repository
    }
}