using System;

namespace _2._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] rowCol = Console.ReadLine().Split(", ");
            int rows = int.Parse(rowCol[0]);
            int cols = int.Parse(rowCol[1]);
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string[] strings = Console.ReadLine().Split(" ");
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(strings[j]);
                }
            }
            for (int j = 0; j < cols; j++)
            {
                int sum = 0;
                for (int i = 0; i < rows; i++)
                {
                    sum += matrix[i, j];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
