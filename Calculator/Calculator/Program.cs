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



        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("5 + 6 = " + program.Add(5, 6));
        }
    }
}
