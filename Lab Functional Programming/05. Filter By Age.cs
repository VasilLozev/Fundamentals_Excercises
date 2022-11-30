using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace _05._Filter_By_Age
{
    internal class Program
    {
        class Person
        {
            public string name;
            public int age;

            public Person(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
        }
        private static List<Person> ReadPeople()
        {
            return new List<Person>();
        }
   
        
        private static Func<Person, bool> CreateFilter(string condition, int ageThreshold)
            {
                if (condition == "younger")
                {
                    return (person) => person.age < ageThreshold;
                }
                else 
                {
                    return (person) => person.age >= ageThreshold;
                }
            }
        private static Action<Person> CreatePrinter(string format)
        {
            if (format == "name")
            {
                return (person) => Console.WriteLine(person.name);
            }
            else if (format == "age")
            {
                return (person) => Console.WriteLine(person.age);
            }
            else
            {
                return (person) => Console.WriteLine($"{person.name} - { person.age}");
            }
        }
        private static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
        {
            foreach (var item in people)
            {
                if (filter.Invoke(item))
                {
                    printer.Invoke(item);
                }
            }
        }
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<Person> people = ReadPeople();
            for (int i = 0; i < N; i++)
            {
                string[] nameAge = Console.ReadLine().Split(", ");
                Person person = new Person(nameAge[0], int.Parse(nameAge[1]));
                people.Add(person);
            }
            string[] filterAgeThreshold = new string[2];
            for (int i = 0; i < 2; i++)
            {
                filterAgeThreshold[i] = Console.ReadLine();
            }
            Func<Person, bool> filter = CreateFilter(filterAgeThreshold[0], int.Parse(filterAgeThreshold[1]));
            string format = Console.ReadLine();
            Action<Person> printer = CreatePrinter(format);
            PrintFilteredPeople(people, filter, printer);
        }
    }
}
