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
            int[] stationLiters = new int[N];
            int[] stationDistances = new int[N];
            for (int i = 0; i <= N - 1; i++)
            {
                string[] pairs = Console.ReadLine().Split(' ');
                stationLiters[i] = int.Parse(pairs[0]);
                stationDistances[i] = int.Parse(pairs[1]);
            }
            for (int i = 0; i < N; i++)
            {
                int currentFuel = 0;
                bool isPossible = true;
                for (int j = i; j < N; j++)
                {
                    currentFuel += stationLiters[j];
                    currentFuel -= stationDistances[j];
                    if (currentFuel < 0)
                    {
                        isPossible = false;
                        break;
                    }
                }
                if (isPossible)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
        }
    }
}