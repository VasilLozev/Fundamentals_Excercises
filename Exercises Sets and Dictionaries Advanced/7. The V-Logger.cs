using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace _7._The_V_Logger
{

    class Vlogger
    {
        public string name;
        public List<string> followers = new List<string>();
        public List<string> following = new List<string>();

        public Vlogger(string name)
        {
            this.name = name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Dictionary<string, Vlogger>();
            while (true)
            {
                string[] command = Console.ReadLine().Split(' ');
                if (command[0] == "Statistics")
                {
                    break;
                }
                if (command[1] == "joined")
                {
                    if (!graph.ContainsKey(command[0]))
                    {
                        graph.Add(command[0], new Vlogger(command[0]));
                    }
                }
                if (command[1] == "followed")
                {
                    string A = command[0];
                    string B = command[2];
                    if (graph.ContainsKey(A))
                    { // New vlogger

                        if (graph.ContainsKey(B))
                        { // New vlogger

                            if (!graph[B].followers.Contains(A))
                            { // New follower
                                if (A != B)
                                {
                                    graph[B].followers.Add(A);
                                    graph[A].following.Add(B);
                                }
                            }
                        }
                    }
                }
            }

            int registeredVloggers = 0;
            int count = 2;

            var graph1 = graph.OrderByDescending(x => x.Value.followers.Count)
                    .ThenBy(x => x.Value.following.Count)
                    .ToDictionary(x=>x.Key, x=>x.Value);
                
            foreach (var vloggers in graph.Keys)
            {
                registeredVloggers++;
            }
            string mostFollowers = graph1.Keys.First();
            Console.WriteLine($"The V-Logger has a total of {registeredVloggers} vloggers in its logs.");
            Console.WriteLine($"1. {mostFollowers} : {graph1[mostFollowers].followers.Count} followers," +
                $" {graph1[mostFollowers].following.Count} following");

            List<string> followers = new List<string>(new List<string>(graph1[mostFollowers].followers.ToList()));
            followers = followers.OrderBy(x => x)
                .ToList();

            foreach (var follower in followers)
            {
                Console.WriteLine($"*  {follower}");
            }
            foreach(var vlogger in graph1.Keys)
            {
                if (vlogger != mostFollowers)
                {
                    Console.WriteLine($"{count}. {graph1[vlogger].name} : {graph1[graph1[vlogger].name].followers.Count} followers, " +
           $"{graph1[graph1[vlogger].name].following.Count} following");
                    count++;
                }
            }
        }
    }
}