using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace _4._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine()
                .Split(", ")
                .Select(x=>Math.Round(double.Parse(x) * 1.2,2))
                .ToArray();
            foreach (var item in prices)
            {
                Console.WriteLine($"{item:f2}");
            }
        }
    }
}
