using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;

namespace _1._Action_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = (strings) => Console.WriteLine(string.Join(Environment.NewLine,strings));
            string[] strings = Console.ReadLine().Split(' ');

            print(strings);
        }                                                                          
    }
}
