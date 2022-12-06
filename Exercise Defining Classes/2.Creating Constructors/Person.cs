using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public string Name { get { return name; } set { value = name; } }
        public int Age { get { return age; } set { value = age; } }
        public Person()
        {
            this.name = "No name";
            this.age = 1;
        }
        public Person(int age) :this()
        {
            this.age = age;
        }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
}
