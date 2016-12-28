using System;
using System.Collections.Generic;

namespace AlgorithmicToolbox
{
    class Week4
    {
        public static void BinarySearch(int n, int[] a, int k, int[] b)
        {
            var result = new List<int>();

            for (int i = 0; i < k; i++)
            {
                result.Add(BinarySearchCore(b[i], a));
            }

            Console.WriteLine(String.Join(" ", result));
        }

        private static int BinarySearchCore(int number, int[] array)
        {
            var low = 0;
            var high = array.Length - 1;

            while (low <= high)
            {
                var mid = low + (high - low) / 2;

                if (number == array[mid])
                {
                    return mid;
                }

                if (number < array[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return -1;
        }
    }
}
