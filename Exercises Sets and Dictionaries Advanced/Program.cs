using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _6._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string color = "";
                List<string> x = new List<string>();
                string input = string.Format($"{color} ->  + {x = Console.ReadLine().Split(",").ToList()}");
                input = Console.ReadLine();
                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }
                foreach (var item in x)
                {
                    if (!clothes[color].ContainsKey(item))
                    {
                        clothes[color].Add(item, 0);
                    }
                    clothes[color][item]++;
                }
            }
            string[] input2 = Console.ReadLine().Split(" ");
            string colorSearched = input2[0];
            string clothing = input2[1];

            foreach (var cloth in clothes.Keys)
            {
                foreach (var color in clothes.Values)
                {
                    
                    Console.WriteLine($"{color} clothes:");
                    foreach (var item in color)
                    {
                        if (item.Key == colorSearched)
                        {
                            Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {item} - {item.Value}");
                        }
                    }
                }
            }
        }
    }
}