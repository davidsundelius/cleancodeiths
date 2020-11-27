namespace Calculator
{
    public class MockConsole : IConsole
    {
        public string ReadLine()
        {
            return "Hello World";
        }
    }
}