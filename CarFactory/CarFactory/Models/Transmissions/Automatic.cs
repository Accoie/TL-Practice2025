namespace CarFactory.Models.Transmissions
{
    public class Automatic : ITransmission
    {
        public int Gears => 6;

        public string Name => "Automatic";
    }
}