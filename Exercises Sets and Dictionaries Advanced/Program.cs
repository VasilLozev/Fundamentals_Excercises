using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                List<string> x = Console.ReadLine().Split(' ').ToList();
                foreach (var item in x)
                {
                   if(!set.TryGetValue(item, out var value))
                    {
                        set.Add(item);
                    }
                }
            }
            Console.WriteLine(string.Join(' ', set.OrderBy(x=>x)));
        }
    }
}
