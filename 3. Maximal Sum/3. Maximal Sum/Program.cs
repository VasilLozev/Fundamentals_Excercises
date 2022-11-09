using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(" ");
            int rows = int.Parse(strings[0]);
            int cols = int.Parse(strings[1]);
            int[,] matrix = new int[rows, cols];
            int[,] matrix2 = new int[3, 3];
            Queue<int> ints1 = new Queue<int>();
            for (int i = 0; i < rows; i++)
            {
                string[] ints = Console.ReadLine().Split(" ");
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(ints[j]);
                    if (i >= 2 & j >= 2)
                    {
                        ints1.Enqueue(matrix[i - 2,j-2] + matrix[i - 2,j-1] + matrix[i - 2, j]
                            + matrix[i - 1, j - 2] + matrix[i - 1, j - 1] + matrix[i - 1, j]
                            + matrix[i, j - 2] + matrix[i, j - 1] + matrix[i, j]); 
                    }
                }
            }
            int MaxSum = ints1.Max();
            for (int i = 2; i < rows; i++)
            {
                for (int j = 2; j < cols; j++)
                {
                    if (matrix[i - 2, j - 2] + matrix[i - 2, j - 1] + matrix[i - 2, j]
                            + matrix[i - 1, j - 2] + matrix[i - 1, j - 1] + matrix[i - 1, j]
                            + matrix[i, j - 2] + matrix[i, j - 1] + matrix[i, j] == MaxSum)
                    {
                        Console.WriteLine("Sum = " + MaxSum);
                        for (int z = i - 2; z <= i; z++)
                        {
                            for (int x = j-2; x <= j; x++)
                            {
                                Console.Write(matrix[z, x] + " ");
                            }
                            Console.WriteLine();
                        }
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}
