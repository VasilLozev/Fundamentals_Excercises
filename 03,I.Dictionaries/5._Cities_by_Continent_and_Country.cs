using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _5._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> map =
                   new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                string[] continents = Console.ReadLine().Split(' ');
                if (!map.ContainsKey(continents[0]))
                {
                    map.Add(continents[0], new Dictionary<string, List<string>>());
                }
                if (!map[continents[0]].ContainsKey(continents[1]))
                {
                    map[continents[0]].Add(continents[1],new List<string>());
                }
                map[continents[0]][continents[1]].Add(continents[2]);
            }
            foreach (var continents in map)
            {
                Console.WriteLine($"{continents.Key}:");
                foreach (var countries in continents.Value)
                {
                    Console.WriteLine($" {countries.Key} -> {string.Join(", ",countries.Value)}");
                }
            }
        }
    }
}
