using System;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            char[,] stringsMatrix = new char[N, N];
           
            for (int i = 0; i < N; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int j = 0; j < N; j++)
                {
                    stringsMatrix[i, j] = row[j];
                }
            }
            char symbol = Console.ReadLine()[0];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (stringsMatrix[i, j] == symbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        Environment.Exit(0);
                    }
                }
            }
            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
