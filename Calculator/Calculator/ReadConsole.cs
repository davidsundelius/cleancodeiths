using System;

namespace Calculator
{
    public class ReadConsole : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}