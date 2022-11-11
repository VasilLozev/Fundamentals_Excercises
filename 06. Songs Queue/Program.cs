using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(", ");
            Queue<string> songs = new Queue<string>(strings.Distinct());

            while (songs.Count > 0)
            {
                string command = Console.ReadLine();
                if (command == "Play")
                {
                    songs.Dequeue();
                    continue;
                }
                if (command.Contains("Add"))
                {
                    string[] x = command.Split(" ", 2);
                    if (songs.Contains(x[1]))
                    {
                        Console.WriteLine($"{x[1]} is already contained!");
                        continue;
                    }
                    songs.Enqueue(x[1]);
                }
                if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs.ToArray()));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
