using System;

namespace StrategyPattern
{
    class Program
    {
        private Program()
        {
            var array = new int[] {6, 8, 3, 2, 4, 6, 8, 9};
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine(string.Join(", ", insertionSort(array)));
            Console.WriteLine(string.Join(", ", bubbleSort(array)));
        }

        private int[] insertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        int tmp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = tmp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return array;
        }
        
        private int[] bubbleSort(int[] array)
        {
            bool needsSorting = true;
            for (int i = 0; i < array.Length - 1 && needsSorting; i++)
            {
                needsSorting = false;
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        needsSorting = true;
                        int tmp = array[j +1];
                        array[j + 1] = array[j];
                        array[j] = tmp;
                    }
                }
            }
            return array;
        }
        
        static void Main(string[] args)
        {
            new Program();
        }
    }
}