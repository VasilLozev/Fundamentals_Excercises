using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renovators
{
    public class StartUp
    {
        static void Main()
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            Queue<int> GreyTiles = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            Dictionary<string, int> LocationCatalog = new Dictionary<string, int>();
                
            while (true)
            {
                if (whiteTiles.Peek() == GreyTiles.Peek())
                {
                    int sum = whiteTiles.Peek() + GreyTiles.Peek();
                    switch (sum)
                    {
                        case (40):
                            if (!LocationCatalog.ContainsKey("Sink"))
                            {
                                LocationCatalog.Add("Sink", 0);
                            }
                            LocationCatalog["Sink"]++;
                            whiteTiles.Pop();
                            GreyTiles.Dequeue();
                            break;
                        case (50):
                            if (!LocationCatalog.ContainsKey("Oven"))
                            {
                                LocationCatalog.Add("Oven", 0);
                            }
                            LocationCatalog["Oven"]++;
                            whiteTiles.Pop();
                            GreyTiles.Dequeue();
                            break;
                        case (60):
                            if (!LocationCatalog.ContainsKey("Countertop"))
                            {
                                LocationCatalog.Add("Countertop", 0);
                            }
                            LocationCatalog["Countertop"]++;
                            whiteTiles.Pop();
                            GreyTiles.Dequeue();
                            break;
                        case (70):
                            if (!LocationCatalog.ContainsKey("Wall"))
                            {
                                LocationCatalog.Add("Wall", 0);
                            }
                            LocationCatalog["Wall"]++;
                            whiteTiles.Pop();
                            GreyTiles.Dequeue();
                            break;
                        default:
                            if (!LocationCatalog.ContainsKey("Floor"))
                            {
                                LocationCatalog.Add("Floor", 0);
                            }
                            LocationCatalog["Floor"]++;
                            whiteTiles.Pop();
                            GreyTiles.Dequeue();
                            break;
                    }
                }
                else
                {
                    int halfWhite = whiteTiles.Pop();
                    halfWhite /= 2;
                    whiteTiles.Push(halfWhite);
                    int grey = GreyTiles.Dequeue();
                    GreyTiles.Enqueue(grey);
                }
                if (whiteTiles.Count == 0 && GreyTiles.Count == 0)
                {
                    Console.WriteLine("White tiles left: none");
                    Console.WriteLine("Grey tiles left: none");
                    break;
                }
                else if (whiteTiles.Count == 0 || GreyTiles.Count == 0)
                {
                    if (whiteTiles.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("White tiles left: ");
                        sb.Append(String.Join(", ", whiteTiles));
                        Console.WriteLine(sb.ToString());
                    }
                    else
                    {
                        Console.WriteLine("White tiles left: none");
                    }
                    if (GreyTiles.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("Grey tiles left: ");
                        sb.Append(String.Join(", ", GreyTiles));
                        Console.WriteLine(sb.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Grey tiles left: none");
                    }
                    break;
                }
            }


            LocationCatalog = LocationCatalog.OrderByDescending(x => x.Value).ThenBy(x => x.Key)
                .ToDictionary(x=>x.Key, x=>x.Value);
            foreach (var item in LocationCatalog.Keys)
            {
                Console.WriteLine($"{item}: {LocationCatalog[item]}");
            }
        }
    }
}
