using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises: Sets and Dictionaries Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> names = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                if (!names.ContainsKey(name))
                {
                    names.Add(name, i);
                }
            }
            foreach (var name in names)
            {
                Console.WriteLine(name.Key);
            }
        }
    }
}
