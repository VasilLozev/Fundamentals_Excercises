namespace RawData
{
    public class Tire
    {
        public int age { get; set; }
        public double pressure { get; set; }
        public Tire(int age, double pressure)
        {
            this.age = age;
            this.pressure = pressure;
        }
    }
}