using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            SortedDictionary<string,Person> dict = new SortedDictionary<string, Person>();

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                Person person = new Person(input[0], int.Parse(input[1]));
                dict.Add(person.Name, person);
            }
            foreach (var person in dict.Where(x => x.Value.Age > 30))
            {
                Console.WriteLine($"{person.Value.Name} - {person.Value.Age}");
            }
        }
    }
}
