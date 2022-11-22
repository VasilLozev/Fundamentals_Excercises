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

            Dictionary<string, Dictionary<string, int>> ClothesByColor = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                string color = tokens[0];

                if (!ClothesByColor.ContainsKey(color))           
                {
                    ClothesByColor[color] = new Dictionary<string, int>();
                }
                for (int j = 1; j < tokens.Length; j++)
                {
                    string currentClothing = tokens[j];
                                                                        
                    if (!ClothesByColor[color].ContainsKey(currentClothing))
                    {
                        ClothesByColor[color].Add(currentClothing, 0);
                    }

                    ClothesByColor[color][currentClothing]++;
                }
            }

            string[] findParams = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var clothByColor in ClothesByColor)
            {
                Console.WriteLine($"{clothByColor.Key} clothes:");

                foreach (var cloth in clothByColor.Value)
                {
                    string printItem = $"* {cloth.Key} - {cloth.Value}";
                    if (clothByColor.Key == findParams[0] && cloth.Key == findParams[1])
                    {
                        printItem += " (found!)";
                    }

                    Console.WriteLine(printItem);
                }
            }
        }
    }
}