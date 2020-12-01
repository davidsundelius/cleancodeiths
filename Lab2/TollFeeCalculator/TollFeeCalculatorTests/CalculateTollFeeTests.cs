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
            var dates = PassingDatesAndPrices.dates;
            var actual = CalculateTollFee.TotalFeeCost(dates);
            var expected = 55;
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(DatesAndPrices), DynamicDataSourceType.Method)]
        public void TullFeePassTest(string dateString, int fee)
        {
            var expected = fee;
            var actual = CalculateTollFee.TollFeePass(
                DateTime.ParseExact(dateString, "yyyy,MM,dd,HH,mm", CultureInfo.InvariantCulture)
            );
                
            Assert.AreEqual(expected, actual);
        }

        internal static IEnumerable<object[]> DatesAndPrices()
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
    }
}
