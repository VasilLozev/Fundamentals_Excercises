using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> min = numbers =>
            {
                int min = int.MaxValue;

                foreach (var number in numbers)
                {
                    if (number < min)
                    {
                        min = number;
                    }
                }

                return min;
            };
            
            Console.WriteLine(min(numbers));
         }
    } 
}
