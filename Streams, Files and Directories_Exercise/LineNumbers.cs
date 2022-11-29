namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Xml;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            string[] lines = File.ReadAllLines(inputFilePath);
            
                for (int i = 0; i < lines.Length; i++)
                {
                    int letterCount = lines[i].Count(ch => char.IsLetter(ch));
                    int symbolCount = lines[i].Count(ch => char.IsPunctuation(ch));

                    sb.AppendLine($"Line {i + 1}: -I was quick to judge him, but it wasn't his fault. ({letterCount})({symbolCount})");
                }

                File.WriteAllText(outputFilePath, sb.ToString());
            
        }
    }
}
