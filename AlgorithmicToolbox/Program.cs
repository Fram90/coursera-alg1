using System;
using System.Linq;

namespace AlgorithmicToolbox
{
    class Program
    {
        static void Main(string[] args)
        {


            var input = Console.ReadLine();
            input = Console.ReadLine();
            var _args = input.Split(' ').Select(x => Int32.Parse(x)).ToArray();

            Lib.QuickSort(_args, 0, _args.Length - 1);
            Console.WriteLine(String.Join(" ", _args));


            Console.ReadLine();
        }
    }

    class Lib
    {
        
    }
}
