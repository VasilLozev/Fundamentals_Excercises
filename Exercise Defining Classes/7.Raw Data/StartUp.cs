using System;
using System.Linq;

namespace RawData
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
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                Tire tire1 = new Tire(int.Parse(input[6]), double.Parse(input[5]));
                Tire tire2 = new Tire(int.Parse(input[8]), double.Parse(input[7]));
                Tire tire3 = new Tire(int.Parse(input[10]), double.Parse(input[9]));
                Tire tire4 = new Tire(int.Parse(input[12]), double.Parse(input[11]));
                Tire[] tires = new Tire[4] { tire1, tire2, tire3, tire4 };
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Car car = new Car(model, engine, cargo, tires);
                Car.Cars.Add(car);
            }
            string command = Console.ReadLine();
            foreach (var car in Car.Cars)
            {
                if (command == "fragile")
                {
                    if (car.Cargo.type == "fragile" && car.Tires.Any(x => x.pressure < 1))
                    {
                        Console.WriteLine(car.Model);
                    }
                }
                else
                {
                    if (car.Cargo.type == "flammable" && car.Engine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}
