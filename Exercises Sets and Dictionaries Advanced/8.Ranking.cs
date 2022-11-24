using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _8.Ranking
{
     class Student
    {
        public string Name;
        public int Points;
        public Student(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }
    }

     class Contest
    {
        public string Name;

        public string Password { get; set; }

        public Contest(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }
    }
    class Reposirory
    {
        public Dictionary<string, string> Contests = new Dictionary<string, string>();
        public Dictionary<string, int> Results = new Dictionary<string, int>();
        public Dictionary<string, Dictionary<string, int>> StudentsContests = new 
            Dictionary<string, Dictionary<string, int>>();
        
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string contest = "";
            string password = "";
            string name = "";
            int points = 0;
            Reposirory repository = new Reposirory();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end of contests")
                {
                    break;
                }
                string[] command1 = command.Split(':');
                contest = command1[0];
                password = command1[1];
                Contest contest1 = new Contest(contest, password);
                repository.Contests.Add(contest, password);
            }
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end of submissions")
                {
                    break;
                }
                string[] command1 = command.Split("=>");

                contest = command1[0];
                password = command1[1];
                name = command1[2];
                points = int.Parse(command1[3]);
                Contest contest1 = new Contest(contest, password);
                Student student = new Student(name, points);

                if (repository.Contests.ContainsKey(contest))
                {
                    if (repository.Contests[contest] == password)
                    {
                        if (!repository.StudentsContests.ContainsKey(student.Name))
                        {
                            repository.StudentsContests.Add(student.Name, new Dictionary<string, int>());
                        }
                        if (!repository.Results.ContainsKey(name))
                        {
                            repository.Results.Add(name, 0);
                        }
                        if (!repository.StudentsContests[student.Name].ContainsKey(contest1.Name))
                        {
                            repository.StudentsContests[student.Name].Add(contest1.Name, 0);
                        }
                        if (repository.StudentsContests[student.Name].ContainsKey(contest1.Name))
                        {
                            if (repository.StudentsContests[student.Name][contest1.Name] < points)
                            {
                                repository.Results[name] -= repository.StudentsContests[student.Name][contest1.Name];
                                repository.StudentsContests[student.Name][contest1.Name] = points;
                                repository.Results[name] += points;
                            }
                        }
                    }
                }
            }
            repository.Results = repository.Results.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
             
            Console.WriteLine($"Best candidate is {repository.Results.First().Key} with total" +
                $" {repository.Results.First().Value} points.");
            repository.StudentsContests = repository.StudentsContests.OrderBy(x => x.Key)
                .ToDictionary(x=>x.Key,x=>x.Value);
            Console.WriteLine("Ranking: ");
            foreach (var item in repository.StudentsContests.Keys)
            {
                Console.WriteLine($"{item}");
                Dictionary<string, int> repoCopy = repository.StudentsContests[item].OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x=>x.Value);
                foreach (var contest3 in repoCopy.Keys)
                {
                    Console.WriteLine($"#  {contest3} ->" +
                        $" {repository.StudentsContests[item][contest3]}");
                }
            }
        }
    }
}
