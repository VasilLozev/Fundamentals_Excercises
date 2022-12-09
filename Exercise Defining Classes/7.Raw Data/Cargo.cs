namespace RawData
{
    public class Cargo
    {
        public string type { get; set; }
        public int weight { get; set; }

        public Cargo(string type, int weight)
        {
            this.type = type;
            this.weight = weight;
        }
    }
}