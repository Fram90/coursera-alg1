using System;
using System.Collections.Generic;
using System.Linq;

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

        static int[] MergeSort(int[] a, ref long inversions)
        {
            if (a.Length <= 1)
            {
                return a;
            }
            int mid = a.Length / 2;

            int[] l1 = new int[mid];
            int[] l2 = new int[a.Length - mid];

            Array.Copy(a, 0, l1, 0, mid);
            Array.Copy(a, mid, l2, 0, l2.Length);

            l1 = MergeSort(l1, ref inversions);
            l2 = MergeSort(l2, ref inversions);


            return Merge(l1, l2, ref inversions);
        }

        static int[] Merge(int[] a, int[] b, ref long pairs)
        {
            var aLen = a.Length;
            var bLen = b.Length;
            int i = 0;
            int j = 0;

            int[] c = new int[aLen + bLen];

            int k = 0;
            while (i < aLen && j < bLen)
            {
                if (a[i] <= b[j])
                {
                    c[k] = a[i];
                    i++;
                }
                else
                {
                    c[k] = b[j];
                    pairs++;
                    j++;
                }
                k++;
            }

            while (i < aLen)
            {
                c[k] = a[i];
                i++;
                k++;
            }

            while (j < bLen)
            {
                c[k] = b[j];
                j++;
                k++;
            }

            return c;
        }

        //public static int[] Majority(int[] array)
        //{
        //    if (array.Length == 1)
        //    {
        //        return array;
        //    }

        //    var mid = array.Length / 2;
        //    var left = new int[mid];
        //    var right = new int[array.Length - mid];
        //    Array.Copy(array, 0, left, 0, mid);
        //    Array.Copy(array, mid, right, 0, array.Length - mid);

        //    var l = Majority(left);
        //    var r = Majority(right);

        //    if (l == -1 && r == -1) return -1;
        //    if (l == -1 && r != -1) 

        //    return -1;
        //}

        //private static int FindMajor(int[] a, int left, int right)
        //{
        //    return 0;
        //}

        public static int[] Lottery(List<Tuple<int, int>> segments, int[] points)
        {
            var sortedS = segments.OrderBy(x => x.Item1).ToList();

            var line = new OffsetArray(sortedS[0].Item1, sortedS.Last().Item2);

            return new int[2];

        }

        private class OffsetArray
        {
            private long _size;
            private int _offset;
            private int[] Array;

            public OffsetArray(int left, int right)
            {
                _size = Math.Abs(left) + Math.Abs(right);
                _offset = Math.Abs(left);
                Array = new int[_size];
            }

            public int this[int index] => Array[index + _offset];
        }
    }
}
