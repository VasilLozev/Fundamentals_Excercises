    using System;
    using System.Collections.Generic;
    using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
       
            static void Main(string[] args)
            {
                string make = Console.ReadLine();
                string model = Console.ReadLine();
                int year = int.Parse(Console.ReadLine());
                double fuelQuantity = double.Parse(Console.ReadLine());
                double fuelConsumption = double.Parse(Console.ReadLine());

                Car firstCar = new Car();
                Car secondCar = new Car(make, model, year);
                Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);
            Console.WriteLine($"{firstCar.Make}, {firstCar.Model}, {firstCar.Year}, {firstCar.FuelConsumption}, {firstCar.FuelQuantity}");
            Console.WriteLine($"{secondCar.Make}, {secondCar.Model}, {secondCar.Year}, {secondCar.FuelConsumption}, {secondCar.FuelQuantity}");
            Console.WriteLine($"{thirdCar.Make}, {thirdCar.Model}, {thirdCar.Year}, {thirdCar.FuelConsumption}, {thirdCar.FuelQuantity}");


        }

    }
}