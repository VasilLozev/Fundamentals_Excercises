using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cupCapacity = new Queue<int>();
            string[] capacity1 = Console.ReadLine().Split(" ");
            Stack<int> bottleCapacity = new Stack<int>();
            string[] capacity2 = Console.ReadLine().Split(" ");
            int wastedLittersOfWater = 0;

            foreach (var item in capacity1)
            {
                cupCapacity.Enqueue(int.Parse(item));
            }
            foreach (var item in capacity2)
            {
                bottleCapacity.Push(int.Parse(item));
            }
            int cupCap = 0;
            int bottleCap = 0;
            while (cupCapacity.Count > 0 && bottleCapacity.Count > 0)
            {
                if (cupCap == 0)
                {
                    cupCap = cupCapacity.Peek();
                }
                bottleCap = bottleCapacity.Peek();
                if (bottleCap >= cupCap)
                {
                    bottleCapacity.Pop();
                    cupCapacity.Dequeue();
                  
                    wastedLittersOfWater += bottleCap - cupCap;
                    cupCap = 0;
                }
                if (bottleCap < cupCap)
                {
                    cupCap -= bottleCap;
                    bottleCapacity.Pop();
                }
            }
            if (bottleCapacity.Count > 0)
            {
                Console.Write($"Bottles:");
                while(bottleCapacity.Count > 0)
                {
                    Console.Write(" " + bottleCapacity.Pop());
                }
            }
            if (cupCapacity.Count > 0)
            {
                Console.Write($"Cups:");
                while (cupCapacity.Count > 0)
                {
                    Console.Write(" " + cupCapacity.Dequeue() );
                }
            }
            Console.Write($"\nWasted litters of water: {wastedLittersOfWater}");
        }
    }
}
