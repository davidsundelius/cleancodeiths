using System;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var printer = new RegularStringPrinter();
            printer.PrintStringFromApi();
        }
    }
}