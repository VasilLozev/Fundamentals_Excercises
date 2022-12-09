using System.Collections.Generic;

namespace CarSalesman
{
    public class Engine
    {
        public static List<Engine> Engines = new List<Engine>();
       
        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
          
         
        public string Efficiency { get; set; }

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = 0;
            this.Efficiency = null;
        }
        public override string ToString()
        {
            if (this.Displacement != 0)
            {
                return $"{this.Model}:" +
              $"\r\n    Power: {this.Power}" +
              $"\r\n    Displacement: {this.Displacement}" +
              $"\r\n    Efficiency: {this.Efficiency}";
              
            }
            else
            {
                return $"{this.Model}:" +
            $"\r\n    Power: {this.Power}" +
            $"\r\n    Displacement: n/a" +
            $"\r\n    Efficiency: {this.Efficiency}";
            }
        }
    }
}