﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> studentRecord = new Dictionary<string, List<double>>();
            for (int i = 0; i < x; i++)
            {
                string[] nameGrade = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (!studentRecord.ContainsKey(nameGrade[0]))
                {
                    studentRecord.Add(nameGrade[0], new List<double>());
                }
                studentRecord[nameGrade[0]].Add(double.Parse(nameGrade[1]));
            }
            foreach (var item in studentRecord)
            {
                Console.WriteLine($"{item.Key} -> {string.Join(" ", item.Value.ToArray().Select(n => Math.Round(n, 2).ToString("N2")))} (avg: {Math.Round(item.Value.Average(), 2).ToString("N2")})");
            }
        }
    }
}
 
