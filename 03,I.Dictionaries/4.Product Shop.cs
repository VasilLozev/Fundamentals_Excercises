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
            Dictionary<string, Dictionary<string,double>> shops =
                    new Dictionary<string, Dictionary<string, double>>();

                string command = Console.ReadLine();

            while (command != "Revision")
            {
                string[] input = command.Split(", ");
                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string,
                 double>());
                }

                shops[shop].Add(product, price);

                command = Console.ReadLine();
            }
            shops = shops.OrderBy(x => x.Key).ToDictionary(x=> x.Key, x=>x.Value);
            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
