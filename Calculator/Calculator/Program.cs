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

        public string ReadLine(IConsole console)
        {
            return console.ReadLine();
        }

        static void Main(string[] args)
        {
            var program = new Program();
            IConsole console = new ReadConsole();
            Console.WriteLine("Test: " + program.ReadLine(console));
            //Console.WriteLine("5 + 6 = " + program.Add(5, 6));
        }
    }
}
