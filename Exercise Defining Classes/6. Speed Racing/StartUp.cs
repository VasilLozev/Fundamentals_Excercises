using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
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
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1km = double.Parse(input[2]);
                
                Car.cars.Add(new Car(model, fuelAmount, fuelConsumptionFor1km, 0));
                
            }
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }
                string[] input = command.Split(' ');
                string model = input[1];
                double amountOfKm = double.Parse(input[2]);

                if (input[0] == "Drive")
                {
                    foreach (var car in Car.cars)
                    {
                        if (car.Model == model)
                        {
                            double[] FuelAmountTravelledDistance = car.Drive(car.FuelAmount, car.FuelConsumptionPerKilometer, amountOfKm, car.TravelledDistance);

                            car.FuelAmount = FuelAmountTravelledDistance[0];
                            car.TravelledDistance = FuelAmountTravelledDistance[1];
                        }
                    }
                }
            }
            foreach (var car in Car.cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
