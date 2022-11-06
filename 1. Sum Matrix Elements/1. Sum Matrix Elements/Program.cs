using System;

namespace _1._Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] counts = Console.ReadLine().Split(", ");
            int rows = int.Parse(counts[0]);
            int cols = int.Parse(counts[1]);
            int[,] matrix = new int[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                string[] x = Console.ReadLine().Split(", ");
                    for (int j = 0; j < cols; j++)
                    {
                    matrix[i, j] = int.Parse(x[j]);
                    }
                }
           
            Console.WriteLine(rows);
            Console.WriteLine(cols);

            int count = 0;
            foreach (var item in matrix)
            {
                count += item;
            }
            Console.WriteLine(count);
        }
    }
}
