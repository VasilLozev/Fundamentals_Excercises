using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace _9.SoftUni_Exam_Results
{
    class Language
    {
        public string Name { get; set; }
        public string Points { get; set; }
        public Language(string name, string points)
        {
            Name = name;
            Points = points;
        }
    }

    class LanguageSubmissions
    {
        public string Language { get; set; }
        public int Submissions { get; set; }
    }

    class Repository
    {
        public Dictionary<string, Dictionary<Language, int>> UsernameResults { get; set; }

        public Dictionary<string, int> TotalLanguageSubmissions { get; set; }
        
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();
            repository.UsernameResults = new Dictionary<string, Dictionary<Language, int>>();
            repository.TotalLanguageSubmissions = new Dictionary<string, int>();
            while (true)
            {
                string read = Console.ReadLine();
                if (read == "exam finished")
                {
                    break;
                }

                string[] input = read.Split('-');
                string username = input[0];
                string language = input[1];
                if (language == "banned")
                {
                    repository.UsernameResults.Remove(username);
                }
                else
                {
                    string points = input[2];
                    Language newLanguage = new Language(language, points);
                    if (!repository.TotalLanguageSubmissions.ContainsKey(language))
                    {
                        repository.TotalLanguageSubmissions.Add(language, 0);
                    }
                    repository.TotalLanguageSubmissions[language]++;
                    if (!repository.UsernameResults.ContainsKey(username))
                    {
                        repository.UsernameResults.Add(username, new Dictionary<Language, int>());
                    }
                    repository.UsernameResults[username].Add(newLanguage,int.Parse(points));
                }
            }
            repository.UsernameResults = repository.UsernameResults
                .OrderByDescending(x => x.Value.Values.Max()).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Results:");                                                          
            foreach (var username in repository.UsernameResults.Keys)
            {
                Dictionary<Language, int> results = repository.UsernameResults[username]
                   .OrderByDescending(x => x.Value).ToDictionary(x=>x.Key,x=>x.Value);
                        
                Console.WriteLine($"{username} | {repository.UsernameResults[username].Values.Max()}");
                 
            }
            repository.TotalLanguageSubmissions = repository.TotalLanguageSubmissions
                .OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Submissions:");
            foreach (var language in repository.TotalLanguageSubmissions)
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
