using System;

namespace TemplatePattern
{
    public class ArraySorter
    {
        private int[] array;

        public void InitializeSortAndPrintArray()
        {
            initializeArray();
            sortArray();
            printArray();
        }
        
        private void initializeArray()
        {
            array = new int[] {6, 8, 3, 2, 4, 6, 8, 9};
        }

        private void sortArray()
        {
            Array.Sort(array);
        }

        private void printArray()
        {
            Console.WriteLine(string.Join(", ", array));
        }
    }
}