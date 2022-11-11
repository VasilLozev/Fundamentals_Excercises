using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            char[,] output = new char[int.Parse(input[0]), int.Parse(input[1])];
            string name = Console.ReadLine();

            for (int i = 0; i < int.Parse(input[0]); i++)
            {
                if (i % 2 == 0)
                {
                    if (i != 0)
                    {
                        for (int j = int.Parse(input[1]) - i + 1; j <= int.Parse(input[1]); j++)
                        {
                            output[i, j-1] = name[j];
                            Console.Write(output[i, j-1]);
                        }
                    }
                    for (int j = 0; j < int.Parse(input[1]) - i; j++)
                    {
                        output[i, j] = name[j];
                        Console.Write(output[i, j]);
                    }
                    
                }
                if (i % 2 != 0)
                {
                    for (int j = int.Parse(input[1]) - 1 - i; j >= 0; j--)
                    {
                        output[i, j] = name[j];
                        Console.Write(output[i, j]);
                    }
                    for (int x = int.Parse(input[1]); x > int.Parse(input[1]) - i; x--)
                    {
                        output[i, x - 1] = name[x];
                        Console.Write(output[i, x - 1]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}