namespace CarFactory.Models.Engines
{
    public class Gasoline : IEngine
    {
        public int MaxSpeed => 240;

        public override string ToString()
        {
            return "Gasoline";
        }
    }
}