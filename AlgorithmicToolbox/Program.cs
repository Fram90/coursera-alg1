using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgorithmicToolbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();

            //var rnd = new Random();
            //var testSegments = new List<int[]>();

            //for (int i = 0; i < 20000; i++)
            //{
            //    testSegments.Add(Lib.GenerateSegment(rnd));
            //}

            //var testPoints = new List<int>();
            //for (int i = 0; i < 10000; i++)
            //{
            //    testPoints.Add(rnd.Next((int)Math.Pow(10, -8), (int)Math.Pow(10, 8)));
            //}

            var segments = new List<int[]>();
            for (int i = 0; i < input[0]; i++)
            {
                segments.Add(Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray());
            }
            var points = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();

            Console.WriteLine(String.Join(" ", Lib.Lottery(segments, points)));

            Console.ReadLine();
        }
    }

    static class Lib
    {
        public static int[] Lottery(List<int[]> segments, int[] points)
        {
            var l = segments.Select(x => x[0]).ToList();
            var r = segments.Select(x => x[1]).ToList();

            var line = new List<Tuple<int, char>>();

            for (int i = 0; i < l.Count; i++)
            {
                line.Add(new Tuple<int, char>(l[i], 'l'));
                line.Add(new Tuple<int, char>(r[i], 'r'));
            }

            var pDict = new Dictionary<int, int>();

            foreach (var point in points)
            {
                line.Add(new Tuple<int, char>(point, 'p'));
                pDict[point] = 0;
            }

            line = line.OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToList();

            int count = 0;
            foreach (var item in line)
            {
                if (item.Item2 == 'l')
                {
                    count++;
                    continue;
                }

                if (item.Item2 == 'r')
                {
                    count--;
                    continue;
                }

                if (item.Item2 == 'p')
                {
                    pDict[item.Item1] = count;
                }
            }

            var result = new List<int>();

            foreach (var point in points)
            {
                result.Add(pDict[point]);
            }

            return result.ToArray();

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

            public int this[int index]
            {
                get { return Array[index + _offset]; }
                set { Array[index + _offset] = value; }
            }
        }

        public static int[] GenerateSegment(Random rnd)
        {
            var result = new int[2];
            result[0] = rnd.Next((int)Math.Pow(10, -8), (int)Math.Pow(10, 8));
            result[1] = rnd.Next(result[0], (int)Math.Pow(10, 8));

            return result;
        }


    }
}
