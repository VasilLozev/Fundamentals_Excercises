using System;

namespace _1._Diagonal_Differenc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < n; i++)
            {
                string[] x = Console.ReadLine().Split(" ");
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = Convert.ToInt32(x[j]);
                    if (i == j)
                    {
                        sum1 += matrix[i, j];
                    }
                    
                }
                sum2 += matrix[i, n - 1 - i];
            }
           
            Console.WriteLine(Math.Abs(sum1-sum2));
        }
    }
}
