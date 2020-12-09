using System;

namespace TemplatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var arraySorter = new ArraySorter();
            arraySorter.initializeArray();
            arraySorter.sortArray();
            arraySorter.printArray();
        }
    }
}