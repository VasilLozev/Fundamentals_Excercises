using System;

namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(" ");
            int row = int.Parse(strings[0]);
            int col = int.Parse(strings[1]);
            string[,] matrix = new string[row, col];
            int count = 0;
            for (int i = 0; i < row; i++)
            {
                string[] elements = Console.ReadLine().Split(" ");
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = elements[j];
                }

            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (i > 0 && j > 0)
                    {
                        if (matrix[i, j] == matrix[i - 1, j])
                        {
                            if (matrix[i, j - 1] == matrix[i - 1, j - 1])
                            {
                                if (matrix[i, j - 1] == matrix[i, j])
                                {
                                    count++;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
