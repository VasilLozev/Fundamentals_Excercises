using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace _8.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] numbers = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(n => int.Parse(n))
                        .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int sum = 0;
            int aliveCells = 0;
            string[] inputs = Console.ReadLine().Split(' ');
            foreach (string item in inputs)
            {
                int[] indexes = item
                        .Split(",", StringSplitOptions.RemoveEmptyEntries)
                        .Select(n => int.Parse(n))
                        .ToArray();

                int row = indexes[0];
                int col = indexes[1];
                BombExplode(row, col, size, matrix);
            }
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (CanExplode(row, col, matrix))
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: " + sum);
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static int BombExplode(int row, int col, int size, int[,] matrix)
        {
            int value = matrix[row, col];
            if (CanExplode(row, col, matrix))
            {
                matrix[row, col] = 0;
                //vertical down-right
                if (CheckIndexValues(row + 1, col + 1, size))
                {
                    matrix[row + 1, col + 1] -= value;

                }
                //vertical down
                if (CheckIndexValues(row + 1, col, size))
                {
                    matrix[row + 1, col] -= value;

                }
                //vertical down-left
                if (CheckIndexValues(row + 1, col - 1, size))
                {
                    matrix[row + 1, col - 1] -= value;

                }
                //vertical up-right
                if (CheckIndexValues(row - 1, col + 1, size))
                {
                    matrix[row - 1, col + 1] -= value;

                }
                //vertical up
                if (CheckIndexValues(row - 1, col, size))
                {
                    matrix[row - 1, col] -= value;

                }
                //vertical up-left
                if (CheckIndexValues(row - 1, col - 1, size))
                {
                    matrix[row - 1, col - 1] -= value;

                }
                //horizont right
                if (CheckIndexValues(row, col + 1, size))
                {
                    matrix[row, col + 1] -= value;

                }
                //horizont left
                if (CheckIndexValues(row, col - 1, size))
                {
                    matrix[row, col - 1] -= value;
                }
            }
            return value;
        }

        static bool CheckIndexValues(int row, int col, int size)
        {
            return row >= 0 && col >= 0 && row < size && col < size;
        }
        static bool CanExplode(int row, int col, int[,] matrix)
        {
            return matrix[row, col] > 0;
        }
    }
}
