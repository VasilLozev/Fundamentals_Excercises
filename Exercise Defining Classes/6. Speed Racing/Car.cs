using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public static List<Car> cars = new List<Car>();

        public string Model
        {
            get;set;
        }
        public double FuelAmount
        {
            get; set;
        }
        public double FuelConsumptionPerKilometer
        {
            get; set;
        }
        public double TravelledDistance
        {
            get; set;
        }
        public double[] Drive(double fuelAmount, double fuelConsumptionPerKilometer, double distance, double travelledDistance)
        {
            if (fuelAmount >= fuelConsumptionPerKilometer * distance)
            {
                fuelAmount -= fuelConsumptionPerKilometer * distance;
                travelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }

            return new double[2] { fuelAmount, travelledDistance }; 
        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double travelledDistance)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = travelledDistance;
        }
    }
}
