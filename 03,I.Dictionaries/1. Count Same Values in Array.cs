using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace _1._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            double[] numbers = Console.ReadLine()
                             .Split(" ")
                             .Select(double.Parse)
                             .ToArray();

            Dictionary<double, int> numberTimes = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!numberTimes.ContainsKey(number))
                {
                    numberTimes.Add(number, 0);
                }

                numberTimes[number]++;
            }
            foreach (var item in numberTimes)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
