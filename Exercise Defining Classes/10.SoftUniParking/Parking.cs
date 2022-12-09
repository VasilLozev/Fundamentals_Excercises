using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;
        private Dictionary<string, Car> cars;
        
        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new Dictionary<string, Car>();
        }
        public int Count { get { return this.cars.Count; } }
        public string AddCar(Car car)
        {
            
            if (this.cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (this.cars.Count == this.capacity)
            {
                return "Parking is full!";
            }
            this.cars.Add(car.RegistrationNumber, car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }
        public string RemoveCar(string RegistrationNumber)
        {

            if (!this.cars.ContainsKey(RegistrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            cars.Remove(RegistrationNumber);
            return $"Successfully removed {RegistrationNumber}";
        }
        public Car GetCar(string registrationNumber)
        {
            return this.cars[registrationNumber];
        }
        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var car in cars)
            {
                if (RegistrationNumbers.Contains(car.Value.RegistrationNumber))
                {
                    cars.Remove(car.Value.RegistrationNumber);
                }
            }
        }
    }
}
