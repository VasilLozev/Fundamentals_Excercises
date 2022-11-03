using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool green = true;
            int count = 0;

            Queue<string> cars = new Queue<string>();
            int seconds = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            int currentPos = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }
                if (command != "END" && command != "green")
                {
                    cars.Enqueue(command);
                    if (green == true)
                    {
                        while (cars.Count > 0)
                        {
                            string car = cars.Peek();
                            Queue<char> car1 = new Queue<char>();
                            
                            foreach (char item in car)
                            {
                                car1.Enqueue(item);
                            }
                            for (int i = currentPos; i < seconds + freeWindow; i++)
                            {
                                car1.Dequeue();
                                if (car1.Count == 0)
                                {
                                    count++;
                                    currentPos = i+1;
                                    break;
                                }
                            }
                            if (car1.Count > 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {car1.Peek()}.");
                                Environment.Exit(0);
                            }
                            cars.Dequeue();
                        }
                        if (command == "green")
                        {
                            if (green == true)
                            {
                                green = false;
                            }
                            else if (green == false)
                            {
                                green = true;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{count} total cars passed the crossroads.");
        }
    }
}
