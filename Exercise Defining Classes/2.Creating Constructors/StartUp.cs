using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person person = new Person();
            Person person1 = new Person(2);
            Person person2 = new Person("az", 5);

            Console.WriteLine($"{person2.Age}, {person2.Name}");
        }
    }
}
