using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace CarSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string model = input[0];
                int power = int.Parse(input[1]);
                int displacement = 0;
                string efficiency = "n/a";
                if (input.Length > 2)
                {
                    if (int.TryParse(input[2], out displacement))
                    {
                        displacement = int.Parse(input[2]);
                    }
                    else if (!int.TryParse(input[2], out displacement))
                    {
                        efficiency = input[2];
                    }
                    if (input.Length > 3)
                    {
                        efficiency = input[3];
                    }
                }
                Engine engine = new Engine(model, power);
                engine.Displacement = displacement;
                engine.Efficiency = efficiency;
                Engine.Engines.Add(engine);
            }
            int M = int.Parse(Console.ReadLine());

            for (int i = 0; i < M; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                
                string model = input[0];
                string engine = input[1];
                int weight = 0;
                string color = "n/a";
                if (input.Length > 2)
                {
                    if (int.TryParse(input[2], out weight))
                    {
                        weight = int.Parse(input[2]);
                    }
                    else if (!int.TryParse(input[2], out weight))
                    {
                        color = input[2];
                    }
                }
                    if (input.Length > 3)
                    {
                        color = input[3];
                    }
                
                Car car = new Car(model, Engine.Engines.Where(x => x.Model == engine).First());
                car.Weight = weight;
                car.Color = color;
                Car.cars.Add(car);
            }
            foreach (var car in Car.cars)
            {
                Console.WriteLine($"{car.ToString()}");
            }
        }
    }
}
