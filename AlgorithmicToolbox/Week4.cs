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

        public static void QuickSort(int[] a, int l, int r)
        {
            if (l >= r)
            {
                return;
            }

            var k = new Random().Next(l, r);
            Swap(ref a[l], ref a[k]);

            var m = Partition3(a, l, r);
            QuickSort(a, l, m[0] - 1);
            QuickSort(a, m[1] + 1, r);
        }

        static int[] Partition3(int[] a, int l, int r)
        {
            var x = a[l];
            int j = l;
            int i = 0;

            for (int k = l + 1; k <= r; k++)
            {
                if (a[k] < x)
                {
                    j++;
                    Swap(ref a[k], ref a[j]);
                    if (i > 0)
                    {
                        Swap(ref a[k], ref a[j + i]);
                    }
                }
                else if (a[k] == x)
                {
                    i++;
                    Swap(ref a[k], ref a[j + i]);
                }
            }
            Swap(ref a[l], ref a[j]);

            return new int[] { j, j + i };
        }

        static void Swap(ref int foo, ref int bar)
        {
            int tmp = foo;
            foo = bar;
            bar = tmp;
        }
    }
}
