﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmicToolbox
{
    class Week3
    {
        public static int ChangingMoney(int m)
        {
            int[] nominals = new[] { 10, 5, 1 };
            int result = 0;

            foreach (var nominal in nominals)
            {
                result += m / nominal;
                m %= nominal;
            }

            return result;
        }

        public static double LootBag(int n, int W)
        {
            int[] w = new int[n];
            int[] v = new int[n];
            double[] a = new double[n];
            var V = new double();
            var A = new int[n];

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var args = input.Split(' ').Select(x => int.Parse(x)).ToArray();

                var ai = (double)args[0] / args[1];

                int j;
                for (j = 0; j < i; j++)
                {
                    if (ai > a[j])
                    {
                        Array.Copy(a, j, a, j + 1, n - j - 1);
                        Array.Copy(w, j, w, j + 1, n - j - 1);
                        Array.Copy(v, j, v, j + 1, n - j - 1);
                        break;
                    }
                }
                a[j] = ai;
                v[j] = args[0];
                w[j] = args[1];
            }

            for (int i = 0; i < n; i++)
            {
                if (W == 0)
                {
                    return V;
                }
                var x = Math.Min(w[i], W);
                V += x * a[i];
                w[i] -= x;
                A[i] += x;
                W -= x;
            }

            return V;
        }

        public static long MaximizingAds(int n)
        {
            int[] v = ImportAdsData(n);
            int[] w = ImportAdsData(n);

            long sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += (long)v[i] * w[i];
            }

            return sum;
        }

        private static int[] ImportAdsData(int n)
        {
            var input = Console.ReadLine();
            var args = input.Split(' ').Select(x => int.Parse(x)).ToArray();
            int[] array = new int[n];

            for (int i = 0; i < args.Length; i++)
            {
                int j;
                for (j = 0; j < i; j++)
                {
                    if (args[i] > array[j])
                    {
                        Array.Copy(array, j, array, j + 1, n - j - 1);
                        break;
                    }
                }

                array[j] = args[i];
            }
            return array;
        }

        public static void CollectingSignatures(int n)
        {
            var pairs = new List<int[]>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var args = input.Split(' ').Select(x => int.Parse(x)).ToArray();

                pairs.Add(args);
            }

            int resCount = 0;
            var resPoints = new List<int>();

            while (pairs.Count > 0)
            {
                var min = pairs.Min(x => x[1]);
                resPoints.Add(min);

                for (int i = 0; i < pairs.Count; i++)
                {
                    if (pairs[i][0] <= min)
                    {
                        pairs.RemoveAt(i--);
                    }
                }

                resCount++;
            }

            Console.WriteLine(resCount);
            Console.WriteLine(String.Join(" ", resPoints));

        }

        public static void Competition(int n)
        {
            var result = new List<int>();

            int i = 1;
            while (true)
            {
                if (n - i <= i)
                {
                    result.Add(n);
                    break;
                }
                result.Add(i);
                n -= i;
                i++;
            }

            Console.WriteLine(result.Count);
            Console.WriteLine(String.Join(" ", result));
        }

        public static void LargestNumber(int n, List<int> numbers)
        {
            StringBuilder sb = new StringBuilder();

            while (numbers.Count > 0)
            {
                int? max = null;

                foreach (int number in numbers)
                {
                    if (IsGreaterOrEqual(number, max) || numbers.Count == 1)
                    {
                        max = number;
                    }
                }
                sb.Append(max);
                numbers.Remove(max.Value);
            }

            Console.WriteLine(sb.ToString());
        }

        private static bool IsGreaterOrEqual(int a, int? b)
        {
            var astr = a.ToString() + b;
            var bstr = b.ToString() + a;

            return int.Parse(astr) >= int.Parse(bstr);
        }
    }
}
