using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmicToolbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            //var n = Int32.Parse(input);

            var _args = input.Split(' ').Select(x => Int64.Parse(x)).ToArray();

            Console.WriteLine(Lib.HugeFibModulo(_args[0], (int)_args[1]));


            Console.ReadLine();
        }
    }

    class Lib
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

            var prev1 = 0L;
            var prev2 = 1L;
            var curr = 0L;

            for (long i = 2; i < n; i++)
            {
                var p1 = prev1 % m;
                var p2 = prev2 % m;
                curr = p1 + p2;

                var temp = prev2;
                prev1 = temp;
                prev2 = curr;

                if (i > 2 && p1 == 0 && p2 == 1)
                {
                    var x = n % (i - 1);
                    return FibMod((int)x, m);
                }
            }

            return (prev1 + curr) % m;
        }

        private static long FibMod(int n, int m)
        {
            if (n <= 1)
            {
                return n;
            }

            long[] result = new long[n];

            result[0] = 0;
            result[1] = 1;

            for (int i = 2; i < n; i++)
            {
                result[i] = (result[i - 2] + result[i - 1]) % m;
            }

            return result[n - 1];
        }
    }
}
