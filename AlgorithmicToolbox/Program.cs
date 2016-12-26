using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmicToolbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var _args = input.Split(' ').Select(x => Int32.Parse(x)).ToArray();

            input = Console.ReadLine();
            var numbers = input.Split(' ').Select(x => Int32.Parse(x)).ToList();

            //Console.WriteLine(Lib.CollectingSignatures(_args[0]));

            Lib.LargestNumber(_args[0], numbers);

            Console.ReadLine();
        }
    }

    class Lib
    {
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
