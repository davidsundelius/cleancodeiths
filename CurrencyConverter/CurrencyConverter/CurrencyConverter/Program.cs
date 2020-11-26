using System;

namespace CurrencyConverter
{
    public class Program
    {
        public readonly static double conversionRate = 8.5;

        public double ConvertUSDtoSEK(double amount)
        {
            if(amount < 0)
            {
                throw new Exception("Only positive numbers");
            }
            return amount*conversionRate;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
