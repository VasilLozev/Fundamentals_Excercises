using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OddLines
{
    
    public class OddLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\input.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    int row = 0;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (row++ % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
}