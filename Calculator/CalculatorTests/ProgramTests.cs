using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System.IO;
using System;

namespace CalculatorTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void AddTest()
        {
            //Arrange
            Program program = new Program();
            //Act
            var expected = program.Add(5, 8);
            //Assert
            Assert.AreEqual(13, expected);
        }

        [TestMethod]
        public void HelloWorldTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                //Arrange
                Program program = new Program();
                Console.SetOut(sw);
                //Act
                program.PrintHelloWorld();
                //Assert
                var expected = string.Format("Hello World{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }
}
