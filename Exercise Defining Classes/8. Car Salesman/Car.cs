using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public static List<Car> cars = new List<Car>();

        public string Model { get; set; }

        public Engine engine { get; set; }
        public int Weight
        {
            get ;
            set;
            
        }
        public string Color
        {
            get;set;
        }

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.engine = engine;
            this.Weight = 0;
            this.Color = null;
        }
        public override string ToString()
        {
            if (this.Weight != 0)
            {
                return $"  {this.Model}:" +
                $"\r\n  {this.engine.ToString()}" +
                $"\r\n  Weight: {this.Weight}" +
                $"\r\n  Color: {this.Color}";
               
            }
            else
            {
                return $"{this.Model}:" +
                $"\r\n  {this.engine.ToString()}" +
                $"\r\n  Weight: n/a" +
                $"\r\n  Color: {this.Color}";
            }
        }
    }
}
