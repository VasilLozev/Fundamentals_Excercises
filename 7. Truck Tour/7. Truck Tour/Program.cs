using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Transactions;

namespace _7._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Stack<int> fuel = new Stack<int>();
            Stack<int> kilometers = new Stack<int>();
            Queue<int> lastPos = new Queue<int>();
            int currentFuel = 0;
            int currentKilometers = 0;
            for (int i = 0; i <= N - 1; i++)
            {
                string[] pairs = Console.ReadLine().Split(' ');
                fuel.Push(int.Parse(pairs[0]));
                kilometers.Push(int.Parse(pairs[1]));
                currentFuel += fuel.Pop();
                currentKilometers += kilometers.Pop();
                if (currentFuel >= currentKilometers)
                {
                    lastPos.Enqueue(i);
                }
                else
                {
                    lastPos.Clear();
                    currentFuel = 0;
                    currentKilometers = 0;
                }
            }
            Console.WriteLine(lastPos.Dequeue());
        }
    }
}
