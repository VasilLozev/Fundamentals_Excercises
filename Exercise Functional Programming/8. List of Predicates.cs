using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Text;

namespace _8__List_of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Predicate<int>> predicate = new List<Predicate<int>>();

            int endRumbers = int.Parse(Console.ReadLine());
          
            HashSet<int> dividers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToHashSet();

            int[] numbers = Enumerable.Range(1, endRumbers).ToArray();
            
            foreach (var divider in dividers)
            {
                predicate.Add(p => p % divider == 0);
            }

            foreach (var number in numbers)
            {
                bool isDivisible = true;
                foreach (var match in predicate)
                {
                    if (!match(number))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    Console.Write($"{number} ");
                }
            }
        }      
    }
}
