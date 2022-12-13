using System;

namespace RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string racingNumber = Console.ReadLine();

            string[][] matrix = new string[size][];

            for (int i = 0; i < size; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ');
            }
            int rowCar = 0;
            int colCar = 0;

            matrix[rowCar][colCar] = racingNumber;

            int kilometersPassed = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    Console.WriteLine($"Racing car {racingNumber} DNF.");
                    break;
                }
                matrix[rowCar][colCar] = ".";
                switch (command)
                {
                    case "left":
                        colCar--;
                        break;
                    case "right":
                        colCar++;
                        break;
                    case "up":
                        rowCar--;
                        break;
                    case "down":
                        rowCar++;
                        break;

                }
                if (matrix[rowCar][colCar] == "T")
                {
                    matrix[rowCar][colCar] = ".";
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            if (matrix[i][j] == "T")
                            {
                                matrix[rowCar][colCar] = ".";
                                matrix[i][j] = racingNumber;
                                rowCar = i;
                                colCar = j;
                            }
                        }
                    }
                    kilometersPassed += 30;
                }
                if (matrix[rowCar][colCar] == ".")
                {
                    matrix[rowCar][colCar] = racingNumber;
                    kilometersPassed += 10;
                }
                if (matrix[rowCar][colCar] == "F")
                {
                    Console.WriteLine($"Racing car {racingNumber} finished the stage!");
                    kilometersPassed += 10;
                    break;
                }
            }
            Console.WriteLine($"Distance covered {kilometersPassed} km.");
            matrix[rowCar][colCar] = "C";
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(string.Join("",matrix[i]));
            }
        }
    }
}
