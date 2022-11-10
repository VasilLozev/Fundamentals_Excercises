using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            string[,] array = new string[int.Parse(input[0]), int.Parse(input[1])];
            for (int i = 0; i < int.Parse(input[0]); i++)
            {
                string[] input1 = Console.ReadLine().Split(" ");
                for (int j = 0; j < int.Parse(input[1]); j++)
                {
                    array[i,j] = input1[j];
                }
            }
            while (true)
            {
                string[] input3 = Console.ReadLine().Split(' ');
                if (input3[0] == "END")
                {
                    break;
                }
                if (input3.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                if (input3[0] != "swap" )
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                if (int.Parse(input3[1]) >= int.Parse(input[0]) ||
                    int.Parse(input3[3]) >= int.Parse(input[0]) ||
                    int.Parse(input3[2]) >= int.Parse(input[1]) ||
                    int.Parse(input3[4]) >= int.Parse(input[1]))
                    {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                else
                {
                    string x = array[int.Parse(input3[1]), int.Parse(input3[2])];
                    array[int.Parse(input3[1]), int.Parse(input3[2])] = array[int.Parse(input3[3]), int.Parse(input3[4])];
                    array[int.Parse(input3[3]), int.Parse(input3[4])] = x;
                    for (int i = 0; i < int.Parse(input[0]); i++)
                    {
                        for (int j = 0; j < int.Parse(input[1]); j++)
                        {
                            Console.Write(array[i,j] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                
            }
        }
    }
}
