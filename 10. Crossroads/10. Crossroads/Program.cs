using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int newgreenLight = greenLight;
            int freeWindow = int.Parse(Console.ReadLine());
            int count = 0;
            bool greenLightOn = true;
            Queue<string> cars = new Queue<string>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }
                if (command == "green")
                {
                    if (greenLightOn == false)
                    {
                        greenLight = newgreenLight;
                        while (greenLight > 0)
                        {
                            Queue<char> chars = new Queue<char>();
                            string car = cars.Dequeue();
                            foreach (var item in car)
                            {
                                chars.Enqueue(item);
                            }
                            for (int i = 0; i < greenLight; i++)
                            {
                                chars.Dequeue();
                                if (chars.Count == 0)
                                {
                                    count++;
                                    greenLight = greenLight - car.Length;
                                    break;
                                }
                            }
                            if (chars.Count > 0)
                            {
                                for (int i = 0; i < freeWindow; i++)
                                {
                                    chars.Dequeue();
                                    if (chars.Count == 0)
                                    {
                                        count++;
                                        greenLight = 0;
                                        break;
                                    }
                                }
                            }
                            if (chars.Count > 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {chars.Peek()}.");
                                Environment.Exit(0);
                            }
                        }
                    }
                    else if (greenLightOn == true)
                    {
                        greenLightOn = false;
                    }
                }
                if (command != "green" && command != "END")
                {
                    cars.Enqueue(command);
                    if (greenLightOn)
                    {
                        while (greenLight > 0 && cars.Count > 0)
                        {
                            Queue<char> chars = new Queue<char>();
                            string car = cars.Dequeue();
                            foreach (var item in car)
                            {
                                chars.Enqueue(item);
                            }
                            for (int i = 0; i < greenLight; i++)
                            {
                                chars.Dequeue();
                                if (chars.Count == 0)
                                {
                                    count++;
                                    greenLight = greenLight - car.Length;
                                    break;
                                }
                            }
                            if (chars.Count > 0)
                            {
                                for (int i = 0; i < freeWindow; i++)
                                {
                                    chars.Dequeue();
                                    if (chars.Count == 0)
                                    {
                                        count++;
                                        greenLight = 0;
                                        break;
                                    }
                                }
                            }
                            if (chars.Count > 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {chars.Peek()}.");
                                Environment.Exit(0);
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
