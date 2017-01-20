using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmicToolbox
{
    class Week5
    {
        public static int KnapsackWithoutRep(int W, int n, int[] w)
        {
            var A = new int[n + 1, W + 1];

            for (int k = 1; k <= n; k++)
            {
                for (int s = 1; s <= W; s++)
                {
                    if (s >= w[k - 1])
                    {
                        A[k, s] = Math.Max(A[k - 1, s], A[k - 1, s - w[k - 1]] + w[k - 1]);
                    }
                    else
                    {
                        A[k, s] = A[k - 1, s];
                    }
                }
            }

            return A[n, W];
        }

        public static int EditingDistance(string a, string b)
        {
            var n = a.Length;
            var m = b.Length;
            var D = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++)
            {
                D[i, 0] = i;
            }

            for (int i = 0; i <= m; i++)
            {
                D[0, i] = i;
            }

            for (int j = 1; j <= m; j++)
            {
                for (int i = 1; i <= n; i++)
                {
                    var ins = D[i, j - 1] + 1;
                    var del = D[i - 1, j] + 1;
                    var mat = D[i - 1, j - 1];
                    var mis = D[i - 1, j - 1] + 1;

                    if (a[i - 1] == b[j - 1])
                    {
                        D[i, j] = Math.Min(Math.Min(ins, del), mat);
                    }
                    else
                    {
                        D[i, j] = Math.Min(Math.Min(ins, del), mis);
                    }
                }
            }

            return D[n, m];
        }

        public static long Partntheses(string str)
        {
            var d = str.Where(x => Char.IsDigit(x)).Select(x => Int32.Parse(x.ToString())).ToArray();
            var op = str.Where(x => !Char.IsDigit(x)).ToArray();

            var n = d.Length;

            var m = new long[n, n];
            var M = new long[n, n];

            for (int i = 0; i < n; i++)
            {
                m[i, i] = M[i, i] = d[i];
            }

            for (int s = 0; s < n; s++)
            {
                for (int i = 0; i < n - s - 1; i++)
                {
                    var j = i + s + 1;
                    var temp = MinAndMax(op, i, j, m, M);

                    m[i, j] = temp[0];
                    M[i, j] = temp[1];
                }
            }

            return M[0, n - 1];
        }

        private static long[] MinAndMax(char[] op, int i, int j, long[,] m, long[,] M)
        {
            var min = Int64.MaxValue;
            var max = Int64.MinValue;

            for (int k = i; k < j; k++)
            {
                var a = Calculate(op[k], M[i, k], M[k + 1, j]);
                var b = Calculate(op[k], M[i, k], m[k + 1, j]);
                var c = Calculate(op[k], m[i, k], M[k + 1, j]);
                var d = Calculate(op[k], m[i, k], m[k + 1, j]);

                min = new long[] { a, b, c, d, min }.Min();
                max = new long[] { a, b, c, d, max }.Max();
            }

            return new long[] { min, max };
        }

        private static long Calculate(char @operator, long a, long b)
        {
            switch (@operator)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                default: throw new Exception("Wrong operator");
            }
        }
    }
}
