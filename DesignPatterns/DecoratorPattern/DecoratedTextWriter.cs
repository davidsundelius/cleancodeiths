using System;

namespace DesignPatterns
{
    public class DecoratedTextWriter : ITextWriter
    {
        private TextWriter tw;
        
        public DecoratedTextWriter()
        {
            tw = new TextWriter(); 
        }
        
        public void writeText(string message)
        {
            Console.WriteLine("-----------");
            tw.writeText(message);
        }
    }
}