namespace CarFactory.Transmissions
{
    public interface ITransmission
    {
        public int Gears { get; }

        public string ToString();
    }
}