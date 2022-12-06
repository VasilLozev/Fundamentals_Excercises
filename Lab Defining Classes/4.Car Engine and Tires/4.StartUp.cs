using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 8.5),
                new Tire(2, 2.3),
            };
            var engine = new Engine(560, 3600);

            var car = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);
            Console.WriteLine($"{car.Model}, {car.Make}, {car.Year}, {car.Engine.HorsePower},{car.Engine.CubicCapacity}," +
                $" {string.Join(" ",car.Tires.Select(x=>x.Pressure))}," +
                $" {string.Join(" ", car.Tires.Select(x => x.Pressure))}");
        }
    }
}
