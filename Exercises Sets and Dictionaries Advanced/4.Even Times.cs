using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, List<int>> set = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!set.ContainsKey(number))
                {
                     set.Add(number, new List<int>());
                }
                set[number].Add(1);
                
            }
            foreach (var item in set)
            {
                if (item.Value.Sum() % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
