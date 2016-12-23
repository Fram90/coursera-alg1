using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmicToolbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var _args = input.Split(' ').Select(x => Int64.Parse(x)).ToArray();

            Console.WriteLine(Week2.PartialFibSumLast(_args[0], _args[1]));
            Console.ReadLine();
        }
    }

    class Lib
    {

    }
}
