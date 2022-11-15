using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine().Split(' ');

            string[,] matrix = new string[size, size];

            for (int row = 0; row < size; row++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int[] tmp = FindStart(size, matrix);
            int startRow = tmp[0], startCol = tmp[1];
            for (int i = 0; i < commands.Length; i++)
            {
               int [] endPositions = CommandMove(startRow, startCol, size, commands[i], matrix);
               startRow = endPositions[0];
               startCol = endPositions[1];
                if (!HasCoal(matrix, size))
                {
                    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                    return;
                }
            }
            int remainingCoals = 0;
            
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row,col] == "c")
                    {
                        remainingCoals ++;
                    }
                }
            }
            Console.WriteLine($"{remainingCoals} coals left. ({startRow}, {startCol})");  
        }

        private static int[] CommandMove(int row, int col, int size, string command, string[,] matrix)
        {
            
            switch (command)
            {
                case "left":
                    if (!fieldIsAvailable(row, col - 1, size))
                    {
                        break;
                    }
                    
                    switch (matrix[row, col - 1])
                    {
                    case "c":
                        matrix[row, col - 1] = "*";                       
                        break;
                    case "s":
                        break;
                    case "*":
                        break;
                    case "e":
                        Console.WriteLine($"Game over! ({row}, {col - 1})");
                        Environment.Exit(0);
                        break;
                    }
                col--;
                break;
                case "right":
                    if (fieldIsAvailable(row, col + 1, size))
                    {
                        switch (matrix[row, col + 1])
                        {
                            case "c":
                                matrix[row, col + 1] = "*";
                                break;
                            case "s":
                                break;
                            case "*":
                                break;
                            case "e":
                                Console.WriteLine($"Game over! ({row}, {col + 1})");
                                Environment.Exit(0);
                                break;
                        }
                        col++;
                    }
                    else
                    {
                        break;
                    }
                    break;
                case "up":
                    if (!fieldIsAvailable(row - 1, col, size))
                    {
                        break;
                    }
                    switch (matrix[row - 1, col])
                    {
                        case "c":
                            matrix[row - 1, col] = "*";
                            break;
                        case "s":
                            break;
                        case "*":
                            break;
                        case "e":
                            Console.WriteLine($"Game over! ({row - 1}, {col})");
                            Environment.Exit(0);
                            break;
                    }
                    row--;
                    break;

                case "down":
                    if (!fieldIsAvailable(row + 1, col, size))
                    {
                        break;
                    }
                    switch (matrix[row + 1, col])
                    {
                        case "c":
                            matrix[row + 1, col] = "*";
                            break;
                        case "s":
                            break;
                        case "*":
                            break;
                        case "e":
                            Console.WriteLine($"Game over! ({row + 1}, {col})");
                            Environment.Exit(0);
                            break;
                    }
                    row++;
                    break;
            }
            return new int[2] { row, col };
        }

        static bool fieldIsAvailable(int row, int col, int size)
        {
            return row >= 0 && col >= 0 && row < size && col < size; 
        }
        static int[] FindStart(int size, string[,] matrix)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i,j] == "s")
                    {
                        return new int[2] { i, j };
                    }
                }
            }
            return null;
        }
        static bool HasCoal(string[,]  matrix, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == "c")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
