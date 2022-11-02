using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _9._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string string1 = "";
            
            Stack<string> stack = new Stack<string>();
            stack.Push(string1);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ");
                if (command[0] == "1")
                {
                    stack.Push(string1);
                    for (int x = 1; x < command.Length; x++)
                    {
                        string1 += (command[x]);
                    }
                }
                if (command[0] == "2")
                {
                    stack.Push(string1);
                    string newString = "";
                    for (int j = 0; j < string1.Length - Convert.ToInt32(command[1]); j++)
                    {
                        newString += string1[j];
                    }
                    string1 = newString;
                }
                if (command[0] == "3")
                {
                    int count = 0;
                    int x = int.Parse(command[1]);
                    foreach (var item in string1)
                    {
                        count++;
                        if (x == count)
                        {
                            Console.WriteLine(item);
                            break;
                        }
                    }
                }

                if (command[0] == "4")
                {
                    string1 = stack.Pop();
                }
            }
        }
    }
}
