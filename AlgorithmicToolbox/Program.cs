using System;
using System.Linq;

namespace AlgorithmicToolbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var _args = input.Split(' ').Select(x => Int32.Parse(x)).ToArray();

            Lib.QuickSort(_args, 0, _args.Length - 1);
            Console.WriteLine(String.Join(" ", _args));

            Console.ReadLine();
        }
    }

    class Lib
    {
        public static void QuickSort(int[] a, int l, int r)
        {
            if (l >= r)
            {
                return;
            }

            var m = Partition3(a, l, r);
            QuickSort(a, l, m - 1);
            QuickSort(a, m + 1, r);

            //var k = new Random().Next(l, r);
            //Swap(ref a[l], ref a[k]);


        }

        static int Partition3(int[] a, int l, int r)
        {
            int j = l;

            for (int i = l + 1; i <= r; i++)
            {
                if (a[i] <= a[l])
                {
                    j++;
                    Swap(ref a[i], ref a[j]);
                }
            }
            Swap(ref a[l], ref a[j]);

            return j;
        }

        static void Swap(ref int foo, ref int bar)
        {
            int tmp = foo;
            foo = bar;
            bar = tmp;
        }
    }
}
