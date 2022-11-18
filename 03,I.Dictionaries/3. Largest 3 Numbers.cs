using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _5._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToList();

            numbers = numbers
                .OrderByDescending(x => x)
                .Take(3)
                .ToList();

            Console.WriteLine(String.Join(" ",numbers));
        }
    }
}
