using System;
using System.Collections.Generic;

namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[,] numbers = new int[number, number];
            numbers[0, 0] = 1;
            Console.Write(1);
            for (int i = 1; i < number; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0)
                    {
                        numbers[i, j] = 1;
                        Console.Write("\n" + numbers[i, j] + " ");
                    }
                    else if (j == i)
                    {
                        numbers[i, j] = 1;
                        Console.Write(numbers[i, j] + " ");
                    }
                    else
                    {
                        numbers[i, j] = numbers[i - 1, j - 1] + numbers[i - 1, j];
                        Console.Write(numbers[i, j] + " ");
                    }
                }
            }
        }
    }
}
