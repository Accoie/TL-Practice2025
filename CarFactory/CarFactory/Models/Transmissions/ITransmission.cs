namespace CarFactory.Models.Transmissions
{
    public interface ITransmission
    {
        public int Gears { get; }

        public string Name { get; }
    }
}