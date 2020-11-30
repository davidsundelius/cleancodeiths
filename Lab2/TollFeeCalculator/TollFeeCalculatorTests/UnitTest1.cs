using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TollFeeCalculator;

namespace TollFeeCalculatorTests
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly DateTime[] dates = new[]
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

        private readonly Tuple<DateTime,int>[] datesAndPrices = new []
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

        [TestMethod]
        public void RunTest()
        {
            using(var stringWriter= new StringWriter())
            {
                Console.SetOut(stringWriter);                
                Program.run(
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
            var dates = PassingDatesAndPricesRepository.dates;
            var actual = Program.TotalFeeCost(dates);
            var expected = 55;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TullFeePassTest()
        {

            for (int i = 0; i < dates.Length; i++)
            {
                var actual = Program.TollFeePass(PassingDatesAndPricesRepository.datesAndPrices[i].Item1);
                var expected = PassingDatesAndPricesRepository.datesAndPrices[i].Item2;

                Assert.AreEqual(expected, actual);
            }

        }
    }
}
