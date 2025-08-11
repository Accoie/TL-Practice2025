namespace CarFactory.Models.Engines
{
    public class Diesel : IEngine
    {
        public int MaxSpeed => 200;

        public string Name => "Diesel";
    }
}