using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string x = Console.ReadLine();
            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (var item in x)
            {
                if (!dict.ContainsKey(item))
                {
                    dict.Add(item, 0);
                }
                dict[item]++;
            }
            dict = dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
