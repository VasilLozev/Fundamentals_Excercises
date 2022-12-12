using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renovators
{
    public class StartUp
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[][] matrix = new char[size][];
            int Row = 0;
            int Col = 0;
            int countOfHoles = 1;
            int countOfRods = 0;
            string command = "";
            for (int i = 0; i < size; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i][j] == 'V')
                    {
                        Row = i;
                        Col = j;
                        matrix[i][j] = '*';

                    }
                }
            }

            while (true)
            {
                command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                var item = Move(size, countOfRods, countOfHoles, command, matrix, Row, Col);
                matrix = item.Item1;
                Row = item.row;
                Col = item.col;
                countOfHoles = item.countOfHoles;
                countOfRods = item.countOfRods;
                foreach (var rows in matrix)
                {
                    if (rows.Contains('E'))
                    {
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
                        foreach (var items in matrix)
                        {
                            Console.WriteLine(items);
                        }
                        return;
                    }
                }
            }
            if (command == "End")
            {
                Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {countOfRods} rod(s).");
                matrix[Row][Col] = 'V';
                foreach (var rows in matrix)
                {
                    Console.WriteLine(rows);
                }
                return;
            }
        }
        public static (char[][], int countOfRods, int countOfHoles, int row, int col) Move(int size, int countOfRods, int countOfHoles, string command, char[][] matrix, int row, int col)
        {
            int Row = row;
            int Col = col;
            switch (command)
            {
                case ("up"):
                    row--;
                    break;
                case ("down"):
                    row++;
                    break;
                case ("left"):
                    col--;
                    break;
                case ("right"):
                    col++;
                    break;
            }
            if (row >= size || row < 0)
            {
                row = Row;
                col = Col;
                return (matrix, countOfRods, countOfHoles, row, col);
            }
            if (col >= size || col < 0)
            {
                row = Row;
                col = Col;
                return (matrix, countOfRods, countOfHoles, row, col);
            }
            if (matrix[row][col] == 'R')
            {
                row = Row;
                col = Col;
                countOfRods++;

                Console.WriteLine("Vanko hit a rod!");
                return (matrix, countOfRods, countOfHoles, row, col);
            }
            if (matrix[row][col] == 'C')
            {
                matrix[row][col] = 'E';
                countOfHoles++;
                return (matrix, countOfRods, countOfHoles, row, col);
            }
            if (matrix[row][col] == '*')
            {
                Console.WriteLine($"The wall is already destroyed at position [{row}, {col}]!");
                return (matrix, countOfRods, countOfHoles, row, col);
            }
            else
            {
                matrix[row][col] = '*';
                countOfHoles++;
            }
            return (matrix, countOfRods, countOfHoles, row, col);
        }
    }
}
