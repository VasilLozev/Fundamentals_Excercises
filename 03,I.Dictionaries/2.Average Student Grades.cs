using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> studentGrades = new
              Dictionary<string, List<decimal>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                decimal grade = decimal.Parse(input[1]);
                if (!studentGrades.ContainsKey(name))
                {
                    studentGrades.Add(name, new List<decimal>());
                }
                studentGrades[name].Add(grade);
            }
            foreach (KeyValuePair<string,List<decimal>> item in
                studentGrades)
            {
                Console.Write($"{item.Key} -> ");

                foreach (decimal grade in item.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {item.Value.Average():f2})");
            }
        }
    }
}
