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
            HashSet<string> names = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                names.Add(Console.ReadLine());
            }
            Console.WriteLine(string.Join('\n', names));
        }
    }
}
