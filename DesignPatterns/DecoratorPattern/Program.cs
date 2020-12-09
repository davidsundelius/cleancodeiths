namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            ITextWriter tw = new DecoratedTextWriter();
            tw.writeText("Hello");
            tw.writeText("World");
        }
    }
}