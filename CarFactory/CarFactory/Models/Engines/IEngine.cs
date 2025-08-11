namespace CarFactory.Models.Engines
{
    public interface IEngine
    {
        public int MaxSpeed { get; }

        public string Name { get; }
    }
}