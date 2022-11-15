using System;
using System.Data;
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

            int[] endPositions = new int[2];

            for (int row = 0; row < size; row++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int startRow = FindStartRow(size, matrix);
            int startCol = FindStartCol(size, matrix);
            for (int i = 0; i < commands.Length; i++)
            {
               endPositions = CommandMove(startRow, startCol, size, commands[i], matrix);
               startRow = endPositions[0];
               startCol = endPositions[1];
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
            int coal = 0;
            
            switch (command)
            {
                case "left":
                    if (fieldIsAvailable(row, col - 1, size))
                    {
                        switch (matrix[row, col - 1])
                        {
                            case "c":
                                coal++;
                                matrix[row, col - 1] = "*";
                                int coalCount = 0;
                                for (int i = 0; i < size; i++)
                                {
                                    for (int j = 0; j < size; j++)
                                    {
                                        if (matrix[i,j] == "c")
                                        {
                                            coalCount++;
                                        }
                                    }
                                }
                                if (coalCount == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({row}, {col - 1})");
                                    Environment.Exit(0);
                                    break;  
                                }
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
                    }
                    else
                    {
                        break;
                    }
                    break;
                case "right":
                    if (fieldIsAvailable(row, col + 1, size))
                    {
                        switch (matrix[row, col + 1])
                        {
                            case "c":
                                coal++;
                                matrix[row, col + 1] = "*";
                                int coalCount = 0;
                                for (int i = 0; i < size; i++)
                                {
                                    for (int j = 0; j < size; j++)
                                    {
                                        if (matrix[i, j] == "c")
                                        {
                                            coalCount++;
                                        }
                                    }
                                }
                                if (coalCount == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({row}, {col + 1})");
                                    Environment.Exit(0);
                                    break;
                                }
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
                    if (fieldIsAvailable(row - 1, col, size))
                    {
                        switch (matrix[row - 1, col])
                        {
                            case "c":
                                coal++;
                                matrix[row - 1, col] = "*";
                                int coalCount = 0;
                                for (int i = 0; i < size; i++)
                                {
                                    for (int j = 0; j < size; j++)
                                    {
                                        if (matrix[i, j] == "c")
                                        {
                                            coalCount++;
                                        }
                                    }
                                }
                                if (coalCount == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({row - 1}, {col})");
                                    Environment.Exit(0);
                                    break;
                                }
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
                    }
                    else
                    {
                        break;
                    }
                    break;
                case "down":
                    if (fieldIsAvailable(row + 1, col, size))
                    {
                        switch (matrix[row + 1, col])
                        {
                            case "c":
                                coal++;
                                matrix[row + 1, col] = "*";
                                int coalCount = 0;
                                for (int i = 0; i < size; i++)
                                {
                                    for (int j = 0; j < size; j++)
                                    {
                                        if (matrix[i, j] == "c")
                                        {
                                            coalCount++;
                                        }
                                    }
                                }
                                if (coalCount == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({row + 1}, {col})");
                                    Environment.Exit(0);
                                    break;
                                }
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
                    }
                    else
                    {
                        break;
                    }
                    break;
            }
            int[] endPositions = new int[2];
            endPositions[0] = row;
            endPositions[1] = col;

            return endPositions;
        }

            static bool fieldIsAvailable(int row, int col, int size)
        {
            return row > 0 && col > 0 && row < size && col < size; 
        }
        static int FindStartRow(int size, string[,] matrix)
        {
            int startRow = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i,j] == "s")
                    {
                        startRow = i;
                    }
                }
            }
            return startRow;
        }
        static int FindStartCol(int size, string[,] matrix)
        {
            int startCol = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == "s")
                    {
                        startCol = j;
                    }
                }
            }
            return startCol;
        }

    }
}
