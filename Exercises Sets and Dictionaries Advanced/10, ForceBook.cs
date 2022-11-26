using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _10__ForceBook
{
    class Repository
    {
        public HashSet<string> Users = new HashSet<string>();
        public Dictionary<string, HashSet<string>> forceUsers = new Dictionary<string, HashSet<string>>();
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Lumpawaroo")
                {
                    break;
                }
                if (input.Contains("|"))
                {
                    string[] input1 = input.Split(" | ");
                    if (!repository.Users.Contains(input1[1]))
                    {
                        repository.Users.Add(input1[1]);
                        if (!repository.forceUsers.ContainsKey(input1[0]))
                        {
                            repository.forceUsers.Add(input1[0], new HashSet<string>());
                        }
                        repository.forceUsers[input1[0]].Add(input1[1]);
                    }
                }
                else
                {
                    string[] input1 = input.Split(" -> ");
                    if (!repository.forceUsers.ContainsKey(input1[1]))
                    {
                        repository.forceUsers.Add(input1[1], new HashSet<string>());
                    }
                    foreach (var key in repository.forceUsers.Keys)
                    {
                        if (repository.forceUsers[key].Contains(input1[0]))
                        {
                            repository.forceUsers[key].Remove(input1[0]);
                        }
                    }
                    repository.forceUsers[input1[1]].Add(input1[0]);
                    repository.Users.Add(input1[0]);
                    Console.WriteLine($"{input1[0]} joins the {input1[1]} side!");
                }
            }
           
                repository.forceUsers = repository.forceUsers.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var forceSide in repository.forceUsers.Keys)
            {
                if (repository.forceUsers[forceSide].Count != 0)
                {
                    Console.WriteLine($"Side: {forceSide}, Members: {repository.forceUsers[forceSide].Count}");
                    List<string> forceUsers = repository.forceUsers[forceSide]
                        .OrderBy(x => x)
                        .ToList();
                    foreach (var forceUser in forceUsers)
                    {
                        Console.WriteLine($"! {forceUser}");
                    }
                }
            }
        }
    }
}
