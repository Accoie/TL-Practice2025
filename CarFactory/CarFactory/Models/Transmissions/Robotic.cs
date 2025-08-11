namespace CarFactory.Models.Transmissions
{
    public class Robotic : ITransmission
    {
        public int Gears => 7;

        public string Name => "Robotic";
    }
}