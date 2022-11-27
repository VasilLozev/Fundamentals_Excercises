using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(wordsFilePath))
            {
                    using (StreamReader reader1 = new StreamReader(textFilePath))
                    {
                        using (StreamWriter writer = new StreamWriter(outputFilePath))
                        {
                            while (!reader.EndOfStream)
                            {
                                string[] read = reader1.ReadToEnd().Split(' ', '-', ',', '.');
                                
                            while (!reader.EndOfStream)
                            {
                                string[] words = reader.ReadToEnd().Split(' ');
                                Dictionary<string, int> dict = new Dictionary<string, int>();
                                for (int i = 0; i < words.Length; i++)
                                {
                                    int count = 0;
                                    foreach (var item in read)
                                    {
                                        if (words[i].Equals( item,
                   StringComparison.OrdinalIgnoreCase))
                                        {
                                            count++;
                                        }
                                    }
                                    dict.Add(words[i],count);
                                }
                                dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                                foreach (var key in dict.Keys)
                                {
                                    writer.WriteLine($"{key} - {dict[key]}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}