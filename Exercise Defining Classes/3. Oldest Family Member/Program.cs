using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < N; i++)
            {
                string[] person = Console.ReadLine().Split(' ');
                family.AddMember(new Person(person[0], int.Parse(person[1])));
            }
            Person oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
