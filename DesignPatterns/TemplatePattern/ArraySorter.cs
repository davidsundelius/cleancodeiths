using System;

namespace TemplatePattern
{
    public class ArraySorter
    {
        private int[] array;
        
        public void initializeArray()
        {
            array = new int[] {6, 8, 3, 2, 4, 6, 8, 9};
        }

        public void sortArray()
        {
            Array.Sort(array);
        }

        public void printArray()
        {
            Console.WriteLine(array);
        }
    }
}