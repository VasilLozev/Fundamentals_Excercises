using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                         .Split(" ")
                         .Select(n => int.Parse(n))
                         .ToArray();
            char[][] matrix = new char[size[0]][];
            for (int row = 0; row < size[0]; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            char[] commands = Console.ReadLine().ToCharArray();

            for (int i = 0; i < commands.Length; i++)
            {
                int[] PlayerPosition = FindPlayer(matrix, size);
                string result = PlayerMove(PlayerPosition[0], PlayerPosition[1], commands[i], size, matrix);                
                List<int[]> bunnies = FindBunnies(matrix, size);
                result += BunniesSpread(bunnies, matrix, size);
                if (FindPlayer(matrix,size) == null)
                {
                    for (int row = 0; row < size[0]; row++)
                    {
                        for (int col = 0; col < size[1]; col++)
                        {
                            Console.Write(matrix[row][col]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine(result);
                    return;
                }
            }
        }

        static List<int[]> FindBunnies(char[][] matrix, int[] size)
        {
            List<int[]> bunniesPositions = new List<int[]>();
            for (int row = 0; row < size[0]; row++)
            {
                for (int col = 0; col < size[1]; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        bunniesPositions.Add(new int[2] {row, col}); 
                    }
                }
            }
            return bunniesPositions;
        }

        static string BunniesSpread(List<int[]> bunnies, char[][] matrix, int[] size)
        {
            string result = "";
            for (int i = 0; i < bunnies.Count; i++)
            {
                int row = bunnies[i][0];
                int col = bunnies[i][1];
                //spread left
                if (isCellValid(row, col - 1, size))
                {
                    if (matrix[row][col - 1] == 'P')
                    {
                        matrix[row][col - 1] = 'B';
                        result = $"dead: {row} {col - 1}";
                    }
                    matrix[row][col - 1] = 'B';
                }

                if (isCellValid(row, col + 1, size))
                {
                    if (matrix[row][col + 1] == 'P')
                    {
                        matrix[row][col + 1] = 'B';
                        result = $"dead: {row} {col + 1}";
                    }
                    matrix[row][col + 1] = 'B';
                }
                if (isCellValid(row - 1, col, size))
                {
                    if (matrix[row - 1][col] == 'P')
                    {
                        matrix[row - 1][col] = 'B';
                        result = $"dead: {row - 1} {col}";
                    }
                    matrix[row - 1][col] = 'B';
                }
                if (isCellValid(row + 1, col, size))
                {
                    if (matrix[row + 1][col] == 'P')
                    {
                        if (matrix[row + 1][col] == 'P')
                        result = $"dead: {row + 1} {col}";
                    }
                    matrix[row + 1][col] = 'B';
                }
            }
            return result;
        }
        static int[] FindPlayer(char[][] matrix, int[] size)
        {
            for (int row = 0; row < size[0]; row++)
            {
                for (int col = 0; col < size[1]; col++)
                {
                    if (matrix[row][col] == 'P')
                    {
                        return new int[2] { row, col };
                    }
                }
            }
            return null;
        }

        static bool isCellValid(int row, int col, int[] size)
        {
            return row >= 0 && col >= 0 && row < size[0] && col < size[1];
        }

        static string PlayerMove(int row, int col, char command, int[] size, char[][] matrix)
        {
            string result = "";
            matrix[row][col] = '.';
            if (command == 'L')
            {
                if (isCellValid(row, col - 1, size))
                {
                    if (matrix[row][col - 1] == 'B')
                    {
                        result = $"dead: {row} {col - 1}";
                    }
                    else
                    {
                        matrix[row][col - 1] = 'P';
                    }
                }
                else
                {
                    result = $"won: {row} {col}";
                }
            }
            if (command == 'R')
            {
                if (isCellValid(row, col + 1, size))
                {
                    if (matrix[row][col + 1] == 'B')
                    {
                        result = $"dead: {row} {col + 1}";
                    }
                    else
                    {
                        matrix[row][col + 1] = 'P';
                    }
                }
                else
                {
                    result = $"won: {row} {col}";
                }
            }
            if (command == 'U')
            {
                if (isCellValid(row - 1, col, size))
                {
                    if (matrix[row - 1][col] == 'B')
                    {
                        result = $"dead: {row - 1} {col}";
                    }
                    else
                    {
                        matrix[row - 1][col] = 'P';
                    }
                }
                else
                {
                    result = $"won: {row} {col}";
                }
            }
            if (command == 'D')
            {
                if (isCellValid(row + 1, col, size))
                {
                    if (matrix[row + 1][col] == 'B')
                    {
                        result = $"dead: {row + 1} {col}";
                    }
                    else
                    {
                        matrix[row + 1][col] = 'P';
                    }
                }
                else
                {
                    result = $"won: {row} {col}";
                }
            }
            return result;
        }
    }
}
