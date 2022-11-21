using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int n = numbers[0];
            int m = numbers[1];

            HashSet<int> list = new HashSet<int>();
            List<int> list2 = new List<int>();
            for (int i = 0; i < n; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < m; i++)
            {
                int x = int.Parse(Console.ReadLine());
                if (list.Contains(x))
                {
                    list2.Add(x);  
                }
            }
            list.IntersectWith(list2);
            foreach (var item in list)
            {
                Console.WriteLine(string.Join(' ', list.ToArray()));           
            }
        }
    }
}
