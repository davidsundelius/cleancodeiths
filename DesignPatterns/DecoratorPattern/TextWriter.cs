using System;
using System.Media;
using System.Net.Mime;

namespace DesignPatterns
{
    public class TextWriter : ITextWriter
    {
        public void writeText(string message) {
            Console.WriteLine(message);
        }
    }
}