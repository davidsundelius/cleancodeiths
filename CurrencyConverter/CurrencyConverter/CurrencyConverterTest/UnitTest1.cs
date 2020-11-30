using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyConverter;

namespace CurrencyConverterTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConvertUSDtoSEKTest()
        {
            Program program = new Program();
            var actual = program.ConvertUSDtoSEK(4);
            Assert.AreEqual(Program.conversionRate*4, actual);
        }

        [TestMethod]
        /*public void ConvertUSDtoSEKExceptionTest()
        {
            Program program = new Program();
            Assert.ThrowsException<System.Exception>(() => program.ConvertUSDtoSEK(-4));
        }*/
    }
}
