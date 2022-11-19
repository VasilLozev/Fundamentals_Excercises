using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    public class Program
    {
        static char[][] matrix;
        static int size_x = 0;
        static int size_y = 0;

        static int player_x = 0;
        static int player_y = 0;

        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                         .Split(" ")
                         .Select(n => int.Parse(n))
                         .ToArray();

            size_x = size[0];
            size_y = size[1];
            matrix = new char[size_x][];
            for (int row = 0; row < size_x; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }
            int[] PlayerPosition = FindPlayer();
            player_x = PlayerPosition[0];
            player_y = PlayerPosition[1];
            matrix[player_x][player_y] = '.';

            char[] commands = Console.ReadLine().ToCharArray();

            for (int i = 0; i < commands.Length; i++)
            {
                PlayerMove(commands[i]);
                BunniesSpread();
                PrintMatrix();
                Console.WriteLine();
                if (matrix[player_x][player_y] == 'B')
                {
                    PrintMatrix();
                    Console.WriteLine($"dead: {player_x} {player_y}");
                    return;
                }
                if (!isCellValid(player_x, player_y))
                {
                    PrintMatrix();
                    Console.WriteLine($"won: {player_x} {player_y}");
                    break;
                }
            }
        }

        static void PrintMatrix()
        {
            for (int row = 0; row < size_x; row++)
            {
                for (int col = 0; col < size_y; col++)
                {
                    if (player_x == row && player_y == col && matrix[player_x][player_y] != 'B')
                    {
                        Console.Write("P");
                        continue;
                    }
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }
        
        static void BunniesSpread()
        {
            char[][] matrixCopy = (char[][])matrix.Clone();
            for (int row = 0; row < size_x; row++)
            {
                for (int col = 0; col < size_y; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        //spread left
                        if (isCellValid(row, col - 1))
                        {
                            matrixCopy[row][col - 1] = 'B';
                        }
                        // right
                        if (isCellValid(row, col + 1))
                        {
                            matrixCopy[row][col + 1] = 'B';
                        }
                        // up
                        if (isCellValid(row - 1, col))
                        {
                            matrixCopy[row - 1][col] = 'B';
                        }
                        // down
                        if (isCellValid(row + 1, col))
                        {
                            matrixCopy[row + 1][col] = 'B';
                        }
                    }
                }
            }
            matrix = matrixCopy;
        }

        static int[] FindPlayer()
        {
            for (int row = 0; row < size_x; row++)
            {
                for (int col = 0; col < size_y; col++)
                {
                    if (matrix[row][col] == 'P')
                    {
                        return new int[2] { row, col };
                    }
                }
            }
            return null;
        }

        static bool isCellValid(int row, int col)
        {
            return row >= 0 && col >= 0 && row < size_x && col < size_y;
        }

        static void PlayerMove(char command)
        {
            if (command == 'L')
            {
                player_x -= 1;
            }
            else if (command == 'R')
            {
                player_x += 1;
            }
            else if (command == 'U')
            {
                player_y -= 1;
            }
            else if (command == 'D')
            {
                player_y += 1;
            }
        }
    }
}
