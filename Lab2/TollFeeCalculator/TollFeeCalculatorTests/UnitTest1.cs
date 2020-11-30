using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using TollFeeCalculator;

namespace TollFeeCalculatorTests
{
    [TestClass]
    public class UnitTest1
    {
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

        [DataTestMethod]
        public void TullFeePassTest()
        {
            var length = PassingDatesAndPricesRepository.dates.Length;
            for (int i = 0; i < length; i++)
            {
                var actual = Program.TollFeePass(PassingDatesAndPricesRepository.datesAndPrices[i].Item1);
                var expected = PassingDatesAndPricesRepository.datesAndPrices[i].Item2;
                //print custom  look at my marking Start test!!
                Trace.WriteLine("Hello World");
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
