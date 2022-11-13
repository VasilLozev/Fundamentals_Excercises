using System;
using System.Collections.Generic;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            List<string[]> input = new List<string[]>();

            for (int i = 0; i < N; i++)
            {
                string[] x = Console.ReadLine().Split(" ");
                input.Add(x);
            }
            for (int i = 0; i < N-1; i++)
            {
                if (input[i].Length == input[i+1].Length)
                {
                    for (int j = 0; j < input[i].Length; j++)
                    {
                        input[i][j] = (int.Parse(input[i][j]) * 2).ToString();
                        input[i + 1][j] = (int.Parse(input[i + 1][j]) * 2).ToString();
                    }
                }
                else
                {
                    for (int j = 0; j < input[i].Length; j++)
                    {
                        input[i][j] = (int.Parse(input[i][j]) / 2).ToString();
                    }
                    for (int j = 0; j < input[i + 1].Length; j++)
                    { 
                        input[i + 1][j] = (int.Parse(input[i + 1][j]) / 2).ToString();
                    }
                }
            }
            while (true)
            {
                string[] command = Console.ReadLine().Split(" ");
                if (command[0] == "End" )
                {
                    break;
                }
                if (command[0] == "Add")
                {
                    for (int i = 0; i < N; i++)
                    {
                        if (int.Parse(command[1]) == i)
                        {
                            for (int j = 0; j < input[i].Length; j++)
                            {
                                if (int.Parse(command[2]) == j)
                                {
                                    input[i][j] = (int.Parse(input[i][j]) + int.Parse(command[3])).ToString();
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                if (command[0] == "Subtract")
                {
                    for (int i = 0; i < N; i++)
                    {
                        if (int.Parse(command[1]) == i)
                        {
                            for (int j = 0; j < input[i].Length; j++)
                            {
                                if (int.Parse(command[2]) == j)
                                {
                                    input[i][j] = (int.Parse(input[i][j]) - int.Parse(command[3])).ToString();
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(String.Join(" ", input[i]));
            }
        }
    }
}
