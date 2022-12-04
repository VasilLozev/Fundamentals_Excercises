using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _7._Predicate_for_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(' ');
            Action<string[], Predicate<int>> printNames = (names, match) =>
            {                                                                                 
                List<string> result = new List<string>();
                foreach (var name in names)
                {
                    if (match(name.Length))
                    {
                      result.Add(name);
                    }
                }
                Console.WriteLine(string.Join('\n',result));
            };
            printNames(names, n => n <= number);
        }
    }
}
