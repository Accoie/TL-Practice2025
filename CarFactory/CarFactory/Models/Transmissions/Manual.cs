namespace CarFactory.Models.Transmissions
{
    public class Manual : ITransmission
    {
        public int Gears => 5;

        public string Name => "Manual";
    }
}