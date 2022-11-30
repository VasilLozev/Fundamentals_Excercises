using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _1._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(String.Join(", ",numbers.Where(x=>x %2 == 0).OrderBy(x=>x).ToArray()));
        }
    }
}
