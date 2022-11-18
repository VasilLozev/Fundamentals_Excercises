using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _3._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers =
                new List<int>(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList());

            Dictionary<int, int> counts = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                counts.Add(i, numbers[i]);
            }
            counts = counts.OrderByDescending(x => x.Value).ToDictionary(v => v.Key, v => v.Value);
            int count1 = 0;
            foreach(var item in counts)
            {
                count1++;
                Console.Write(item.Value + " ");
                    if(count1 == 3)
                {
                    break;
                }
            }
        }
    }
}
