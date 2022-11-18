using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();
            for (int i = 0; i < n; i++)
            {
                names.Add(Console.ReadLine());
            }
            names = names.Distinct().ToList();
            foreach (var item in names)
            {
                Console.WriteLine(item); 
            }
        }
    }
}
