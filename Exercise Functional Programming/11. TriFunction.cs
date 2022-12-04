using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(' ');

            Func<string, int, bool> checkEqualOrLargerNameSum = (name, sum) =>
                name.Sum(ch => ch) >= sum;

            Func<string[], int, Func<string, int, bool>, string> getFirstName = (names, sum, match) =>
                names.FirstOrDefault(name => match(name, sum));

            Console.WriteLine(getFirstName(names, sum, checkEqualOrLargerNameSum));
        }
    }
}
