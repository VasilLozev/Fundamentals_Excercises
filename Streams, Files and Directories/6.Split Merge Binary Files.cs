using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream image = new FileStream(sourceFilePath, FileMode.Open))
            {
                using (FileStream partOneBytes = new FileStream(partOneFilePath, FileMode.Open))
                {
                    using (FileStream partTwoBytes = new FileStream(partTwoFilePath, FileMode.Open))
                    {
                        byte[] imageBuffer = new byte[image.Length];
                        using (FileStream output1 = new FileStream(partOneFilePath, FileMode.Create))
                        {
                            using (FileStream output2 = new FileStream(partTwoFilePath, FileMode.Create))
                            {
                                for (int i = 0; i < imageBuffer.Length; i++)
                                {
                                    if (i % 2 != 0)
                                    {
                                        output1.Write(new byte[] { imageBuffer[i] });
                                    }
                                    else
                                    {
                                        output2.Write(new byte[] { imageBuffer[i] });
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream joinedFile = new FileStream(joinedFilePath, FileMode.Open))
            {
                using (FileStream partOneBytes = new FileStream(partOneFilePath, FileMode.Open))
                {
                    using (FileStream partTwoBytes = new FileStream(partTwoFilePath, FileMode.Open))
                    {
                        byte[] partOneBuffer = new byte[partOneBytes.Length];
                        byte[] partTwoBuffer = new byte[partTwoBytes.Length];
                        using (FileStream output = new FileStream(joinedFilePath, FileMode.Create))
                        {
                            for (int i = 0; i < partOneBuffer.Length; i++)
                            {
                                output.Write(new byte[] { partTwoBuffer[i] });
                                
                                output.Write(new byte[] { partOneBuffer[i] });
                            }
                        }
                    }
                }
            }
        }
    }
}