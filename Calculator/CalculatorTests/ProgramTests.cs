using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void AddTest()
        {
            Program program = new Program();
            Assert.AreEqual(14, program.Add(5,8));
        }
    }
}
