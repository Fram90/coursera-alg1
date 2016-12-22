using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmicToolbox
{
    class Week1
    {
        public static void Run()
        {
            var input = Console.ReadLine();

            var n = Int32.Parse(input);
            var numbers = new int[n];

            input = Console.ReadLine();

            int i = 0;
            foreach (var s in input.Split(' '))
            {
                numbers[i++] = Int32.Parse(s);
            }

            Console.WriteLine(Week1.MaxPairwiseProductFast(numbers));


            //var rnd = new Random();
            //while (true)
            //{

            //    int n = rnd.Next(2, 1000);

            //    int[] a = new int[n];
            //    for (int i = 0; i < n; i++)
            //    {
            //        a[i] = rnd.Next(99999);
            //    }
            //    Console.WriteLine(String.Join(" ", a));


            //    var res1 = MaxPairwiseProduct(a);
            //    var res2 = MaxPairwiseProductFast(a);

            //    if (res1 != res2)
            //    {
            //        Console.WriteLine($"Wrong answer: {res1} {res2}");
            //        break;
            //    }

            //    Console.WriteLine("OK");
            //}
        }

        public static long MaxPairwiseProduct(int[] numbers)
        {
            long result = 0;
            int n = numbers.Length;

            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    if ((long)numbers[i] * numbers[j] > result)
                    {
                        result = (long)numbers[i] * numbers[j];
                    }
                }
            }
            return result;
        }

        public static long MaxPairwiseProductFast(int[] numbers)
        {
            int n = numbers.Length;

            int max_index1 = -1;
            for (int i = 0; i < n; ++i)
            {
                if (max_index1 == -1 || numbers[i] > numbers[max_index1])
                    max_index1 = i;
            }

            int max_index2 = -1;
            for (int i = 0; i < n; ++i)
            {
                if (i != max_index1 && (max_index2 == -1 || numbers[i] > numbers[max_index2]))
                    max_index2 = i;
            }

            return (long)numbers[max_index1] * numbers[max_index2];
        }
    }
}
