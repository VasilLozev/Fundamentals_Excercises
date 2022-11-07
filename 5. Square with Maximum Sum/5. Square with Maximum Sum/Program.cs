using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _5._Square_with_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] rowCol = Console.ReadLine().Split(", ");
            int[,] matrix = new int[int.Parse(rowCol[0]), int.Parse(rowCol[1])];
            Queue<int> sum = new Queue<int>();
            
            for (int i = 0; i < int.Parse(rowCol[0]); i++)
            {
                string[] cols = Console.ReadLine().Split(", ");
                for (int j = 0; j < int.Parse(rowCol[1]); j++)
                {
                  matrix[i, j] = int.Parse(cols[j]);
                }
            }
            for (int i = 0; i < int.Parse(rowCol[0]) - 1; i++)
            {
                for (int j = 0; j < int.Parse(rowCol[1]) - 1; j++)
                {
                    Queue<int> elements = new Queue<int>();
                    elements.Enqueue(matrix[i, j]);
                    elements.Enqueue(matrix[i, j + 1]);
                    elements.Enqueue(matrix[i + 1, j]);
                    elements.Enqueue(matrix[i + 1, j + 1]);
                    if (elements.Sum() > sum.Sum())
                    {
                        sum = elements;
                    }
                }
            }
            int sum3 = sum.Sum();
            while (sum.Count > 2)
            {
                Console.Write(sum.Dequeue() + " ");
            }
            while (sum.Count > 1)
            {
                Console.Write($"\n{sum.Dequeue()} ");
            }
            while (sum.Count > 0)
            {
                Console.Write($"{sum.Dequeue()} \n");
            }
            Console.WriteLine(sum3);
        }
    }
}
  