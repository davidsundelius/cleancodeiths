using System;

namespace Calculator
{
    public class Program
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public void PrintHelloWorld()
        {
            Console.WriteLine("Hello World");
        }

        public string ReadLineAndMakeUpperCase(IConsole console)
        {
            var result = console.ReadLine();
            result += " hello!";
            return result.ToUpper();
        }

        static void Main(string[] args)
        {
            var program = new Program();
            IConsole console = new ReadConsole();
            Console.WriteLine("Test: " + program.ReadLineAndMakeUpperCase(console));
            //Console.WriteLine("5 + 6 = " + program.Add(5, 6));
        }
    }
}
