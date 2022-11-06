using System;
using System.Diagnostics.CodeAnalysis;

namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int [,] matrix = new int[n, n];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                string[] strings = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(strings[j]);
                    if (i == j)
                    {
                        sum += matrix[i, j];
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
