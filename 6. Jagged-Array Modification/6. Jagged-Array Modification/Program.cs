using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            List<string[]> matrix = new List<string[]>();
            for (int i = 0; i < rows; i++)
            {
                string[] string1 = Console.ReadLine().Split(" ");
                matrix.Add(string1);
            }
            string command = "";
            while (command != "END")
            {
                while (true)
                {
                    string[] string1 = Console.ReadLine().Split(" ");

                    if (string1[0] == "END")
                    {
                        command = "END";
                        foreach (var item in matrix)
                        {
                            foreach (var x in item)
                            {
                                Console.Write(x + " ");
                            }
                            Console.WriteLine();
                        }
                        break;
                    }
                    int row = int.Parse(string1[1]);
                    int col = int.Parse(string1[2]);
                    int value = int.Parse(string1[3]);
                    if (string1[0] == "Subtract" || string1[0] == "Add")
                    {
                        if (row < 0)
                        {
                            Console.WriteLine("Invalid coordinates");
                            break;
                        }
                        if (col < 0)
                        {
                            Console.WriteLine("Invalid coordinates");
                            break;
                        }
                        if (row > rows - 1 || col > matrix[row].Count() - 1)
                        {
                            Console.WriteLine("Invalid coordinates");
                            break;
                        }
                        else if (row > rows - 1 && col > matrix[row].Length - 1)
                        {
                            Console.WriteLine("Invalid coordinates");
                            break;
                        }
                        else if (string1[0] == "Subtract" && row <= rows - 1 && col <= matrix[row].Length - 1)
                        {
                            string num = matrix[row].ElementAt(col).ToString();
                            int num1 = int.Parse(num) - value;
                            matrix[row][col] = num1.ToString();
                        }
                        else if (string1[0] == "Add" && row <= rows - 1 && col <= matrix[row].Length - 1)
                        {
                            string num = matrix[row][col].ToString();
                            int num1 = int.Parse(num) + value;
                            matrix[row][col] = num1.ToString();
                        }
                    }
                }
            }
        }
    }
}
