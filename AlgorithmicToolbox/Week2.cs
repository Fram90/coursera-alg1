using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmicToolbox
{
    class Week2
    {
        public static long Fib1(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            long[] result = new long[n];

            result[0] = 1;
            result[1] = 1;

            for (int i = 2; i < n; i++)
            {
                result[i] = result[i - 2] + result[i - 1];
            }

            return result[n - 1];
        }

        public static int Fib2(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            int[] result = new int[n];

            result[0] = 1;
            result[1] = 1;

            for (int i = 2; i < n; i++)
            {
                result[i] = (result[i - 2] + result[i - 1]) % 10;
            }

            return result[n - 1];
        }

        public static long GCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }

            return GCD(b, a % b);
        }

        public static long LCM(int a, int b)
        {
            var gcd = GCD(a, b);
            return (long)a * b / gcd;
        }

        public static long HugeFibModulo(long n, int m)
        {
            if (n <= 1)
            {
                return (int)n;
            }

            var p_prev = 0L;
            var prev = 1L;
            var pp_m = 0L;
            var p_m = 0L;

            for (long i = 2; i <= n; i++)
            {
                pp_m = p_prev % m;
                p_m = prev % m;

                var curr = pp_m + p_m;

                var temp = prev;
                p_prev = temp;
                prev = curr;

                if (i > 2 && pp_m == 0 && p_m == 1)
                {
                    var x = n % (i - 2);
                    return HugeFibModulo(x, m);
                }
            }

            return (pp_m + p_m) % m;
        }

        public static long FibSumLast(long n)
        {
            int sum = 0;
            var y = n % 60;

            for (int i = 0; i <= y; i++)
            {
                sum += (int)HugeFibModulo(i, 10);
            }

            return sum % 10;
        }

        public static int PartialFibSumLast(long m, long n)
        {
            if (n == m)
            {
                return (int)HugeFibModulo(n % 60, 10);
            }

            var sum = (int)FibSumLast(n % 60) - (int)FibSumLast(m - 1) + 10;
            return Math.Abs(sum % 10);
        }
    }
}
