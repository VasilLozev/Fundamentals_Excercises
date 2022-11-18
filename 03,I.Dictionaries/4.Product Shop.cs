using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

namespace _4__Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string,double>> FoodShops =
                    new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(", ");

                if (input[0] == "Revision")
                {
                    break;
                }

                if (!FoodShops.ContainsKey(input[0]))
                {
                    FoodShops.Add(input[0], new Dictionary<string, double>());
                }
                FoodShops[input[0]].Add(input[1], double.Parse(input[2]));
                FoodShops = FoodShops.OrderBy(x=>x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

            }
            foreach (var item in FoodShops)
            {
                Console.WriteLine($"{item.Key}->");
                foreach (var product in item.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
