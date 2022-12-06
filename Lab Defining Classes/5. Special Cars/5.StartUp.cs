using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace CarManufacturer
{
    internal class StartUp
    {
        public static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Tire> tires1 = new List<Tire>();
            List<int> year = new List<int>();
            List<double> pressure = new List<double>();
            while (true)
            {
                string read = Console.ReadLine();
                if (read == "No more tires")
                {
                    break;
                }
               
                string[] yearPressure = read.Split(' ');
                for (int i = 0; i < yearPressure.Length; i++)
                {
                    if (i%2 == 0)
                    {
                         year.Add(int.Parse(yearPressure[i]));
                    }
                    else
                    {
                         pressure.Add(double.Parse(yearPressure[i]));
                    }
                    
                }
            }
            for (int i = 0; i < year.Count; i++)
            {
                tires1.Add(new Tire(year[i], pressure[i]));
                if (tires1.Count % 4 == 0)
                {
                    tires.Add(new Tire[4] { tires1[0], tires1[1], tires1[2], tires1[3] });
                    tires1.Clear();
                }
            }
            List<Engine> engines = new List<Engine>();
            while (true)
            {
                string read = Console.ReadLine();
                if (read == "Engines done")
                {
                    break;
                }
                string[] horsePowerCubicCapacity = read.Split(' ');
                engines.Add(new Engine(int.Parse(horsePowerCubicCapacity[0]), double.Parse(horsePowerCubicCapacity[1])));
            }

            List<Car> cars = new List<Car>();
            while (true)
            {
                string read = Console.ReadLine();
                if (read == "Show special")
                {
                    break;
                }
                string[] carInfo = read.Split(' ');
                string make = carInfo[0];
                string model = carInfo[1];
                int yearCar = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                Engine engine = engines[int.Parse(carInfo[5])];
                Tire[] tirespair = new Tire[] { tires[int.Parse(carInfo[6])][0], tires[int.Parse(carInfo[6])][1],
                tires[int.Parse(carInfo[6])][2], tires[int.Parse(carInfo[6])][3]};
                cars.Add(new Car(make, model, yearCar,
                    fuelQuantity,
                    fuelConsumption,
                    engine,
                    tirespair)
                    );
            }
            foreach (var car in cars)
            {
                if (car.Year >= 2017 && car.Engine.HorsePower > 330)
                {
                    double pressureCar = 0;
                    foreach (var tire in car.Tires)
                    {
                        pressureCar += tire.Pressure;
                    }
                    if (pressureCar >= 9 && pressureCar <= 10)
                    {
                        car.Drive(20);
                        Console.WriteLine($"Make: {car.Make}" + Environment.NewLine +
                                          $"Model: {car.Model}" + Environment.NewLine +
                                          $"Year: {car.Year}" + Environment.NewLine +
                                          $"HorsePowers: {car.Engine.HorsePower}" + Environment.NewLine +
                                          $"FuelQuantity: {car.FuelQuantity:f1}");
                    }
                }
            }
        }
    }
}
