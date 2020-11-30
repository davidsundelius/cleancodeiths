namespace Calculator
{
    public class MockConsole : IConsole
    {
        private bool isFirst = true;
        public string ReadLine()
        {
            if (isFirst)
            {
                isFirst = false;
                return "Hello World";
            }
            else
            {
                return "2";
            }
        }
    }
}