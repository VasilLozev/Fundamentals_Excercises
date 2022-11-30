using System;
using System.Linq;

namespace _3._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string read = Console.ReadLine();
            if (read != null)
            {

                string[] words = read
                    .Split(' ')
                    .Where(x => x.StartsWith(char.ToUpper(x.First())))
                    .ToArray();

                foreach (var word in words)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
