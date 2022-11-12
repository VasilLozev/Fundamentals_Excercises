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
            Stack<char> stack = new Stack<char>(name);
            Queue<char> queue = new Queue<char>(name);
            for (int i = 0; i < int.Parse(input[0]); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < int.Parse(input[1]); j++)
                    {
                        output[i, j] = queue.Dequeue();
                        if (queue.Count == 0)
                        {
                            queue = new Queue<char>(name);
                        }
                    }
                }
                if (i % 2 != 0)
                {
                    for (int j = int.Parse(input[1]) - 1; j >= 0; j--)
                    {
                        if (queue.Count == 0)
                        {
                            queue = new Queue<char>(name);
                        }
                        output[i, j] = queue.Dequeue();
                    }
                }
                for (int j = 0; j < int.Parse(input[1]); j++)
                {
                    Console.Write(output[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}