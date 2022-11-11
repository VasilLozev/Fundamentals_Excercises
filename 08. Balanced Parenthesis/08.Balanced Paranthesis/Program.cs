using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> brackets = new Stack<char>();
            string input = Console.ReadLine();
            try
            {
                foreach (var item in input)
                {
                    switch (item)
                    {
                        case '(':
                        case '[':
                        case '{':
                            brackets.Push(item);
                            break;
                        case ')':
                            if (brackets.Pop() != '(')
                            {
                                Console.WriteLine("NO");
                                return
                                ;
                            }
                            break;
                        case ']':
                            if (brackets.Pop() != '[')
                            {
                                Console.WriteLine("NO");
                                return
                                ;
                            }
                            break;
                        case '}':
                            if (brackets.Pop() != '{')
                            {
                                Console.WriteLine("NO");
                                return
                                ;
                            }
                            break;
                    }
                }
            }
            catch  (System.Exception ex)
            {
                Console.WriteLine("NO" );
                return;
            }

            if (brackets.Count > 0)
            {
                Console.WriteLine("NO");
            }
            else
                Console.WriteLine("YES");
        }
    }
}
