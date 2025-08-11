namespace CarFactory.Models.Engines
{
    public class Gasoline : IEngine
    {
        public int MaxSpeed => 240;

        public string Name => "Gasoline";
    }
}