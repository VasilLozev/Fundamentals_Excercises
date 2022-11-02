using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _8._Balanced_Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strings = Console.ReadLine();
            Stack<char> exit = new Stack<char>();
            Queue<char> enter = new Queue<char>();
            int count = 0;
            string[] possibles = { "()", "[]", "{}", ")(", "][", "}{" };
            if (strings.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }
            foreach (var c in strings)
            {
                enter.Enqueue(c);
                exit.Push(c);
                if (c == ' ')
                {
                    count++;
                }
            }
            if (count % 2 != 0)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }
            while (enter.Count > 0)
            {
                char x = enter.Dequeue();
                char y = exit.Pop();


                if (!possibles.Contains(x.ToString() + y.ToString()))
                {
                    Console.WriteLine("NO");
                    Environment.Exit(0);
                }
            }
            Console.WriteLine("YES");
        }
    }
}