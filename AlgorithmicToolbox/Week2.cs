using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmicToolbox
{
    class Week2
    {
        public static void Run()
        {
            Console.WriteLine(GCD(357, 234));
        }

        public static long GCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }

            return GCD(b, a % b);
        }

        public static long NthFibonacci(int n)
        {
            long[] result = new long[n];

            result[0] = 0;
            result[1] = 1;

            for (int i = 2; i < n; i++)
            {
                result[i] = result[i - 2] + result[i - 1];
            }

            return result[n - 1];
        }
    }
}
