using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            var passingDates = new DateTime[] 
            {
            new DateTime(2020,6,30,00,5,00),
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
            var actual = Program.TotalFeeCost(passingDates);
            var expected = 55;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TotalFeeCostTest()
        {
            
            Assert.AreEqual(expected, actual);
        }
    }
}
